using VueDemo.Models.Abstract;

namespace VueDemo.Models.Concrete
{
    public class ProductDal : IProductDal
    {
        private readonly Context _context;

        public ProductDal(Context context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            
            var entity = _context.Entry(product);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                var entity = _context.Entry(product);
                entity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            var entity = _context.Entry(product);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
