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
using System.Data;

namespace H10ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
      string TaulunNimi;
      string Yhteysmerkkijono;
      string messu;

    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //TODO täytetään combobox asiakkaitten maitten nimillä
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
        Yhteysmerkkijono = JAMK.ICT.Properties.Settings.Default.Tietokanta;
        lbMessages.Content = Yhteysmerkkijono;
      TaulunNimi = JAMK.ICT.Properties.Settings.Default.taulu;
      cbCountries.ItemsSource = JAMK.ICT.Data.DBPlacebo.GetCitiesOfCustomersFromSQLServer(Yhteysmerkkijono, TaulunNimi).AsDataView();
      cbCountries.DisplayMemberPath = "city";
    }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
        DataTable asiakkaat = JAMK.ICT.Data.DBPlacebo.GetTestCustomers();
        dgCustomers.ItemsSource = asiakkaat.AsDataView();
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
        
        DataTable asiakkaat = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(Yhteysmerkkijono,TaulunNimi,out messu);
        dgCustomers.ItemsSource = asiakkaat.AsDataView();
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
      //TODO
    }
  }
}
