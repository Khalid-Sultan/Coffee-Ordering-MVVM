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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Coffee_Ordering_with_MVVM.Model;

namespace Coffee_Ordering_with_MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        double pbt;
        double tax = 0.00, total = 0.00;
        List<Coffee> coffees;
        public OrderView()
        {
            this.coffees = new List<Coffee>();
            InitializeComponent();
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            Coffee coffee = new Coffee
            {
                beanSelection = (BeanSelection)bean.SelectedIndex,
                iceSelection = (IceSelection)ice.SelectedIndex,
                condimentType = (CondimentType)condiment.SelectedIndex,
                creamSelection = (CreamSelection)cream.SelectedIndex,
                sizeSelection = (SizeSelection)size.SelectedIndex,
                price = 10.0+
                ((int)bean.SelectedIndex) * 2.5 +
                ((int)ice.SelectedIndex) * 1.25 +
                ((int)condiment.SelectedIndex) * 2 +
                ((int)cream.SelectedIndex) * 2.25 +
                ((int)size.SelectedIndex) * 1.75
            };
            coffees.Add(coffee);
            addToCurrentOrder($"Order #{coffees.Count} \t Price  = {coffee.price} Br.", coffee.price);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grid grid = this.Parent as Grid;
            Window window = grid.Parent as Window;
            grid.Children.Remove(this);
            MainView mainView = new MainView(coffees);
            mainView.Show();
            window.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentOrder.Children.RemoveRange(0, coffees.Count);
            coffees = new List<Coffee>();
            pbt = 0;
            tax = 0.00;
            total = 0.00;
            pbtOrder.Content = $"PBT : {pbt} Br.";
            taxOrder.Content = $"Tax : {tax} Br.";
            totalOrder.Content = $"Total : {total} Br.";
        }
        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = this.Parent as Grid;
            Window window = grid.Parent as Window;
            grid.Children.Remove(this);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }
        private void addToCurrentOrder(String order, double price)
        {
            Label label = new Label();
            label.Content = order;
            label.Foreground = System.Windows.Media.Brushes.White;
            pbt += price;
            tax = 0.15 * pbt;
            total = pbt + tax;
            pbtOrder.Content = $"PBT : {pbt} Br.";
            taxOrder.Content = $"Tax : {tax} Br.";
            totalOrder.Content = $"Total : {total} Br.";
            currentOrder.Children.Insert(currentOrder.Children.Count - 3, label);
        }
    }
}
