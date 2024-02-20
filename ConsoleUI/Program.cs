using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
           
        }
    }
}
