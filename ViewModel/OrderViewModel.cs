using Coffee_Ordering_with_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Ordering_with_MVVM.ViewModel.OrderViewModel
{

    public class OrderViewModel
    {
        public ObservableCollection<Coffee> Orders { get; set; }
        public enumsHolder currentCoffee { get; set; }
        public void LoadCoffees(List<Coffee> coffee)
        {
            ObservableCollection<Coffee> orders = new ObservableCollection<Coffee>();
            currentCoffee = new enumsHolder();
            if (coffee.Count > 0)
            {
                foreach (Coffee c in coffee)
                {
                    orders.Add(c);
                    currentCoffee = new enumsHolder
                    {
                        beanSelection = (int)c.beanSelection,
                        condimentType = (int)c.condimentType,
                        creamSelection = (int)c.creamSelection,
                        iceSelection = (int)c.iceSelection,
                        sizeSelection = (int)c.sizeSelection,
                        price = (double)c.price
                    };
                }
            }
            else
            {
                Coffee c = new Coffee
                {
                    beanSelection = BeanSelection.ARABICA,
                    condimentType = CondimentType.SALT,
                    creamSelection = CreamSelection.NONE,
                    iceSelection = IceSelection.HOT,
                    sizeSelection = SizeSelection.SMALL,
                    price = 0.00
                };
                orders.Add(c);
                currentCoffee = new enumsHolder {
                    beanSelection = (int) c.beanSelection,
                    condimentType = (int) c.condimentType,
                    creamSelection = (int) c.creamSelection,
                    iceSelection = (int)c.iceSelection,
                    sizeSelection = (int)c.sizeSelection,
                    price = (double) c.price
                };
            }
            Orders = orders;
        }  
    }
    public class enumsHolder : INotifyPropertyChanged
    {
        private int _condimentType { get; set; }
        private int _iceSelection { get; set; }
        private int _beanSelection { get; set; }
        private int _creamSelection { get; set; }
        private int _sizeSelection { get; set; }
        private double _price { get; set; }

        public int condimentType
        {
            get { return _condimentType; }
            set
            {
                if (_condimentType != value)
                {
                    _condimentType = value;
                    RaisePropertyChanged("condimentType");
                }
            }
        }
        public int iceSelection
        {
            get { return _iceSelection; }
            set
            {
                if (_iceSelection != value)
                {
                    _iceSelection = value;
                    RaisePropertyChanged("iceSelection");
                }
            }
        }
        public int beanSelection
        {
            get { return _beanSelection; }
            set
            {
                if (_beanSelection != value)
                {
                    _beanSelection = value;
                    RaisePropertyChanged("beanSelection");
                }
            }
        }
        public int creamSelection
        {
            get { return _creamSelection; }
            set
            {
                if (_creamSelection != value)
                {
                    _creamSelection = value;
                    RaisePropertyChanged("creamSelection");
                }
            }
        }
        public int sizeSelection
        {
            get { return _sizeSelection; }
            set
            {
                if (_sizeSelection != value)
                {
                    _sizeSelection = value;
                    RaisePropertyChanged("sizeSelection");
                }
            }
        }
        public double price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChanged("price");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
