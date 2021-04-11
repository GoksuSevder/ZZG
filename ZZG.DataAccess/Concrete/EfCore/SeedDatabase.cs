using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZZG.Entities;

namespace ZZG.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ZZGContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                    
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }
                context.SaveChanges();
            }

        }
        private static Category[] Categories =
        {
           new Category() {Name="Bay"},
           new Category() {Name="Bayan"},
           new Category() {Name="Çocuk"}
        };
        private static Product[] Products =
        {
            new Product() { Name = "GLASS1",Price = 100,ImageUrl = "1.JPG"},
            new Product() { Name = "GLASS2",Price = 200,ImageUrl = "2.JPG"},
            new Product() { Name = "GLASS3",Price = 300,ImageUrl = "3.JPG"},
            new Product() { Name = "GLASS4",Price = 400,ImageUrl = "4.JPG"},
            new Product() { Name = "GLASS5",Price = 500,ImageUrl = "5.JPG"},
            new Product() { Name = "GLASS6",Price = 600,ImageUrl = "6.JPG"},
            new Product() { Name = "GLASS7",Price = 700,ImageUrl = "7.JPG"},
        };
    }
}
