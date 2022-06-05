namespace APP
{
    partial class Form2
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
            this.btnconsultar = new System.Windows.Forms.Button();
            this.btnrealizarreserva = new System.Windows.Forms.Button();
            this.L_NombreVendedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnconsultar
            // 
            this.btnconsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconsultar.Location = new System.Drawing.Point(447, 200);
            this.btnconsultar.Name = "btnconsultar";
            this.btnconsultar.Size = new System.Drawing.Size(172, 78);
            this.btnconsultar.TabIndex = 3;
            this.btnconsultar.Text = "Consultar Reservas";
            this.btnconsultar.UseVisualStyleBackColor = true;
            this.btnconsultar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnrealizarreserva
            // 
            this.btnrealizarreserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrealizarreserva.Location = new System.Drawing.Point(168, 200);
            this.btnrealizarreserva.Name = "btnrealizarreserva";
            this.btnrealizarreserva.Size = new System.Drawing.Size(172, 78);
            this.btnrealizarreserva.TabIndex = 2;
            this.btnrealizarreserva.Text = "Realizar Reserva";
            this.btnrealizarreserva.UseVisualStyleBackColor = true;
            this.btnrealizarreserva.Click += new System.EventHandler(this.button1_Click);
            // 
            // L_NombreVendedor
            // 
            this.L_NombreVendedor.AutoSize = true;
            this.L_NombreVendedor.Location = new System.Drawing.Point(57, 406);
            this.L_NombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_NombreVendedor.Name = "L_NombreVendedor";
            this.L_NombreVendedor.Size = new System.Drawing.Size(47, 13);
            this.L_NombreVendedor.TabIndex = 10;
            this.L_NombreVendedor.Text = "Ninguno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 406);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cliente:";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(600, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 46);
            this.button3.TabIndex = 11;
            this.button3.Text = "Desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.L_NombreVendedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnconsultar);
            this.Controls.Add(this.btnrealizarreserva);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registrar reservas";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnconsultar;
        private System.Windows.Forms.Button btnrealizarreserva;
        private System.Windows.Forms.Label L_NombreVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}