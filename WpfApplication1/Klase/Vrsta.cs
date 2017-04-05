using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Klase
{
    class Vrsta
    {
        string id, ime, opis, turisticki_status, datum;
        double prihod_od_turizma;
        Tip tip;
        Etiketa etiketa;
        bool opasna_za_ljude, crvena_lista, naseljeni_region;
        
        public Vrsta(string id_,string ime_,string opis_,string ts,string dat,double prihod,Tip t,Etiketa e,bool ozlj,bool cl,bool nr)
        {
            id = id_;
            ime = ime_;
            opis = opis_;
            turisticki_status = ts;
            datum = dat;
            prihod_od_turizma = prihod;
            tip = t;
            etiketa = e;
            opasna_za_ljude = ozlj;
            crvena_lista = cl;
            naseljeni_region = nr;
        }
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
