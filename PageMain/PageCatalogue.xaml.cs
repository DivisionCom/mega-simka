using SPTC.ApplicationData;
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

namespace SPTC.PageMain
{
    /// <summary>
    /// Interaction logic for PageCatalogue.xaml
    /// </summary>
    public partial class PageCatalogue : Page
    {
        Tarifs[] FindTarifs()
        {
            List<Tarifs> tarifs = AppConnect.modelOdb.Tarifs.ToList();
            var tarifsAll = tarifs;
            if (txb_search != null)
            {
                tarifs = tarifs.Where(x => x.tarifs_name.ToLower().Contains(txb_search.Text.ToLower())).ToList();
                switch (cb_price.SelectedIndex)
                {
                    case 1:
                        tarifs = tarifs.OrderBy(x => x.tarifs_price).ToList();
                        break;
                    case 2:
                        tarifs = tarifs.OrderByDescending(x => x.tarifs_price).ToList();
                        break;
                }
            }

            if (cb_self.SelectedIndex > 0)
            {
                tarifs = tarifs.Where(x => x.Providers.provider_name == cb_self.SelectedItem.ToString()).ToList();
            }

            if (tarifs.Count > 0)
            {
                label_material.Text = "Найдено " + tarifs.Count.ToString() + " из " + tarifsAll.Count.ToString();
            }
            else
            {
                label_material.Text = "Элементы не найдены";
            }

            return tarifs.ToArray();
        }
        private void SetPriceTarifs()
        {
            cb_price.Items.Add("Не выбрано");
            cb_price.Items.Add("Сначала дешевле");
            cb_price.Items.Add("Сначала дороже");
            cb_price.SelectedIndex = 0;
        }

        private void SetSelfTarifs()
        {
            cb_self.Items.Add("Провайдер");
            foreach (var providers in AppConnect.modelOdb.Providers)
            {
                cb_self.Items.Add(providers.provider_name);
            }
            cb_self.SelectedIndex = 0;
        }

        public PageCatalogue()
        {
            InitializeComponent(); 
            SetPriceTarifs();
            SetSelfTarifs();
            lb_catalogue.ItemsSource = FindTarifs();

            switch (Flag.role)
            {
                case 1:
                    btn_adminpanel.Visibility = Visibility.Visible;
                    break;
                case 2:
                    btn_adminpanel.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    btn_adminpanel.Visibility = Visibility.Visible;
                    break;
                case 4:
                    btn_adminpanel.Visibility = Visibility.Hidden;
                    btn_exit.Content = "Авторизация";
                    break;
            }
        }

        private void grid_Loading(object sender, RoutedEventArgs e)
        {
            var CurrentTarifs = SPTCEntities.GetContext().Tarifs.ToList();
            lb_catalogue.ItemsSource = CurrentTarifs;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Flag.flag = null;
            AppFrame.frameMain.Navigate(new PageLogin());
        }

        private void cb_price_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_catalogue.ItemsSource = FindTarifs();
        }

        private void cb_self_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_catalogue.ItemsSource = FindTarifs();
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            lb_catalogue.ItemsSource = FindTarifs();
        }

        private void page_loading(object sender, RoutedEventArgs e)
        {
            AppConnect.modelOdb.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            lb_catalogue.ItemsSource = FindTarifs();
        }

        private void btn_adminpanel_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdmin.PageMenuAdmin());
        }

        public static bool getTarif(string tarif)
        {
            var tarifOdj = SPTCEntities.GetContext().Tarifs.FirstOrDefault(x => x.tarifs_name == tarif);
            if (tarifOdj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
