using System.Text.RegularExpressions;

namespace renombrador_de_archivos;

public partial class Form1 : Form
{
    private readonly List<string> archivos = [];
    private readonly HashSet<string> archivosSet = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<(string nuevo, string viejo)> ultimoRenombrado = [];

    public Form1()
    {
        InitializeComponent();
        EngancharDrop(this);
    }

    // ---- Drag & drop ----

    private void EngancharDrop(Control padre)
    {
        padre.AllowDrop = true;
        padre.DragEnter += (_, e) =>
            e.Effect = e.Data?.GetDataPresent(DataFormats.FileDrop) == true ? DragDropEffects.Copy : DragDropEffects.None;
        padre.DragDrop += (_, e) =>
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is not string[] paths) return;
            foreach (var p in paths)
            {
                var files = File.Exists(p) ? [p]
                    : Directory.Exists(p) ? Directory.GetFiles(p)
                    : [];
                AgregarArchivos(files);
            }
            ActualizarPreview();
        };
        foreach (Control hijo in padre.Controls)
            EngancharDrop(hijo);
    }

    private void AgregarArchivos(IEnumerable<string> files)
    {
        foreach (var f in files)
            if (archivosSet.Add(f))
                archivos.Add(f);
    }

    // ---- Botones ----

    private void BtnSeleccionar_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog { Multiselect = true, Title = "Elegi los archivos a renombrar" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        AgregarArchivos(dialog.FileNames);
        ActualizarPreview();
    }

    private void BtnLimpiar_Click(object? sender, EventArgs e)
    {
        archivos.Clear();
        archivosSet.Clear();
        ActualizarPreview();
    }

    private void BtnRenombrar_Click(object? sender, EventArgs e)
    {
        var nombre = txtNombre.Text.Trim();

        if (archivos.Count == 0)
        {
            MessageBox.Show("Primero agrega archivos.", "Renombrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (string.IsNullOrEmpty(nombre))
        {
            MessageBox.Show("Escribi un nombre base.", "Renombrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (nombre.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            MessageBox.Show("El nombre contiene caracteres no validos.", "Renombrador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var ordenados = ArchivosOrdenados().ToList();
        var destinos = CalcularDestinos(ordenados);

        // Avisar si algun destino ya existe y NO esta entre los seleccionados
        var colisiones = destinos.Count(d => File.Exists(d) && !archivosSet.Contains(d));
        if (colisiones > 0 && MessageBox.Show(
                $"Ya existen {colisiones} archivo(s) con esos nombres. Queres sobrescribirlos?",
                "Conflicto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            // Pasar todos a nombres temporales primero, para evitar choques entre si
            var temporales = new List<string>();
            foreach (var a in ordenados)
            {
                var temp = Path.Combine(Path.GetDirectoryName(a)!, Guid.NewGuid() + Path.GetExtension(a));
                File.Move(a, temp);
                temporales.Add(temp);
            }

            ultimoRenombrado.Clear();
            for (var i = 0; i < temporales.Count; i++)
            {
                File.Move(temporales[i], destinos[i], overwrite: true);
                ultimoRenombrado.Add((destinos[i], ordenados[i]));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al renombrar: " + ex.Message, "Renombrador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        btnDeshacer.Enabled = true;
        archivos.Clear();
        archivosSet.Clear();
        ActualizarPreview();
        lblEstado.Text = $"Listo: {ultimoRenombrado.Count} archivo(s) renombrado(s). Podes deshacerlo.";
    }

    private void BtnDeshacer_Click(object? sender, EventArgs e)
    {
        var errores = 0;
        foreach (var (nuevo, viejo) in ultimoRenombrado)
            try { if (File.Exists(nuevo)) File.Move(nuevo, viejo); }
            catch { errores++; }

        ultimoRenombrado.Clear();
        btnDeshacer.Enabled = false;
        lblEstado.Text = errores == 0
            ? "Se deshizo el ultimo renombrado."
            : $"Se deshizo con {errores} error(es).";
    }

    private void ChkContinuar_CheckedChanged(object? sender, EventArgs e)
    {
        numInicio.Enabled = !chkContinuar.Checked;
        ActualizarPreview();
    }

    private void Opciones_Changed(object? sender, EventArgs e) => ActualizarPreview();

    // ---- Preview y numeracion ----

    private void ActualizarPreview()
    {
        lista.Items.Clear();
        var ordenados = ArchivosOrdenados().ToList();
        var destinos = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : CalcularDestinos(ordenados);

        for (var i = 0; i < ordenados.Count; i++)
        {
            var item = new ListViewItem(Path.GetFileName(ordenados[i]));
            item.SubItems.Add(destinos != null ? Path.GetFileName(destinos[i]) : "");
            lista.Items.Add(item);
        }
        lblEstado.Text = $"{archivos.Count} archivo(s) en la lista.";
    }

    private IEnumerable<string> ArchivosOrdenados() => cmbOrden.SelectedIndex switch
    {
        1 => archivos.OrderBy(File.GetLastWriteTime),
        2 => archivos.OrderByDescending(File.GetLastWriteTime),
        3 => archivos.OrderBy(Path.GetFileName, StringComparer.OrdinalIgnoreCase),
        4 => archivos.OrderByDescending(Path.GetFileName, StringComparer.OrdinalIgnoreCase),
        _ => archivos,
    };

    private List<string> CalcularDestinos(List<string> ordenados)
    {
        var inicio = chkContinuar.Checked ? SiguienteNumero() : (int)numInicio.Value;
        var formato = "D" + (int)numDigitos.Value;
        var nombre = txtNombre.Text.Trim();
        return ordenados.Select((a, i) => Path.Combine(
            Path.GetDirectoryName(a)!,
            $"{nombre} ({(inicio + i).ToString(formato)}){Path.GetExtension(a)}"))
            .ToList();
    }

    private int SiguienteNumero()
    {
        var nombre = txtNombre.Text.Trim();
        if (nombre.Length == 0) return 1;

        var regex = new Regex($"^{Regex.Escape(nombre)} \\((\\d+)\\)", RegexOptions.IgnoreCase);
        var max = 0;
        foreach (var dir in archivos.Select(a => Path.GetDirectoryName(a)!).Distinct())
            foreach (var f in Directory.EnumerateFiles(dir))
            {
                var m = regex.Match(Path.GetFileName(f));
                if (m.Success && int.TryParse(m.Groups[1].Value, out var n))
                    max = Math.Max(max, n);
            }
        return max + 1;
    }
}
