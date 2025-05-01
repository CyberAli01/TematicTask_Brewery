namespace BreweryApp.Forms
{
    partial class OrderCardForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel tableLayout;
        private Label lblClient;
        private TextBox txtClient;
        private Label lblBeers;
        private ListBox lstBeers;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblTotal;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayout = new TableLayoutPanel();
            this.lblClient = new Label();
            this.txtClient = new TextBox();
            this.lblBeers = new Label();
            this.lstBeers = new ListBox();
            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();
            this.lblTotal = new Label();
            this.btnSave = new Button();

            SuspendLayout();

            // TableLayout
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout.RowCount = 5;
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Padding = new Padding(10);

            // lblClient
            lblClient.Text = "Клиент:";
            lblClient.Anchor = AnchorStyles.Left;
            tableLayout.Controls.Add(lblClient, 0, 0);

            // txtClient
            txtClient.ReadOnly = true;
            txtClient.Dock = DockStyle.Fill;
            tableLayout.Controls.Add(txtClient, 1, 0);

            // lblBeers
            lblBeers.Text = "Состав заказа:";
            lblBeers.Anchor = AnchorStyles.Left;
            tableLayout.Controls.Add(lblBeers, 0, 1);

            // lstBeers
            lstBeers.Dock = DockStyle.Fill;
            lstBeers.IntegralHeight = false;
            lstBeers.ScrollAlwaysVisible = true;
            tableLayout.SetRowSpan(lstBeers, 2);
            tableLayout.Controls.Add(lstBeers, 1, 1);

            // lblStatus
            lblStatus.Text = "Статус:";
            lblStatus.Anchor = AnchorStyles.Left;
            tableLayout.Controls.Add(lblStatus, 0, 3);

            // cmbStatus
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Dock = DockStyle.Fill;
            tableLayout.Controls.Add(cmbStatus, 1, 3);

            // lblTotal
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Dock = DockStyle.Fill;
            tableLayout.Controls.Add(lblTotal, 0, 4);
            tableLayout.SetColumnSpan(lblTotal, 2);

            // btnSave
            btnSave.Text = "Сохранить";
            btnSave.Dock = DockStyle.Fill;
            btnSave.Click += btnSave_Click;
            tableLayout.Controls.Add(btnSave, 0, 4);
            tableLayout.SetColumnSpan(btnSave, 2);

            // Настройки формы
            ClientSize = new Size(500, 400);
            Controls.Add(tableLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            ResumeLayout(false);
        }
    }
}