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
            foreach (DataGridViewRow row in contractGrid.Rows)
            {
                if(row.Selected){
                    SelectedContracts.Add(new Contract(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()));
                }
            }
            this.Close();
        }

        private void ContractSelectionForm_Load(object sender, EventArgs e)
        {
            IList<Contract> contracts = Contract.GetCurrentContract();
            foreach (Contract contract in contracts)
            {

                DataGridViewRow row = (DataGridViewRow)this.contractGrid.RowTemplate.Clone();
                DataGridViewCheckBoxCell selected = new DataGridViewCheckBoxCell();
                row.Cells.Add(selected);

                DataGridViewTextBoxCell contractId = new DataGridViewTextBoxCell();
                contractId.Value=contract.ContractID;
                row.Cells.Add(contractId);

                DataGridViewTextBoxCell contractName = new DataGridViewTextBoxCell();
                contractName.Value = contract.ContractName;
                row.Cells.Add(contractName);

                contractGrid.Rows.Add(row);
                
            }
        }
    }
}
