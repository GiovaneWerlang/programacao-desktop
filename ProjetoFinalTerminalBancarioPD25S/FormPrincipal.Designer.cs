
namespace ProjetoFinalTerminalBancarioPD25S
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cstBtnInsert = new DESKTOP.CustomButton();
            this.SuspendLayout();
            // 
            // cstBtnInsert
            // 
            this.cstBtnInsert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cstBtnInsert.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cstBtnInsert.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cstBtnInsert.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cstBtnInsert.Hovering = false;
            this.cstBtnInsert.Location = new System.Drawing.Point(300, 170);
            this.cstBtnInsert.MouseHoverColor = System.Drawing.SystemColors.ScrollBar;
            this.cstBtnInsert.MousePressed = false;
            this.cstBtnInsert.Name = "cstBtnInsert";
            this.cstBtnInsert.Size = new System.Drawing.Size(200, 100);
            this.cstBtnInsert.TabIndex = 1;
            this.cstBtnInsert.Text = "Inserir Cartão";
            this.cstBtnInsert.Click += new System.EventHandler(this.cstBtnInsert_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cstBtnInsert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "Terminal Bancário";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPrincipal_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private DESKTOP.CustomButton cstBtnInsert;
    }
}

