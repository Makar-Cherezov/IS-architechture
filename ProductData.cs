using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР_1_консоль
{
    public class ProductData
    {
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DateOfUpdating { get; set; }

        public ProductData(string productName, string sellerName, string productDescription, float price, bool isAvailable, DateTime date)
        {
            ProductName = productName;
            SellerName = sellerName;
            ProductDescription = productDescription;
            Price = price;
            IsAvailable = isAvailable;
            DateOfUpdating = date;
        }
    }
}
