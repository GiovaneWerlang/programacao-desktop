using DESKTOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalTerminalBancarioPD25S
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.Focus();
        }

        

        public void fechar()
        {
            Close();
            Application.Exit();
        }

       
        private void cstBtnInsert_Click(object sender, EventArgs e)
        {
            FormInsert formInsert = new FormInsert();
            formInsert.Show();
        }

        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    //Alternativa para os componentes não impedirem
                    FormSair form = new FormSair();
                    form.fechar = new FormSair.fecharDelegate(fechar);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    e.Handled = true;
                    break;
            }
            
        }
    }
}
