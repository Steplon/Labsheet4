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

namespace Exercise2_Books
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow(string[] categories)
        {
            InitializeComponent();
            comboBoxCategory.ItemsSource = categories;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //get values from inputs
            string name = textBoxName.Text;
            decimal price = Convert.ToDecimal(textBoxPrice.Text);
            DateTime date = dpReleaseDate.SelectedDate.Value;
            string category = comboBoxCategory.SelectedItem as string;

            //create book object
            Book newBook = new Book(name, price, date, category);

            //get reference to main window
            MainWindow main = Owner as MainWindow;

            //add to collection
            main.books.Add(newBook);

            //close window
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //close window
            this.Close();
        }
    }
}
