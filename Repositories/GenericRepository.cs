using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuncDenizci.Models;

namespace TuncDenizci.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();

        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }

        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }

        public void TAdd(T cc)
        {
            c.Set<T>().Add(cc);
            c.SaveChanges();
        }

        public void TDelete(T cc)
        {
            c.Set<T>().Remove(cc);
            c.SaveChanges();
        }

        public void TUpdate(T cc)
        {
            c.Set<T>().Update(cc);
            c.SaveChanges();
        }

        public T TGet(int id)
        {
            return c.Set<T>().Find(id);
        }
    }
}
