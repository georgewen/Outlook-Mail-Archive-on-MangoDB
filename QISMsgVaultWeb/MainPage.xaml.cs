using QISMsgVaultWeb.MsgVaultSvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace QISMsgVaultWeb
{
    public partial class MainPage : UserControl
    {
        public ObservableCollection<MongoMail> MyCollection { get; set; }
        public int pageIndex { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.SizeChanged += new SizeChangedEventHandler(Layout_SizeChanged);

            // load data
            DataContext = this;
            //MyCollection = new ObservableCollection<MongoMail>();
            pageIndex = 0; //set initial page number

            MsgVaultSvc.MsgVaultServiceClient client = new MsgVaultSvc.MsgVaultServiceClient();
            //client.GetAllEmailsCompleted += new EventHandler<GetAllEmailsCompletedEventArgs>(client_GetAllEmailsCompleted);
            client.GetEmailsPageCompleted += new EventHandler<GetEmailsPageCompletedEventArgs>(client_GetEmailsPageCompleted);

            try
            {
                //client.GetAllEmailsAsync();
                client.GetEmailsPageAsync(0,20);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void Layout_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LayoutRoot.Width = e.NewSize.Width ;
            LayoutRoot.Height = e.NewSize.Height;

        } 

        void client_GetEmailsPageCompleted(object sender, GetEmailsPageCompletedEventArgs e)
        {
            MyCollection = new ObservableCollection<MongoMail>();
            List<MongoMail> res = e.Result.ToList();
            foreach (MongoMail mm in res)
            {
                MyCollection.Add(mm);
            }
            MsgsGrid.ItemsSource = MyCollection;//e.Result;
        }


        private void MsgsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Body" || e.Column.Header.ToString() == "EntryID" || e.Column.Header.ToString() =="CC" || e.Column.Header.ToString() =="Id")
                e.Cancel = true;
        }

        private void MsgsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MsgsGrid.SelectedItem != null)
            {
                //MessageBox.Show("selection changed!");

                MongoMail mail = (MongoMail)MsgsGrid.SelectedItem;
                
                //int index1 = ((MongoMail)item).index_1;

                Lbl_From.Content = "From: " + mail.SenderEmailAddress;                
                Lbl_Cc.Content = "Cc: " + mail.CC;
                Lbl_Subject.Content =  mail.Subject;
                Lbl_To.Content = "To: " + mail.To;
                txt_Body.Text = mail.Body;
                Lbl_sent.Content = "Sent: " + mail.CreationTime;
                //textBox1.DataContext = MsgsGrid.CurrentColumn.Header.ToString() + ": " +  ((TextBlock)MsgsGrid.CurrentColumn.GetCellContent(MsgsGrid.SelectedItem)).Text;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pageIndex++;
            MsgVaultSvc.MsgVaultServiceClient client = new MsgVaultSvc.MsgVaultServiceClient();
            client.GetEmailsPageCompleted += new EventHandler<GetEmailsPageCompletedEventArgs>(client_GetEmailsPageCompleted);
            try
            {
                client.GetEmailsPageAsync(pageIndex, 20);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (pageIndex>=1)
                pageIndex--;
            MsgVaultSvc.MsgVaultServiceClient client = new MsgVaultSvc.MsgVaultServiceClient();
            client.GetEmailsPageCompleted += new EventHandler<GetEmailsPageCompletedEventArgs>(client_GetEmailsPageCompleted);
            try
            {
                client.GetEmailsPageAsync(pageIndex, 20);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        
    }
}
