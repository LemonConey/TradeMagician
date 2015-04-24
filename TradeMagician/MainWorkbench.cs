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
    public partial class MainWorkbench : Form
    {
        private int childFormNumber = 0;
        public MainWorkbench()
        {
            InitializeComponent();
        }

        private void MainWorkbench_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        /// <summary>
        /// 选择合约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contractSelectToolbar_Click(object sender, EventArgs e)
        {
            ContractSelectionForm selectForm = new ContractSelectionForm();
            selectForm.ShowDialog();
            //selectForm.Show();
            ApiContext.SubscribedContracts = selectForm.SelectedContracts;
            ShowQuoteView();
        }

        private void ShowQuoteView()
        {
            QuotationForm quotationForm = MdiChildren.ToList<Form>().Find(f =>
            {
                return f is QuotationForm;
            }) as QuotationForm;
            if (quotationForm == null)
            {
                quotationForm = new QuotationForm(ApiContext.SubscribedContracts);
                quotationForm.MdiParent = this;
                quotationForm.Show();
                //quotationForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                //quotationForm.ReSubscribe
                quotationForm.Activate();
                quotationForm.ReSubscribe();
            }

        }

        /// <summary>
        /// 查询持仓
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryInvestorPositionToolbar_Click(object sender, EventArgs e)
        {
            InvestorPositionForm investorPosition = MdiChildren.ToList<Form>().Find(f =>
            {
                return f is InvestorPositionForm;
            }) as InvestorPositionForm;
            if (investorPosition == null)
            {
                investorPosition = new InvestorPositionForm();
                investorPosition.MdiParent = this;
                investorPosition.Show();
                investorPosition.WindowState = FormWindowState.Maximized;
            }
            else
            {
                //quotationForm.ReSubscribe
                investorPosition.Activate();
            }
        }
        
    }
}
