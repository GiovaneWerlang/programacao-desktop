using CORE.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class OnLancamentos : IRepositorio<Lançamento>
    {
        public void Delete(Lançamento item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Lançamentos.Remove(item);
                    db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Lançamento> GetAll()
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    return db.Lançamentos.OrderBy(l => l.Data).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void New(Lançamento item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Lançamentos.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Save(Lançamento item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Saque(Conta contaSaque, decimal Valor)
        {
            using (var db = new TERMINALPD25SContext())
            {
                if (contaSaque == null) return -1;
                else if (contaSaque.Saldo < Valor) return 1;
                else
                {
                    Lançamento lançamento = new Lançamento();
                    lançamento.Data = DateTime.Now;
                    lançamento.ContaId = (int)contaSaque.Id;
                    lançamento.Operacao = 0; //débito
                    lançamento.Historico = contaSaque.Saldo.ToString();
                    lançamento.Valor = Valor;

                    try
                    {
                        New(lançamento);
                        Save(lançamento);
                        contaSaque.Saldo -= Valor;
                        OnContas conta = new OnContas();
                        conta.Save(contaSaque);

                        return 0;
                    }
                    catch (Exception ex)
                    {
                        return 2;
                    }
                }
            }
        }

        public int Transferencia(Conta ContaOrigem, Conta ContaDestino, decimal Valor)
        {
            using (var db = new TERMINALPD25SContext())
            {
                if (ContaOrigem.Saldo < Valor) return -1;
                else if (ContaOrigem == null || ContaOrigem == null) return 1;
                else
                {
                    

                    Lançamento lancamentoOrigem = new Lançamento();
                    lancamentoOrigem.Data = DateTime.Now;
                    lancamentoOrigem.ContaId = (int)ContaOrigem.Id;
                    lancamentoOrigem.Operacao = 1; //débito transf
                    lancamentoOrigem.Historico = ContaDestino.CorrentistaId + "," + ContaOrigem.Saldo;
                    lancamentoOrigem.Valor = Valor;

                    Lançamento lancamentoDestino = new Lançamento();
                    lancamentoDestino.Data = DateTime.Now;
                    lancamentoDestino.ContaId = (int)ContaDestino.Id;
                    lancamentoDestino.Operacao = 2; //crédito transf
                    lancamentoDestino.Historico = ContaOrigem.CorrentistaId + "," + ContaDestino.Saldo;
                    lancamentoDestino.Valor = Valor;

                    

                    try
                    {
                        ContaOrigem.Saldo -= Valor;
                        ContaDestino.Saldo += Valor;
                        OnContas conta = new OnContas();
                        conta.Save(ContaOrigem);
                        conta.Save(ContaDestino);

                        New(lancamentoOrigem);
                        Save(lancamentoOrigem);

                        New(lancamentoDestino);
                        Save(lancamentoDestino);

                        return 0;
                    }
                    catch (Exception ex)
                    {
                        return 2;
                    }
                }
            }
        }

        public List<Lançamento> Extrato(int ContaID)
        {
            List<Lançamento> lista = new List<Lançamento>();
            using (var db = new TERMINALPD25SContext())
            {
                var conta = db.Contas.Find(ContaID);
                if (conta == null) return null;
                //else if (db.Lançamentos.Find(ContaID) == null) return null;
                else if (db.Lançamentos.Where(l => l.ContaId == ContaID).Count() == 0) return null;
                else
                {
                    try
                    {
                        int dias = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                        lista = db.Lançamentos.Where(l => l.ContaId == ContaID && l.Data >= DateTime.Now.AddDays(-dias)).OrderBy(l => l.Data).ToList();
                        return lista;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
