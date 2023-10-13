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
            button1 = new Button();
            lstAlemania = new ListBox();
            lstItalia = new ListBox();
            lstBrasil = new ListBox();
            lstFrancia = new ListBox();
            cmbPaises = new ComboBox();
            lstArgentinaEntrenador = new ListBox();
            label2 = new Label();
            label3 = new Label();
            lstItaliaEntrenador = new ListBox();
            lstIAlemaniaEntrenador = new ListBox();
            lstIFranciaEntrenador = new ListBox();
            lstIBrasilEntrenador = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(205, 24);
            label1.TabIndex = 0;
            label1.Text = "Convocar nuevo jugador";
            // 
            // lstArgentina
            // 
            lstArgentina.FormattingEnabled = true;
            lstArgentina.ItemHeight = 15;
            lstArgentina.Location = new Point(427, 41);
            lstArgentina.Name = "lstArgentina";
            lstArgentina.Size = new Size(345, 124);
            lstArgentina.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaption;
            button1.Location = new Point(89, 45);
            button1.Name = "button1";
            button1.Size = new Size(152, 58);
            button1.TabIndex = 3;
            button1.Text = "Convocar Personal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lstAlemania
            // 
            lstAlemania.FormattingEnabled = true;
            lstAlemania.ItemHeight = 15;
            lstAlemania.Location = new Point(427, 41);
            lstAlemania.Name = "lstAlemania";
            lstAlemania.Size = new Size(345, 124);
            lstAlemania.TabIndex = 4;
            // 
            // lstItalia
            // 
            lstItalia.FormattingEnabled = true;
            lstItalia.ItemHeight = 15;
            lstItalia.Location = new Point(427, 41);
            lstItalia.Name = "lstItalia";
            lstItalia.Size = new Size(345, 124);
            lstItalia.TabIndex = 5;
            // 
            // lstBrasil
            // 
            lstBrasil.FormattingEnabled = true;
            lstBrasil.ItemHeight = 15;
            lstBrasil.Location = new Point(427, 41);
            lstBrasil.Name = "lstBrasil";
            lstBrasil.Size = new Size(345, 124);
            lstBrasil.TabIndex = 6;
            // 
            // lstFrancia
            // 
            lstFrancia.FormattingEnabled = true;
            lstFrancia.ItemHeight = 15;
            lstFrancia.Location = new Point(427, 41);
            lstFrancia.Name = "lstFrancia";
            lstFrancia.Size = new Size(345, 124);
            lstFrancia.TabIndex = 7;
            // 
            // cmbPaises
            // 
            cmbPaises.FormattingEnabled = true;
            cmbPaises.Items.AddRange(new object[] { "Italia", "Francia", "Brasil", "Argentina", "Alemania" });
            cmbPaises.Location = new Point(427, 12);
            cmbPaises.Name = "cmbPaises";
            cmbPaises.Size = new Size(121, 23);
            cmbPaises.TabIndex = 8;
            cmbPaises.SelectedIndexChanged += cmbPaises_SelectedIndexChanged;
            // 
            // lstArgentinaEntrenador
            // 
            lstArgentinaEntrenador.FormattingEnabled = true;
            lstArgentinaEntrenador.ItemHeight = 15;
            lstArgentinaEntrenador.Location = new Point(427, 195);
            lstArgentinaEntrenador.Name = "lstArgentinaEntrenador";
            lstArgentinaEntrenador.Size = new Size(345, 124);
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
            lstItaliaEntrenador.Location = new Point(427, 195);
            lstItaliaEntrenador.Name = "lstItaliaEntrenador";
            lstItaliaEntrenador.Size = new Size(345, 124);
            lstItaliaEntrenador.TabIndex = 12;
            // 
            // lstIAlemaniaEntrenador
            // 
            lstIAlemaniaEntrenador.FormattingEnabled = true;
            lstIAlemaniaEntrenador.ItemHeight = 15;
            lstIAlemaniaEntrenador.Location = new Point(427, 195);
            lstIAlemaniaEntrenador.Name = "lstIAlemaniaEntrenador";
            lstIAlemaniaEntrenador.Size = new Size(345, 124);
            lstIAlemaniaEntrenador.TabIndex = 13;
            // 
            // lstIFranciaEntrenador
            // 
            lstIFranciaEntrenador.FormattingEnabled = true;
            lstIFranciaEntrenador.ItemHeight = 15;
            lstIFranciaEntrenador.Location = new Point(427, 195);
            lstIFranciaEntrenador.Name = "lstIFranciaEntrenador";
            lstIFranciaEntrenador.Size = new Size(345, 124);
            lstIFranciaEntrenador.TabIndex = 14;
            // 
            // lstIBrasilEntrenador
            // 
            lstIBrasilEntrenador.FormattingEnabled = true;
            lstIBrasilEntrenador.ItemHeight = 15;
            lstIBrasilEntrenador.Location = new Point(427, 195);
            lstIBrasilEntrenador.Name = "lstIBrasilEntrenador";
            lstIBrasilEntrenador.Size = new Size(345, 124);
            lstIBrasilEntrenador.TabIndex = 15;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstIBrasilEntrenador);
            Controls.Add(lstIFranciaEntrenador);
            Controls.Add(lstIAlemaniaEntrenador);
            Controls.Add(lstItaliaEntrenador);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lstArgentinaEntrenador);
            Controls.Add(cmbPaises);
            Controls.Add(lstFrancia);
            Controls.Add(lstBrasil);
            Controls.Add(lstItalia);
            Controls.Add(lstAlemania);
            Controls.Add(button1);
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
        private Button button1;
        private ListBox lstAlemania;
        private ListBox lstItalia;
        private ListBox lstBrasil;
        private ListBox lstFrancia;
        private ComboBox cmbPaises;
        private ListBox lstArgentinaEntrenador;
        private Label label2;
        private Label label3;
        private ListBox lstItaliaEntrenador;
        private ListBox lstIAlemaniaEntrenador;
        private ListBox lstIFranciaEntrenador;
        private ListBox lstIBrasilEntrenador;
    }
}