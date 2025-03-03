using DBPaulMain.Model;
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

namespace DBPaulMain
{
    /// <summary>
    /// Логика взаимодействия для AddRepairMan.xaml
    /// </summary>
    public partial class AddRepairMan : Window
    {
        public string selected;

        public AddRepairMan()
        {
            InitializeComponent();

            foreach(User usr in UserList.ManList)
            {
                lv_repairMan.Items.Add(usr.ToString());
            }

            lv_repairMan.SelectedIndex = 0;
        }

        private void lv_repairMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = (string)lv_repairMan.SelectedItem;
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
