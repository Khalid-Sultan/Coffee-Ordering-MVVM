using Coffee_Ordering_with_MVVM.Model;
using Coffee_Ordering_with_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coffee_Ordering_with_MVVM
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MainView : Window
    {
        List<Coffee> Coffee2 { get; set; }
        public MainView(List<Coffee> coffee)
        {
            InitializeComponent(); 
            this.Coffee2 = coffee;
        }
        private void CoffeeViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CoffeeViewModel coffeeViewModelObject = new CoffeeViewModel();
            coffeeViewModelObject.LoadCoffee(Coffee2);
            CoffeeViewControl.DataContext = coffeeViewModelObject;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OrderWindow orderWindow = new OrderWindow(new List<Coffee>());
            orderWindow.Show();
            this.Close();
        }
    }
}
