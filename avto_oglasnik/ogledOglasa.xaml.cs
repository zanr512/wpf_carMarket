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
using System.Collections.ObjectModel;

namespace avto_oglasnik
{
    /// <summary>
    /// Interaction logic for ogledOglasa.xaml
    /// </summary>
    public partial class ogledOglasa : Window
    {
        Oglas prikazi;
        List<Komentar> komentarji = new List<Komentar>();

        ObservableCollection<Komentar> seznam_komentarjev = new ObservableCollection<Komentar>();

        public ogledOglasa(Oglas sprejet, List<Komentar> comment)
        {
            InitializeComponent();
            komentarji = comment;

            seznam_komentarjev = new ObservableCollection<Komentar>(komentarji);

            prikazi = sprejet;

            komentarji_list.ItemsSource = seznam_komentarjev;

            if (sprejet.slika != "/Resource/audi1.jpg")
                slikaVozika.Source = new BitmapImage(new Uri(prikazi.slika));

            naslovTxt.Content = prikazi._znamka + " " + prikazi._model;

            telSTtxt.Content = prikazi._tel_st;
            prodInfoTxt.Content = prikazi._ime + " " + prikazi._priimek;
            locTxt.Content = prikazi._lokacija;

            regTxt.Content = prikazi._mesec_reg + " " + prikazi._letnik_reg;
            starTxt.Content = prikazi.stanjeV;
            kmTxt.Content = prikazi._prevozeniKm;
            gorivoTxt.Content = prikazi._gorivo;
            ccmTxt.Content = prikazi._prostornina_motorja + " ccm";
            mocTxt.Content = prikazi._moc_motorja_KM + " KM";
            menjTxt.Content = prikazi._menjalnik;
            oblikaTxt.Content = prikazi._oblika;
            cenaZgoraj.Content = prikazi._cena + "€";


            string content = null;


            if(prikazi._ALU)
            {
                content = "- ALU platišča";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });

            }
            if (prikazi._ABS)
            {
                content = "- zavorni sistem ABS";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi._ESP)
            {
                content = "- ESP elektronski porgram stabilnosti";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi._ABC)
            {
                content = "- Active Body System";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if(prikazi._stiri_kolesni_pogon)
            {
                content = "- štirikolesni pogon (4WD)";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi._sportno_podvozje)
            {
                content = "- športno podvozje";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }




            content = "- " + prikazi.st_airbagov + " x zračna vreča / Airbag";
            ostalo.Children.Add(new Label{
                Content = content,
                FontWeight = FontWeights.Bold
            });
            if (prikazi.meglenke)
            {
                content = "- meglenke";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.zavorna_luc)
            {
                content = "- 3. zavorna luč";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi._stiri_kolesni_pogon)
            {
                content = "- štirikolesni pogon (4WD)";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.LED_zarometi)
            {
                content = "- LED žarometi";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.alarm)
            {
                content = "- alarmna naprava";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }



            if (prikazi.rocna_klima)
            {
                content = "- klimatska naprava: ročna";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.auto_klima)
            {
                content = "- klimatska naprava: avtomatska";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.dvo_conska)
            {
                content = "- klimatska naprava: 2 conska";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.stiri_coska)
            {
                content = "- klimatska naprava: 4 conska";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.el_pomik_stekel)
            {
                content = "- elektronski pomik stekel";
                ostalo.Children.Add(new Label{
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.centralno_zaklepanje)
            {
                content = "- centralno zaklepanje";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.keyless_go)
            {
                content = "- KeyLess GO";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.tempomat)
            {
                content = "- tempomat";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }



            if (prikazi.vlecna_kljuka)
            {
                content = "- vlečna kljuka";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.vzratna_kamera)
            {
                content = "- vzratna kamera";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.parkirni_senzorji)
            {
                content = "- parkirni senzorji";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.stresne_sani)
            {
                content = "- strešne sani";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.bluetooth)
            {
                content = "- Bluetooth vmesnik";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.USB)
            {
                content = "- USB vmesnik";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.tv_sprejemnik)
            {
                content = "- TV sprejemnik";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }
            if (prikazi.navigacija)
            {
                content = "- GPS navigacija";
                ostalo.Children.Add(new Label
                {
                    Content = content,
                    FontWeight = FontWeights.Bold
                });
            }

            cenaTxt.Content = prikazi._cena + " €";

            oglasP.Text = prikazi.opis;



            if (sprejet.slike_oglasa.Count == 0)
                slikeTab.IsEnabled = false;
            else
            {
                foreach (string item in sprejet.slike_oglasa)
                {
                    slikeStackPanel.Children.Add(new System.Windows.Controls.Image
                    {
                        Source = new BitmapImage(new Uri(item)),
                        Width = double.NaN,
                        MaxWidth = 860
                    });
                }
            }

            


            
        }

        private void cmt_onGetKomentar(object sender, Komentar kmt)
        {
            seznam_komentarjev.Add(kmt);
        }

        private void Window_Closed(object sender, EventArgs e)
        {

            MainWindow m = new MainWindow();


            m.kom_class = seznam_komentarjev.ToList<Komentar>();

            m.Close();


            this.Close();
        }
    }
}
