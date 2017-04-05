using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Drawing;


namespace WpfApplication1.Windows
{
    /// <summary>
    /// Interaction logic for Novi_tip_prozor.xaml
    /// </summary>
    public partial class Novi_tip_prozor : Window
    {
        bool jedinstven = false;

        public Novi_tip_prozor()
        {
            InitializeComponent();
            Uri myUri = new Uri("question-mark.jpg", UriKind.RelativeOrAbsolute);
            JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];

            image.Source = bitmapSource2;
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
                Tip t = new Tip(id_textbox.Text, id_textbox.Text, opis_text_box.Text, image.Source);
                MainWindow.Dodaj_tip(t);
                this.Close();
            }
        }

        private void promena_fokusa(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Sadrzi_tip(id_textbox.Text))
            {
                Error_message.Text = "ID vec postoji";
            }
            else
            {
                Error_message.Text = "";
                jedinstven = true;
            }
        }

       
        private void pronadji_clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

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

                image.Source = bitmapSource2;
            }
            catch
            {     
            }


        }
    }
}
