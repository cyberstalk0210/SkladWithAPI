using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace Sklad.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } 
        public string Description { get; set; } = string.Empty;

    }
}
