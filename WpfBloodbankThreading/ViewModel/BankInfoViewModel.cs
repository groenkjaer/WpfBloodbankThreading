using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBloodbankThreading.Model;

namespace WpfBloodbankThreading.ViewModel
{
    public class BankInfoViewModel
    {
        public BankInfoModel Model { get; set; }

        public BankInfoViewModel()
        {
            Model = new BankInfoModel();
        }
    }
}
