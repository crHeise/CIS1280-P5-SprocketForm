/*
 * Chris Heise (cheise3@cnm.edu)
 * CIS 1280-R01
 * Program 5: Sprocket Order Form
 * SprocketOrderForm.xaml.cs
 */

using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HeiseP5
{
    /// <summary>
    /// Interaction logic for SprocketOrderForm.xaml
    /// </summary>
    public partial class SprocketOrderForm : Window
    {
        SprocketOrder order = new SprocketOrder();

        public SprocketOrderForm()
        {
            InitializeComponent();
            lbSprockets.ItemsSource = order.Sprockets;
        }

        private void cbLocal_Checked(object sender, RoutedEventArgs e)
        {
            //Disable address fields
            ChangeAdressStatus(false);
        }

        private void cbLocal_Unchecked(object sender, RoutedEventArgs e)
        {
            //Enable address fields
            ChangeAdressStatus(true);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SprocketForm sprocketForm = new SprocketForm();

            bool? result = sprocketForm.ShowDialog();

            if(result == true)
            {
                order.Add(sprocketForm.Sprocket);
                lbSprockets.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Add Sprocket Cancelled");
            }

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ConfirmForm confirm = new ConfirmForm();

            bool? result = confirm.ShowDialog();

            if(result == true)
            {
                order.Remove(lbSprockets.SelectedItem as Sprocket);
                lbSprockets.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Sprocket Removal Cancelled");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Add customer info into order
                order.CustName = txbCustName.Text;
                if (cbLocal.IsChecked == false)
                {
                    order.CustAddress.Street = txbStreet.Text;
                    order.CustAddress.City = txbCity.Text;
                    order.CustAddress.State = txbState.Text;
                    order.CustAddress.ZipCode = txbZip.Text;
                }
                else
                {
                    order.CustAddress = null;
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == true)
                {
                    using (StreamWriter file = new StreamWriter(saveFile.OpenFile()))
                    {
                        file.WriteLine(order.ToString());

                        foreach (var sprocket in order.Sprockets)
                        {
                            file.WriteLine(sprocket.ToString());
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        private void ChangeAdressStatus (bool bEnabled)
        {
            lblStreet.IsEnabled = bEnabled;
            txbStreet.IsEnabled = bEnabled;
            lblCity.IsEnabled = bEnabled;
            txbCity.IsEnabled = bEnabled;
            lblState.IsEnabled = bEnabled;
            txbState.IsEnabled = bEnabled;
            lblZip.IsEnabled = bEnabled;
            txbZip.IsEnabled = bEnabled;
        }
    }
}
