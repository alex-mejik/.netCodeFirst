using DB_TEST.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DB_TEST
{


    public class Product
    {
        public int ProductId { get; set; } // Primary Key
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                //var migrator = new DbMigrator(new Configuration());
                //migrator.Update();

                // Add a category
                var category = new Category { Name = "Electronics" };
                context.Categories.Add(category);

                // Add a product
                var product = new Product { Name = "Smartphone", Price = 500, Category = category, Comment = "test" };
                context.Products.Add(product);

                // Save changes
                context.SaveChanges();
            }


        }
    }
}
