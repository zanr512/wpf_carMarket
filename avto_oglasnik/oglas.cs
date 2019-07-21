using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace avto_oglasnik
{

    public class Oglas
    {
        public Oglas()
        {

        }

        public string ID { get; set; }

        //Prodajalec
        public string _ime { get; set; }
        public string _priimek { get; set; }
        public string _lokacija { get; set; }
        public string _tel_st { get; set; }

        public List<Komentar> komentarji { get; set; }

        //Oglas
        public string _znamka { get; set; }
        public string _model { get; set; }
        public int _letnik_reg { get; set; }
        public string _mesec_reg { get; set; }
        public string _oblika { get; set; }
        public string _menjalnik { get; set; }
        public string _gorivo { get; set; }
        public int _moc_motorja_KM { get; set; }
        public int _prostornina_motorja { get; set; }
        public int _cena { get; set; }
        public int _prevozeniKm { get; set; }

        //podvozje
        public bool _ALU { get; set; }
        public bool _ABS { get; set; }
        public bool _ESP { get; set; }
        public bool _ABC { get; set; }
        public bool _stiri_kolesni_pogon { get; set; }
        public bool _sportno_podvozje { get; set; }

        //varnost
        public int st_airbagov { get; set; }
        public bool meglenke { get; set; }
        public bool zavorna_luc { get; set; }
        public bool LED_zarometi { get; set; }
        public bool alarm { get; set; }

        //udboje
        public bool rocna_klima { get; set; }
        public bool auto_klima { get; set; }
        public bool dvo_conska { get; set; }
        public bool stiri_coska { get; set; }
        public bool el_pomik_stekel { get; set; }
        public bool centralno_zaklepanje { get; set; }
        public bool keyless_go { get; set; }
        public bool tempomat { get; set; }

        //ostalo
        public bool vlecna_kljuka { get; set; }
        public bool vzratna_kamera { get; set; }
        public bool parkirni_senzorji { get; set; }
        public bool stresne_sani { get; set; }
        public bool bluetooth { get; set; }
        public bool USB { get; set; }
        public bool tv_sprejemnik { get; set; }
        public bool navigacija { get; set; }


        public List<string> slike_oglasa { get; set; }

        public string datumString { get; set; }


        public int datumInt { get; set; }

        public string opis { get; set; }
        public string stanjeV { get; set; }

        public string slika
        {
            get{
                string pot;

                if (this.slike_oglasa.Count == 0)
                    pot = "/Resource/audi1.jpg";
                else
                    pot = this.slike_oglasa[0];

                return pot;
            }
        }

        public string iskanje
        {
            get
            {
                return this._gorivo + " " + this._znamka + " " + this._model;
            }
        }

        public string pomembno
        {
            get
            {
                return "-" + "letnik: " + this._letnik_reg + System.Environment.NewLine + "-" + this._prevozeniKm + " km" + System.Environment.NewLine + "-" + this._gorivo + ", " + this._prostornina_motorja + " ccm, " + this._moc_motorja_KM + " KM" + System.Environment.NewLine + System.Environment.NewLine + "\"" + this.opis + "\"";
            }
        }

        public string znamka_model
        {
            get
            {
                return this._znamka + " " + this._model; 
            }
        }

    }
}
