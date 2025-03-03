using DBPaulMain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для OpenOrCreate.xaml
    /// </summary>
    public partial class OpenOrCreate : Window, INotifyPropertyChanged
    {
        private string _selectedMan;
        public string selectedMan 
        { 
            get
            {
                return _selectedMan;
            }
            set
            {
                _selectedMan = value;
                OnPropertyChanged("selectedMan");
            } 
        }
        private int? _id;

        public OpenOrCreate(int? id)
        {
            InitializeComponent();
            DataContext = this;
            cb_type.ItemsSource = Enum.GetValues(typeof(DeviceType));
            cb_type.SelectedIndex = 0;
            cb_status.ItemsSource = Enum.GetValues(typeof(StatusType));
            cb_status.SelectedIndex = 0;
            _id = id;
            selectedMan = UserList.ManList[0].ToString();
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext ac = new ApplicationContext();

            User? convertedMan = UserList.FindByString(selectedMan);
            if (convertedMan == null) { convertedMan = UserList.ManList[0]; }

            if(_id == null)
            {
                Request newRequest = new Request(
                    new Random().Next(),
                    dp_CreationDate.DisplayDate,
                    (DeviceType)cb_type.SelectedItem,
                    tb_model.Text,
                    tb_description.Text,
                    tb_name.Text,
                    tb_cNumber.Text,
                    (StatusType)cb_status.SelectedItem,
                    convertedMan);
                List<Request> qrList = ac.Requests.ToList();
                qrList.Add(newRequest);
                ac.Requests = qrList;
            }
            MessageBox.Show("Успешно!");
            DialogResult = true;
            this.Close();
        }

        private void bt_repairMan_Click(object sender, RoutedEventArgs e)
        {
            AddRepairMan repManWin = new AddRepairMan();
            bool? result = repManWin.ShowDialog();
            if (result == true) { selectedMan = repManWin.selected; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
