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
    public partial class FormMenu : Form
    {
        #region atributos
        Conta conta;
        Conta contaDestino;

        System.Drawing.Rectangle workingRectangle =
            Screen.PrimaryScreen.WorkingArea;

        int _width = 0;
        int _height = 0;
        int status = 0;
        bool transfField = true;

        Label nomeCorrentista = new Label();
        Label saldoConta = new Label();

        Label aviso = new Label();


        TextBox txtValorSaque = new TextBox();
        Label valorSaque = new Label();
        
        
        List<char> listaValorSaque = new List<char>();

        TextBox txtValorTransf = new TextBox();
        TextBox txtContaTransf = new TextBox();
        Label valorTransf = new Label();
        Label contaTransf = new Label();

        List<char> listaValorTransf = new List<char>();
        List<char> listaContaTransf = new List<char>();


        CustomButton cstBtnCorrigeTransf = new CustomButton();
        CustomButton cstBtnConfirmaTransf = new CustomButton();
        CustomButton cstBtnConfirmaTF = new CustomButton();

        TextBox extrato = new TextBox();

        #endregion

        #region FormLoad

        public FormMenu(Object contaR)
        {
            InitializeComponent();
            _width = workingRectangle.Width;
            _height = workingRectangle.Height;
            this.Size = new System.Drawing.Size(_width, _height);
            cstBtnConfirmaSaque.Hide();
            cstBtnCorrigeSaque.Hide();


            if (contaR != null)
            {
                conta = contaR as Conta;
            }
        }

        #endregion

      

               

        #region Voltar
        private void cstBtnVoltar_Click(object sender, EventArgs e)
        {
            cstBtnSaque.Show();
            cstBtnTransf.Show();
            cstBtnSaldo.Show();
            cstBtnExtrato.Show();
            switch (status)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        this.Controls.Remove(valorSaque);
                        this.Controls.Remove(txtValorSaque);
                        txtValorSaque.ResetText();

                        this.Controls.Remove(aviso);
                        aviso.ResetText();

                        cstBtnConfirmaSaque.Hide();
                        cstBtnCorrigeSaque.Hide();
                        for (int i = 0; i < listaValorSaque.Count; i++)
                        {
                            listaValorSaque.RemoveAt(i);
                        }

                        break;
                    }
                case 2:
                    {
                        this.Controls.Remove(contaTransf);
                        this.Controls.Remove(txtContaTransf);
                        txtContaTransf.ResetText();

                        this.Controls.Remove(valorTransf);
                        this.Controls.Remove(txtValorTransf);
                        txtValorTransf.ResetText();

                        this.Controls.Remove(aviso);
                        aviso.ResetText();

                        this.Controls.Remove(cstBtnConfirmaTransf);
                        this.Controls.Remove(cstBtnCorrigeTransf);

                        for (int i = 0; i < listaContaTransf.Count; i++)
                        {
                            listaContaTransf.RemoveAt(i);
                        }
                        for (int i = 0; i < listaValorTransf.Count; i++)
                        {
                            listaValorTransf.RemoveAt(i);
                        }
                        break;
                    }
                case 3:
                    {
                        this.Controls.Remove(extrato);
                        extrato.ResetText();
                        break;
                    }
                case 4:
                    {
                        this.Controls.Remove(nomeCorrentista);
                        nomeCorrentista.ResetText();
                        this.Controls.Remove(saldoConta);
                        saldoConta.ResetText();
                        break;
                    }

            }

            status = 0;
        }

        #endregion

        #region Sair

        private void cstBtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Saque
        
        private void cstBtnSaque_Click(object sender, EventArgs e)
        {
            status = 1;
            cstBtnSaque.Hide();
            cstBtnTransf.Hide();
            cstBtnSaldo.Hide();
            cstBtnExtrato.Hide();
            valorSaque.Show();
            txtValorSaque.Show();
            cstBtnConfirmaSaque.Show();
            cstBtnCorrigeSaque.Show();

            valorSaque.Text = "Insira o valor para saque:";
            //valorSaque.AutoSize = true;
            valorSaque.Size = new Size(450, 100);
            valorSaque.Font = new Font("Calibri", 28, FontStyle.Bold);
            valorSaque.Location = new Point(_width / 2 - valorSaque.Width / 2, _height / 3 - 40);
            valorSaque.ForeColor = Color.Black;
            valorSaque.Padding = new Padding(6);

            listaValorSaque.Clear();


            txtValorSaque.Text = "0.00";
            txtValorSaque.Size = new Size(244, 23);
            txtValorSaque.Location = new Point(_width / 2 - txtValorSaque.Width / 2, _height / 3 + 80);
            txtValorSaque.Font = new Font("Calibri", 28, FontStyle.Bold);
            txtValorSaque.ForeColor = Color.Black;
            txtValorSaque.Padding = new Padding(6);
            txtValorSaque.KeyPress += new KeyPressEventHandler(txtValorSaque_KeyPress);
            txtValorSaque.ReadOnly = true;



            this.Controls.Add(valorSaque);
            this.Controls.Add(txtValorSaque);

            txtValorSaque.Focus();
        }



        private void txtValorSaque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            else
            {
                txtValorSaque.BackColor = txtValorSaque.BackColor;
                txtValorSaque.ForeColor = Color.Black;
                listaValorSaque.Add(e.KeyChar);
                e.Handled = true;
                if (listaValorSaque.Count < 3)
                {
                    if (listaValorSaque.Count == 1)
                    {
                        txtValorSaque.Text = "0.0" + listaValorSaque[0];
                    }
                    else
                    {
                        txtValorSaque.Text = "0." + listaValorSaque[0] + listaValorSaque[1];
                    }
                }
                else
                {
                    string texto = "";
                    for (int i = 0; i < listaValorSaque.Count; i++)
                    {
                        if (i == listaValorSaque.Count - 3)
                        {
                            texto += listaValorSaque[i];
                            texto += ".";
                        }
                        else
                        {
                            texto += listaValorSaque[i];
                        }
                    }
                    txtValorSaque.Text = texto;
                }

            }
        }

        private void cstBtnConfirmaSaque_Click(object sender, EventArgs e)
        {
            if (txtValorSaque.Text == "0.00")
            {
                txtValorSaque.BackColor = txtValorSaque.BackColor;
                txtValorSaque.ForeColor = Color.Red;

                aviso.Text = "Valor informado inválido.";
                aviso.AutoSize = true;
                aviso.Location = new Point(_width / 2 - aviso.Width / 2, _height / 2);
                aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                aviso.ForeColor = Color.Black;
                aviso.Padding = new Padding(6);
                this.Controls.Add(aviso);
            }
            else
            {
                decimal saque = Decimal.Parse(txtValorSaque.Text);
                if (conta.Saldo >= saque)
                {

                    OnLancamentos onLancamento = new OnLancamentos();
                    int res = onLancamento.Saque(conta, saque);
                    if (res == -1 || res == 1) aviso.Text = "Erro.";

                    valorSaque.Hide();
                    txtValorSaque.Hide();
                    cstBtnConfirmaSaque.Hide();
                    cstBtnCorrigeSaque.Hide();
                    cstBtnVoltar.Show();
                    cstBtnSair.Show();

                    aviso.Text = "Aguarde um momento. Seu dinheiro será entregue em breve.";
                    aviso.AutoSize = true;
                    aviso.Location = new Point(_width / 2 - aviso.Width / 2, _height / 2);
                    aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                    aviso.ForeColor = Color.Black;
                    aviso.Padding = new Padding(6);
                    this.Controls.Add(aviso);
                    Task.Delay(3000);



                }
                else
                {
                    txtValorSaque.BackColor = txtValorSaque.BackColor;
                    txtValorSaque.ForeColor = Color.Red;

                    aviso.Text = "Saldo em conta insuficiente.";
                    aviso.AutoSize = true;
                    aviso.Location = new Point(_width / 2 - aviso.Width / 2, _height / 2);
                    aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                    aviso.ForeColor = Color.Black;
                    aviso.Padding = new Padding(6);
                    this.Controls.Add(aviso);
                }
            }
        }

        private void cstBtnCorrigeSaque_Click(object sender, EventArgs e)
        {
            txtValorSaque.BackColor = txtValorSaque.BackColor;
            txtValorSaque.ForeColor = Color.Black;
            if (listaValorSaque.Count > 1)
            {
                listaValorSaque.RemoveAt(listaValorSaque.Count - 1);
                if (listaValorSaque.Count < 3)
                {
                    if (listaValorSaque.Count == 1)
                    {
                        txtValorSaque.Text = "0.0" + listaValorSaque[0];
                    }

                    if (listaValorSaque.Count == 2)
                        txtValorSaque.Text = "0." + listaValorSaque[0] + listaValorSaque[1];

                }
                else
                {
                    string texto = "";
                    for (int i = 0; i < listaValorSaque.Count; i++)
                    {
                        if (i == listaValorSaque.Count - 3)
                        {
                            texto += listaValorSaque[i];
                            texto += ".";
                        }
                        else
                        {
                            texto += listaValorSaque[i];
                        }
                    }
                    txtValorSaque.Text = texto;
                }
            }
            else if (listaValorSaque.Count == 1)
            {
                listaValorSaque.RemoveAt(0);
                txtValorSaque.Text = "0.00";
            }
        }

        
        #endregion

        #region Transferencia
        private void cstBtnTransf_Click(object sender, EventArgs e)
        {
            status = 2;
            cstBtnSaque.Hide();
            cstBtnTransf.Hide();
            cstBtnSaldo.Hide();
            cstBtnExtrato.Hide();


            contaTransf.Text = "Insira a conta para transferir:";
            //contaTransf.AutoSize = true;
            contaTransf.Size = new Size(500, 100);
            contaTransf.Font = new Font("Calibri", 28, FontStyle.Bold);
            contaTransf.Location = new Point(_width / 2 - contaTransf.Width / 2, _height / 3 - 40);
            contaTransf.ForeColor = Color.Black;
            contaTransf.Padding = new Padding(6);

            txtContaTransf.Text = "0";
            txtContaTransf.Size = new Size(244, 23);
            txtContaTransf.Location = new Point(_width / 2 - txtContaTransf.Width / 2, _height / 3 + 80);
            txtContaTransf.Font = new Font("Calibri", 28, FontStyle.Bold);
            txtContaTransf.ForeColor = Color.Black;
            txtContaTransf.Padding = new Padding(6);
            txtContaTransf.KeyPress += new KeyPressEventHandler(txtContaTransf_KeyPress);
            txtContaTransf.ReadOnly = true;

            valorTransf.Text = "Insira o valor para transferir:";
            //valorTransf.AutoSize = true;
            valorTransf.Size = new Size(500, 100);
            valorTransf.Font = new Font("Calibri", 28, FontStyle.Bold);
            valorTransf.Location = new Point(_width / 2 - valorTransf.Width / 2, _height / 2 - 40);
            valorTransf.ForeColor = Color.Black;
            valorTransf.Padding = new Padding(6);

            listaValorTransf.Clear();


            txtValorTransf.Text = "0.00";
            txtValorTransf.Size = new Size(244, 23);
            txtValorTransf.Location = new Point(_width / 2 - txtValorTransf.Width / 2, _height / 2 + 80);
            txtValorTransf.Font = new Font("Calibri", 28, FontStyle.Bold);
            txtValorTransf.ForeColor = Color.Black;
            txtValorTransf.Padding = new Padding(6);
            txtValorTransf.KeyPress += new KeyPressEventHandler(txtValorTransf_KeyPress);
            txtValorTransf.ReadOnly = true;

            cstBtnConfirmaTransf.Text = "Confirmar";
            cstBtnConfirmaTransf.Size = new Size(250, 120);
            cstBtnConfirmaTransf.Location = new Point(_width / 2 - cstBtnConfirmaTransf.Width / 2, cstBtnSair.Location.Y);
            cstBtnConfirmaTransf.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            cstBtnConfirmaTransf.BackColor = Color.DarkGray;
            cstBtnConfirmaTransf.BorderColor = Color.DimGray;
            cstBtnConfirmaTransf.MouseHoverColor = Color.Silver;

            cstBtnCorrigeTransf.Text = "Corrige";
            cstBtnCorrigeTransf.Size = new Size(250, 120);
            cstBtnCorrigeTransf.Location = new Point(cstBtnVoltar.Location.X, cstBtnSair.Location.Y - 200);
            cstBtnCorrigeTransf.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            cstBtnCorrigeTransf.BackColor = Color.DarkGray;
            cstBtnCorrigeTransf.BorderColor = Color.DimGray;
            cstBtnCorrigeTransf.MouseHoverColor = Color.Silver;

            cstBtnConfirmaTransf.Click -= new EventHandler(btnConfirmaT_Click);
            cstBtnConfirmaTransf.Click += new EventHandler(btnConfirmaT_Click);

            cstBtnCorrigeTransf.Click -= new EventHandler(btnCorrigeT_Click);
            cstBtnCorrigeTransf.Click += new EventHandler(btnCorrigeT_Click);

            this.Controls.Add(contaTransf);
            this.Controls.Add(txtContaTransf);

            this.Controls.Add(valorTransf);
            this.Controls.Add(txtValorTransf);

            this.Controls.Add(cstBtnConfirmaTransf);
            this.Controls.Add(cstBtnCorrigeTransf);

            txtValorTransf.LostFocus += TxtValorTransf_LostFocus;
            txtContaTransf.LostFocus += TxtContaTransf_LostFocus;

            txtValorTransf.Show();
            txtContaTransf.Show();
            contaTransf.Show();
            valorTransf.Show();
            cstBtnConfirmaTransf.Show();
            cstBtnConfirmaTF.Hide();
            cstBtnCorrigeTransf.Show();

            txtContaTransf.Focus();

        }

        private void TxtValorTransf_LostFocus(object sender, EventArgs e)
        {
            transfField = false;
        }

        private void TxtContaTransf_LostFocus(object sender, EventArgs e)
        {
            transfField = true;
        }



        private void btnConfirmaT_Click(object sender, EventArgs e)
        {

            if (txtValorTransf.Text == "0.00")
            {
                txtValorTransf.BackColor = txtValorTransf.BackColor;
                txtValorTransf.ForeColor = Color.Red;

                aviso.Text = "Valor informado inválido.";
                aviso.AutoSize = true;
                aviso.Location = new Point(_width / 2 - aviso.Width / 2, _height / 2 + 140);
                aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                aviso.ForeColor = Color.Black;
                aviso.Padding = new Padding(6);
                this.Controls.Add(aviso);
            }
            else
            {
                decimal transf = Decimal.Parse(txtValorTransf.Text);
                if (conta.Saldo >= transf)
                {
                    OnContas onConta = new OnContas();
                    if (onConta.GetById(int.Parse(txtContaTransf.Text)) == null)
                    {
                        aviso.Text = "Conta informada não encontrada.";
                        aviso.AutoSize = true;
                        aviso.Location = new Point(_width / 2 - aviso.Width / 2, _height / 2 + 140);
                        aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                        aviso.ForeColor = Color.Black;
                        aviso.Padding = new Padding(6);
                        this.Controls.Add(aviso);
                    }
                    else
                    {
                        contaDestino = onConta.GetById(int.Parse(txtContaTransf.Text));


                        txtValorTransf.Hide();
                        txtContaTransf.Hide();
                        contaTransf.Hide();
                        valorTransf.Hide();
                        cstBtnConfirmaTransf.Hide();
                        cstBtnCorrigeTransf.Hide();
                        cstBtnVoltar.Show();
                        cstBtnSair.Show();

                        cstBtnConfirmaTF.Text = "Confirmar";
                        cstBtnConfirmaTF.Size = new Size(250, 120);
                        cstBtnConfirmaTF.Location = new Point(_width / 2 - cstBtnConfirmaTF.Width / 2, cstBtnSair.Location.Y);
                        cstBtnConfirmaTF.Font = new Font("Segoe UI", 26, FontStyle.Bold);
                        cstBtnConfirmaTF.BackColor = Color.DarkGray;
                        cstBtnConfirmaTF.BorderColor = Color.DimGray;
                        cstBtnConfirmaTF.MouseHoverColor = Color.Silver;

                        cstBtnConfirmaTF.Click -= new EventHandler(btnConfirmaF_Click);
                        cstBtnConfirmaTF.Click += new EventHandler(btnConfirmaF_Click);

                        this.Controls.Add(cstBtnConfirmaTF);

                        cstBtnConfirmaTF.Show();

                        Correntista correntista = new OnCorrentistas().GetById(contaDestino.CorrentistaId);
                        aviso.Text = "Conta Destino: " + contaDestino.CorrentistaId + "\nNome: " + correntista.Nome + "\nValor: " + txtValorTransf.Text;
                        aviso.AutoSize = true;
                        aviso.Location = new Point(_width / 2 - ((aviso.Width / 3) * 2) / 2, _height / 2);
                        aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                        aviso.ForeColor = Color.Black;
                        aviso.Padding = new Padding(6);
                        this.Controls.Add(aviso);

                    }

                }
                else
                {
                    txtValorSaque.BackColor = txtValorSaque.BackColor;
                    txtValorSaque.ForeColor = Color.Red;

                    aviso.Text = "Saldo em conta insuficiente.";
                    aviso.AutoSize = true;
                    aviso.Location = new Point(_width / 2 - aviso.Width / 2, _height / 2 + 140);
                    aviso.Font = new Font("Calibri", 28, FontStyle.Bold);
                    aviso.ForeColor = Color.Black;
                    aviso.Padding = new Padding(6);
                    this.Controls.Add(aviso);
                }
            }

        }

        private void btnCorrigeT_Click(object sender, EventArgs e)
        {
            if (!transfField)
            {
                txtValorTransf.BackColor = txtValorTransf.BackColor;
                txtValorTransf.ForeColor = Color.Black;
                if (listaValorTransf.Count > 1)
                {
                    listaValorTransf.RemoveAt(listaValorTransf.Count - 1);
                    if (listaValorTransf.Count < 3)
                    {
                        if (listaValorTransf.Count == 1)
                        {
                            txtValorTransf.Text = "0.0" + listaValorTransf[0];
                        }

                        if (listaValorTransf.Count == 2)
                            txtValorTransf.Text = "0." + listaValorTransf[0] + listaValorTransf[1];

                    }
                    else
                    {
                        string texto = "";
                        for (int i = 0; i < listaValorTransf.Count; i++)
                        {
                            if (i == listaValorTransf.Count - 3)
                            {
                                texto += listaValorTransf[i];
                                texto += ".";
                            }
                            else
                            {
                                texto += listaValorTransf[i];
                            }
                        }
                        txtValorTransf.Text = texto;
                    }
                }
                else if (listaValorTransf.Count == 1)
                {
                    listaValorTransf.RemoveAt(0);
                    txtValorTransf.Text = "0.00";
                }
            }
            else if (transfField)
            {
                if (listaContaTransf.Count > 1)
                {
                    listaContaTransf.RemoveAt(listaContaTransf.Count - 1);

                    string texto = "";

                    for (int i = 0; i < listaContaTransf.Count; i++)
                    {

                        texto += listaContaTransf[i];

                    }
                    txtContaTransf.Text = texto;
                }
                else if (listaContaTransf.Count == 1)
                {
                    listaContaTransf.RemoveAt(0);
                    txtContaTransf.Text = "0";
                }

            }
        }




        private void txtValorTransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            transfField = false;
            if (e.Handled) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            else
            {
                txtValorTransf.BackColor = txtValorTransf.BackColor;
                txtValorTransf.ForeColor = Color.Black;
                listaValorTransf.Add(e.KeyChar);
                e.Handled = true;
                if (listaValorTransf.Count < 3)
                {
                    if (listaValorTransf.Count == 1)
                    {
                        txtValorTransf.Text = "0.0" + listaValorTransf[0];
                    }
                    else
                    {
                        txtValorTransf.Text = "0." + listaValorTransf[0] + listaValorTransf[1];
                    }
                }
                else
                {
                    string texto = "";
                    for (int i = 0; i < listaValorTransf.Count; i++)
                    {
                        if (i == listaValorTransf.Count - 3)
                        {
                            texto += listaValorTransf[i];
                            texto += ".";
                        }
                        else
                        {
                            texto += listaValorTransf[i];
                        }
                    }
                    txtValorTransf.Text = texto;
                }

            }
        }

        private void txtContaTransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            transfField = true;
            if (e.Handled) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            else
            {
                txtContaTransf.BackColor = txtContaTransf.BackColor;
                txtContaTransf.ForeColor = Color.Black;
                listaContaTransf.Add(e.KeyChar);
                e.Handled = true;

                string texto = "";

                for (int i = 0; i < listaContaTransf.Count; i++)
                {

                    texto += listaContaTransf[i];

                }
                txtContaTransf.Text = texto;


            }
        }

        private void btnConfirmaF_Click(object sender, EventArgs e)
        {
            OnLancamentos onLancamento = new OnLancamentos();
            int res = onLancamento.Transferencia(conta, contaDestino, Decimal.Parse(txtValorTransf.Text));
            if (res == -1 || res == 1) aviso.Text = "Erro.";
            aviso.Text = "Transferência realizada com sucesso.";
            this.Controls.Remove(cstBtnConfirmaTF);
            Task.Delay(3000);


        }

        #endregion

        #region Saldo

        private void cstBtnSaldo_Click(object sender, EventArgs e)
        {
            status = 4;
            cstBtnSaque.Hide();
            cstBtnTransf.Hide();
            cstBtnSaldo.Hide();
            cstBtnExtrato.Hide();

            OnCorrentistas onCorrentista = new OnCorrentistas();
            nomeCorrentista.Text = onCorrentista.GetById(conta.CorrentistaId).Nome;

            nomeCorrentista.AutoSize = true;
            nomeCorrentista.Location = new Point(_width / 2 - nomeCorrentista.Width / 2, _height / 3);
            nomeCorrentista.Font = new Font("Calibri", 18, FontStyle.Bold);
            nomeCorrentista.ForeColor = Color.Black;
            nomeCorrentista.Padding = new Padding(6);

            saldoConta.Text = conta.Saldo.ToString("0.00");
            saldoConta.AutoSize = true;
            saldoConta.Location = new Point(_width / 2 - saldoConta.Width / 2, _height / 3 + 41);
            saldoConta.Font = new Font("Calibri", 18, FontStyle.Bold);
            saldoConta.ForeColor = Color.Black;
            saldoConta.Padding = new Padding(6);


            this.Controls.Add(nomeCorrentista);
            this.Controls.Add(saldoConta);
        }
        #endregion

        #region Extrato
        private void cstBtnExtrato_Click(object sender, EventArgs e)
        {
            status = 3;
            cstBtnSaque.Hide();
            cstBtnTransf.Hide();
            cstBtnSaldo.Hide();
            cstBtnExtrato.Hide();

            OnLancamentos onLancamento = new OnLancamentos();
            extrato.Multiline = true;

            extrato.Font = new Font("Courier New", 12, FontStyle.Bold);
            extrato.ForeColor = Color.Black;


            String historico = "";

            List<Lançamento> listaHistorico = onLancamento.Extrato(conta.Id);
            if (listaHistorico != null)
            {
                if (listaHistorico.Count >= 1)
                {
                    historico = "Data mov.".PadRight(21) + "NR.".PadRight(15) + "Histórico".PadRight(19) + "Operação".PadRight(9) + "Valor".PadLeft(15) +" Saldo".PadLeft(15) ;
                    extrato.AppendText(historico + Environment.NewLine);
                    foreach (Lançamento lanc in listaHistorico)
                    {
                        historico = "";
                        historico = lanc.Data.ToShortDateString().PadRight(21) + lanc.Id.ToString().PadRight(15) +  (lanc.Historico.Contains(",") ? lanc.Historico.Substring(2, 7) : lanc.Historico.Substring(0, 7)).PadRight(19) +  (lanc.Operacao == 0 ? "Saque" : "Transf").PadRight(9) + lanc.Valor.ToString("0.00").PadLeft(15) + " " + lanc.Conta.Saldo.ToString("0.00").PadLeft(15);
                        extrato.AppendText(historico + Environment.NewLine);
                    }
                }
                else
                {
                    historico = "Essa conta não possui movimentações.";
                    extrato.AppendText(historico);
                }
            }
            else
            {
                historico = "Erro, extrato da conta é nulo.";
                extrato.AppendText(historico);
            }
            
            extrato.Size = new Size((int)(_width / 1.8), (int)(_height / 2));
            extrato.Location = new Point((int)(_width / 4.4), _height / 4);
            extrato.ScrollBars = ScrollBars.Vertical;
            extrato.WordWrap = true;
            extrato.ReadOnly = true;
            this.Controls.Add(extrato);
        }

        #endregion

        
    }
}
