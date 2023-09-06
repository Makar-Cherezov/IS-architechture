using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ЛР_1_консоль
{
    class CSVDataHandler : IDataHandler
    {
        public List<ProductData> LoadAll(string path)
        {
            List<ProductData> allProducts = new List<ProductData>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    allProducts.Add(new ProductData(fields[0], fields[1], fields[2],
                            float.Parse(fields[3]), bool.Parse(fields[4]), DateTime.Parse(fields[5])));
                }
            }
            return allProducts;
        }
    }
}
