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
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }
        public static DetailForm create(string quotation_id)
        {
            var detailForm = new DetailForm();
            detailForm.Text = quotation_id;
            return detailForm;
        }
        private void DetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
