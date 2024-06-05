namespace TP
{
    partial class AddInvenUI
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
            this.addInvenLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.addInvenTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.addInvenTable)).BeginInit();
            this.SuspendLayout();
            // 
            // addStock
            // 
            this.addInvenLabel.AutoSize = true;
            this.addInvenLabel.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addInvenLabel.Location = new System.Drawing.Point(12, 9);
            this.addInvenLabel.Name = "addStock";
            this.addInvenLabel.Size = new System.Drawing.Size(91, 18);
            this.addInvenLabel.TabIndex = 11;
            this.addInvenLabel.Text = "재고 등록";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(861, 114);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(85, 42);
            this.quitButton.TabIndex = 14;
            this.quitButton.Text = "종료";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(861, 30);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(85, 40);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "등록";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addStockTable
            // 
            this.addInvenTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addInvenTable.Location = new System.Drawing.Point(12, 30);
            this.addInvenTable.Name = "addStockTable";
            this.addInvenTable.RowTemplate.Height = 23;
            this.addInvenTable.Size = new System.Drawing.Size(843, 501);
            this.addInvenTable.TabIndex = 16;
            // 
            // AddInven
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 623);
            this.Controls.Add(this.addInvenTable);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.addInvenLabel);
            this.Name = "AddInven";
            this.Text = "AddInven";
            ((System.ComponentModel.ISupportInitialize)(this.addInvenTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label addInvenLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView addInvenTable;
    }
}