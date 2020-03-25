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
using System.IO;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;

namespace Imenik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Osoba> listaO = new ObservableCollection<Osoba>();
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("Osobe.dat"))
            {

            BinaryFormatter bf = new BinaryFormatter();
            using(FileStream fs = new FileStream("Osobe.dat", FileMode.Open, FileAccess.Read))
            {
                listaO = bf.Deserialize(fs) as ObservableCollection<Osoba>;
            }
            }

            dg.ItemsSource = listaO;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OsobeEditor oE = new OsobeEditor();
            oE.Owner = this;
            if (oE.ShowDialog()==true)
            {

            listaO.Add(oE.DataContext as Osoba);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                listaO.Remove(dg.SelectedItem as Osoba);
            }
        }

private void Window_Closed(object sender, EventArgs e)
        {
            BinaryFormatter BF = new BinaryFormatter();
            using (FileStream kaFajlu = new FileStream("Osobe.dat", FileMode.Create, FileAccess.Write))
            {
                BF.Serialize(kaFajlu, listaO);
            }
        }
    }
}
