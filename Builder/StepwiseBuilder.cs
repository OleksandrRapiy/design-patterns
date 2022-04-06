using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public enum CarType
    {
        Sedan,
        SpeedCar
    }
    public class Car
    {
        public string Name { get; set; }
        public CarType Type { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Type}";
        }
    }

    public interface ISpecifyCarName
    {
        ISpecifyCarType CarName(string name);
    }

    public interface ISpecifyCarType
    {
        IBuildCar CarType(CarType carType);
    }

    public interface IBuildCar
    {
        Car Build();
    }

    public class CarBuilder
    {
        private sealed class InterfaceImp : ISpecifyCarName, ISpecifyCarType, IBuildCar
        {
            private Car car = new Car();

            public Car Build()
            {
                return car;
            }

            public ISpecifyCarType CarName(string name)
            {
                car.Name = name;
                return this;
            }

            public IBuildCar CarType(CarType carType)
            {
                car.Type = carType;
                return this;
            }

        }

        public static ISpecifyCarName Create()
        {
            return new InterfaceImp();
        }
    }
}
