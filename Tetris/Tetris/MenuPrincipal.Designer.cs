namespace Tetris
{
    partial class MenuPrincipal
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
            this.btnUnJugador = new System.Windows.Forms.Button();
            this.btnDosJugadores = new System.Windows.Forms.Button();
            this.btnCreditos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUnJugador
            // 
            this.btnUnJugador.BackColor = System.Drawing.Color.Black;
            this.btnUnJugador.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnJugador.ForeColor = System.Drawing.Color.White;
            this.btnUnJugador.Location = new System.Drawing.Point(125, 95);
            this.btnUnJugador.Name = "btnUnJugador";
            this.btnUnJugador.Size = new System.Drawing.Size(103, 43);
            this.btnUnJugador.TabIndex = 0;
            this.btnUnJugador.Text = "Un Jugador";
            this.btnUnJugador.UseVisualStyleBackColor = false;
            this.btnUnJugador.Click += new System.EventHandler(this.btnUnJugador_Click);
            // 
            // btnDosJugadores
            // 
            this.btnDosJugadores.BackColor = System.Drawing.Color.Black;
            this.btnDosJugadores.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDosJugadores.ForeColor = System.Drawing.Color.White;
            this.btnDosJugadores.Location = new System.Drawing.Point(125, 144);
            this.btnDosJugadores.Name = "btnDosJugadores";
            this.btnDosJugadores.Size = new System.Drawing.Size(103, 43);
            this.btnDosJugadores.TabIndex = 1;
            this.btnDosJugadores.Text = "Dos Jugadores";
            this.btnDosJugadores.UseVisualStyleBackColor = false;
            this.btnDosJugadores.Click += new System.EventHandler(this.btnDosJugadores_Click);
            // 
            // btnCreditos
            // 
            this.btnCreditos.BackColor = System.Drawing.Color.Black;
            this.btnCreditos.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditos.ForeColor = System.Drawing.Color.White;
            this.btnCreditos.Location = new System.Drawing.Point(125, 193);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.Size = new System.Drawing.Size(103, 43);
            this.btnCreditos.TabIndex = 2;
            this.btnCreditos.Text = "Creditos";
            this.btnCreditos.UseVisualStyleBackColor = false;
            this.btnCreditos.Click += new System.EventHandler(this.btnCreditos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Super Kratos Tetris";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Something Beyond Compare";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(355, 266);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreditos);
            this.Controls.Add(this.btnDosJugadores);
            this.Controls.Add(this.btnUnJugador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.Text = "Super Kratos Tetris";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnJugador;
        private System.Windows.Forms.Button btnDosJugadores;
        private System.Windows.Forms.Button btnCreditos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}