using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla Model A",
                        shortDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        longDesc = "Tesla A",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Электромобили"]
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
                        Category = Categories["Электромобили"]
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
                        Category = Categories["Электромобили"]
                    }
                    );
            }

            content.SaveChanges(); //сохраняем все изменения в БД
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category==null) //если объектов в ней нет
                {
                    var list = new Category[] //то создаем список данных
                    {
                        new Category{categoryName = "Электромобили", desc = "Современный вид транспорта" },
                        new Category{categoryName = "Классические авто", desc = "С двигателем внутренного сгорания" }
                    };

                    category = new Dictionary<string, Category>(); //выделяем помять для нашей переменной
                    foreach(Category elem in list)
                    {
                        category.Add(elem.categoryName, elem); //добавляем в категори объект 
                    }
                }

                return category;
            }
        }
    }
}
