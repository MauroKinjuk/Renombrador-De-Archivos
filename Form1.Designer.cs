namespace renombrador_de_archivos;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        layout = new TableLayoutPanel();
        barra1 = new FlowLayoutPanel();
        btnSeleccionar = new Button();
        btnLimpiar = new Button();
        lblNombreBase = new Label();
        txtNombre = new TextBox();
        lblEmpezarEn = new Label();
        numInicio = new NumericUpDown();
        lblDigitos = new Label();
        numDigitos = new NumericUpDown();
        barra2 = new FlowLayoutPanel();
        lblOrden = new Label();
        cmbOrden = new ComboBox();
        chkContinuar = new CheckBox();
        btnRenombrar = new Button();
        btnDeshacer = new Button();
        lista = new ListView();
        colNombreActual = new ColumnHeader();
        colNombreNuevo = new ColumnHeader();
        lblEstado = new Label();
        ((System.ComponentModel.ISupportInitialize)numInicio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numDigitos).BeginInit();
        layout.SuspendLayout();
        barra1.SuspendLayout();
        barra2.SuspendLayout();
        SuspendLayout();
        // 
        // layout
        // 
        layout.ColumnCount = 1;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(barra1, 0, 0);
        layout.Controls.Add(barra2, 0, 1);
        layout.Controls.Add(lista, 0, 2);
        layout.Controls.Add(lblEstado, 0, 3);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(10);
        layout.RowCount = 4;
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.Size = new Size(740, 500);
        layout.TabIndex = 0;
        // 
        // barra1
        // 
        barra1.AutoSize = true;
        barra1.Controls.Add(btnSeleccionar);
        barra1.Controls.Add(btnLimpiar);
        barra1.Controls.Add(lblNombreBase);
        barra1.Controls.Add(txtNombre);
        barra1.Controls.Add(lblEmpezarEn);
        barra1.Controls.Add(numInicio);
        barra1.Controls.Add(lblDigitos);
        barra1.Controls.Add(numDigitos);
        barra1.Dock = DockStyle.Fill;
        barra1.Location = new Point(10, 10);
        barra1.Margin = new Padding(0);
        barra1.Name = "barra1";
        barra1.Size = new Size(720, 29);
        barra1.TabIndex = 0;
        barra1.WrapContents = false;
        // 
        // btnSeleccionar
        // 
        btnSeleccionar.AutoSize = true;
        btnSeleccionar.Location = new Point(3, 3);
        btnSeleccionar.Name = "btnSeleccionar";
        btnSeleccionar.Size = new Size(129, 23);
        btnSeleccionar.TabIndex = 0;
        btnSeleccionar.Text = "Seleccionar archivos...";
        btnSeleccionar.Click += new EventHandler(BtnSeleccionar_Click);
        // 
        // btnLimpiar
        // 
        btnLimpiar.AutoSize = true;
        btnLimpiar.Location = new Point(138, 3);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(50, 23);
        btnLimpiar.TabIndex = 1;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Click += new EventHandler(BtnLimpiar_Click);
        // 
        // lblNombreBase
        // 
        lblNombreBase.AutoSize = true;
        lblNombreBase.Location = new Point(206, 8);
        lblNombreBase.Margin = new Padding(12, 8, 3, 3);
        lblNombreBase.Name = "lblNombreBase";
        lblNombreBase.Size = new Size(82, 15);
        lblNombreBase.TabIndex = 2;
        lblNombreBase.Text = "Nombre base:";
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(294, 3);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(160, 23);
        txtNombre.TabIndex = 3;
        txtNombre.TextChanged += new EventHandler(Opciones_Changed);
        // 
        // lblEmpezarEn
        // 
        lblEmpezarEn.AutoSize = true;
        lblEmpezarEn.Location = new Point(469, 8);
        lblEmpezarEn.Margin = new Padding(12, 8, 3, 3);
        lblEmpezarEn.Name = "lblEmpezarEn";
        lblEmpezarEn.Size = new Size(70, 15);
        lblEmpezarEn.TabIndex = 4;
        lblEmpezarEn.Text = "Empezar en:";
        // 
        // numInicio
        // 
        numInicio.Location = new Point(545, 3);
        numInicio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numInicio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numInicio.Name = "numInicio";
        numInicio.Size = new Size(60, 23);
        numInicio.TabIndex = 5;
        numInicio.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numInicio.ValueChanged += new EventHandler(Opciones_Changed);
        // 
        // lblDigitos
        // 
        lblDigitos.AutoSize = true;
        lblDigitos.Location = new Point(620, 8);
        lblDigitos.Margin = new Padding(12, 8, 3, 3);
        lblDigitos.Name = "lblDigitos";
        lblDigitos.Size = new Size(47, 15);
        lblDigitos.TabIndex = 6;
        lblDigitos.Text = "Digitos:";
        // 
        // numDigitos
        // 
        numDigitos.Location = new Point(673, 3);
        numDigitos.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
        numDigitos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numDigitos.Name = "numDigitos";
        numDigitos.Size = new Size(50, 23);
        numDigitos.TabIndex = 7;
        numDigitos.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numDigitos.ValueChanged += new EventHandler(Opciones_Changed);
        // 
        // barra2
        // 
        barra2.AutoSize = true;
        barra2.Controls.Add(lblOrden);
        barra2.Controls.Add(cmbOrden);
        barra2.Controls.Add(chkContinuar);
        barra2.Controls.Add(btnRenombrar);
        barra2.Controls.Add(btnDeshacer);
        barra2.Dock = DockStyle.Fill;
        barra2.Location = new Point(10, 39);
        barra2.Margin = new Padding(0);
        barra2.Name = "barra2";
        barra2.Size = new Size(720, 29);
        barra2.TabIndex = 1;
        barra2.WrapContents = false;
        // 
        // lblOrden
        // 
        lblOrden.AutoSize = true;
        lblOrden.Location = new Point(0, 8);
        lblOrden.Margin = new Padding(0, 8, 3, 3);
        lblOrden.Name = "lblOrden";
        lblOrden.Size = new Size(43, 15);
        lblOrden.TabIndex = 0;
        lblOrden.Text = "Orden:";
        // 
        // cmbOrden
        // 
        cmbOrden.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbOrden.Items.AddRange(new object[] { "Como se agregaron", "Fecha (viejas primero)", "Fecha (nuevas primero)", "Nombre A-Z", "Nombre Z-A" });
        cmbOrden.Location = new Point(49, 3);
        cmbOrden.Name = "cmbOrden";
        cmbOrden.Size = new Size(190, 23);
        cmbOrden.TabIndex = 1;
        cmbOrden.SelectedIndex = 0;
        cmbOrden.SelectedIndexChanged += new EventHandler(Opciones_Changed);
        // 
        // chkContinuar
        // 
        chkContinuar.AutoSize = true;
        chkContinuar.Location = new Point(254, 6);
        chkContinuar.Margin = new Padding(12, 6, 3, 3);
        chkContinuar.Name = "chkContinuar";
        chkContinuar.Size = new Size(136, 19);
        chkContinuar.TabIndex = 2;
        chkContinuar.Text = "Continuar numeracion";
        chkContinuar.CheckedChanged += new EventHandler(ChkContinuar_CheckedChanged);
        // 
        // btnRenombrar
        // 
        btnRenombrar.AutoSize = true;
        btnRenombrar.Location = new Point(396, 3);
        btnRenombrar.Name = "btnRenombrar";
        btnRenombrar.Size = new Size(75, 23);
        btnRenombrar.TabIndex = 3;
        btnRenombrar.Text = "Renombrar";
        btnRenombrar.Click += new EventHandler(BtnRenombrar_Click);
        // 
        // btnDeshacer
        // 
        btnDeshacer.AutoSize = true;
        btnDeshacer.Enabled = false;
        btnDeshacer.Location = new Point(477, 3);
        btnDeshacer.Name = "btnDeshacer";
        btnDeshacer.Size = new Size(62, 23);
        btnDeshacer.TabIndex = 4;
        btnDeshacer.Text = "Deshacer";
        btnDeshacer.Click += new EventHandler(BtnDeshacer_Click);
        // 
        // lista
        // 
        lista.Columns.AddRange(new ColumnHeader[] { colNombreActual, colNombreNuevo });
        lista.Dock = DockStyle.Fill;
        lista.FullRowSelect = true;
        lista.Location = new Point(13, 71);
        lista.Name = "lista";
        lista.Size = new Size(714, 419);
        lista.TabIndex = 2;
        lista.View = View.Details;
        // 
        // colNombreActual
        // 
        colNombreActual.Text = "Nombre actual";
        colNombreActual.Width = 340;
        // 
        // colNombreNuevo
        // 
        colNombreNuevo.Text = "Nombre nuevo";
        colNombreNuevo.Width = 340;
        // 
        // lblEstado
        // 
        lblEstado.AutoSize = true;
        lblEstado.Location = new Point(13, 496);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(274, 15);
        lblEstado.TabIndex = 3;
        lblEstado.Text = "Arrastra archivos o carpetas, o usa el boton para elegirlos.";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 540);
        Controls.Add(layout);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Renombrador";
        ((System.ComponentModel.ISupportInitialize)numInicio).EndInit();
        ((System.ComponentModel.ISupportInitialize)numDigitos).EndInit();
        layout.ResumeLayout(false);
        layout.PerformLayout();
        barra1.ResumeLayout(false);
        barra1.PerformLayout();
        barra2.ResumeLayout(false);
        barra2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel layout;
    private FlowLayoutPanel barra1;
    private Button btnSeleccionar;
    private Button btnLimpiar;
    private Label lblNombreBase;
    private TextBox txtNombre;
    private Label lblEmpezarEn;
    private NumericUpDown numInicio;
    private Label lblDigitos;
    private NumericUpDown numDigitos;
    private FlowLayoutPanel barra2;
    private Label lblOrden;
    private ComboBox cmbOrden;
    private CheckBox chkContinuar;
    private Button btnRenombrar;
    private Button btnDeshacer;
    private ListView lista;
    private ColumnHeader colNombreActual;
    private ColumnHeader colNombreNuevo;
    private Label lblEstado;
}
