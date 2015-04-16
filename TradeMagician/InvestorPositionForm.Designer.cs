namespace TradeMagician
{
    partial class InvestorPositionForm
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
            this.investorPositonGrid = new System.Windows.Forms.DataGridView();
            this.ExchangeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrumentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YdPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TdPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.investorPositonGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // investorPositonGrid
            // 
            this.investorPositonGrid.AllowUserToAddRows = false;
            this.investorPositonGrid.AllowUserToDeleteRows = false;
            this.investorPositonGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.investorPositonGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.investorPositonGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExchangeID,
            this.InstrumentID,
            this.Symbol,
            this.YdPosition,
            this.TdPosition,
            this.Position});
            this.investorPositonGrid.Location = new System.Drawing.Point(13, 13);
            this.investorPositonGrid.Name = "investorPositonGrid";
            this.investorPositonGrid.ReadOnly = true;
            this.investorPositonGrid.RowTemplate.Height = 27;
            this.investorPositonGrid.Size = new System.Drawing.Size(889, 470);
            this.investorPositonGrid.TabIndex = 0;
            // 
            // ExchangeID
            // 
            this.ExchangeID.HeaderText = "代码";
            this.ExchangeID.Name = "ExchangeID";
            this.ExchangeID.ReadOnly = true;
            // 
            // InstrumentID
            // 
            this.InstrumentID.HeaderText = "合约代码";
            this.InstrumentID.Name = "InstrumentID";
            this.InstrumentID.ReadOnly = true;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "符号";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // YdPosition
            // 
            this.YdPosition.HeaderText = "昨日持仓";
            this.YdPosition.Name = "YdPosition";
            this.YdPosition.ReadOnly = true;
            // 
            // TdPosition
            // 
            this.TdPosition.HeaderText = "今仓";
            this.TdPosition.Name = "TdPosition";
            this.TdPosition.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "持仓均价";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // InvestorPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 495);
            this.Controls.Add(this.investorPositonGrid);
            this.Name = "InvestorPositionForm";
            this.Text = "InvestorPositionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InvestorPositionForm_FormClosing);
            this.Load += new System.EventHandler(this.InvestorPositionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.investorPositonGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView investorPositonGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrumentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YdPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn TdPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
    }
}