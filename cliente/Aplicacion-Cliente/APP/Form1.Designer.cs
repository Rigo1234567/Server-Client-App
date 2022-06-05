namespace APP
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MTB_IdVend = new System.Windows.Forms.MaskedTextBox();
            this.L_TAccion = new System.Windows.Forms.Label();
            this.B_Conectar = new System.Windows.Forms.Button();
            this.B_Cancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MTB_IdVend
            // 
            this.MTB_IdVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MTB_IdVend.Location = new System.Drawing.Point(215, 361);
            this.MTB_IdVend.Margin = new System.Windows.Forms.Padding(2);
            this.MTB_IdVend.Name = "MTB_IdVend";
            this.MTB_IdVend.Size = new System.Drawing.Size(348, 23);
            this.MTB_IdVend.TabIndex = 21;
            this.MTB_IdVend.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MTB_IdVend_MaskInputRejected);
            // 
            // L_TAccion
            // 
            this.L_TAccion.AutoSize = true;
            this.L_TAccion.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TAccion.Location = new System.Drawing.Point(275, 303);
            this.L_TAccion.Name = "L_TAccion";
            this.L_TAccion.Size = new System.Drawing.Size(234, 23);
            this.L_TAccion.TabIndex = 20;
            this.L_TAccion.Text = "Indique el Id. del cliente:";
            this.L_TAccion.Click += new System.EventHandler(this.L_TAccion_Click);
            // 
            // B_Conectar
            // 
            this.B_Conectar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Conectar.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Conectar.Location = new System.Drawing.Point(455, 403);
            this.B_Conectar.Name = "B_Conectar";
            this.B_Conectar.Size = new System.Drawing.Size(108, 35);
            this.B_Conectar.TabIndex = 19;
            this.B_Conectar.Text = "Conectar";
            this.B_Conectar.UseVisualStyleBackColor = false;
            this.B_Conectar.Click += new System.EventHandler(this.B_Conectar_Click);
            // 
            // B_Cancelar
            // 
            this.B_Cancelar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Cancelar.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Cancelar.Location = new System.Drawing.Point(215, 403);
            this.B_Cancelar.Name = "B_Cancelar";
            this.B_Cancelar.Size = new System.Drawing.Size(108, 35);
            this.B_Cancelar.TabIndex = 18;
            this.B_Cancelar.Text = "Cancelar";
            this.B_Cancelar.UseVisualStyleBackColor = false;
            this.B_Cancelar.Click += new System.EventHandler(this.B_Cancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::APP.Properties.Resources.gym;
            this.pictureBox1.Location = new System.Drawing.Point(292, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 198);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "Gym FITUNED";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MTB_IdVend);
            this.Controls.Add(this.L_TAccion);
            this.Controls.Add(this.B_Conectar);
            this.Controls.Add(this.B_Cancelar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "autenticación";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox MTB_IdVend;
        private System.Windows.Forms.Label L_TAccion;
        private System.Windows.Forms.Button B_Conectar;
        private System.Windows.Forms.Button B_Cancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}

