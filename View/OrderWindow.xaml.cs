using Coffee_Ordering_with_MVVM.Model;
using Coffee_Ordering_with_MVVM.ViewModel.OrderViewModel;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
  
        List<Coffee> coffees { get; set; }
        public OrderWindow(List<Coffee> coffee)
        {
            InitializeComponent();
            this.coffees = coffee; 
        } 
        private void OrderViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            OrderViewModel orderViewModelObject = new OrderViewModel();
            orderViewModelObject.LoadCoffees(coffees);
            OrderViewControl.DataContext = orderViewModelObject;            
        }
    }
}
