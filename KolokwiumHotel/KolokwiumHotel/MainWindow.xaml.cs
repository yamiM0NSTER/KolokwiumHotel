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
using System.Globalization;

namespace KolokwiumHotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hotel hotel;

        public MainWindow()
        {
            InitializeComponent();
            hotel = new Hotel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Informacje.Text = hotel.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                hotel.UstawDate(DateTime.ParseExact(dataRezerwacji.Text, "yyyy-MM-dd", provider));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Podaj poprawną datę");
                return;
            }

            if (hotel.SprawdzDate(DateTime.Now))
            {
                dataRezerwBtn.Visibility = Visibility.Hidden;
                text1.Visibility = Visibility.Hidden;
                dataRezerwacji.Visibility = Visibility.Hidden;
                dodajRezerwacjebtn.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Data musi być późniejsza od systemowej");
                return;
            }

            pokazRezerwacjeBtn.IsEnabled = true;
            dataRezerwacjiBtn.IsEnabled = false;
        }

        private void dodajRezerwacjebtn_Click(object sender, RoutedEventArgs e)
        {
            text2.Visibility = Visibility.Visible;
            text3.Visibility = Visibility.Visible;
            text4.Visibility = Visibility.Visible;
            text5.Visibility = Visibility.Visible;
            imie.Visibility = Visibility.Visible;
            nazwisko.Visibility = Visibility.Visible;
            nr.Visibility = Visibility.Visible;
            cena.Visibility = Visibility.Visible;
            addRezerwBtn.Visibility = Visibility.Visible;
        }

        private void addRezerwBtn_Click(object sender, RoutedEventArgs e)
        {
            if (imie.Text.Length == 0 || nazwisko.Text.Length == 0 || nr.Text.Length == 0 || cena.Text.Length == 0)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione");
                return;
            }

            int numer = 0;
            try
            {
                numer = Int32.Parse(nr.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Numer musi być liczbą");
                return;
            }
            if( numer < 1 )
            {
                MessageBox.Show("Numer musi być liczbą dodatnią");
                return;
            }

            double cenad = 0;
            try
            {
                cenad = double.Parse(cena.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cena musi być liczbą rzeczywistą");
                return;
            }
            if (cenad <= 0)
            {
                MessageBox.Show("Cena musi być liczbą dodatnią");
                return;
            }

            hotel.DodajRezerwacje(imie.Text, nazwisko.Text, numer, cenad);
            usunRezerwacjeBtn.IsEnabled = true;
            wyczyscRezerwacjeBtn.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hotel.OdwolajRezerwacje();
            usunRezerwacjeBtn.IsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            hotel.OdwolajWszystkieRezerwacje();
            wyczyscRezerwacjeBtn.IsEnabled = false;
            dataRezerwacjiBtn.IsEnabled = true;
            dodajRezerwacjebtn.IsEnabled = false;
            text2.Visibility = Visibility.Hidden;
            text3.Visibility = Visibility.Hidden;
            text4.Visibility = Visibility.Hidden;
            text5.Visibility = Visibility.Hidden;
            imie.Visibility = Visibility.Hidden;
            nazwisko.Visibility = Visibility.Hidden;
            nr.Visibility = Visibility.Hidden;
            cena.Visibility = Visibility.Hidden;
            addRezerwBtn.Visibility = Visibility.Hidden;
            pokazRezerwacjeBtn.IsEnabled = false;
            Informacje.Text = "Wszystko zostało wyczyszczone.";
            usunRezerwacjeBtn.IsEnabled = false;
        }

        private void dataRezerwacjiBtn_Click(object sender, RoutedEventArgs e)
        {
            dataRezerwBtn.Visibility = Visibility.Visible;
            text1.Visibility = Visibility.Visible;
            dataRezerwacji.Visibility = Visibility.Visible;
        }

    }
}
