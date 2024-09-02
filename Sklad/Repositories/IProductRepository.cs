using Sklad.Model;

namespace Sklad.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(int id);
        void Delete(int id);


    }
}
