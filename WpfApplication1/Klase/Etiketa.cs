using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1.Klase
{
   
    class Etiketa
    {
        private Color _boja;
        private string _ID;
        private string _opis;
        
       public Etiketa(Color color,string id,string opis)
        {
            _boja = color;
            _ID = id;
            _opis = opis;
        }
        public Etiketa() { }

        public Color Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                _boja = value;
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


    }
}
