using DBPaulMain.Model;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBPaulMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext aC = new ApplicationContext();

        public MainWindow()
        {
            InitializeComponent();

            List<Request> rqList = aC.Requests.ToList();
            Request rq = new Request(
                0111011011,
                DateTime.Now,
                DeviceType.Computer,
                "model",
                "description",
                "Name",
                "telephobe",
                StatusType.New,
                null);

            rqList.Add(rq);
            aC.Requests = rqList;

            UpdateLv();
        }

        private void UpdateLv()
        {
            lv_requests.Items.Clear();
            foreach (Request rq in aC.Requests) { lv_requests.Items.Add(rq.ToString()); }
        }

        private void CreateNewRequest()
        {
            OpenOrCreate createWin = new OpenOrCreate(null);
            bool? result = createWin.ShowDialog();
            if (result == true) { UpdateLv(); }
        }

        private void bt_Add_Click(object sender, RoutedEventArgs e) { CreateNewRequest(); }
    }
}