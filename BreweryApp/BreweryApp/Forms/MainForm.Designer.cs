namespace BreweryApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.ListBox statusList;
        private System.Windows.Forms.SplitContainer rightSplit;
        private System.Windows.Forms.DataGridView ordersGrid;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.PictureBox picBeer;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.TextBox searchBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainSplit = new SplitContainer();
            statusList = new ListBox();
            rightSplit = new SplitContainer();
            ordersGrid = new DataGridView();
            searchBox = new TextBox();
            btnCard = new Button();
            txtDetails = new TextBox();
            picBeer = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)mainSplit).BeginInit();
            mainSplit.Panel1.SuspendLayout();
            mainSplit.Panel2.SuspendLayout();
            mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightSplit).BeginInit();
            rightSplit.Panel1.SuspendLayout();
            rightSplit.Panel2.SuspendLayout();
            rightSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ordersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBeer).BeginInit();
            SuspendLayout();

            // mainSplit 
            mainSplit.Dock = DockStyle.Fill;
            mainSplit.Location = new Point(0, 0);
            mainSplit.Name = "mainSplit";
            
            // mainSplit.Panel1 (левая панель) 
            mainSplit.Panel1.Controls.Add(statusList);
            
            // mainSplit.Panel2 (правая панель) 
            mainSplit.Panel2.Controls.Add(rightSplit);
            mainSplit.Size = new Size(1067, 692);
            mainSplit.SplitterDistance = 266;
            mainSplit.SplitterWidth = 5;
            mainSplit.TabIndex = 0;

            // statusList 
            statusList.Dock = DockStyle.Fill;
            statusList.FormattingEnabled = true;
            statusList.Items.AddRange(new object[] { "В обработке", "Готов", "Доставляется", "Завершен" });
            statusList.Location = new Point(0, 0);
            statusList.Name = "statusList";
            statusList.Size = new Size(266, 692);
            statusList.TabIndex = 0;

            // rightSplit 
            rightSplit.Dock = DockStyle.Fill;
            rightSplit.Orientation = Orientation.Horizontal;
            
            // rightSplit.Panel1 (верхняя правая панель) 
            rightSplit.Panel1.Controls.Add(searchBox);
            rightSplit.Panel1.Controls.Add(ordersGrid);
            rightSplit.Panel1.Controls.Add(btnCard);
             
            // rightSplit.Panel2 (нижняя правая панель) 
            rightSplit.Panel2.Controls.Add(txtDetails);
            rightSplit.Panel2.Controls.Add(picBeer);
            rightSplit.Size = new Size(796, 692);
            rightSplit.SplitterDistance = 450;
            rightSplit.SplitterWidth = 6;
            rightSplit.TabIndex = 0;

            // ordersGrid 
            ordersGrid.Dock = DockStyle.Fill;
            ordersGrid.ColumnHeadersHeight = 29;
            ordersGrid.Location = new Point(0, 27);
            ordersGrid.Name = "ordersGrid";
            ordersGrid.RowHeadersWidth = 51;
            ordersGrid.Size = new Size(796, 393);
            ordersGrid.TabIndex = 1;

            // searchBox 
            searchBox.Dock = DockStyle.Top;
            searchBox.Location = new Point(0, 0);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Поиск...";
            searchBox.Size = new Size(796, 27);
            searchBox.TabIndex = 0;

            // btnCard 
            btnCard.Dock = DockStyle.Bottom;
            btnCard.Location = new Point(0, 420);
            btnCard.Name = "btnCard";
            btnCard.Size = new Size(796, 30);
            btnCard.TabIndex = 2;
            btnCard.Text = "Карточка заказа";

            // txtDetails 
            txtDetails.Dock = DockStyle.Top;
            txtDetails.Location = new Point(0, 0);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.Size = new Size(796, 150);
            txtDetails.TabIndex = 0;

            // picBeer
            picBeer.Dock = DockStyle.Fill;
            picBeer.Location = new Point(0, 150);
            picBeer.Name = "picBeer";
            picBeer.Size = new Size(796, 86);
            picBeer.SizeMode = PictureBoxSizeMode.Zoom;
            picBeer.TabIndex = 1;
            picBeer.TabStop = false;

            // MainForm 
            ClientSize = new Size(1067, 692);
            Controls.Add(mainSplit);
            Name = "MainForm";
            Text = "Пивоварня";
            mainSplit.Panel1.ResumeLayout(false);
            mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplit).EndInit();
            mainSplit.ResumeLayout(false);
            rightSplit.Panel1.ResumeLayout(false);
            rightSplit.Panel1.PerformLayout();
            rightSplit.Panel2.ResumeLayout(false);
            rightSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rightSplit).EndInit();
            rightSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ordersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBeer).EndInit();
            ResumeLayout(false);
        }
    }
}