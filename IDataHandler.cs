using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР_1_консоль
{
    public interface IDataHandler
    {
        //public ProductData LoadProduct(string path, int position);

        public List<ProductData> LoadAll(string path);

        public ProductData LoadByNumber(string path, int position);

        public void SaveProduct();

        public void SaveAll();

        public void DeleteProduct();

    }


}
