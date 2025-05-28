using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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

namespace FilmekDolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection kapcs = new MySqlConnection("server = srv1.tarhely.pro;database = v2labgwj_12a; uid =v2labgwj_12a; password = 'HASnEeKvbDEPGgvTZubG';");
        List<Film> filmek = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Lekerdez_Click(object sender, RoutedEventArgs e){
                    kapcs.Open();
                    var lekerdezes = new MySqlCommand("SELECT * FROM peterffyd_filmek", kapcs).ExecuteReader();
                    dgAdatok.ItemsSource = filmek;
                    while (lekerdezes.Read())
                    {
                        var film = new Film(lekerdezes["filmazon"].ToString(), lekerdezes["cim"].ToString(), Convert.ToInt32(lekerdezes["ev"]), lekerdezes["szines"].ToString(), lekerdezes["mufaj"].ToString(), Convert.ToInt32(lekerdezes["hossz"]));
                        filmek.Add(film);
                    }
                    kapcs.Close();
                }
        private void dgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbFilmAzon.Content = ((Film)dgAdatok.SelectedItem).Filmazon;
            tb1.Text = ((Film)dgAdatok.SelectedItem).Cim;
            tb2.Text = ((Film)dgAdatok.SelectedItem).Ev.ToString();
            tb3.Text = ((Film)dgAdatok.SelectedItem).Szines;
            tb4.Text = ((Film)dgAdatok.SelectedItem).Mufaj;
            tb5.Text = ((Film)dgAdatok.SelectedItem).Hossz.ToString();
        }

        private void modosit_Click(object sender, RoutedEventArgs e)
        {
            kapcs.Open();
            new MySqlCommand($"UPDATE peterffyd_filmek SET cim = '{tb1.Text}', ev = { tb2.Text }, szines = '{tb3.Text}', mufaj = '{tb4.Text}', hossz = { tb5.Text} where filmazon = '{lbFilmAzon.Content}'", kapcs).ExecuteNonQuery();
            kapcs.Close();
            dgAdatok.Items.Refresh();
        }
    }
}