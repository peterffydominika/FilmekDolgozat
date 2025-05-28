using MySql.Data.MySqlClient;
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
    }
}