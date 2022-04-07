using System;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var polarPoint = Point.Factory.NewPolarPoint(1, 334);
            Console.WriteLine(polarPoint);

            var polarPointAsync = await Point.Factory.CreatePolarCoordinatesAsync(12.32, 21.2);
            Console.WriteLine(polarPointAsync);


            var themeFactory = new TrackingThemeFactory();
            var lightTheme = themeFactory.Create(false);
            var darkTheme = themeFactory.Create(true);

            Console.WriteLine(themeFactory.Info);

            var replacebleFactory = new ReplacebleThemeFactory();
            var theme = replacebleFactory.Create(true);
            Console.WriteLine(theme.Value.BgrColor);
            replacebleFactory.ReplaceTheme(false);

            Console.WriteLine(theme.Value.BgrColor);


            var personFactory = new PersonFactory();
            var person = personFactory.CreatePerson("Alex");
            var person2 = personFactory.CreatePerson("Alex2");


            Console.WriteLine(person);
            Console.WriteLine(person2);



            /// Abstract factory 
            var figureFactory = new FigureFactory();
            IFigure threeDFigure = figureFactory.Create3DFigure();
            IFigure twoDFigure = figureFactory.Create2DFigure();


            threeDFigure.Draw();
            twoDFigure.Draw();
        }
    }
}
