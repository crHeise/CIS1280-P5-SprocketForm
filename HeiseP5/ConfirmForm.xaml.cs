/*
 * Chris Heise (cheise3@cnm.edu)
 * CIS 1280-R01
 * Program 5: Sprocket Order Form
 * ConfirmForm.xaml.cs
 */

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

namespace HeiseP5
{
    /// <summary>
    /// Interaction logic for ConfirmForm.xaml
    /// </summary>
    public partial class ConfirmForm : Window
    {
        public ConfirmForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
