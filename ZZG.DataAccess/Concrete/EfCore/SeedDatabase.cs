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
                    context.AddRange(ProductCategories);
                }
              

                context.SaveChanges();
            }

        }
        private static Category[] Categories =
        {
           new Category() {Name="Erkek"},
           new Category() {Name="Kadın"},
           new Category() {Name="Çocuk"}
        };
        private static Product[] Products =
        {
            new Product() { Name = "GLASS1",Price = 100,ImageUrl = "pic1.jpg",Description="Güzel gözlük"},
            new Product() { Name = "GLASS2",Price = 200,ImageUrl = "pic2.jpg",Description="Güzel gözlük"},
            new Product() { Name = "GLASS3",Price = 300,ImageUrl = "pic3.jpg",Description="Güzel gözlük"},
            new Product() { Name = "GLASS4",Price = 400,ImageUrl = "pic4.jpg",Description="Güzel gözlük"},
            new Product() { Name = "GLASS5",Price = 500,ImageUrl = "pic5.jpg",Description="Güzel gözlük"},
            new Product() { Name = "GLASS6",Price = 600,ImageUrl = "pic6.jpg",Description="Güzel gözlük"},
            new Product() { Name = "GLASS7",Price = 700,ImageUrl = "pic7.jpg",Description="Güzel gözlük"},
        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory() {Product = Products[0] ,Category = Categories[0] },
            new ProductCategory() {Product = Products[1] ,Category = Categories[0] },
            new ProductCategory() {Product = Products[2] ,Category = Categories[0] },
            new ProductCategory() {Product = Products[3] ,Category = Categories[1] },
            new ProductCategory() {Product = Products[4] ,Category = Categories[1] },
            new ProductCategory() {Product = Products[5] ,Category = Categories[2] },
            new ProductCategory() {Product = Products[6] ,Category = Categories[2] },
        };
    }
}
