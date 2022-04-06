using System.Globalization;

namespace OpenClosed
{
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }

        public override string ToString()
        {
            return $"{ new CultureInfo("en-US", false).TextInfo.ToTitleCase(Name)} - {Color}, {Size}";
        }
    }
}
