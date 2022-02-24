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

namespace ImenikWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Osoba> Osobe { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            //while (true)
            // {
            //     Osobe.Add(new Osoba { Ime = "asdasd", Prezime = "asdasd" });
            //}
            DataContext = new Osoba();
            dgOsoba.ItemsSource = Osobe;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Osobe.Add(DataContext as Osoba);
            DataContext = new Osoba();
        }
    }
}