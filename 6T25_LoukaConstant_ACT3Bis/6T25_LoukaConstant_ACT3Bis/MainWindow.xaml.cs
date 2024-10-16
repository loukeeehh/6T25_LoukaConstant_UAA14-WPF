using System.IO.Packaging;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6T25_LoukaConstant_ACT3Bis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CalendarDateRange blackoutDays = new CalendarDateRange(new DateTime(0001, 01, 01), DateTime.Now.AddDays(-1));
            date_arrivee.BlackoutDates.Add(blackoutDays);
            date_arrivee.SelectedDate = DateTime.Now;
            date_arrivee.CalendarClosed += new RoutedEventHandler(SelectDateChangeEvent);
            date_sortie.BlackoutDates.Add(blackoutDays);
            btn_duree.Click += new RoutedEventHandler(btn_duree_Click);
        }


        public void btn_duree_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan semaines = date_sortie.SelectedDate.Value - date_arrivee.SelectedDate.Value;
            semaine.Text = (semaines.Days / 7).ToString();

        }

        public void SelectDateChangeEvent(object sender, RoutedEventArgs e) 
        {
            CalendarDateRange blackoutDays = new CalendarDateRange(new DateTime(0001, 01, 01), date_arrivee.SelectedDate.Value.Date);
            date_sortie.BlackoutDates.Clear();
            date_sortie.BlackoutDates.Add(blackoutDays);
        }

        
    }
}