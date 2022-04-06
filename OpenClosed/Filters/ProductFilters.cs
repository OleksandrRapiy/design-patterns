using System.Collections.Generic;

namespace OpenClosed
{
    /// <summary>
    /// Bad example, because of if we want to add new filter, we alway have to change Product Filter class 
    /// </summary>
    public static class ProductFilters
    {
        public static IEnumerable<Product> FilterBySize(this IEnumerable<Product> products, Size size)
        {
            foreach (var item in products)
            {
                if (item.Size == size)
                {
                    yield return item;
                }
            }
        }
    }



}
