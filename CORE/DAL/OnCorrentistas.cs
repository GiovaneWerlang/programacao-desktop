using CORE.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public class OnCorrentistas : IRepositorio<Correntista>
    {
        public void Delete(Correntista item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Correntistas.Remove(item);
                    db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Correntista> GetAll()
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    return db.Correntistas.OrderBy(c => c.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Correntista GetById(int id)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    Correntista correntista = db.Correntistas.Where(c => c.Id == id).ToList().FirstOrDefault();
                    if (correntista != null)
                        return correntista;
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void New(Correntista item)
        {
            try
            {
                using (var db = new TERMINALPD25SContext())
                {
                    db.Correntistas.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Save(Correntista item)
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
