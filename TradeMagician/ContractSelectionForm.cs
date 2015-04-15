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
    public partial class ContractSelectionForm : Form
    {
        public IList<Contract> SelectedContracts = new List<Contract>();
        public ContractSelectionForm()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            ApiContext.SubscribedContracts.Clear();

            foreach (DataGridViewRow row in contractGrid.Rows)
            {
                Boolean isSelected = Convert.ToBoolean(row.Cells["Selected"].Value);
                if (isSelected)
                {
                    SelectedContracts.Add(new Contract(row.Cells["ContractID"].Value.ToString(), row.Cells["ContractName"].Value.ToString()));
                }
            }
            ApiContext.SubscribedContracts = SelectedContracts;
            this.Close();
        }

        private void ContractSelectionForm_Load(object sender, EventArgs e)
        {
            IList<Contract> contracts = Contract.GetCurrentContract();
            foreach (Contract contract in contracts)
            {
                int index = this.contractGrid.Rows.Add();
                DataGridViewRow row = this.contractGrid.Rows[index];
                bool isSubscribed = ApiContext.SubscribedContracts.Any<Contract>(c =>
                {
                    return c.ContractName.Equals(contract.ContractName);
                });
                row.Cells["Selected"].Value = isSubscribed;
                row.Selected = isSubscribed;
                row.Cells["ContractID"].Value = contract.ContractID;
                row.Cells["ContractName"].Value = contract.ContractName;
            }
        }

        private void contractGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            DataGridViewRow currentRow = grid.Rows[e.RowIndex];
            Boolean isSelect=!Convert.ToBoolean(currentRow.Cells["Selected"].Value);
            currentRow.Cells["Selected"].Value = isSelect;
            currentRow.Selected = isSelect;
        }

    }
}
