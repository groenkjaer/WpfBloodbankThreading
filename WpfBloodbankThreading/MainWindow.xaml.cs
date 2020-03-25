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
using System.Diagnostics;
using System.Windows.Threading;
using WpfBloodbankThreading.UserControls;
using System.Threading;

namespace WpfBloodbankThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void UpdateTextCallback(int value, BankInfo ucTarget, int threadId);

        public MainWindow() //I am master branch
        {
            InitializeComponent();
            Thread[] threads = new Thread[3];
            BankInfo[] bankInfos = new BankInfo[] { ucEstland, ucLetland, ucLitauen };

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(BankBranch)) { IsBackground = true };
                threads[i].Start(bankInfos[i]);
            }
        }

        private void BankBranch(object _obj)
        {
            int threadId = Environment.CurrentManagedThreadId; 
            BankInfo bankBranch = _obj as BankInfo;
            Random rng = new Random(threadId); //Brug tråd id som seed så de har forskellige værdier
            
            while (true)
            {
                bankBranch.Dispatcher.Invoke(new UpdateTextCallback(UpdateTextValue), rng.Next(1, 100), bankBranch, threadId);
                Thread.Sleep(800);
            }
        }

        private void UpdateTextValue(int value, BankInfo ucTarget, int threadId)
        {
            if (ucTarget.lblBloodLevel.Content.ToString() == "")
            {
                value += 0;
            }
            else
            {
                value += (int)ucTarget.lblBloodLevel.Content;
            }
            
            ucTarget.lblBloodLevel.Content = value;
            ucTarget.lblThreadNumber.Content = threadId;
        }
    }
}
