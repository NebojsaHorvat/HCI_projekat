using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WpfApplication1.Klase;

namespace WpfApplication1.Windows
{
    /// <summary>
    /// Interaction logic for New_species_window.xaml
    /// </summary>
    public partial class New_species_window : Window, INotifyPropertyChanged
    {
        bool jedinstven = false;
        bool ime_bool = false;
        double prihod;
        bool prihod_bool=false;
        ImageSource slika;

        internal ObservableCollection<string> Tipovi
        {
            get;
            set;
        }
        public New_species_window()
        {
            InitializeComponent();
            this.DataContext = this;
            Tipovi = new ObservableCollection<string> 
            {
                "test 1", 
                "test 2"
            };
            
            MainWindow.tipovi_lista(Tipovi);
            slika = Ikonica.Source;

        }
        
        private void Odustani_clicked(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_clicked(object sender, RoutedEventArgs e)
        {
            if (id_textbox.Text == "")
            {
                Error_message.Text = "ID ne sme ostati prazan";
            }
            else if (!jedinstven)
            {
                Error_message.Text = "ID vec postoji";
            }
            else if (prihod_textbox.Text.Equals(""))
            {
                Error_prihod.Text = "Polje za prihod mora biti popunjeno";
            }
            else if(! prihod_bool)
            {
                Error_prihod.Text = "Prihod sme sadrzati samo cifre";
            }
            
            else if(ime_text_box.Text == "")
            {
                Error_ime.Text = "Polje za ime mora biti popunjeno";
            }
            else if(ime_bool && prihod_bool && jedinstven )
            {
                Tip t = new Tip();
                Etiketa et = new Etiketa();
                
                Vrsta v = new Vrsta(id_textbox.Text, ime_text_box.Text, opis_text_box.Text, (string)turisticki_status_cb.SelectionBoxItem, datum_b.SelectedDate.ToString(), prihod, t, et, Opasna_za_ljude_da.IsChecked.Value, crvena_lista_da.IsChecked.Value, naseljen_region_da.IsChecked.Value);
                MainWindow.Dodaj_vrstu( v);
                this.Close();
            }

        }

        private void promenjen_fokus(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Sadrzi_vrstu(id_textbox.Text))
            {
                Error_message.Text = "ID vec postoji";
            }
            else
            {
                Error_message.Text = "";
                jedinstven = true;
            }
        }

        private void dodaj_tip_clicked(object sender, RoutedEventArgs e)
        {
            var novi_tip_prozor = new WpfApplication1.Windows.Novi_tip_prozor();
            novi_tip_prozor.Show();
        }

        private void dodaj_etiketu_clicked(object sender, RoutedEventArgs e)
        {
            var nova_etiketa_prozor = new WpfApplication1.Windows.Nova_etiketa_prozor();
            nova_etiketa_prozor.Show();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
            string prihods=prihod_textbox.Text;
            if (Double.TryParse(prihods, out prihod))
            {
                prihod_bool = true;
                Error_prihod.Text = "";
            }
            else
            {
                prihod_bool = false;
                Error_prihod.Text = "Prihod sme sadrzati samo cifre";
            }
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if(Char.IsLetter(ime_text_box.Text[0]) )
            {
                ime_bool = true;
                Error_ime.Text = "";
            }
            else
            {
                Error_ime.Text = "Ime sme da pocne samo slovom";
                ime_bool = true;
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        private void pronadji_ikonicu_clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";

            try
            {

                open.ShowDialog();
                /*// display image in picture box
                image = new BitmapImage();
                image.Source = new BitmapImage(open.FileName);
                // image file path
                //textBox1.Text = open.FileName;
                * */
                Uri myUri = new Uri(open.FileName, UriKind.RelativeOrAbsolute);
                JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource2 = decoder2.Frames[0];

                slika = bitmapSource2;
                Ikonica.Source = bitmapSource2;
            }
            catch { }
        }

    }
}
