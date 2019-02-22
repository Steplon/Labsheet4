using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Newtonsoft.Json;

namespace Exercise2_Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> books = new ObservableCollection<Book>();
        ObservableCollection<Book> searchBooks = new ObservableCollection<Book>();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //set listbox and combobox items
            lbxBooks.ItemsSource = books;
            comboBoxFilter.ItemsSource = new string[] { "Horror", "Sci Fi", "Biography", "Fiction", "Educational" };
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Owner = this;
            addBookWindow.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Book deleteBook = lbxBooks.SelectedItem as Book;
            books.Remove(deleteBook);

        }
    }
}
