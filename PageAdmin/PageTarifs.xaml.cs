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

namespace SPTC.PageAdmin
{
    /// <summary>
    /// Interaction logic for PageTarifs.xaml
    /// </summary>
    public partial class PageTarifs : Page
    {
        Tarifs tarif = new Tarifs();
        public PageTarifs()
        {
            InitializeComponent();
            lv_tarifs.ItemsSource = SPTCEntities.GetContext().Tarifs.ToList();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAddTarifs(tarif, false, tarif));
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tarifObj = lv_tarifs.SelectedItems.Cast<Tarifs>().ToList().ElementAt(0);
                Tarifs Tarifs = new Tarifs()
                {
                    tarifs_name = tarifObj.tarifs_name,
                    tarifs_count = tarifObj.tarifs_count,
                    tarifs_category = tarifObj.tarifs_category,
                    tarifs_price = tarifObj.tarifs_price,
                    tarifs_provider = tarifObj.tarifs_provider,
                    tarifs_description = tarifObj.tarifs_description,
                    tarifs_photo = tarifObj.tarifs_photo
                };
                var tarifObj2 = lv_tarifs.SelectedItems.Cast<Tarifs>().ToList();
                try
                {
                    AppFrame.frameMain.Navigate(new PageAddTarifs(tarifObj, true, tarifObj));
                    SPTCEntities.GetContext().SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            catch
            {
                MessageBox.Show("Ошибка! Выберите тариф", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить тариф?", "Предупреждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var userObj = lv_tarifs.SelectedItems.Cast<Tarifs>().ToList();
                try
                {
                    SPTCEntities.GetContext().Tarifs.RemoveRange(userObj);
                    SPTCEntities.GetContext().SaveChanges();
                    MessageBox.Show("Тариф успешно удалён!");

                    lv_tarifs.ItemsSource = SPTCEntities.GetContext().Tarifs.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMenuAdmin());
        }
    }
}
