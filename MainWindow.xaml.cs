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

            if (File.Exists("osobe.txt"))
            {
                foreach (string red in File.ReadLines("osobe.txt"))
                {
                    string[] polja = red.Split(";");
                    Osobe.Add(new Osoba
                    {
                        Ime = polja[0],
                        Prezime = polja[1],
                        BrojTelefona = polja[2],
                        Email = polja[3]
                    });
                }
            }
            DataContext = new Osoba();
            dgOsoba.ItemsSource = Osobe;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Editor ed = new();
            ed.Owner = this;
            ed.ShowDialog();

            if (ed.DialogResult.HasValue && ed.DialogResult.Value)
            {
                Osobe.Add(ed.DataContext as Osoba);
            }
        }

        private void Brisanje(object sender, RoutedEventArgs e)
        {
            if (!Osobe.Remove(dgOsoba.SelectedItem as Osoba))
            {
                MessageBox.Show("Selektuj nesto brt");
            }
        }

        private void Izmena(object sender, RoutedEventArgs e)
        {
            Editor ed = new();
            ed.Owner = this;
            ed.DataContext = dgOsoba.SelectedItem;
            ed.ShowDialog();
        }

        private void Promena(object sender, SelectionChangedEventArgs e)
        {
            if (dgOsoba.SelectedItem is null)
            {
                dugmeBrisanje.IsEnabled = false;
                dugmeIzmena.IsEnabled = false;
            }
            else
            {
                dugmeBrisanje.IsEnabled = true;
                dugmeIzmena.IsEnabled = true;
            }
        }

        private void Zatvaranje(object sender, EventArgs e)
        {
            if (File.Exists("osobe.txt"))
            {
                File.Delete("osobe.txt");
            }
            Osobe.ToList().ForEach(o => File.AppendAllText("osobe.txt",
                $"{o.Ime};{o.Prezime};{o.BrojTelefona};{o.Email}{Environment.NewLine}"));
        }
    }
}