namespace servidor_interfaz
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
            this.components = new System.ComponentModel.Container();
            this.btniniciar = new System.Windows.Forms.Button();
            this.btndetener = new System.Windows.Forms.Button();
            this.PB_Server = new System.Windows.Forms.ProgressBar();
            this.L_TitEstado = new System.Windows.Forms.Label();
            this.lB_Clientes = new System.Windows.Forms.ListBox();
            this.TB_Bit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btniniciar
            // 
            this.btniniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniniciar.Location = new System.Drawing.Point(15, 71);
            this.btniniciar.Name = "btniniciar";
            this.btniniciar.Size = new System.Drawing.Size(111, 44);
            this.btniniciar.TabIndex = 0;
            this.btniniciar.Text = "iniciar";
            this.btniniciar.UseVisualStyleBackColor = true;
            this.btniniciar.Click += new System.EventHandler(this.btniniciar_Click);
            // 
            // btndetener
            // 
            this.btndetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndetener.Location = new System.Drawing.Point(268, 71);
            this.btndetener.Name = "btndetener";
            this.btndetener.Size = new System.Drawing.Size(129, 44);
            this.btndetener.TabIndex = 1;
            this.btndetener.Text = "detener";
            this.btndetener.UseVisualStyleBackColor = true;
            this.btndetener.Click += new System.EventHandler(this.btndetener_Click);
            // 
            // PB_Server
            // 
            this.PB_Server.Location = new System.Drawing.Point(154, 14);
            this.PB_Server.Margin = new System.Windows.Forms.Padding(2);
            this.PB_Server.Name = "PB_Server";
            this.PB_Server.Size = new System.Drawing.Size(232, 19);
            this.PB_Server.TabIndex = 2;
            // 
            // L_TitEstado
            // 
            this.L_TitEstado.AutoSize = true;
            this.L_TitEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TitEstado.Location = new System.Drawing.Point(26, 9);
            this.L_TitEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_TitEstado.Name = "L_TitEstado";
            this.L_TitEstado.Size = new System.Drawing.Size(86, 24);
            this.L_TitEstado.TabIndex = 4;
            this.L_TitEstado.Text = "Estado: ";
            // 
            // lB_Clientes
            // 
            this.lB_Clientes.FormattingEnabled = true;
            this.lB_Clientes.Location = new System.Drawing.Point(11, 235);
            this.lB_Clientes.Margin = new System.Windows.Forms.Padding(2);
            this.lB_Clientes.Name = "lB_Clientes";
            this.lB_Clientes.Size = new System.Drawing.Size(243, 147);
            this.lB_Clientes.TabIndex = 5;
            // 
            // TB_Bit
            // 
            this.TB_Bit.Location = new System.Drawing.Point(342, 235);
            this.TB_Bit.Margin = new System.Windows.Forms.Padding(2);
            this.TB_Bit.Multiline = true;
            this.TB_Bit.Name = "TB_Bit";
            this.TB_Bit.Size = new System.Drawing.Size(247, 147);
            this.TB_Bit.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 200);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "usuarios conectados: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bitácora: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(632, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Bit);
            this.Controls.Add(this.lB_Clientes);
            this.Controls.Add(this.L_TitEstado);
            this.Controls.Add(this.PB_Server);
            this.Controls.Add(this.btndetener);
            this.Controls.Add(this.btniniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btniniciar;
        private System.Windows.Forms.Button btndetener;
        private System.Windows.Forms.ProgressBar PB_Server;
        private System.Windows.Forms.Label L_TitEstado;
        private System.Windows.Forms.ListBox lB_Clientes;
        private System.Windows.Forms.TextBox TB_Bit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

