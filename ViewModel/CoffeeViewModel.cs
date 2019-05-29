using Coffee_Ordering_with_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Ordering_with_MVVM.ViewModel
{
    class CoffeeViewModel
    {
        public ObservableCollection<Coffee> CoffeeModels { get; set; }
        public void LoadCoffee(List<Coffee> coffee)
        {
            ObservableCollection<Coffee> coffees = new ObservableCollection<Coffee>();
            foreach(Coffee c in coffee)
            {
                coffees.Add(c);
            }
            CoffeeModels = coffees;
        }
    }
}
