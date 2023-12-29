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
    public partial class FormAccount : Form
    {
        bool isNew;
        List<Conta> inserted = new List<Conta>();
        Correntista corrent;
        public FormAccount(Object correntista)
        {
            InitializeComponent();
            if (correntista != null)
            {
                corrent = correntista as Correntista;
                if (new OnContas().GetUserContas(corrent.Id) != null)
                {
                    bds.DataSource = new OnContas().GetUserContas(corrent.Id);
                    dgv.DataSource = bds;
                    dgv.Columns["LimiteCredito"].DefaultCellStyle.Format = "0.00##";
                    dgv.Columns["Saldo"].DefaultCellStyle.Format = "0.00##";
                    dgv.Columns["Correntista"].Visible = false;
                    dgv.Columns["Lançamentos"].Visible = false;
                }else
                {
                    bds.DataSource = new OnContas().GetUserContas(corrent.Id);
                    dgv.DataSource = bds;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            bds.AddNew();
            isNew = true;
            var cont = bds.Current as Conta;
            if (corrent != null && cont != null)
            {
                cont.CorrentistaId = corrent.Id;
                inserted.Add(cont);

            }
            if (cont != null)
            {
                inserted.Add(cont);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            
        }

        private void cstBtnNova_Click(object sender, EventArgs e)
        {
            bds.AddNew();
            isNew = true;
            var cont = bds.Current as Conta;
            if (corrent != null && cont != null)
            {
                cont.CorrentistaId = corrent.Id;
                inserted.Add(cont);

            }
            if (cont != null)
            {
                inserted.Add(cont);
            }
        }

        private void cstBtnSalvar_Click(object sender, EventArgs e)
        {
            bds.EndEdit();
            if (isNew)
            {
                foreach (var c in inserted)
                {
                    new OnContas().New(c);
                }
                foreach (var i in (List<Conta>)bds.DataSource)
                {
                    if (!inserted.Contains(i)) new OnContas().Save(i);
                }
                inserted.Clear();
                if (corrent != null)
                    bds.DataSource = new OnContas().GetUserContas(corrent.Id);
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
                FormMenu formMenu = new FormMenu(bds.Current);
                formMenu.Show();
            }
        }
    }
}
