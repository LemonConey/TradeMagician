namespace TradeMagician
{
    partial class QuotationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.quotationGrid = new System.Windows.Forms.DataGridView();
            this.InstrumentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighestPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowestPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettlementPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreSettlementPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.quotationGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // quotationGrid
            // 
            this.quotationGrid.AllowUserToAddRows = false;
            this.quotationGrid.AllowUserToDeleteRows = false;
            this.quotationGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quotationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quotationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InstrumentID,
            this.LastPrice,
            this.HighestPrice,
            this.LowestPrice,
            this.SettlementPrice,
            this.PreSettlementPrice});
            this.quotationGrid.Location = new System.Drawing.Point(13, 13);
            this.quotationGrid.Name = "quotationGrid";
            this.quotationGrid.ReadOnly = true;
            this.quotationGrid.RowTemplate.Height = 27;
            this.quotationGrid.Size = new System.Drawing.Size(871, 511);
            this.quotationGrid.TabIndex = 0;
            // 
            // InstrumentID
            // 
            this.InstrumentID.HeaderText = "合约";
            this.InstrumentID.Name = "InstrumentID";
            this.InstrumentID.ReadOnly = true;
            // 
            // LastPrice
            // 
            this.LastPrice.HeaderText = "最新价";
            this.LastPrice.Name = "LastPrice";
            this.LastPrice.ReadOnly = true;
            // 
            // HighestPrice
            // 
            this.HighestPrice.HeaderText = "最高价";
            this.HighestPrice.Name = "HighestPrice";
            this.HighestPrice.ReadOnly = true;
            // 
            // LowestPrice
            // 
            this.LowestPrice.HeaderText = "最低价";
            this.LowestPrice.Name = "LowestPrice";
            this.LowestPrice.ReadOnly = true;
            // 
            // SettlementPrice
            // 
            this.SettlementPrice.HeaderText = "结算价";
            this.SettlementPrice.Name = "SettlementPrice";
            this.SettlementPrice.ReadOnly = true;
            // 
            // PreSettlementPrice
            // 
            this.PreSettlementPrice.HeaderText = "昨结算价";
            this.PreSettlementPrice.Name = "PreSettlementPrice";
            this.PreSettlementPrice.ReadOnly = true;
            // 
            // QuotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 536);
            this.Controls.Add(this.quotationGrid);
            this.Name = "QuotationForm";
            this.Text = "QuotationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuotationForm_FormClosing);
            this.Load += new System.EventHandler(this.QuotationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quotationGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView quotationGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrumentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighestPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowestPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlementPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreSettlementPrice;
    }
}