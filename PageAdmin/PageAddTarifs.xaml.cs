using Microsoft.Win32;
using SPTC.ApplicationData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PageAddTarifs.xaml
    /// </summary>
    public partial class PageAddTarifs : Page
    {
        private Tarifs _tarifs = new Tarifs();
        bool shouldUpdate;
        Tarifs tarif;
        Tarifs newTarif;
        Tarifs updateTarif;
        public PageAddTarifs(Tarifs tarif, bool shouldUpdate, Tarifs updateTarif = null)
        {
            this.shouldUpdate = shouldUpdate;
            this.tarif = tarif;
            this.updateTarif = updateTarif;

            InitializeComponent();

            txb_name.Focus();
            foreach (var item in AppConnect.modelOdb.Category.ToList())
            {
                cb_type.Items.Add(item.category_name);
            }
            foreach (var item in AppConnect.modelOdb.Providers.ToList())
            {
                cb_provider.Items.Add(item.provider_name);
            }

            _tarifs = tarif;

            if (tarif == null)
            {
                cb_type.SelectedIndex = 0;
                cb_provider.SelectedIndex = 0;
            }

            if (shouldUpdate)
            {
                txb_name.Text = updateTarif.tarifs_name;
                txb_price.Text = updateTarif.tarifs_price.ToString();
                txb_amount.Text = updateTarif.tarifs_count.ToString();
                txb_desc.Text = updateTarif.tarifs_description;

                cb_provider.SelectedItem = AppConnect.modelOdb.Providers.FirstOrDefault
                    (x => x.id_provider == _tarifs.tarifs_provider).provider_name;

                cb_type.Text = AppConnect.modelOdb.Category.FirstOrDefault
                    (x => x.id_category == _tarifs.tarifs_category).category_name;

                FindFilterCategoryMat();
                FindFilterProviderMat();
            }
            else
            {
                newTarif = new Tarifs();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            FindFilterCategoryMat();
            FindFilterProviderMat();

            if (shouldUpdate)
            {
                localupdateTarifs(tarif);
                updateTarifs();
                MessageBox.Show("Изменения сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.Navigate(new PageTarifs());
            }
            else
            {
                localupdateTarifs(newTarif);
                addtarif();
                MessageBox.Show("Тариф добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.Navigate(new PageTarifs());
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageTarifs());
        }

        private void btn_image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            try
            {
                string directory;
                directory = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\'), dialog.FileName.Length - dialog.FileName.Substring(0, dialog.FileName.LastIndexOf('\\')).Length);

                if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\img\\" + directory))
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\img\\" + directory);
                }

                File.Copy(dialog.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\" + directory);
                _tarifs.tarifs_photo = dialog.SafeFileName;
                AppConnect.modelOdb.SaveChanges();
                DataContext = null;
                DataContext = _tarifs;
            }
            catch
            {
                _tarifs.tarifs_photo = "picture.png";
                AppConnect.modelOdb.SaveChanges();
                DataContext = null;
                DataContext = _tarifs;
            }
        }

        private void txb_amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txb_amount.Text = Regex.Replace(txb_amount.Text, "[^0-9]", "");
        }

        private void txb_price_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txb_price.Text = Regex.Replace(txb_price.Text, "[^0-9.]", "");
        }

        private void FindFilterCategoryMat()
        {
            var _category = AppConnect.modelOdb.Category.FirstOrDefault(x => x.category_name == cb_type.SelectedItem.ToString());
            if (_category == null)
            {
                MessageBox.Show("Выберите элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _tarifs.tarifs_category = _category.id_category;
            }
        }

        private void FindFilterProviderMat()
        {
            var _provider = AppConnect.modelOdb.Providers.FirstOrDefault(x => x.provider_name == cb_provider.SelectedItem.ToString());
            if (_provider == null)
            {
                MessageBox.Show("Выберите элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _tarifs.tarifs_provider = _provider.id_provider;
            }
        }

        private void addtarif()
        {
            SPTCEntities.GetContext().Tarifs.Add(newTarif);
            SPTCEntities.GetContext().SaveChanges();
        }

        private void updateTarifs()
        {
            Tarifs updatedtarif = SPTCEntities.GetContext().Tarifs.Where(x => x.id_tarifs == updateTarif.id_tarifs).SingleOrDefault();
            updatedtarif.tarifs_name = updateTarif.tarifs_name;
            updatedtarif.tarifs_count = updateTarif.tarifs_count;
            updatedtarif.tarifs_price = updateTarif.tarifs_price;
            updatedtarif.tarifs_description = updateTarif.tarifs_description;
            updatedtarif.tarifs_category = _tarifs.tarifs_category;
            updatedtarif.tarifs_provider = _tarifs.tarifs_provider;
            updatedtarif.tarifs_photo = _tarifs.tarifs_photo;
        }

        private void localupdateTarifs(Tarifs tarif)
        {
            tarif.tarifs_name = txb_name.Text;
            tarif.tarifs_count = Convert.ToInt32(txb_amount.Text);
            tarif.tarifs_price = Convert.ToDouble(txb_price.Text);
            tarif.tarifs_description = txb_desc.Text;
            tarif.tarifs_category = _tarifs.tarifs_category;
            tarif.tarifs_provider = _tarifs.tarifs_provider;
            tarif.tarifs_photo = _tarifs.tarifs_photo;
        }
    }
}
