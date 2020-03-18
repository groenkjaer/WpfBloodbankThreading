﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
            BankBranch(ucEstland);
        }

        private void BankBranch(object _obj)
        {
            DispatcherTimer dt = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 2) }; //Change values every 2 seconds using this

            BankInfo uc = _obj as BankInfo;
            uc.lblBloodLevel.Content = 30;
            uc.lblThreadNumber.Content = Environment.CurrentManagedThreadId;
        }
    }
}