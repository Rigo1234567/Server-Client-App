namespace app
{
    partial class mostrarafiliaciones
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
            this.dgvasignaciones = new System.Windows.Forms.DataGridView();
            this.btnsalr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvasignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvasignaciones
            // 
            this.dgvasignaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.dgvasignaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvasignaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvasignaciones.Location = new System.Drawing.Point(102, 25);
            this.dgvasignaciones.Name = "dgvasignaciones";
            this.dgvasignaciones.ReadOnly = true;
            this.dgvasignaciones.Size = new System.Drawing.Size(583, 170);
            this.dgvasignaciones.TabIndex = 6;
            // 
            // btnsalr
            // 
            this.btnsalr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalr.Location = new System.Drawing.Point(325, 253);
            this.btnsalr.Name = "btnsalr";
            this.btnsalr.Size = new System.Drawing.Size(126, 37);
            this.btnsalr.TabIndex = 23;
            this.btnsalr.Text = "salir";
            this.btnsalr.UseVisualStyleBackColor = true;
            this.btnsalr.Click += new System.EventHandler(this.btnsalr_Click);
            // 
            // mostrarafiliaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnsalr);
            this.Controls.Add(this.dgvasignaciones);
            this.Name = "mostrarafiliaciones";
            this.Text = "mostrarafiliaciones";
            this.Load += new System.EventHandler(this.mostrarafiliaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvasignaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvasignaciones;
        private System.Windows.Forms.Button btnsalr;
    }
}