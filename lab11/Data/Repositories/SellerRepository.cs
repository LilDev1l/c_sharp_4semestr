using lab11.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Data.Repositories
{
    class SellerRepository : IDataService<Seller>
    {
        private ApplicationContext _db;

        public SellerRepository(ApplicationContext db)
        {
            _db = db;
        }

        public Seller Insert(Seller entity)
        {
            return _db.Sellers.Add(entity);
        }

        public bool Delete(int id)
        {
            bool flag = false;

            var entity = _db.Sellers.Find(id);
            if (entity != null)
            {
                _db.Sellers.Remove(entity);
                flag = true;
            }

            return flag;
        }

        public Seller GetById(int id)
        {
            return _db.Sellers.Find(id);
        }

        public IEnumerable<Seller> GetAll()
        {
            return _db.Sellers.Include("Products");
        }
        public async Task PrintAllAsync()
        {
            await _db.Sellers.Include("Products").ForEachAsync(p =>
            {
                Console.WriteLine("Name Seller{0} Name Product{1} Weight:{2} Price:{3}", p.Name, p.Products.First().Name, p.Products.First().Weight, p.Products.First().Price);
            });
        }
        public Seller Update(Seller oldEntity, Seller entity)
        {
            var dest = _db.Sellers.Find(oldEntity);

            dest.Name = entity.Name;

            return dest;
        }
    }
}
