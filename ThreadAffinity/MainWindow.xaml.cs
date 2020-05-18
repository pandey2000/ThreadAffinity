using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Factory.StartNew(ChangeName);
            Task.Factory.StartNew(ChangeName);
            Task.Factory.StartNew(ChangeName);
        }

        private void ChangeName()
        {
            string[] arr = { "a", "b", "c", "d", "e" };
            Random rnd = new Random();
            int i = 100;
            while(i-- != 0)
            {
                Thread.Sleep(100);
                UpdateName(arr[rnd.Next(0,4)]);
            }      
        }

        private void UpdateName(string v)
        {
            //txtMessage.Text = v;
            //The Dispatcher is provided to make changes to the objects created by UI thread. We can't modify such objects directly by other threads.
            Dispatcher.Invoke(() => txtMessage.Text = v);            
        }
    }
}
