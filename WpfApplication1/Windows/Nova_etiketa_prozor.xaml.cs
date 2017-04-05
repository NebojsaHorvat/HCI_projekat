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
using System.Windows.Shapes;
using WpfApplication1.Klase;

namespace WpfApplication1.Windows
{
    /// <summary>
    /// Interaction logic for Nova_etiketa_prozor.xaml
    /// </summary>

    public partial class Nova_etiketa_prozor : Window
    {
        bool jedinstven = false;
        private string _opis;
        private Color _color;

        public Nova_etiketa_prozor()
        {
            InitializeComponent();
        }

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            _color = (Color)ClrPcker_Background.SelectedColor;
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
            else
            {
               
                Color boja = (Color)ClrPcker_Background.SelectedColor;
                Etiketa etiketa = new Etiketa(boja, id_textbox.Text, opis_text_box.Text);
                MainWindow.Dodaj_etiketu(etiketa);
                this.Close();
            }


            
            /*      KONVERZIJA BROJA OD 5 CIFARA U INT
            int id_int;

            if (Int32.TryParse(id, out id_int))
            {
                if(id_int >99999 || id_int < 10000 )
                {
                    Error_message.Text = "ID je broj od 5 cifara";
                }
                else if(MainWindow.Sadrzi_etiketu(id_int))
                {
                    Error_message.Text = "ID vec postoji";
                }
                else
                {
                    Etiketa etiketa = new Etiketa(boja, id_int, opis_text_box.Text);
                    MainWindow.Dodaj_etiketu(etiketa);
                    this.Close();
                }
              
            }
            else
            {
                Error_message.Text = "ID sme sadrzati samo cifre";
            }*/

        }



        private void promenjen_fokus(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Sadrzi_etiketu(id_textbox.Text))
            {
                Error_message.Text = "ID vec postoji";
            }
            else
            {
                Error_message.Text = "";
                jedinstven = true;
            }
        }

       


    }
}
