using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AdventOfCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Day1Result { get; set; }
        public string Day1Result2 { get; set; }

        public string Day2Result { get; set; }
        public string Day2Result2 { get; set; }

        public string Day3Result { get; set; }
        public string Day3Result3 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            AdventOfCode.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int optional;
            Day1Result = Day1.ProcessDay1(out optional).ToString();
            OnPropertyChanged("Day1Result");
            Day1Result2 = optional.ToString();
            OnPropertyChanged("Day1Result2");

            Day2Result = Day2.ProcessDay2(out optional).ToString();
            OnPropertyChanged("Day2Result");
            Day2Result2 = optional.ToString();
            OnPropertyChanged("Day2Result2");

            Day3Result = Day3.ProcessDay3(out optional).ToString();
            OnPropertyChanged("Day3Result");
            Day3Result3 = optional.ToString();
            OnPropertyChanged("Day3Result3");
        }
    }
}
