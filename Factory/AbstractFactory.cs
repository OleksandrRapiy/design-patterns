using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IFigure
    {
        void Draw();
    }
    public interface IThreeDFigure: IFigure
    {

    }

    public interface ITwoDFigure: IFigure
    {

    }


    public class ThreeDFigure : IThreeDFigure
    {
        public void Draw()
        {
            Console.WriteLine("ThreeDFigure");
        }
    }

    public class TwoDFigure : ITwoDFigure
    {
        public void Draw()
        {
            Console.WriteLine("TwoDFigure");
        }
    }

    public interface IFigureFactory
    {
        public IThreeDFigure Create3DFigure();
        public ITwoDFigure Create2DFigure();
    }

    public class FigureFactory : IFigureFactory
    {
        public ITwoDFigure Create2DFigure()
        {
            return new TwoDFigure();
        }

        public IThreeDFigure Create3DFigure()
        {
            return new ThreeDFigure();
        }
    }
}
