using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {

        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>
                {
                    new Car 
                    {
                        name = "Tesla Model A", 
                        shortDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", 
                        longDesc = "Tesla A", 
                        img = "/img/tesla.jpg", 
                        price = 45000, 
                        isFavorite = true, 
                        available = true, 
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name = "Tesla Model B",
                        shortDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        longDesc = "Tesla B",
                        img = "/img/tesla2.jpg",
                        price = 40000,
                        isFavorite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name = "Tesla Model C",
                        shortDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        longDesc = "Tesla C",
                        img = "/img/tesla3.jpg",
                        price = 50000,
                        isFavorite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
