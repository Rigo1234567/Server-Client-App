namespace APP
{
    partial class ConsultarReservas
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
            this.dgvreservas = new System.Windows.Forms.DataGridView();
            this.L_TAccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvreservas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvreservas
            // 
            this.dgvreservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvreservas.Location = new System.Drawing.Point(38, 78);
            this.dgvreservas.Name = "dgvreservas";
            this.dgvreservas.Size = new System.Drawing.Size(678, 320);
            this.dgvreservas.TabIndex = 0;
            // 
            // L_TAccion
            // 
            this.L_TAccion.AutoSize = true;
            this.L_TAccion.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TAccion.Location = new System.Drawing.Point(256, 27);
            this.L_TAccion.Name = "L_TAccion";
            this.L_TAccion.Size = new System.Drawing.Size(234, 23);
            this.L_TAccion.TabIndex = 21;
            this.L_TAccion.Text = "LISTA DE SUS RESERVAS:";
            // 
            // ConsultarReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_TAccion);
            this.Controls.Add(this.dgvreservas);
            this.Name = "ConsultarReservas";
            this.Text = "reservas";
            this.Load += new System.EventHandler(this.ConsultarReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvreservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvreservas;
        private System.Windows.Forms.Label L_TAccion;
    }
}