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

namespace avto_oglasnik
{
    /// <summary>
    /// Interaction logic for komentar.xaml
    /// </summary>
    public partial class komentar : UserControl
    {
        public delegate void GetKomentar(object sender, Komentar kmt);
        public event GetKomentar onGetKomentar;

        public komentar()
        {
            InitializeComponent();
        }

        private void emoji_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string emojiS = (emoji.SelectedItem as ListBoxItem).Content.ToString();
            komentarTxt.Text = komentarTxt.Text.Insert(komentarTxt.CaretIndex, emojiS);
        }

        private void objavi_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(vzdevekT.Text))
            {
                MessageBox.Show("Prosim vnesi vzdevek!", "Opozorilo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (String.IsNullOrEmpty(komentarTxt.Text))
            {
                MessageBox.Show("Prosim vnesi komentar!", "Opozorilo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }


            if (onGetKomentar != null)
            {
                Komentar tmp = new Komentar
                {
                    Vzdevek = vzdevekT.Text,
                    Komentar_t = komentarTxt.Text,
                    Datum = DateTime.Now.ToString()
                };

                komentarTxt.Text = "";
                vzdevekT.Text = "";
                onGetKomentar(this, tmp);
            }
        }
    }
}
