using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        string[] categories = new string[] { "Horror", "Sci Fi", "Biography", "Fiction", "Educational" };

        public MainWindow()
        {
            InitializeComponent();
            Array.Sort(categories);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //set listbox and combobox items
            lbxBooks.ItemsSource = books;
            comboBoxFilter.ItemsSource = categories;

            //load json file
            LoadJsonFile();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //create new window object
            AddBookWindow addBookWindow = new AddBookWindow(categories);

            //set new window objects owner as main window
            addBookWindow.Owner = this;

            //show the window and block controls on mainwindow
            addBookWindow.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //get the selected book and delete from books list
            Book deleteBook = lbxBooks.SelectedItem as Book;
            books.Remove(deleteBook);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //create a sting in JSON format using the books collection
            string json = JsonConvert.SerializeObject(books,Formatting.Indented);

            if (!String.IsNullOrEmpty(json))
            {
                //create stream writer object
                using (StreamWriter sw = new StreamWriter(@"d:\temp\books.json"))
                {
                    //write to file
                    sw.Write(json);
                }
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadJsonFile();
        }

        private void LoadJsonFile()
        {
            //create a stream reader to read the json file
            using (StreamReader sr = new StreamReader(@"d:\temp\books.json"))
            {
                //read the file into a string
                string json = sr.ReadToEnd();

                //deserialize json text into objects
                books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);

                //refresh the display
                lbxBooks.ItemsSource = books;

            }
        }

        private void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            lbxBooks.ItemsSource = books;
        }

        private void ComboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check the value selected
            string selected = comboBoxFilter.SelectedValue as string;

            //clear search collection
            searchBooks.Clear();

            //check if null
            if (!String.IsNullOrEmpty(selected))
            {
                //iterate through books for matches
                foreach (Book b in books)
                {
                    //check matches
                    if (b.Category.ToLower() == selected.ToLower())
                    {
                        //add matches to search collection
                        searchBooks.Add(b);
                    }
                }
                //display search collection
                lbxBooks.ItemsSource = searchBooks;
            }
        }

        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //check the value selected
            string selected = tbxSearch.Text;

            //clear search collection
            searchBooks.Clear();

            //check if null
            if (!String.IsNullOrEmpty(selected))
            {
                //iterate through books for matches
                foreach (Book b in books)
                {
                    //check matches on category or name
                    if (b.Category.ToLower() == selected.ToLower() || b.Name.ToLower() == selected.ToLower())
                    {
                        //add matches to search collection
                        searchBooks.Add(b);
                    }
                }
                //display search collection
                lbxBooks.ItemsSource = searchBooks;
            }
        }
    }
}
