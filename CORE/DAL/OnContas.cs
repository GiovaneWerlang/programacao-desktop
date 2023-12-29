using CORE.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class OnContas : IRepositorio<Conta>
    {
        public void Delete(Conta item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Contas.Remove(item);
                    db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Conta> GetAll()
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    return db.Contas.OrderBy(c => c.Correntista).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Conta> GetUserContas(int id)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    return db.Contas.Where(c => c.CorrentistaId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Conta GetById(int id)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    return db.Contas.Where(c => c.CorrentistaId == id).ToList().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Conta getSaldo(int id)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    Conta conta = db.Contas.Find(id);
                    if (conta != null)
                        return conta;
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void New(Conta item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Contas.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Save(Conta item)
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
    }
}
