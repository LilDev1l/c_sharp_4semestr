using lab11.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Data
{
    class UnitOfWork : IDisposable
    {
        private ApplicationContext _db = new ApplicationContext();
        private ProductRepository _productRepository;
        private SellerRepository _sellerRepository;
        
        public ProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }

                return _productRepository;
            }
        }

        public SellerRepository Sellers
        {
            get
            {
                if (_sellerRepository == null)
                {
                    _sellerRepository = new SellerRepository(_db);
                }

                return _sellerRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public DbContextTransaction BeginTransaction()
        {
            return _db.Database.BeginTransaction();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
