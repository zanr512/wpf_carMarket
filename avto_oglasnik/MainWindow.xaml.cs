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
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace avto_oglasnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Oglas oglas_tmp;
        public static List<Komentar> kom_tmp;

        public Oglas temp
        {
            set
            {
                oglas_tmp = value;
            }
            get
            {
                return oglas_tmp;
            }
        }

        public List<Komentar> kom_class
        {
            set
            {
                kom_tmp = value;
            }
            get
            {
                return kom_tmp;
            }
        }



        
        ObservableCollection<Oglas> seznam_oglasov;
        public MainWindow()
        {
            InitializeComponent();

            levi_pogled.IsChecked = true;

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Oglas>));

            //if(!File.Exists(@"Podatki.xml"))
            //{
            //    File.Create(@"Podatki.xml");
                
            //}
            

            StreamReader reader = new StreamReader(@"Podatki.xml");
            seznam_oglasov = (ObservableCollection<Oglas>)serializer.Deserialize(reader);

            


            reader.Close();

            Oglasi.ItemsSource = seznam_oglasov;

            CollectionViewSource.GetDefaultView(Oglasi.ItemsSource).Filter = UserFilter;//m => (((Oglas)m)._znamka.Contains(iskanjeTxtBox.Text);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(120);
            dt.Tick += Dt_Tick;
            dt.Start();

        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("SHRANO");
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Oglas>));
            TextWriter writer = new StreamWriter(@"Podatki.xml");

            serializer.Serialize(writer, seznam_oglasov);

            writer.Close();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(120);
            dt.Tick += Dt_Tick;
            dt.Start();

        }

        private void iskanjeTxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            iskanjeTxtBox.Text = "";
        }


        //GLAVNI MENI IZHOD
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        //DODAJANJE NOVIH AVTOMOBILOV
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ListViewItem tmpList = new ListViewItem();
            //Border tmpBrd = new Border();
            Image tmpImg = new Image();
            //Grid tmpGrid = new Grid();
            //Label tmpLbl = new Label();
            //TextBlock tmpTxt = new TextBlock();

            //tmpBrd.BorderBrush = System.Windows.Media.Brushes.Black;
            //tmpBrd.BorderThickness = new Thickness(1);

            //tmpList.HorizontalAlignment = HorizontalAlignment.Stretch;
            //tmpList.Height = 140;


            //tmpGrid.Height = 140;
            //tmpGrid.ShowGridLines = true;

            //ColumnDefinition col1 = new ColumnDefinition();
            //ColumnDefinition col2 = new ColumnDefinition();
            //ColumnDefinition col3 = new ColumnDefinition();

            //col1.Width = new GridLength(210,GridUnitType.Pixel);
            //col2.Width = new GridLength(2, GridUnitType.Star);
            //col3.Width = new GridLength(1, GridUnitType.Star);

            //RowDefinition row1 = new RowDefinition();
            //RowDefinition row2 = new RowDefinition();

            //row1.Height = new GridLength(1, GridUnitType.Star);
            //row2.Height = new GridLength(3, GridUnitType.Star);

            //tmpGrid.ColumnDefinitions.Add(col1);
            //tmpGrid.ColumnDefinitions.Add(col2);
            //tmpGrid.ColumnDefinitions.Add(col3);

            //tmpGrid.RowDefinitions.Add(row1);
            //tmpGrid.RowDefinitions.Add(row2);

            //Grid.SetColumn(tmpImg, 0);
            //Grid.SetRowSpan(tmpImg, 20);

            //tmpImg.HorizontalAlignment = HorizontalAlignment.Left;
            //tmpImg.Width = Double.NaN;
            //tmpImg.Source = new BitmapImage(new Uri(@"/Resource/audi1.jpg", UriKind.RelativeOrAbsolute));

            //tmpLbl.FontWeight = FontWeights.Bold;
            //tmpLbl.FontSize = 13;
            //tmpLbl.Content = "Audi A4 Avant quattro 2.0 TDI S-tronic";

            //Grid.SetRow(tmpLbl, 0);
            //Grid.SetColumn(tmpLbl, 1);


            //Grid.SetRow(tmpTxt, 1);
            //Grid.SetColumn(tmpTxt, 1);

            //tmpTxt.Padding = new Thickness(3);
            //tmpTxt.Text = "OPIS AVOTMOBILA";

            //Border brd1 = new Border();
            //brd1.HorizontalAlignment = HorizontalAlignment.Right;
            //brd1.Height = 60;
            //brd1.MaxWidth = 90;
            //brd1.BorderBrush = System.Windows.Media.Brushes.Red;
            //brd1.BorderThickness = new Thickness(1);
            //brd1.Margin = new Thickness(0, 5, 10, 0);
            //brd1.VerticalAlignment = VerticalAlignment.Top;



            //Grid.SetRow(brd1, 0);
            //Grid.SetColumn(brd1, 2);
            //Grid.SetRowSpan(brd1, 2);

            //Label lbl1 = new Label();

            //lbl1.HorizontalAlignment = HorizontalAlignment.Center;
            //lbl1.VerticalAlignment = VerticalAlignment.Center;
            //lbl1.Content = "5200€";
            //lbl1.FontSize = 20;
            //lbl1.FontWeight = FontWeights.Bold;

            //brd1.Child = lbl1;

            //tmpGrid.Children.Add(tmpImg);
            //tmpGrid.Children.Add(tmpLbl);
            //tmpGrid.Children.Add(tmpTxt);
            //tmpGrid.Children.Add(brd1);

            //tmpBrd.Child = tmpGrid;


            //tmpList.Content = tmpBrd;

            //Oglasi.Items.Add(tmpList);

            dodajOglas oglas = new dodajOglas();

            Oglas o = new Oglas();


            oglas.ShowDialog();

            if (temp != null)
            {
                seznam_oglasov.Add(temp);
                temp = null;
                MessageBox.Show("Oglas uspešno dodan");
            }


            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Oglas>));
            TextWriter writer = new StreamWriter(@"Podatki.xml");

            serializer.Serialize(writer, seznam_oglasov);

            writer.Close();




        }

        private void btnOdstrani_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            if(Oglasi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izberi oglase, ki jih želiš izbrisati!", "Opozorilo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            while (Oglasi.SelectedItems.Count > 0)
            {
                Oglas idOglas = (Oglas)Oglasi.SelectedItems[0];
                seznam_oglasov.Remove(idOglas);
                //seznam_oglasov.Remove((Oglas)Oglasi.SelectedItems[0]));
            }

            //Oglas idOglas = (Oglas)Oglasi.SelectedItem;

            //seznam_oglasov.Remove(idOglas);



            //CollectionView sortiran = (CollectionView)CollectionViewSource.GetDefaultView(Oglasi.ItemsSource);
            //sortiran.SortDescriptions.Add(new System.ComponentModel.SortDescription("_znamka", System.ComponentModel.ListSortDirection.Descending));

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Oglas>));
            TextWriter writer = new StreamWriter(@"Podatki.xml");

            serializer.Serialize(writer, seznam_oglasov);

            writer.Close();

        }

        private void Oglasi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Oglas poslji = (Oglas)Oglasi.SelectedItem;
            ogledOglasa okno = new ogledOglasa(poslji,poslji.komentarji);

            okno.ShowDialog();

            poslji.komentarji = kom_class;
            kom_class = null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string filter = stanje.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
            //MessageBox.Show(filter);


            

        }


        private bool UserFilter(object item)
        {
            bool isciCombo = true;
            bool isciIskanje = true;

            bool iskanlo = true;

            Oglas t = (Oglas)item;

            // MessageBox.Show("iscem " + stanje.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            if (stanje.SelectedItem != null)
            {
                isciCombo = t.stanjeV.Contains((stanje.SelectedItem as ComboBoxItem).Content.ToString());
            }
                
            if(!String.IsNullOrEmpty(iskanjeTxtBox.Text))
            {
                isciIskanje = t.iskanje.IndexOf(iskanjeTxtBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                //MessageBox.Show(isciIskanje.ToString());
            }


            if (bencin.IsChecked == true && diesel.IsChecked == true)
                iskanlo = (t._gorivo == "Diesel") || (t._gorivo == "Bencin");
            else if (diesel.IsChecked == true)
            {
                iskanlo = t._gorivo == "Diesel";
            }
            else if (bencin.IsChecked == true)
            {
                iskanlo = t._gorivo == "Bencin";
            }




            //MessageBox.Show((isciCombo || isciIskanje).ToString());
            return (isciCombo && isciIskanje && iskanlo);


            //stanje.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");


        }

        //RESETIRAJ FILTRE
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           

            stanje.SelectedItem = null;
            bencin.IsChecked = false;
            diesel.IsChecked = false;
            iskanjeTxtBox.Text = "";
            CollectionViewSource.GetDefaultView(Oglasi.ItemsSource).Filter = null;
            CollectionViewSource.GetDefaultView(Oglasi.ItemsSource).SortDescriptions.Clear();

        }

        //UVOZI FILE
        private void odpri_file_source(object sender, RoutedEventArgs e)
        {
            string ime_datoteke;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files|*.xml";
            if (openFileDialog.ShowDialog() == true)
                ime_datoteke = openFileDialog.FileName;
            else return;
            //MessageBox.Show(ime_datoteke);

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Oglas>));


            StreamReader reader = new StreamReader(@ime_datoteke);
            seznam_oglasov = (ObservableCollection<Oglas>)serializer.Deserialize(reader);



            reader.Close();

            Oglasi.ItemsSource = seznam_oglasov;
        }

        //IZVOZI FILE
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            string ime_datoteke;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files|*.xml";
            if (saveFileDialog.ShowDialog() == true)
                ime_datoteke = saveFileDialog.FileName;
            else
                return;

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Oglas>));
            TextWriter writer = new StreamWriter(@ime_datoteke);

            serializer.Serialize(writer, seznam_oglasov);

            writer.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Oglasi.ItemsSource).Filter = UserFilter;
            CollectionViewSource.GetDefaultView(Oglasi.ItemsSource).Refresh();
        }

        private void logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void levi_pogled_Click(object sender, RoutedEventArgs e)
        {
            if(desni_pogled.IsChecked == true)
            {
                desni_pogled.IsChecked = false;
                levi_pogled.IsChecked = true;
                spremeni.HorizontalAlignment = HorizontalAlignment.Stretch;
                rect.SetValue(Grid.ColumnProperty, 1);
                spremeni.SetValue(Grid.ColumnProperty, 1);
            }
        }

        private void desni_pogled_Click(object sender, RoutedEventArgs e)
        {
            if (levi_pogled.IsChecked == true)
            {
                spremeni.HorizontalAlignment = HorizontalAlignment.Stretch;
                desni_pogled.IsChecked = true;
                levi_pogled.IsChecked = false;
                rect.SetValue(Grid.ColumnProperty, 3);
                spremeni.SetValue(Grid.ColumnProperty, 3);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CollectionView sortiran = (CollectionView)CollectionViewSource.GetDefaultView(Oglasi.ItemsSource);
            sortiran.SortDescriptions.Add(new System.ComponentModel.SortDescription("datumInt", System.ComponentModel.ListSortDirection.Descending));
        }
    }


}
