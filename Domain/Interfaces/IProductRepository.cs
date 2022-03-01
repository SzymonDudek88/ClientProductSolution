using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public  interface IProductRepository
    {

        IEnumerable<Product> GetAll();
        Product GetById (int id);

        Product Add(Product product);

        void Update(Product product);
        void Delete(Product product);

    }
}
