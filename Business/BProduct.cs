﻿using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        public List<Product> GetProductsByName(string productName)
        {

            List<Product> products = new List<Product>();

            ProductDB productDataAccess = new ProductDB();
            products = productDataAccess.GetProducts();

            var results = products.Where(x => x.Name.Contains(productName)).ToList();

            return results;
        }
    }
}
