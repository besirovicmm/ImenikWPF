using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Imenik
{
    /// <summary>
    /// Interaction logic for OsobeEditor.xaml
    /// </summary>
    public partial class OsobeEditor : Window
    {
        public OsobeEditor()
        {
            InitializeComponent();
            DataContext = new Osoba();
            BindingGroup = new BindingGroup();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BindingGroup.CommitEdit())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            Close();

        }
    }
}
