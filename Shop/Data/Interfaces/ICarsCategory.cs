using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface ICarsCategory
    {
        ///<summary>
        ///Интерфейс.Функция, которая возвращает все категории.
        ///</summary>
        IEnumerable<Category> AllCategories { get; }
    }
}
