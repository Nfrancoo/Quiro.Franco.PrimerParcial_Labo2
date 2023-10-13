namespace FormSelecciones
{
    partial class ConvocarEntrenador
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
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            txtEdad = new TextBox();
            label4 = new Label();
            txtPais = new TextBox();
            label5 = new Label();
            txtTactica = new TextBox();
            button1 = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(41, 27);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(41, 50);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(39, 87);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(41, 110);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 23);
            txtApellido.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(39, 151);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 4;
            label3.Text = "Edad";
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(41, 174);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(240, 23);
            txtEdad.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(39, 212);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 6;
            label4.Text = "Pais";
            // 
            // txtPais
            // 
            txtPais.Location = new Point(41, 235);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(240, 23);
            txtPais.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(39, 272);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 8;
            label5.Text = "Tactica";
            // 
            // txtTactica
            // 
            txtTactica.Location = new Point(41, 295);
            txtTactica.Name = "txtTactica";
            txtTactica.Size = new Size(240, 23);
            txtTactica.TabIndex = 9;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 343);
            button1.Name = "button1";
            button1.Size = new Size(141, 70);
            button1.TabIndex = 18;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(169, 343);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 70);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ConvocarEntrenador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 450);
            Controls.Add(btnCancelar);
            Controls.Add(button1);
            Controls.Add(txtTactica);
            Controls.Add(label5);
            Controls.Add(txtPais);
            Controls.Add(label4);
            Controls.Add(txtEdad);
            Controls.Add(label3);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "ConvocarEntrenador";
            Text = "ConvocarEntrenador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtApellido;
        private Label label3;
        private TextBox txtEdad;
        private Label label4;
        private TextBox txtPais;
        private Label label5;
        private TextBox txtTactica;
        private Button button1;
        private Button btnCancelar;
    }
}