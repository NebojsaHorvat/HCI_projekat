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
using WpfApplication1.Klase;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static  Dictionary<string,Tip> tipovi;
        private static  Dictionary<string, Etiketa> etikete;
        private static Dictionary<string, Vrsta> vrste;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            tipovi = new Dictionary<string,Tip>();
            etikete = new Dictionary<string, Etiketa>();
            vrste = new Dictionary<string, Vrsta>();

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(@"../../Images/world-map.jpg", UriKind.Relative));
            kanvas.Background = imageBrush;
            
        }

        internal static void  Dodaj_etiketu(Etiketa e)
        {
            etikete.Add(e.ID,e);
        }
        internal static bool Sadrzi_etiketu(string id)
        {
            return etikete.ContainsKey(id);
        }
        internal static void Dodaj_tip(Tip t)
        {
            tipovi.Add(t.ID, t);
        }
        internal static bool Sadrzi_tip(string id)
        {
            return tipovi.ContainsKey(id);
        }
        internal static void Dodaj_vrstu(Vrsta v)
        {
            vrste.Add(v.ID, v);
        }
        internal static bool Sadrzi_vrstu(string id)
        {
            return vrste.ContainsKey(id);
        }

        private void new_species_clicked(object sender, RoutedEventArgs e)
        {
            var new_species_window = new WpfApplication1.Windows.New_species_window();
            new_species_window.Show();
            
        }

        private void Novi_tip_clicked(object sender, RoutedEventArgs e)
        {
            var novi_tip_prozor = new WpfApplication1.Windows.Novi_tip_prozor();
            novi_tip_prozor.Show();
        }

        private void Nova_etiketa_clicked(object sender, RoutedEventArgs e)
        {
            var nova_etiketa_prozor = new WpfApplication1.Windows.Nova_etiketa_prozor();
            nova_etiketa_prozor.Show();
        }

        internal static void tipovi_lista(System.Collections.ObjectModel.ObservableCollection<string> o_tipovi)
        {
            foreach(var t in tipovi)
            {
                o_tipovi.Add(t.Key);
            }
        }
    }
}
