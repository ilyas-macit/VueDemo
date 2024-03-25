namespace VueDemo.Models.Abstract
{
    public interface IProductDal
    {
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
        List<Product> GetAll();

    }
}
