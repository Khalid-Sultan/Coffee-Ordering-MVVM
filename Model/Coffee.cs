using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Coffee_Ordering_with_MVVM.Model
{
    public class CoffeeModel { }
    public class Coffee
    {
        public CondimentType condimentType { get; set; }
        public IceSelection iceSelection { get; set; }
        public BeanSelection beanSelection { get; set; }
        public CreamSelection creamSelection { get; set; }
        public SizeSelection sizeSelection { get; set; }
        public double price { get; set; }
    }
    public enum CommonOrder
    {
        Latte = 0, Espresso = 1, Machiatto = 2, Custom = 3
    }
    public enum CondimentType
    {
        NONE = 0, SALT = 1, SUGAR = 2
    }
    public enum IceSelection
    {
        HOT = 0, ICED = 1
    }
    public enum BeanSelection
    {
        HARRAR = 0, YIRGACHEFE = 1, SIDAMO = 2, ARABICA = 3
    }
    public enum CreamSelection
    {
        NONE = 0, MILK = 1, WHIPPED = 2, HALFANDHALF = 4, DOUBLE = 4
    }
    public enum SizeSelection
    {
        SMALL = 0, MEDIUM = 1, LARGE = 2
    } 
}
