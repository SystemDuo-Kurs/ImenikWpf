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

namespace ImenikWpf
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Editor()
        {
            InitializeComponent();
            DataContext = new Osoba();
            BindingGroup = new();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if (BindingGroup.UpdateSources())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Greeeska!");
            }
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}