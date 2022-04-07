using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "One", "Second" };
            HtmlBuilder builder = new HtmlBuilder("ul");
            foreach (var item in words)
            {
                builder.AddChild("li", item);
            }

            Console.WriteLine(builder);


            var productBuilder = new ProductBuilder()
                          .AddProductName("Some")
                          .AddProductPart("HeadPhones", 10, 2)
                          .AddProductPart("Charg Station", 10, 20)
                          .AddProductPart("Some another part of phone", 12, 2);

            Console.WriteLine(productBuilder);


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
