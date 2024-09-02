using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sklad.Interfaces;
using Sklad.Model;
using System.Text.RegularExpressions;

namespace Sklad.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll()
        {
            return _products.ToList();
        }

        public Product GetById(int id)
        {
           var result =  _products.Find(product =>  product.Id == id);
            if (result == null) {
                Console.WriteLine("Product Not Found");
                return null;
            }
            else
            {
                return result;
            }
            
        }

        public void Add(Product product) {
            int pId;
            string pName;
            string pDescription;
            int pPrice;

            // new Product(); 
            do
            {
                Console.WriteLine("Enter Product Id");
                if (int.TryParse(Console.ReadLine(), out pId) && pId > 0) { 
                    product.Id = pId;
                break;
                }
                else
                {
                    Console.WriteLine("Invalid Product Id. Please enter a valid number.");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Enter Product Name");
                pName = Console.ReadLine();
                bool isValid = pName.Length >3 && pName.Take(3).All(c=> !char.IsDigit(c));
                if (isValid && !string.IsNullOrEmpty(pName))
                {
                    product.Name = pName;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Product Name. It must start with letters.");
                }
            }
            while (true);

                Console.WriteLine("Enter Product Description:");
                pDescription = Console.ReadLine();
                product.Description = pDescription;
            

            do
            {
                Console.WriteLine("Enter Product Price");
                if(int.TryParse(Console.ReadLine(), out pPrice) && pPrice > 0)
                {
                    product.Price = pPrice;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Product Price. Please enter a positive number.");
                }

            }
            while (true);
            
            _products.Add(product);
        }
        public void Update(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            string pNewName;
            string pNewDescription;
            int pNewPrice;

            do
            {
                Console.WriteLine("Enter New Product Name:");
                pNewName = Console.ReadLine();

                bool isValidName = pNewName.Length >= 3 && pNewName.Take(3).All(c => !char.IsDigit(c));

                if (isValidName && !string.IsNullOrEmpty(pNewName))
                {
                    product.Name = pNewName;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Product Name. It must start with letters.");
                }
            }
            while (true); 

            Console.WriteLine("Enter New Product Description:");
            pNewDescription = Console.ReadLine();
            product.Description = pNewDescription;
            do
            {
                Console.WriteLine("Enter New Product Price:");
                if (int.TryParse(Console.ReadLine(), out pNewPrice) && pNewPrice > 0)
                {
                    product.Price = pNewPrice;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Product Price. Please enter a positive number.");
                }
            }
            while (true); 

            Console.WriteLine("Product updated successfully.");
        }
        public void Delete(int id)
        {
            var result = GetById(id);
            
            if (result == null) {
                Console.WriteLine("Product Not Found ");
                return;
            }
            
            _products.Remove(result);
            Console.WriteLine("Product deleted successfully.");
        }


    }
}

