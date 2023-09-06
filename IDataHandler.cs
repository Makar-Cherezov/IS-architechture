using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР_1_консоль
{
    public interface IDataHandler
    {
        public ProductData ParseLineToProduct(string line);

        public string ParseProductToLine(ProductData product);

        public List<ProductData> LoadAll(string path);

        public ProductData LoadByNumber(string path, int position);

        public void SaveProduct(string path, ProductData product);

        public void SaveAllProducts(string path, List<ProductData> allProduct);

        public void DeleteProduct(string path, ProductData product);

    }


}
