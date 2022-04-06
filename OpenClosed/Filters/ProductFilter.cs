using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosed
{
    // Example of Open-Closed Principle 
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> ts, ISpecification<T> specification);
    }


    public class ProductColorSpecification : ISpecification<Product>
    {
        private readonly Color color;
        public ProductColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class ProductSizeSpecification : ISpecification<Product>
    {
        private readonly Size size;

        public ProductSizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class ProductSizeAndColorSpecification: ISpecification<Product>
    {
        private readonly Size size;
        private readonly Color color;

        public ProductSizeAndColorSpecification(Size size, Color color)
        {
            this.size = size;
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == size && t.Color == color;
        }
    }

    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> ts, ISpecification<Product> specification)
        {
            foreach (var item in ts)
                if (specification.IsSatisfied(item))
                    yield return item;
        }
    }
}
