using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public  interface IProductRepository
    {

       Task< IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize);
       Task <int> GetAllCountAsync();
        Product GetById (int id);

        Product Add(Product product);

        void Update(Product product);
     
        void Delete(Product product);

    }
}
