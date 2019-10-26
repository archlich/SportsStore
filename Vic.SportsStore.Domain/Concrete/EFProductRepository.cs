﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        //private EFDbContext context = new EFDbContext();
        //public IEnumerable<Product> Products
        //{
        //    get { return context.Products; }
        //}

        public EFDbContext Context { get; set; }

        public IEnumerable<Product> Products
        {
            get
            {
                return Context.Products;
            }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                Context.Products.Add(product);
            }
            else
            {
                Product dbEntry = Context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            Context.SaveChanges();
        }
    }
}
