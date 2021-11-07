using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    //Функция, которая получает все товары
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currCategory { get; set; }
    }
}
