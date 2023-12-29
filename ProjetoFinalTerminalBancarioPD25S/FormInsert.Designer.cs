
namespace DESKTOP
{
    partial class FormInsert
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.bds = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cstBtnConfirma = new DESKTOP.CustomButton();
            this.cstBtnCancelar = new DESKTOP.CustomButton();
            this.cstBtnSalvar = new DESKTOP.CustomButton();
            this.ctsBtnNovo = new DESKTOP.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 25;
            this.dgv.Size = new System.Drawing.Size(800, 400);
            this.dgv.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.cstBtnConfirma);
            this.panel1.Controls.Add(this.cstBtnCancelar);
            this.panel1.Controls.Add(this.cstBtnSalvar);
            this.panel1.Controls.Add(this.ctsBtnNovo);
            this.panel1.Location = new System.Drawing.Point(12, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 49);
            this.panel1.TabIndex = 1;
            // 
            // cstBtnConfirma
            // 
            this.cstBtnConfirma.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cstBtnConfirma.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cstBtnConfirma.Hovering = false;
            this.cstBtnConfirma.Location = new System.Drawing.Point(650, 0);
            this.cstBtnConfirma.MouseHoverColor = System.Drawing.SystemColors.ScrollBar;
            this.cstBtnConfirma.MousePressed = false;
            this.cstBtnConfirma.Name = "cstBtnConfirma";
            this.cstBtnConfirma.Size = new System.Drawing.Size(126, 48);
            this.cstBtnConfirma.TabIndex = 7;
            this.cstBtnConfirma.Text = "Confirma";
            this.cstBtnConfirma.Click += new System.EventHandler(this.cstBtnConfirma_Click);
            // 
            // cstBtnCancelar
            // 
            this.cstBtnCancelar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cstBtnCancelar.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cstBtnCancelar.Hovering = false;
            this.cstBtnCancelar.Location = new System.Drawing.Point(350, 0);
            this.cstBtnCancelar.MouseHoverColor = System.Drawing.SystemColors.ScrollBar;
            this.cstBtnCancelar.MousePressed = false;
            this.cstBtnCancelar.Name = "cstBtnCancelar";
            this.cstBtnCancelar.Size = new System.Drawing.Size(126, 48);
            this.cstBtnCancelar.TabIndex = 6;
            this.cstBtnCancelar.Text = "Cancelar";
            this.cstBtnCancelar.Click += new System.EventHandler(this.cstBtnCancelar_Click);
            // 
            // cstBtnSalvar
            // 
            this.cstBtnSalvar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cstBtnSalvar.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cstBtnSalvar.Hovering = false;
            this.cstBtnSalvar.Location = new System.Drawing.Point(167, 0);
            this.cstBtnSalvar.MouseHoverColor = System.Drawing.SystemColors.ScrollBar;
            this.cstBtnSalvar.MousePressed = false;
            this.cstBtnSalvar.Name = "cstBtnSalvar";
            this.cstBtnSalvar.Size = new System.Drawing.Size(126, 48);
            this.cstBtnSalvar.TabIndex = 5;
            this.cstBtnSalvar.Text = "Salvar";
            this.cstBtnSalvar.Click += new System.EventHandler(this.cstBtnSalvar_Click);
            // 
            // ctsBtnNovo
            // 
            this.ctsBtnNovo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ctsBtnNovo.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ctsBtnNovo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctsBtnNovo.Hovering = false;
            this.ctsBtnNovo.Location = new System.Drawing.Point(0, 0);
            this.ctsBtnNovo.Margin = new System.Windows.Forms.Padding(0);
            this.ctsBtnNovo.MouseHoverColor = System.Drawing.SystemColors.ScrollBar;
            this.ctsBtnNovo.MousePressed = false;
            this.ctsBtnNovo.Name = "ctsBtnNovo";
            this.ctsBtnNovo.Size = new System.Drawing.Size(126, 48);
            this.ctsBtnNovo.TabIndex = 4;
            this.ctsBtnNovo.Text = "Novo Correntista";
            this.ctsBtnNovo.Click += new System.EventHandler(this.ctsBtnNovo_Click);
            // 
            // FormInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInsert";
            this.Text = "FormInsert";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource bds;
        private System.Windows.Forms.Panel panel1;
        private CustomButton ctsBtnNovo;
        private CustomButton cstBtnSalvar;
        private CustomButton cstBtnCancelar;
        private CustomButton cstBtnConfirma;
    }
}