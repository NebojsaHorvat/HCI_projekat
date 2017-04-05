using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    class Tip
    {
        private string _ime;
        private string _ID;
        private ImageSource _ikonica;
        private string _opis;
        public Tip(string id ,string ime,string opis,ImageSource slika)
        {
            ID = id;
            Ime = ime;
            Opis = opis;
            _ikonica = slika;
        }
        public Tip() { }
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                _ime = value;
            }
        }
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                _opis = value;
            }
        }
        public override string ToString()
        {
            return ID + "-" + Ime;
        }
    }
}
