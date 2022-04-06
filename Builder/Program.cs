using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{

    public class HtmlElement
    {
        public string Name, Text;
        private int indentSize = 2;
        public List<HtmlElement> Elements = new List<HtmlElement>();

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public string ToStringImp(int indent)
        {
            var sb = new StringBuilder();
            var spaces = new string(' ', indentSize * indent);

            sb.AppendLine($"{spaces}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * indent + 1));
                sb.AppendLine(Text);
            }

            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImp(indent + 1));
            }
            sb.AppendLine($"{spaces}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImp(0);
        }
    }

    public class HtmlBuilder
    {
        HtmlElement root = new HtmlElement();
        public string RootName { get; }

        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            RootName = rootName;
        }

        public void AddChild(string name, string text)
        {
            var el = new HtmlElement(name, text);
            root.Elements.Add(el);
        }

        public void Clear()
        {
            root = new HtmlElement { Name = RootName };
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var words = new string[] { "One", "Second" };
            //HtmlBuilder builder = new HtmlBuilder("ul");
            //foreach (var item in words)
            //{
            //    builder.AddChild("li", item);
            //}

            //Console.WriteLine(builder);


            //var productBuilder = new ProductBuilder("Phone", 111, 2);
            //productBuilder.AddProductPart("HeadPhones", 10, 2)
            //              .AddProductPart("Charg Station", 10, 20)
            //              .AddProductPart("Some another part of phone", 12, 2);

            //Console.WriteLine(productBuilder);


            var personInfoBuilder = Person.Build.BuildCredentials("Jhon", "Smith")
                                    .BuildJob(new string[] { "Some", "Another" })
                                    .BuilPersonWithData("Rap", "Rainbow", new string[] { "some", "anothre" })
                                    .Buid();


            Console.WriteLine(personInfoBuilder);




            var product = new ProductBuilder()
                .AddProductName("Apple").AddProductPrice(123.432f).Build();


            Console.WriteLine(product);


            var car = CarBuilder.Create().CarName("Some").CarType(CarType.Sedan).Build();
            Console.WriteLine(car);


            var house = new HouseBuilder().HouseAddress.AtCity("New-York").AtStreet("Washington Post").HouseSize.Size(100).RoomCount(5).Build();


            Console.WriteLine(house);


            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");

            Console.WriteLine(cb);

        }
    }
}
