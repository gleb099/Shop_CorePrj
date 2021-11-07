using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {

        private readonly AppDBContent appDBContent; //нужна по сути для работы с файлом appDbContent.cs

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        IEnumerable<Car> IAllCars.Cars => appDBContent.Car.Include(c => c.Category);

        IEnumerable<Car> IAllCars.getFavCars => appDBContent.Car.Where(p => p.isFavorite).Include(c => c.Category); //получаем все объекты у которых isfavorite = true

        Car IAllCars.getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
