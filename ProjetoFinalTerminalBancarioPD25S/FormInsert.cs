using CORE.DAL;
using CORE.MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP
{
    public partial class FormInsert : Form
    {
        bool isNew;
        List<Correntista> inserted = new List<Correntista>();
        public FormInsert()
        {
            InitializeComponent();
            bds.DataSource = new OnCorrentistas().GetAll();
            dgv.DataSource = bds;
            dgv.Columns["Conta"].Visible = false;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (bds.Current != null)
            {
                FormAccount formAccount = new FormAccount(bds.Current);
                formAccount.Show();
            }
        }

        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bds.EndEdit();
            if (isNew)
            {
                foreach (var c in inserted)
                {
                    new OnCorrentistas().New(c);
                }
                foreach (var i in (List<Correntista>)bds.DataSource)
                {
                    if (!inserted.Contains(i)) new OnCorrentistas().Save(i);
                }
                inserted.Clear();
                bds.DataSource = new OnCorrentistas().GetAll();
            }
        }

        private void ctsBtnNovo_Click(object sender, EventArgs e)
        {
            bds.AddNew();
            isNew = true;
            var cor = bds.Current as Correntista;
            if (cor != null)
            {
                inserted.Add(cor);
            }
        }

        private void cstBtnSalvar_Click(object sender, EventArgs e)
        {
            var dado = bds.Current as Correntista;
            if (dado.Nome != null && dado.Cpf != null)
            {
                bds.EndEdit();
                if (isNew)
                {
                    foreach (var c in inserted)
                    {
                        new OnCorrentistas().New(c);
                    }
                    foreach (var i in (List<Correntista>)bds.DataSource)
                    {
                        if (!inserted.Contains(i)) new OnCorrentistas().Save(i);
                    }
                    inserted.Clear();
                    bds.DataSource = new OnCorrentistas().GetAll();
                }
            }else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.");
            }
        }

        private void cstBtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cstBtnConfirma_Click(object sender, EventArgs e)
        {
            if (bds.Current != null)
            {
                FormAccount formAccount = new FormAccount(bds.Current);
                formAccount.Show();
            }
        }
    }
}
