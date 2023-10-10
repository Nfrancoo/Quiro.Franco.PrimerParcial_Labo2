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
            cmbPaises = new ComboBox();
            lstJugadores = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(205, 24);
            label1.TabIndex = 0;
            label1.Text = "Convocar nuevo jugador";
            label1.Click += label1_Click;
            // 
            // cmbPaises
            // 
            cmbPaises.FormattingEnabled = true;
            cmbPaises.Items.AddRange(new object[] { "Argentina", "Francia", "Brasil", "Alemania", "Italia" });
            cmbPaises.Location = new Point(427, 24);
            cmbPaises.Name = "cmbPaises";
            cmbPaises.Size = new Size(121, 23);
            cmbPaises.TabIndex = 1;
            cmbPaises.SelectedIndexChanged += cmbPaises_SelectedIndexChanged;
            // 
            // lstJugadores
            // 
            lstJugadores.FormattingEnabled = true;
            lstJugadores.ItemHeight = 15;
            lstJugadores.Location = new Point(427, 53);
            lstJugadores.Name = "lstJugadores";
            lstJugadores.Size = new Size(345, 199);
            lstJugadores.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaption;
            button1.Location = new Point(96, 60);
            button1.Name = "button1";
            button1.Size = new Size(152, 58);
            button1.TabIndex = 3;
            button1.Text = "Convocar Jugador";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(lstJugadores);
            Controls.Add(cmbPaises);
            Controls.Add(label1);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbPaises;
        private ListBox lstJugadores;
        private Button button1;
    }
}