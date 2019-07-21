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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;


namespace avto_oglasnik
{

    /// <summary>
    /// Interaction logic for dodajOglas.xaml
    /// </summary>
    
    public partial class dodajOglas : Window
    {
        public dodajOglas()
        {
            InitializeComponent();
            string[] znamke = new string[] { "Audi", "BMW", "Citroen", "Ford", "Mercedes-Benz", "Opel", "Peugeot", "Renault", "Škoda", "Volkswagen", "Abarth", "AEV", "Aixam", "Alfa Romeo", "Alpine", "Artega", "Aston Martin", "Audi", "Austin", "Autobianchi", "Bentley", "BMW", "Brilliance", "Bugatti", "Buick", "Cadillac", "Chatenet", "Chevrolet", "Chrysler", "Citroen", "Cobra", "Dacia", "Daewoo", "Daihatsu", "DKW", "Dodge", "Donkervoort", "DS Automobiles", "EV", "Ferrari", "Fiat", "Fisker", "Ford", "GMC", "Greatwall", "Grecav", "Honda", "Hummer", "Hyundai", "Infiniti", "Isuzu", "Iveco", "Jaguar", "JDM", "Jeep", "Kia", "KTM", "Lada", "Lamborghini", "Lancia", "LandRover", "LandWind", "Lexus", "Ligier", "Lincoln", "London Taxi", "Lotus", "LuAZ", "Mahindra", "Maruti", "Maserati", "Maybach", "Mazda", "McLaren", "Mercedes-Benz", "MG", "Microcar", "Mini", "Mitsubishi", "Morgan", "Moskvič", "Nissan", "NSU", "Oldsmobile", "Opel", "Peugeot", "Piaggio", "Plymouth", "Pontiac", "Porsche", "Proton", "Puch", "Renault", "Replica", "Rolls-Royce", "Rover", "Saab", "Saturn", "Seat", "Shuanghuan", "Simca", "Smart", "Spyker", "SsangYong", "Subaru", "Suzuki", "Škoda", "Talbot", "Tata", "Tavria", "Tazzari", "Tesla", "Toyota", "Trabant", "Triumph", "TVR", "UAZ", "Vauxhall", "Venturi", "Volga", "Volvo", "Volkswagen", "Wartburg", "Westfield", "Wiesmann", "Zastava" };
            string[] meseci = new string[] { "januar", "februar", "marec", "april", "maj", "junij", "julij", "avgust", "september", "oktober", "november", "december" };
            string[] oblike = new string[] { "Limuzina", "Kombilimuzina", "Karavan", "Enoprostorec", "Coupe", "Cabrio", "SUV", "Pick-up" };
            foreach(string el in znamke)
            {
                znamka.Items.Add(el);
            }
            foreach(string el in meseci)
            {
                meseciCMB.Items.Add(el);
            }
            foreach(string el in oblike)
            {
                oblikaCMB.Items.Add(el);
            }
            for(int i = DateTime.Now.Year; i >= 1970; i--)
            {
                letaCMB.Items.Add(i);
            }

            List<string> seznam_slik = new List<string>();

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rez = System.Windows.MessageBox.Show("Ali si prepričan, da želiš zapreti to okno?", "Delete confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (rez == MessageBoxResult.Yes)
                this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string izpolni = "";
            if (string.IsNullOrWhiteSpace(imeTXT.Text))
                izpolni = izpolni + "\n-ime";
            if (string.IsNullOrWhiteSpace(priimekTXT.Text))
                izpolni = izpolni + "\n-priimek";
            if (string.IsNullOrWhiteSpace(telTXT.Text))
                izpolni = izpolni + "\n-telefonska stevilka";
            if (string.IsNullOrWhiteSpace(lokacijaTXT.Text))
                izpolni = izpolni + "\n-lokacija";
            if (string.IsNullOrWhiteSpace(znamka.Text))
                izpolni = izpolni + "\n-znamka";
            if (string.IsNullOrWhiteSpace(modelTXT.Text))
                izpolni = izpolni + "\n-model";
            if (string.IsNullOrWhiteSpace(letaCMB.Text))
                izpolni = izpolni + "\n-letnik registracije";
            if (string.IsNullOrWhiteSpace(menjalnikCMB.Text))
                izpolni = izpolni + "\n-menjalnik";
            if (string.IsNullOrWhiteSpace(oblikaCMB.Text))
                izpolni = izpolni + "\n-oblika";
            if (string.IsNullOrWhiteSpace(prevozeniTXT.Text))
                izpolni = izpolni + "\n-prevozeni kilometri";
            if (string.IsNullOrWhiteSpace(box.Text))
                izpolni = izpolni + "\n-opis vozila";


            string gorivo = null;
            string stanje = null;

            if (rb1.IsChecked == true)
            {
                gorivo = rb1.Content.ToString();
            }
            else if (rb2.IsChecked == true)
            {
                gorivo = rb2.Content.ToString();
            }
            else if (rb3.IsChecked == true)
            {
                gorivo = rb3.Content.ToString();
            }
            else if (rb4.IsChecked == true)
            {
                gorivo = rb4.Content.ToString();
            }
            else
                izpolni = izpolni + "\n-gorivo";

            if (rb11.IsChecked == true)
            {
                stanje = rb11.Content.ToString();
            }
            else if (rb12.IsChecked == true)
            {
                stanje = rb12.Content.ToString();
            }
            else if (rb13.IsChecked == true)
            {
                stanje = rb13.Content.ToString();
            }
            else if (rb14.IsChecked == true)
            {
                stanje = rb14.Content.ToString();
            }
            else
                izpolni = izpolni + "\n-stanje vozila";


            bool tmp_b = ALU.IsChecked.GetValueOrDefault();

            if (izpolni.Length > 0)
            {
                MessageBox.Show("Izpolni naslednja polja: " + izpolni);
                return;
            }

            



            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);


            int secondsSinceEpoch = (int)t.TotalSeconds;

            string id = secondsSinceEpoch.ToString() + imeTXT.Text + telTXT.Text;

            List<string> slikeList = seznamSlikLB.Items.OfType<string>().ToList();

            List<string> slike = new List<string>();
            

            int cifra = 0;

            if (!System.IO.Directory.Exists(System.IO.Path.GetFullPath(@"..\..\..\") + "\\slikeAvtoOglasnik"))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetFullPath(@"..\..\..\") + "\\slikeAvtoOglasnik");


            foreach (string item in slikeList)
            {
                string novaPot = System.IO.Path.GetFullPath(@"..\..\..\") + "\\slikeAvtoOglasnik\\" + id + cifra + System.IO.Path.GetExtension(item).ToString();
                
                File.Copy(item, novaPot);
                cifra++;
                slike.Add(novaPot);
            }




            Oglas o = new Oglas
            {
                //Prodajalec

                ID = id,

                _ime = imeTXT.Text,
                _priimek = priimekTXT.Text,
                _lokacija = lokacijaTXT.Text,
                _tel_st = telTXT.Text,

                //osnovni podatki
                _znamka = znamka.Text,
                _cena = Int32.Parse(cenaTXT.Text),
                _model = modelTXT.Text,
                _letnik_reg = Convert.ToInt32(letaCMB.Text),
                _mesec_reg = meseciCMB.Text,
                _oblika = oblikaCMB.Text,
                _menjalnik = menjalnikCMB.Text,
                _prevozeniKm = Int32.Parse(prevozeniTXT.Text),
                _gorivo = gorivo,
                //RADIO BUTTON
                _moc_motorja_KM = Int32.Parse(mocTXT.Text),
                _prostornina_motorja = Convert.ToInt32(ccmTXT.Text),

                //PODVOZJE
                _ALU = ALU.IsChecked.GetValueOrDefault(),
                _ABS = ABS.IsChecked.GetValueOrDefault(),
                _ESP = ESP.IsChecked.GetValueOrDefault(),
                _ABC = ABC.IsChecked.GetValueOrDefault(),
                _stiri_kolesni_pogon = stiri_wd.IsChecked.GetValueOrDefault(),
                _sportno_podvozje = sport_podvozje.IsChecked.GetValueOrDefault(),

                //Varnost

                st_airbagov = Convert.ToInt32(st_airbagTXT.Text),
                meglenke = meglenke.IsChecked.GetValueOrDefault(),
                zavorna_luc = zavorna_luc.IsChecked.GetValueOrDefault(),
                LED_zarometi = led_zarometi.IsChecked.GetValueOrDefault(),
                alarm = alarmna_naprava.IsChecked.GetValueOrDefault(),

                //Udobje
                rocna_klima = rocnaKlima.IsChecked.GetValueOrDefault(),
                auto_klima = avtoKlima.IsChecked.GetValueOrDefault(),
                dvo_conska = dvaconska.IsChecked.GetValueOrDefault(),
                stiri_coska = stiriconska.IsChecked.GetValueOrDefault(),
                el_pomik_stekel = elPomik.IsChecked.GetValueOrDefault(),
                centralno_zaklepanje = elPomik.IsChecked.GetValueOrDefault(),
                keyless_go = keyless.IsChecked.GetValueOrDefault(),
                tempomat = tempo.IsChecked.GetValueOrDefault(),

                //Ostala oprema
                vlecna_kljuka = vlecna.IsChecked.GetValueOrDefault(),
                vzratna_kamera = vzratna.IsChecked.GetValueOrDefault(),
                parkirni_senzorji = senzor.IsChecked.GetValueOrDefault(),
                stresne_sani = sani.IsChecked.GetValueOrDefault(),
                bluetooth = bt.IsChecked.GetValueOrDefault(),
                USB = usb.IsChecked.GetValueOrDefault(),
                tv_sprejemnik = tv.IsChecked.GetValueOrDefault(),
                navigacija = gps.IsChecked.GetValueOrDefault(),



                slike_oglasa = slike,

                stanjeV = stanje,

                datumString = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(),
                datumInt = secondsSinceEpoch,

                opis = box.Text,
                komentarji = new List<Komentar>()


            };


            MainWindow m = new MainWindow();

            m.temp = o;

            m.Close();


            this.Close();

        }

        private void stevilkeMetoda(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void dodajSlikoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(openFileDialog.ShowDialog() == true)
            {
                dodajSliko.Source = new BitmapImage(new Uri(@openFileDialog.FileName.ToString()));
                seznamSlikLB.Items.Add(openFileDialog.FileName.ToString());
            }

        }

        private void seznamSlikLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp = null;
            //MessageBox.Show(e.AddedItems[0].ToString());
            if (e.AddedItems.Count > 0)
            {
                tmp = e.AddedItems[0].ToString();
                dodajSliko.Source = new BitmapImage(new Uri(@tmp));
            }
            else
                dodajSliko.Source = null;
            
        }

        private void zbrisiSliko_Click(object sender, RoutedEventArgs e)
        {
            dodajSliko.Source = null;
            seznamSlikLB.Items.Remove(seznamSlikLB.SelectedItem);
        }
    }
}
