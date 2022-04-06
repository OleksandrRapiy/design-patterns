using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class House
    {
        public string StreetAddress { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public int HouseSize { get; set; }
        public int CountOfRoom { get; set; }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}\n" +
                $"House size in metters: {HouseSize}, Count of Rooms: {CountOfRoom}";
        }
    }

    public class HouseBuilder
    {
        protected House house = new House();

        public HouseAddressBuilder HouseAddress => new HouseAddressBuilder(house);
        public HouseSizeBuilder HouseSize => new HouseSizeBuilder(house);


        public House Build() => house;
    }

    public class HouseAddressBuilder: HouseBuilder
    {
        public HouseAddressBuilder(House house)
        {
            this.house = house;
        }

        public HouseAddressBuilder AtStreet(string street)
        {
            house.StreetAddress = street;
            return this;
        } 
        public HouseAddressBuilder WithPostCode(string postCode)
        {
            house.PostCode = postCode;
            return this;
        } 
        public HouseAddressBuilder AtCity(string city)
        {
            house.City = city;
            return this;
        } 
    }
    public class HouseSizeBuilder: HouseBuilder
    {

        public HouseSizeBuilder(House house)
        {
            this.house = house;
        }

        public HouseSizeBuilder Size(int size)
        {
            house.HouseSize = size;
            return this;
        }        
        
        public HouseSizeBuilder RoomCount(int rooms)
        {
            house.CountOfRoom = rooms;
            return this;
        }
    }
}
