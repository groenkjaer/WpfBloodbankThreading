using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows;

namespace WpfBloodbankThreading.Model
{
    public class BankInfoModel : INotifyPropertyChanged
    {
        private Thread currentThread;
        private Random random;

        private int threadNumber;
        public int ThreadNumber
        {
            get { return threadNumber; }
            set
            {
                if (threadNumber != value)
                {
                    threadNumber = value;
                    RaisePropertyChanged("ThreadNumber");
                }
            }
        }

        private int bloodLevel;
        public int BloodLevel
        {
            get { return bloodLevel; }
            set
            {
                if (bloodLevel != value)
                {
                    bloodLevel = value;
                    RaisePropertyChanged("BloodLevel");
                }
            }
        }

        public BankInfoModel()
        {
            currentThread = new Thread(new ThreadStart(BankBranch)) { IsBackground = true };
            random = new Random(currentThread.ManagedThreadId);

            ThreadNumber = currentThread.ManagedThreadId;
            BloodLevel = random.Next(1, 100);
            currentThread.Start();
        }

        public void BankBranch()
        {
            while (true)
            {
                BloodLevel += random.Next(1, 100);
                Thread.Sleep(800);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
