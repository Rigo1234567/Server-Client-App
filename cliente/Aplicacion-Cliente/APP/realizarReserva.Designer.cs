namespace APP
{
    partial class realizarReserva
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
            this.CB_Art = new System.Windows.Forms.ComboBox();
            this.L_TAccion = new System.Windows.Forms.Label();
            this.btnreserva = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvreser = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvreser)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Art
            // 
            this.CB_Art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Art.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Art.FormattingEnabled = true;
            this.CB_Art.Location = new System.Drawing.Point(322, 94);
            this.CB_Art.Name = "CB_Art";
            this.CB_Art.Size = new System.Drawing.Size(259, 24);
            this.CB_Art.TabIndex = 21;
            // 
            // L_TAccion
            // 
            this.L_TAccion.AutoSize = true;
            this.L_TAccion.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TAccion.Location = new System.Drawing.Point(12, 94);
            this.L_TAccion.Name = "L_TAccion";
            this.L_TAccion.Size = new System.Drawing.Size(304, 19);
            this.L_TAccion.TabIndex = 20;
            this.L_TAccion.Text = "Fechas de las sedes con Cupos disponibles:";
            // 
            // btnreserva
            // 
            this.btnreserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreserva.Location = new System.Drawing.Point(322, 151);
            this.btnreserva.Name = "btnreserva";
            this.btnreserva.Size = new System.Drawing.Size(156, 51);
            this.btnreserva.TabIndex = 22;
            this.btnreserva.Text = "reservar";
            this.btnreserva.UseVisualStyleBackColor = true;
            this.btnreserva.Click += new System.EventHandler(this.btnreserva_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 33);
            this.label2.TabIndex = 25;
            this.label2.Text = "RESERVAS FITUNED";
            // 
            // dgvreser
            // 
            this.dgvreser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvreser.Location = new System.Drawing.Point(525, 300);
            this.dgvreser.Name = "dgvreser";
            this.dgvreser.Size = new System.Drawing.Size(240, 150);
            this.dgvreser.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(596, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "Sus Reservas";
            // 
            // realizarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvreser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnreserva);
            this.Controls.Add(this.CB_Art);
            this.Controls.Add(this.L_TAccion);
            this.Name = "realizarReserva";
            this.Text = " ";
            this.Load += new System.EventHandler(this.realizarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvreser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Art;
        private System.Windows.Forms.Label L_TAccion;
        private System.Windows.Forms.Button btnreserva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvreser;
        private System.Windows.Forms.Label label3;
    }
}