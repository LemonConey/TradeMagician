using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeMagician
{
    public partial class QuotationForm : Form
    {
        IList<Contract> SubscribedContracts { get; set; }
        public QuotationForm()
        {
            InitializeComponent();
        }
        public QuotationForm(IList<Contract> contracts):this()
        {
            SubscribedContracts = contracts;
        }
    }
}
