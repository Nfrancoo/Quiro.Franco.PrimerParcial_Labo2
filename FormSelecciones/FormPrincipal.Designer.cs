namespace FormSelecciones
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lstArgentina = new ListBox();
            btnConvocar = new Button();
            lstAlemania = new ListBox();
            lstItalia = new ListBox();
            lstBrasil = new ListBox();
            lstFrancia = new ListBox();
            cmbPaises = new ComboBox();
            lstArgentinaEntrenador = new ListBox();
            label2 = new Label();
            label3 = new Label();
            lstItaliaEntrenador = new ListBox();
            lstAlemaniaEntrenador = new ListBox();
            lstFranciaEntrenador = new ListBox();
            lstBrasilEntrenador = new ListBox();
            label4 = new Label();
            lstArgentinaMasajeador = new ListBox();
            lstBrasilMasajeador = new ListBox();
            lstFranciaMasajeador = new ListBox();
            lstItaliaMasajeador = new ListBox();
            lstAlemaniaMasajeador = new ListBox();
            btnEliminar = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(275, 24);
            label1.TabIndex = 0;
            label1.Text = "Convocar Personal a la Seleccion";
            // 
            // lstArgentina
            // 
            lstArgentina.FormattingEnabled = true;
            lstArgentina.ItemHeight = 15;
            lstArgentina.Location = new Point(378, 43);
            lstArgentina.Name = "lstArgentina";
            lstArgentina.Size = new Size(410, 124);
            lstArgentina.TabIndex = 2;
            // 
            // btnConvocar
            // 
            btnConvocar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnConvocar.ForeColor = SystemColors.ActiveCaption;
            btnConvocar.Location = new Point(89, 45);
            btnConvocar.Name = "btnConvocar";
            btnConvocar.Size = new Size(152, 58);
            btnConvocar.TabIndex = 3;
            btnConvocar.Text = "Convocar Personal";
            btnConvocar.UseVisualStyleBackColor = true;
            btnConvocar.Click += btnConvocar_Click;
            // 
            // lstAlemania
            // 
            lstAlemania.FormattingEnabled = true;
            lstAlemania.ItemHeight = 15;
            lstAlemania.Location = new Point(378, 43);
            lstAlemania.Name = "lstAlemania";
            lstAlemania.Size = new Size(410, 124);
            lstAlemania.TabIndex = 4;
            // 
            // lstItalia
            // 
            lstItalia.FormattingEnabled = true;
            lstItalia.ItemHeight = 15;
            lstItalia.Location = new Point(378, 43);
            lstItalia.Name = "lstItalia";
            lstItalia.Size = new Size(410, 124);
            lstItalia.TabIndex = 5;
            // 
            // lstBrasil
            // 
            lstBrasil.FormattingEnabled = true;
            lstBrasil.ItemHeight = 15;
            lstBrasil.Location = new Point(378, 43);
            lstBrasil.Name = "lstBrasil";
            lstBrasil.Size = new Size(410, 124);
            lstBrasil.TabIndex = 6;
            // 
            // lstFrancia
            // 
            lstFrancia.FormattingEnabled = true;
            lstFrancia.ItemHeight = 15;
            lstFrancia.Location = new Point(378, 43);
            lstFrancia.Name = "lstFrancia";
            lstFrancia.Size = new Size(410, 124);
            lstFrancia.TabIndex = 7;
            // 
            // cmbPaises
            // 
            cmbPaises.FormattingEnabled = true;
            cmbPaises.Items.AddRange(new object[] { "Italia", "Francia", "Brasil", "Argentina", "Alemania" });
            cmbPaises.Location = new Point(378, 12);
            cmbPaises.Name = "cmbPaises";
            cmbPaises.Size = new Size(121, 23);
            cmbPaises.TabIndex = 8;
            cmbPaises.SelectedIndexChanged += cmbPaises_SelectedIndexChanged;
            // 
            // lstArgentinaEntrenador
            // 
            lstArgentinaEntrenador.FormattingEnabled = true;
            lstArgentinaEntrenador.ItemHeight = 15;
            lstArgentinaEntrenador.Location = new Point(378, 195);
            lstArgentinaEntrenador.Name = "lstArgentinaEntrenador";
            lstArgentinaEntrenador.Size = new Size(410, 124);
            lstArgentinaEntrenador.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(683, 14);
            label2.Name = "label2";
            label2.Size = new Size(89, 24);
            label2.TabIndex = 10;
            label2.Text = "Jugadores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(653, 168);
            label3.Name = "label3";
            label3.Size = new Size(119, 24);
            label3.TabIndex = 11;
            label3.Text = "Entrenadores";
            // 
            // lstItaliaEntrenador
            // 
            lstItaliaEntrenador.FormattingEnabled = true;
            lstItaliaEntrenador.ItemHeight = 15;
            lstItaliaEntrenador.Location = new Point(378, 195);
            lstItaliaEntrenador.Name = "lstItaliaEntrenador";
            lstItaliaEntrenador.Size = new Size(410, 124);
            lstItaliaEntrenador.TabIndex = 12;
            // 
            // lstAlemaniaEntrenador
            // 
            lstAlemaniaEntrenador.FormattingEnabled = true;
            lstAlemaniaEntrenador.ItemHeight = 15;
            lstAlemaniaEntrenador.Location = new Point(378, 195);
            lstAlemaniaEntrenador.Name = "lstAlemaniaEntrenador";
            lstAlemaniaEntrenador.Size = new Size(410, 124);
            lstAlemaniaEntrenador.TabIndex = 13;
            // 
            // lstFranciaEntrenador
            // 
            lstFranciaEntrenador.FormattingEnabled = true;
            lstFranciaEntrenador.ItemHeight = 15;
            lstFranciaEntrenador.Location = new Point(378, 195);
            lstFranciaEntrenador.Name = "lstFranciaEntrenador";
            lstFranciaEntrenador.Size = new Size(410, 124);
            lstFranciaEntrenador.TabIndex = 14;
            // 
            // lstBrasilEntrenador
            // 
            lstBrasilEntrenador.FormattingEnabled = true;
            lstBrasilEntrenador.ItemHeight = 15;
            lstBrasilEntrenador.Location = new Point(378, 195);
            lstBrasilEntrenador.Name = "lstBrasilEntrenador";
            lstBrasilEntrenador.Size = new Size(410, 124);
            lstBrasilEntrenador.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(653, 322);
            label4.Name = "label4";
            label4.Size = new Size(121, 24);
            label4.TabIndex = 16;
            label4.Text = "Masajeadores";
            // 
            // lstArgentinaMasajeador
            // 
            lstArgentinaMasajeador.FormattingEnabled = true;
            lstArgentinaMasajeador.ItemHeight = 15;
            lstArgentinaMasajeador.Location = new Point(378, 352);
            lstArgentinaMasajeador.Name = "lstArgentinaMasajeador";
            lstArgentinaMasajeador.Size = new Size(410, 124);
            lstArgentinaMasajeador.TabIndex = 17;
            // 
            // lstBrasilMasajeador
            // 
            lstBrasilMasajeador.FormattingEnabled = true;
            lstBrasilMasajeador.ItemHeight = 15;
            lstBrasilMasajeador.Location = new Point(378, 352);
            lstBrasilMasajeador.Name = "lstBrasilMasajeador";
            lstBrasilMasajeador.Size = new Size(410, 124);
            lstBrasilMasajeador.TabIndex = 18;
            // 
            // lstFranciaMasajeador
            // 
            lstFranciaMasajeador.FormattingEnabled = true;
            lstFranciaMasajeador.ItemHeight = 15;
            lstFranciaMasajeador.Location = new Point(378, 352);
            lstFranciaMasajeador.Name = "lstFranciaMasajeador";
            lstFranciaMasajeador.Size = new Size(410, 124);
            lstFranciaMasajeador.TabIndex = 19;
            // 
            // lstItaliaMasajeador
            // 
            lstItaliaMasajeador.FormattingEnabled = true;
            lstItaliaMasajeador.ItemHeight = 15;
            lstItaliaMasajeador.Location = new Point(378, 352);
            lstItaliaMasajeador.Name = "lstItaliaMasajeador";
            lstItaliaMasajeador.Size = new Size(410, 124);
            lstItaliaMasajeador.TabIndex = 20;
            // 
            // lstAlemaniaMasajeador
            // 
            lstAlemaniaMasajeador.FormattingEnabled = true;
            lstAlemaniaMasajeador.ItemHeight = 15;
            lstAlemaniaMasajeador.Location = new Point(378, 352);
            lstAlemaniaMasajeador.Name = "lstAlemaniaMasajeador";
            lstAlemaniaMasajeador.Size = new Size(410, 124);
            lstAlemaniaMasajeador.TabIndex = 21;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.ActiveCaption;
            btnEliminar.Location = new Point(89, 195);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(152, 58);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar Personal";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 168);
            label5.Name = "label5";
            label5.Size = new Size(275, 24);
            label5.TabIndex = 23;
            label5.Text = "Convocar Personal a la Seleccion";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 491);
            Controls.Add(label5);
            Controls.Add(btnEliminar);
            Controls.Add(lstAlemaniaMasajeador);
            Controls.Add(lstItaliaMasajeador);
            Controls.Add(lstFranciaMasajeador);
            Controls.Add(lstBrasilMasajeador);
            Controls.Add(lstArgentinaMasajeador);
            Controls.Add(label4);
            Controls.Add(lstFranciaEntrenador);
            Controls.Add(lstBrasilEntrenador);
            Controls.Add(lstAlemaniaEntrenador);
            Controls.Add(lstItaliaEntrenador);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lstArgentinaEntrenador);
            Controls.Add(cmbPaises);
            Controls.Add(lstFrancia);
            Controls.Add(lstBrasil);
            Controls.Add(lstItalia);
            Controls.Add(lstAlemania);
            Controls.Add(btnConvocar);
            Controls.Add(lstArgentina);
            Controls.Add(label1);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            FormClosing += FormPrincipal_FormClosing;
            Leave += FormPrincipal_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstArgentina;
        private Button btnConvocar;
        private ListBox lstAlemania;
        private ListBox lstItalia;
        private ListBox lstBrasil;
        private ListBox lstFrancia;
        private ComboBox cmbPaises;
        private ListBox lstArgentinaEntrenador;
        private Label label2;
        private Label label3;
        private ListBox lstItaliaEntrenador;
        private ListBox lstAlemaniaEntrenador;
        private ListBox lstFranciaEntrenador;
        private ListBox lstBrasilEntrenador;
        private Label label4;
        private ListBox lstArgentinaMasajeador;
        private ListBox lstBrasilMasajeador;
        private ListBox lstFranciaMasajeador;
        private ListBox lstItaliaMasajeador;
        private ListBox lstAlemaniaMasajeador;
        private Button btnEliminar;
        private Label label5;
    }
}