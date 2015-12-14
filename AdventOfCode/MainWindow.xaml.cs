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
        public string Day3Result2 { get; set; }

        public string Day4Result { get; set; }
        public string Day4Result2 { get; set; }

        public string Day5Result { get; set; }
        public string Day5Result2 { get; set; }

        public string Day6Result { get; set; }
        public string Day6Result2 { get; set; }

        public string Day7Result { get; set; }
        public string Day7Result2 { get; set; }

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
            Button1_Click(sender, e);
            Button2_Click(sender, e);
            Button3_Click(sender, e);
            Button4_Click(sender, e);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int optional;
            Day1Result = Day1.ProcessDay1(out optional).ToString();
            OnPropertyChanged("Day1Result");
            Day1Result2 = optional.ToString();
            OnPropertyChanged("Day1Result2");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int optional;
            Day2Result = Day2.ProcessDay2(out optional).ToString();
            OnPropertyChanged("Day2Result");
            Day2Result2 = optional.ToString();
            OnPropertyChanged("Day2Result2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            int optional;
            Day3Result = Day3.ProcessDay3(out optional).ToString();
            OnPropertyChanged("Day3Result");
            Day3Result2 = optional.ToString();
            OnPropertyChanged("Day3Result2");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            long optional;
            Day4Result = Day4.ProcessDay4(out optional).ToString();
            OnPropertyChanged("Day4Result");
            Day4Result2 = optional.ToString();
            OnPropertyChanged("Day4Result2");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            int optional;
            Day5Result = Day5.ProcessDay5(out optional).ToString();
            OnPropertyChanged("Day5Result");
            Day5Result2 = optional.ToString();
            OnPropertyChanged("Day5Result2");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            long optional;
            Day6Result = Day6.ProcessDay6(out optional).ToString();
            OnPropertyChanged("Day6Result");
            Day6Result2 = optional.ToString();
            OnPropertyChanged("Day6Result2");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            long optional;
            Day7Result = Day7.ProcessDay7(out optional).ToString();
            OnPropertyChanged("Day7Result");
            Day7Result2 = optional.ToString();
            OnPropertyChanged("Day7Result2");
        }
    }
}
