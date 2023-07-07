/*
 * Chris Heise (cheise3@cnm.edu)
 * CIS 1280-R01
 * Program 5: Sprocket Order Form
 * SprocketForm.xaml.cs
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
    /// Interaction logic for SprocketForm.xaml
    /// </summary>
    public partial class SprocketForm : Window
    {
        private Sprocket sprocket;

        public Sprocket Sprocket
        {
            get { return sprocket; }
            set { sprocket = value; }
        }

        public SprocketForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txbItemId.Text);
                int teeth = int.Parse(txbNumTeeth.Text);
                int items = int.Parse(txbNumItems.Text);

                int materialIndex = cbItemType.SelectedIndex;
                switch (materialIndex)
                {
                    case 0:
                        sprocket = new SteelSprocket(id, items, teeth);
                        break;
                    case 1:
                        sprocket = new AluminumSprocket(id, items, teeth);
                        break;
                    case 2:
                        sprocket = new PlasticSprocket(id, items, teeth);
                        break;
                }

                DialogResult = true;
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void FillComboBox()
        {
            cbItemType.Items.Add("Steel");
            cbItemType.Items.Add("Aluminum");
            cbItemType.Items.Add("Plastic");
            cbItemType.SelectedIndex = 0;
        }
    }
}
