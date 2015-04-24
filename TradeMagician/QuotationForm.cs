using QuantBox.XAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        Thread worker = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        private void QuotationForm_Load(object sender, EventArgs e)
        {
            InitRows();
            ApiContext.QuoteApi.Subscribe(Contract.GetSubscribeString(SubscribedContracts), "");
            worker = new Thread(new ThreadStart(WorkerThread));
            worker.IsBackground = true;
            worker.Start();
            cts.Token.Register(() =>
            {
                //worker线程停止
                Trace.TraceInformation("QuotationView Update Thread is Stopped.");
            });
        }
        private void InitRows()
        {
            RowIndexMap.Clear();
            quotationGrid.Rows.Clear();

            foreach(Contract contract in SubscribedContracts)
            {
                int index = quotationGrid.Rows.Add();
                DataGridViewRow row = quotationGrid.Rows[index];
                row.Cells["InstrumentID"].Value = contract.ContractName;
                RowIndexMap.Add(contract.ContractName, index);
            }
        }

        delegate void UpdateMarketDataDelegate(DepthMarketDataField data);
        IDictionary<String, int> RowIndexMap = new Dictionary<String, int>();
        IDictionary<String, DetailForm> DetailForms = new Dictionary<String, DetailForm>();
        private void UpdateMarketData(DepthMarketDataField marketData)
        {
            if (!RowIndexMap.ContainsKey(marketData.InstrumentID))
            {
                //DataGridViewRow row = new DataGridViewRow();
                int index=quotationGrid.Rows.Add();
                RowIndexMap.Add(marketData.InstrumentID, index);
            }
            DataGridViewRow currentRow = quotationGrid.Rows[RowIndexMap[marketData.InstrumentID]];
            currentRow.Cells["InstrumentID"].Value = marketData.InstrumentID;
            currentRow.Cells["LastPrice"].Value = marketData.LastPrice.ToString();
            currentRow.Cells["HighestPrice"].Value = marketData.HighestPrice.ToString();
            currentRow.Cells["LowestPrice"].Value = marketData.LowestPrice.ToString();
            currentRow.Cells["SettlementPrice"].Value = marketData.SettlementPrice.ToString();
            currentRow.Cells["PreSettlementPrice"].Value = marketData.PreSettlementPrice.ToString();

        }
        private void WorkerThread()
        {
            DepthMarketDataField marketData;
            while (true && !cts.IsCancellationRequested)
            {
                if (ApiContext.DepthMarketDataQueue.Count >= 1) 
                {
                    Boolean getted = ApiContext.DepthMarketDataQueue.TryDequeue(out marketData);
                    if (getted)
                    {
                        Invoke(new UpdateMarketDataDelegate(UpdateMarketData), marketData);
                    }
                }
                
            }
        }

        private void QuotationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
            ApiContext.QuoteApi.Unsubscribe(Contract.GetSubscribeString(SubscribedContracts), "");
        }
        
        public void ReSubscribe()
        {
            UnSubscribe();
            Subscribe();
        }
        public void Subscribe()
        {
            SubscribedContracts = ApiContext.SubscribedContracts;
            InitRows();
            ApiContext.QuoteApi.Subscribe(Contract.GetSubscribeString(SubscribedContracts), "");
        }
        private void UnSubscribe()
        {
            ApiContext.QuoteApi.Unsubscribe(Contract.GetSubscribeString(SubscribedContracts), "");
            quotationGrid.Rows.Clear();

        }

        private void quotationGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = quotationGrid.Rows[e.RowIndex];
            string instId = (currentRow.Cells["InstrumentId"].Value as string);
            if (!DetailForms.ContainsKey(instId) || DetailForms[instId].IsDisposed)
            {
                DetailForms[instId] = DetailForm.create(instId);
                DetailForms[instId].MdiParent = this.MdiParent;
            }
            var detailForm = DetailForms[instId];
            detailForm.Show();
            detailForm.Activate();
        }
    }
}
