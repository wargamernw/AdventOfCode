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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SelectDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Color
        {
            Unset,
            Red,
            White,
            Blue,
            Black
        };

        Color[] solvedColors;
        Color[] selectedColors;

        public MainWindow()
        {
            InitializeComponent();

            solvedColors = new Color[6];

            solvedColors[0] = Color.Red;
            solvedColors[1] = Color.White;
            solvedColors[2] = Color.Blue;
            solvedColors[3] = Color.Unset;
            solvedColors[4] = Color.Unset;
            solvedColors[5] = Color.Unset;

            selectedColors = new Color[6];
            selectedColors[0] = Color.Unset;
            selectedColors[1] = Color.Unset;
            selectedColors[2] = Color.Unset;
            selectedColors[3] = Color.Unset;
            selectedColors[4] = Color.Unset;
            selectedColors[5] = Color.Unset;

            Button1Unset.IsChecked = true;
            Button2Unset.IsChecked = true;
            Button3Unset.IsChecked = true;
            Button4Unset.IsChecked = true;
            Button5Unset.IsChecked = true;
            Button6Unset.IsChecked = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            string rowName = button.Name[6].ToString();
            string colorName = button.Name.Remove(0, 7);

            Color selected;
            Enum.TryParse<Color>(colorName, out selected);

            selectedColors[int.Parse(rowName) - 1] = selected;

            CheckForSuccess();
        }

        void CheckForSuccess()
        {
            Success.Visibility = Visibility.Hidden;

            int i = 0;

            foreach (Color test in solvedColors)
            {
                if (test != selectedColors[i])
                {
                    return;
                }

                i++;
            }

            Success.Visibility = Visibility.Visible;
        }
    }
}
