using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ЛР_1_консоль
{
    class CSVDataHandler : IDataHandler
    {
        public ProductData ParseLineToProduct(string line)
        {
            string[] fields = line.Split(',');
            return new ProductData(fields[0], fields[1], fields[2],
                            float.Parse(fields[3]), bool.Parse(fields[4]), DateTime.Parse(fields[5])));
        }

        public string ParseProductToLine(ProductData product)
        {
            string line = product.ProductName + product.SellerName + product.ProductDescription +
                product.Price.ToString() + product.IsAvailable.ToString() + product.DateOfUpdating.ToString();
            return line;
        }

        public List<ProductData> LoadAll(string path)
        {
            List<ProductData> allProducts = new List<ProductData>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                allProducts.Add(ParseLineToProduct(line));
            }
            return allProducts;
        }
        public ProductData LoadByNumber(string path, int position)
        {
            string line = File.ReadLines(path).Skip(position - 1).First();
            return ParseLineToProduct(line);
        }
        public void SaveProduct(string path, ProductData product)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(ParseProductToLine(product), true);
            }
        }
        public void SaveAllProducts(string path, List<ProductData> allProducts)
        {
            using (var sw = new StreamWriter(path))
            {
                foreach (var product in allProducts)
                {
                    sw.WriteLine(ParseProductToLine(product), true);
                }
                
            }
        }
        public void DeleteProduct(string path, ProductData product)
        {
            File.WriteAllLines(path, 
                File.ReadLines(path).Where(l => l != ParseProductToLine(product)).ToList());
        }
    }
}
