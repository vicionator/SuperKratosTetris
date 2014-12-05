namespace Tetris
{
    partial class MenuDosJugadores
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
            this.btnConectarIP = new System.Windows.Forms.Button();
            this.btnEsperarPartida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConectarIP
            // 
            this.btnConectarIP.BackColor = System.Drawing.Color.Black;
            this.btnConectarIP.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectarIP.ForeColor = System.Drawing.Color.White;
            this.btnConectarIP.Location = new System.Drawing.Point(86, 147);
            this.btnConectarIP.Name = "btnConectarIP";
            this.btnConectarIP.Size = new System.Drawing.Size(103, 43);
            this.btnConectarIP.TabIndex = 4;
            this.btnConectarIP.Text = "Conectar con IP";
            this.btnConectarIP.UseVisualStyleBackColor = false;
            // 
            // btnEsperarPartida
            // 
            this.btnEsperarPartida.BackColor = System.Drawing.Color.Black;
            this.btnEsperarPartida.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsperarPartida.ForeColor = System.Drawing.Color.White;
            this.btnEsperarPartida.Location = new System.Drawing.Point(86, 98);
            this.btnEsperarPartida.Name = "btnEsperarPartida";
            this.btnEsperarPartida.Size = new System.Drawing.Size(103, 43);
            this.btnEsperarPartida.TabIndex = 3;
            this.btnEsperarPartida.Text = "Esperar Partida";
            this.btnEsperarPartida.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione una opcion";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Black;
            this.btnVolver.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(86, 196);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(103, 43);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // MenuDosJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConectarIP);
            this.Controls.Add(this.btnEsperarPartida);
            this.Name = "MenuDosJugadores";
            this.Text = "Dos Jugadores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectarIP;
        private System.Windows.Forms.Button btnEsperarPartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
    }
}