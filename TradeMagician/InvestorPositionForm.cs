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
    public partial class InvestorPositionForm : Form
    {
        Thread worker = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        public InvestorPositionForm()
        {
            InitializeComponent();
        }

        private void InvestorPositionForm_Load(object sender, EventArgs e)
        {
            worker = new Thread(new ThreadStart(WorkerThread));
            worker.IsBackground = true;
            worker.Start();
            cts.Token.Register(() =>
            {
                //worker线程停止
                Trace.TraceInformation("InvestorPositon Update Thread is Stopped.");
            });

            QryInvestorPosition();
        }

        public void QryInvestorPosition()
        {
            String contracts = Contract.GetSubscribeString(ApiContext.SubscribedContracts);
            ApiContext.TradeApi.ReqQryInvestorPosition(contracts, "");
        }

        public void ReQryInvestorPosition()
        {
            QryInvestorPosition();
        }

        delegate void UpdateInvestorPositionDataDelegate(PositionField data);
        IDictionary<String, int> RowIndexMap = new Dictionary<String, int>();
        private void UpdateInvestorPositionData(PositionField data)
        {
            if (!RowIndexMap.ContainsKey(data.InstrumentID))
            {
                //DataGridViewRow row = new DataGridViewRow();
                int index = investorPositonGrid.Rows.Add();
                RowIndexMap.Add(data.InstrumentID, index);
            }
            DataGridViewRow currentRow = investorPositonGrid.Rows[RowIndexMap[data.InstrumentID]];
            currentRow.Cells["ExchangeID"].Value = data.ExchangeID;
            currentRow.Cells["InstrumentID"].Value = data.InstrumentID;
            currentRow.Cells["Symbol"].Value = data.Symbol;
            currentRow.Cells["YdPosition"].Value = data.YdPosition.ToString();
            currentRow.Cells["TdPosition"].Value = data.TdPosition.ToString();
            currentRow.Cells["Position"].Value = data.Position.ToString();

        }
        private void WorkerThread()
        {
            PositionField data;
            while (true && !cts.IsCancellationRequested)
            {
                if (ApiContext.DepthMarketDataQueue.Count >= 1)
                {
                    Boolean getted = ApiContext.InvestorPosition.TryDequeue(out data);
                    if (getted)
                    {
                        Invoke(new UpdateInvestorPositionDataDelegate(UpdateInvestorPositionData), data);
                    }
                    
                }

            }
        }

        private void InvestorPositionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }

    }
}
