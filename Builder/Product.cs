using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }

        private List<Product> _productParts = new List<Product>();

        public Product()
        {

        }

        public Product(string name, float price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public void AddProductPart(Product product)
        {
            _productParts.Add(product);
        }

        private string ToStringProduct(int indent)
        {
            var sb = new StringBuilder();
            var space = new string(' ', indent);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                sb.AppendLine($"{space}{Name} - {Price}, {Count}");
            }

            foreach (var item in _productParts)
            {
                sb.Append(item.ToStringProduct(indent + 1));
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringProduct(0);
        }
    }

    public class ProductBuilder
    {
        Product rootProduct = new Product();


        public ProductBuilder()
        {

        }

        public ProductBuilder AddProductPart(string name, float price, int count)
        {
            rootProduct.AddProductPart(new Product(name, price, count));

            return this;
        }


        public ProductBuilder AddProductName(string name)
        {
            rootProduct.Name = name;
            return this;
        }

        public ProductBuilder AddProductPrice(float price)
        {
            rootProduct.Price = price;
            return this;
        }

        public Product Build()
        {
            return rootProduct;
        }

        public void Clear()
        {
            rootProduct = new Product();
        }

        public override string ToString()
        {
            return rootProduct.ToString();
        }
    }
}
