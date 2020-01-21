namespace NostrumUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.pnlBilling = new System.Windows.Forms.Panel();
            this.lblBlgClient = new System.Windows.Forms.Label();
            this.lblBlgDate = new System.Windows.Forms.Label();
            this.lblBlgTerms = new System.Windows.Forms.Label();
            this.lblBlgInvoice = new System.Windows.Forms.Label();
            this.txtBlgTerms = new System.Windows.Forms.TextBox();
            this.lblblgClientError = new System.Windows.Forms.Label();
            this.txtBlgInvoice = new System.Windows.Forms.TextBox();
            this.lblInvoiceError = new System.Windows.Forms.Label();
            this.dtpBlgDate = new System.Windows.Forms.DateTimePicker();
            this.lblTermDays = new System.Windows.Forms.Label();
            this.cbBlgClient = new System.Windows.Forms.ComboBox();
            this.pnlExpired = new System.Windows.Forms.Panel();
            this.cbDCBatch = new System.Windows.Forms.ComboBox();
            this.lblDCProductError = new System.Windows.Forms.Label();
            this.dtpDCDate = new System.Windows.Forms.DateTimePicker();
            this.lblDCProduct = new System.Windows.Forms.Label();
            this.lblDCQtyError = new System.Windows.Forms.Label();
            this.lblDCBatch = new System.Windows.Forms.Label();
            this.lblDCQty = new System.Windows.Forms.Label();
            this.lblDCBatchError = new System.Windows.Forms.Label();
            this.lblDCDate = new System.Windows.Forms.Label();
            this.cbDCProduct = new System.Windows.Forms.ComboBox();
            this.txtDCQty = new System.Windows.Forms.TextBox();
            this.rbSale = new System.Windows.Forms.RadioButton();
            this.rbDonated = new System.Windows.Forms.RadioButton();
            this.lnkViewOld = new System.Windows.Forms.LinkLabel();
            this.btnBlgClear = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.tabPayment = new System.Windows.Forms.TabPage();
            this.lblPmtInfo = new System.Windows.Forms.Label();
            this.btnPmtView = new System.Windows.Forms.Button();
            this.dtpPmtTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPmtFrm = new System.Windows.Forms.DateTimePicker();
            this.lblPmtTo = new System.Windows.Forms.Label();
            this.lblPmtFrom = new System.Windows.Forms.Label();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOutstanding = new System.Windows.Forms.Button();
            this.cbPmtClient = new System.Windows.Forms.ComboBox();
            this.lblPmtClient = new System.Windows.Forms.Label();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.dtpPurchase = new System.Windows.Forms.DateTimePicker();
            this.lnkEditPdt = new System.Windows.Forms.LinkLabel();
            this.cbDrugType = new System.Windows.Forms.ComboBox();
            this.lblMRPError = new System.Windows.Forms.Label();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtMfr = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblProductError = new System.Windows.Forms.Label();
            this.cbVAT = new System.Windows.Forms.ComboBox();
            this.lblVATError = new System.Windows.Forms.Label();
            this.lblBatchError = new System.Windows.Forms.Label();
            this.lblQtyError = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.dtpMfg = new System.Windows.Forms.DateTimePicker();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblMfr = new System.Windows.Forms.Label();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lblMfg = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.lblClientAddressError = new System.Windows.Forms.Label();
            this.lnkEditClnt = new System.Windows.Forms.LinkLabel();
            this.lblDispError = new System.Windows.Forms.Label();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.txtTINNo = new System.Windows.Forms.TextBox();
            this.txtDLNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblClientError = new System.Windows.Forms.Label();
            this.btnCltClear = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.lblTINNo = new System.Windows.Forms.Label();
            this.lblDLNo = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpStkTo = new System.Windows.Forms.DateTimePicker();
            this.dtpStkFrom = new System.Windows.Forms.DateTimePicker();
            this.lblStkTo = new System.Windows.Forms.Label();
            this.lblStkFrom = new System.Windows.Forms.Label();
            this.cbStkProduct = new System.Windows.Forms.ComboBox();
            this.lblStkProduct = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabBilling.SuspendLayout();
            this.pnlBilling.SuspendLayout();
            this.pnlExpired.SuspendLayout();
            this.tabPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.tabProduct.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.tabStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBilling);
            this.tabControl.Controls.Add(this.tabPayment);
            this.tabControl.Controls.Add(this.tabProduct);
            this.tabControl.Controls.Add(this.tabClient);
            this.tabControl.Controls.Add(this.tabStock);
            this.tabControl.ItemSize = new System.Drawing.Size(42, 18);
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(935, 633);
            this.tabControl.TabIndex = 3;
            // 
            // tabBilling
            // 
            this.tabBilling.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabBilling.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabBilling.BackgroundImage")));
            this.tabBilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabBilling.Controls.Add(this.pnlBilling);
            this.tabBilling.Controls.Add(this.pnlExpired);
            this.tabBilling.Controls.Add(this.rbSale);
            this.tabBilling.Controls.Add(this.rbDonated);
            this.tabBilling.Controls.Add(this.lnkViewOld);
            this.tabBilling.Controls.Add(this.btnBlgClear);
            this.tabBilling.Controls.Add(this.btnBilling);
            this.tabBilling.Location = new System.Drawing.Point(4, 22);
            this.tabBilling.Margin = new System.Windows.Forms.Padding(4);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Padding = new System.Windows.Forms.Padding(4);
            this.tabBilling.Size = new System.Drawing.Size(927, 607);
            this.tabBilling.TabIndex = 3;
            this.tabBilling.Text = "Billing";
            // 
            // pnlBilling
            // 
            this.pnlBilling.BackColor = System.Drawing.Color.Transparent;
            this.pnlBilling.Controls.Add(this.lblBlgClient);
            this.pnlBilling.Controls.Add(this.lblBlgDate);
            this.pnlBilling.Controls.Add(this.lblBlgTerms);
            this.pnlBilling.Controls.Add(this.lblBlgInvoice);
            this.pnlBilling.Controls.Add(this.txtBlgTerms);
            this.pnlBilling.Controls.Add(this.lblblgClientError);
            this.pnlBilling.Controls.Add(this.txtBlgInvoice);
            this.pnlBilling.Controls.Add(this.lblInvoiceError);
            this.pnlBilling.Controls.Add(this.dtpBlgDate);
            this.pnlBilling.Controls.Add(this.lblTermDays);
            this.pnlBilling.Controls.Add(this.cbBlgClient);
            this.pnlBilling.Location = new System.Drawing.Point(180, 133);
            this.pnlBilling.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBilling.Name = "pnlBilling";
            this.pnlBilling.Size = new System.Drawing.Size(559, 192);
            this.pnlBilling.TabIndex = 67;
            // 
            // lblBlgClient
            // 
            this.lblBlgClient.BackColor = System.Drawing.Color.Transparent;
            this.lblBlgClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlgClient.Location = new System.Drawing.Point(12, 14);
            this.lblBlgClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlgClient.Name = "lblBlgClient";
            this.lblBlgClient.Size = new System.Drawing.Size(191, 30);
            this.lblBlgClient.TabIndex = 33;
            this.lblBlgClient.Text = "Client Name";
            // 
            // lblBlgDate
            // 
            this.lblBlgDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBlgDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlgDate.Location = new System.Drawing.Point(12, 50);
            this.lblBlgDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlgDate.Name = "lblBlgDate";
            this.lblBlgDate.Size = new System.Drawing.Size(191, 30);
            this.lblBlgDate.TabIndex = 37;
            this.lblBlgDate.Text = "Date";
            // 
            // lblBlgTerms
            // 
            this.lblBlgTerms.BackColor = System.Drawing.Color.Transparent;
            this.lblBlgTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlgTerms.Location = new System.Drawing.Point(12, 124);
            this.lblBlgTerms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlgTerms.Name = "lblBlgTerms";
            this.lblBlgTerms.Size = new System.Drawing.Size(191, 30);
            this.lblBlgTerms.TabIndex = 39;
            this.lblBlgTerms.Text = "Payment Terms";
            // 
            // lblBlgInvoice
            // 
            this.lblBlgInvoice.BackColor = System.Drawing.Color.Transparent;
            this.lblBlgInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlgInvoice.Location = new System.Drawing.Point(12, 87);
            this.lblBlgInvoice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlgInvoice.Name = "lblBlgInvoice";
            this.lblBlgInvoice.Size = new System.Drawing.Size(191, 30);
            this.lblBlgInvoice.TabIndex = 40;
            this.lblBlgInvoice.Text = "Invoice Number";
            // 
            // txtBlgTerms
            // 
            this.txtBlgTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlgTerms.Location = new System.Drawing.Point(243, 124);
            this.txtBlgTerms.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlgTerms.Name = "txtBlgTerms";
            this.txtBlgTerms.Size = new System.Drawing.Size(53, 26);
            this.txtBlgTerms.TabIndex = 4;
            this.txtBlgTerms.Text = "30";
            // 
            // lblblgClientError
            // 
            this.lblblgClientError.AutoSize = true;
            this.lblblgClientError.BackColor = System.Drawing.Color.Transparent;
            this.lblblgClientError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblblgClientError.ForeColor = System.Drawing.Color.Red;
            this.lblblgClientError.Location = new System.Drawing.Point(521, 15);
            this.lblblgClientError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblblgClientError.Name = "lblblgClientError";
            this.lblblgClientError.Size = new System.Drawing.Size(0, 25);
            this.lblblgClientError.TabIndex = 45;
            // 
            // txtBlgInvoice
            // 
            this.txtBlgInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBlgInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlgInvoice.Location = new System.Drawing.Point(243, 87);
            this.txtBlgInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlgInvoice.Name = "txtBlgInvoice";
            this.txtBlgInvoice.Size = new System.Drawing.Size(264, 26);
            this.txtBlgInvoice.TabIndex = 3;
            // 
            // lblInvoiceError
            // 
            this.lblInvoiceError.AutoSize = true;
            this.lblInvoiceError.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoiceError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceError.ForeColor = System.Drawing.Color.Red;
            this.lblInvoiceError.Location = new System.Drawing.Point(176, 154);
            this.lblInvoiceError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoiceError.Name = "lblInvoiceError";
            this.lblInvoiceError.Size = new System.Drawing.Size(0, 25);
            this.lblInvoiceError.TabIndex = 44;
            // 
            // dtpBlgDate
            // 
            this.dtpBlgDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpBlgDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBlgDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBlgDate.Location = new System.Drawing.Point(243, 50);
            this.dtpBlgDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBlgDate.Name = "dtpBlgDate";
            this.dtpBlgDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpBlgDate.Size = new System.Drawing.Size(148, 26);
            this.dtpBlgDate.TabIndex = 2;
            // 
            // lblTermDays
            // 
            this.lblTermDays.AutoSize = true;
            this.lblTermDays.BackColor = System.Drawing.Color.Transparent;
            this.lblTermDays.Location = new System.Drawing.Point(311, 129);
            this.lblTermDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTermDays.Name = "lblTermDays";
            this.lblTermDays.Size = new System.Drawing.Size(38, 17);
            this.lblTermDays.TabIndex = 41;
            this.lblTermDays.Text = "days";
            // 
            // cbBlgClient
            // 
            this.cbBlgClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBlgClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBlgClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBlgClient.FormattingEnabled = true;
            this.cbBlgClient.Location = new System.Drawing.Point(241, 14);
            this.cbBlgClient.Margin = new System.Windows.Forms.Padding(4);
            this.cbBlgClient.Name = "cbBlgClient";
            this.cbBlgClient.Size = new System.Drawing.Size(265, 28);
            this.cbBlgClient.TabIndex = 1;
            // 
            // pnlExpired
            // 
            this.pnlExpired.BackColor = System.Drawing.Color.Transparent;
            this.pnlExpired.Controls.Add(this.cbDCBatch);
            this.pnlExpired.Controls.Add(this.lblDCProductError);
            this.pnlExpired.Controls.Add(this.dtpDCDate);
            this.pnlExpired.Controls.Add(this.lblDCProduct);
            this.pnlExpired.Controls.Add(this.lblDCQtyError);
            this.pnlExpired.Controls.Add(this.lblDCBatch);
            this.pnlExpired.Controls.Add(this.lblDCQty);
            this.pnlExpired.Controls.Add(this.lblDCBatchError);
            this.pnlExpired.Controls.Add(this.lblDCDate);
            this.pnlExpired.Controls.Add(this.cbDCProduct);
            this.pnlExpired.Controls.Add(this.txtDCQty);
            this.pnlExpired.Location = new System.Drawing.Point(180, 398);
            this.pnlExpired.Margin = new System.Windows.Forms.Padding(4);
            this.pnlExpired.Name = "pnlExpired";
            this.pnlExpired.Size = new System.Drawing.Size(559, 192);
            this.pnlExpired.TabIndex = 66;
            this.pnlExpired.Visible = false;
            // 
            // cbDCBatch
            // 
            this.cbDCBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDCBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDCBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDCBatch.FormattingEnabled = true;
            this.cbDCBatch.Location = new System.Drawing.Point(243, 54);
            this.cbDCBatch.Margin = new System.Windows.Forms.Padding(4);
            this.cbDCBatch.Name = "cbDCBatch";
            this.cbDCBatch.Size = new System.Drawing.Size(263, 28);
            this.cbDCBatch.TabIndex = 2;
            // 
            // lblDCProductError
            // 
            this.lblDCProductError.AutoSize = true;
            this.lblDCProductError.BackColor = System.Drawing.Color.Transparent;
            this.lblDCProductError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCProductError.ForeColor = System.Drawing.Color.Red;
            this.lblDCProductError.Location = new System.Drawing.Point(515, 18);
            this.lblDCProductError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCProductError.Name = "lblDCProductError";
            this.lblDCProductError.Size = new System.Drawing.Size(20, 25);
            this.lblDCProductError.TabIndex = 64;
            this.lblDCProductError.Text = "*";
            // 
            // dtpDCDate
            // 
            this.dtpDCDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDCDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDCDate.Location = new System.Drawing.Point(243, 130);
            this.dtpDCDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDCDate.Name = "dtpDCDate";
            this.dtpDCDate.Size = new System.Drawing.Size(119, 26);
            this.dtpDCDate.TabIndex = 4;
            // 
            // lblDCProduct
            // 
            this.lblDCProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblDCProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCProduct.Location = new System.Drawing.Point(56, 16);
            this.lblDCProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCProduct.Name = "lblDCProduct";
            this.lblDCProduct.Size = new System.Drawing.Size(100, 30);
            this.lblDCProduct.TabIndex = 54;
            this.lblDCProduct.Text = "Product:";
            // 
            // lblDCQtyError
            // 
            this.lblDCQtyError.AutoSize = true;
            this.lblDCQtyError.BackColor = System.Drawing.Color.Transparent;
            this.lblDCQtyError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCQtyError.ForeColor = System.Drawing.Color.Red;
            this.lblDCQtyError.Location = new System.Drawing.Point(372, 96);
            this.lblDCQtyError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCQtyError.Name = "lblDCQtyError";
            this.lblDCQtyError.Size = new System.Drawing.Size(20, 25);
            this.lblDCQtyError.TabIndex = 63;
            this.lblDCQtyError.Text = "*";
            // 
            // lblDCBatch
            // 
            this.lblDCBatch.BackColor = System.Drawing.Color.Transparent;
            this.lblDCBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCBatch.Location = new System.Drawing.Point(56, 53);
            this.lblDCBatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCBatch.Name = "lblDCBatch";
            this.lblDCBatch.Size = new System.Drawing.Size(80, 30);
            this.lblDCBatch.TabIndex = 54;
            this.lblDCBatch.Text = "Batch:";
            // 
            // lblDCQty
            // 
            this.lblDCQty.BackColor = System.Drawing.Color.Transparent;
            this.lblDCQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCQty.Location = new System.Drawing.Point(53, 90);
            this.lblDCQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCQty.Name = "lblDCQty";
            this.lblDCQty.Size = new System.Drawing.Size(103, 30);
            this.lblDCQty.TabIndex = 54;
            this.lblDCQty.Text = "Quantity:";
            // 
            // lblDCBatchError
            // 
            this.lblDCBatchError.AutoSize = true;
            this.lblDCBatchError.BackColor = System.Drawing.Color.Transparent;
            this.lblDCBatchError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCBatchError.ForeColor = System.Drawing.Color.Red;
            this.lblDCBatchError.Location = new System.Drawing.Point(517, 59);
            this.lblDCBatchError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCBatchError.Name = "lblDCBatchError";
            this.lblDCBatchError.Size = new System.Drawing.Size(20, 25);
            this.lblDCBatchError.TabIndex = 63;
            this.lblDCBatchError.Text = "*";
            // 
            // lblDCDate
            // 
            this.lblDCDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDCDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCDate.Location = new System.Drawing.Point(56, 127);
            this.lblDCDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCDate.Name = "lblDCDate";
            this.lblDCDate.Size = new System.Drawing.Size(73, 30);
            this.lblDCDate.TabIndex = 56;
            this.lblDCDate.Text = "Date:";
            // 
            // cbDCProduct
            // 
            this.cbDCProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDCProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDCProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDCProduct.FormattingEnabled = true;
            this.cbDCProduct.Location = new System.Drawing.Point(243, 17);
            this.cbDCProduct.Margin = new System.Windows.Forms.Padding(4);
            this.cbDCProduct.Name = "cbDCProduct";
            this.cbDCProduct.Size = new System.Drawing.Size(263, 28);
            this.cbDCProduct.TabIndex = 1;
            // 
            // txtDCQty
            // 
            this.txtDCQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCQty.Location = new System.Drawing.Point(243, 92);
            this.txtDCQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDCQty.Name = "txtDCQty";
            this.txtDCQty.Size = new System.Drawing.Size(119, 26);
            this.txtDCQty.TabIndex = 3;
            // 
            // rbSale
            // 
            this.rbSale.AutoSize = true;
            this.rbSale.BackColor = System.Drawing.Color.Transparent;
            this.rbSale.Checked = true;
            this.rbSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSale.Location = new System.Drawing.Point(320, 86);
            this.rbSale.Margin = new System.Windows.Forms.Padding(4);
            this.rbSale.Name = "rbSale";
            this.rbSale.Size = new System.Drawing.Size(63, 24);
            this.rbSale.TabIndex = 60;
            this.rbSale.TabStop = true;
            this.rbSale.Text = "Sale";
            this.rbSale.UseVisualStyleBackColor = false;
            // 
            // rbDonated
            // 
            this.rbDonated.AutoSize = true;
            this.rbDonated.BackColor = System.Drawing.Color.Transparent;
            this.rbDonated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDonated.Location = new System.Drawing.Point(452, 86);
            this.rbDonated.Margin = new System.Windows.Forms.Padding(4);
            this.rbDonated.Name = "rbDonated";
            this.rbDonated.Size = new System.Drawing.Size(97, 24);
            this.rbDonated.TabIndex = 58;
            this.rbDonated.Text = "Donation";
            this.rbDonated.UseVisualStyleBackColor = false;
            // 
            // lnkViewOld
            // 
            this.lnkViewOld.AutoSize = true;
            this.lnkViewOld.BackColor = System.Drawing.Color.Transparent;
            this.lnkViewOld.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkViewOld.LinkColor = System.Drawing.Color.Gray;
            this.lnkViewOld.Location = new System.Drawing.Point(771, 21);
            this.lnkViewOld.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkViewOld.Name = "lnkViewOld";
            this.lnkViewOld.Size = new System.Drawing.Size(96, 25);
            this.lnkViewOld.TabIndex = 7;
            this.lnkViewOld.TabStop = true;
            this.lnkViewOld.Text = "View Old";
            // 
            // btnBlgClear
            // 
            this.btnBlgClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlgClear.Location = new System.Drawing.Point(475, 332);
            this.btnBlgClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnBlgClear.Name = "btnBlgClear";
            this.btnBlgClear.Size = new System.Drawing.Size(136, 41);
            this.btnBlgClear.TabIndex = 6;
            this.btnBlgClear.Text = "Clear";
            this.btnBlgClear.UseVisualStyleBackColor = true;
            // 
            // btnBilling
            // 
            this.btnBilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.Location = new System.Drawing.Point(307, 332);
            this.btnBilling.Margin = new System.Windows.Forms.Padding(4);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(124, 41);
            this.btnBilling.TabIndex = 5;
            this.btnBilling.Text = "Billing";
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // tabPayment
            // 
            this.tabPayment.BackColor = System.Drawing.Color.Silver;
            this.tabPayment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPayment.BackgroundImage")));
            this.tabPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPayment.Controls.Add(this.lblPmtInfo);
            this.tabPayment.Controls.Add(this.btnPmtView);
            this.tabPayment.Controls.Add(this.dtpPmtTo);
            this.tabPayment.Controls.Add(this.dtpPmtFrm);
            this.tabPayment.Controls.Add(this.lblPmtTo);
            this.tabPayment.Controls.Add(this.lblPmtFrom);
            this.tabPayment.Controls.Add(this.dgvPayment);
            this.tabPayment.Controls.Add(this.btnOutstanding);
            this.tabPayment.Controls.Add(this.cbPmtClient);
            this.tabPayment.Controls.Add(this.lblPmtClient);
            this.tabPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPayment.Location = new System.Drawing.Point(4, 22);
            this.tabPayment.Margin = new System.Windows.Forms.Padding(4);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.Padding = new System.Windows.Forms.Padding(4);
            this.tabPayment.Size = new System.Drawing.Size(927, 607);
            this.tabPayment.TabIndex = 2;
            this.tabPayment.Text = "Payment";
            // 
            // lblPmtInfo
            // 
            this.lblPmtInfo.AutoSize = true;
            this.lblPmtInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPmtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPmtInfo.ForeColor = System.Drawing.Color.Chocolate;
            this.lblPmtInfo.Location = new System.Drawing.Point(259, 565);
            this.lblPmtInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPmtInfo.Name = "lblPmtInfo";
            this.lblPmtInfo.Size = new System.Drawing.Size(330, 20);
            this.lblPmtInfo.TabIndex = 65;
            this.lblPmtInfo.Text = "* Double click on any row to make payment";
            this.lblPmtInfo.Visible = false;
            // 
            // btnPmtView
            // 
            this.btnPmtView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPmtView.Location = new System.Drawing.Point(288, 252);
            this.btnPmtView.Margin = new System.Windows.Forms.Padding(4);
            this.btnPmtView.Name = "btnPmtView";
            this.btnPmtView.Size = new System.Drawing.Size(163, 42);
            this.btnPmtView.TabIndex = 4;
            this.btnPmtView.Text = "Invoice Details";
            this.btnPmtView.UseVisualStyleBackColor = true;
            // 
            // dtpPmtTo
            // 
            this.dtpPmtTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpPmtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPmtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPmtTo.Location = new System.Drawing.Point(363, 193);
            this.dtpPmtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPmtTo.Name = "dtpPmtTo";
            this.dtpPmtTo.Size = new System.Drawing.Size(143, 26);
            this.dtpPmtTo.TabIndex = 3;
            // 
            // dtpPmtFrm
            // 
            this.dtpPmtFrm.CustomFormat = "dd-MMM-yyyy";
            this.dtpPmtFrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPmtFrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPmtFrm.Location = new System.Drawing.Point(364, 161);
            this.dtpPmtFrm.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPmtFrm.Name = "dtpPmtFrm";
            this.dtpPmtFrm.Size = new System.Drawing.Size(141, 26);
            this.dtpPmtFrm.TabIndex = 2;
            this.dtpPmtFrm.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // lblPmtTo
            // 
            this.lblPmtTo.BackColor = System.Drawing.Color.Transparent;
            this.lblPmtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPmtTo.Location = new System.Drawing.Point(301, 193);
            this.lblPmtTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPmtTo.Name = "lblPmtTo";
            this.lblPmtTo.Size = new System.Drawing.Size(55, 30);
            this.lblPmtTo.TabIndex = 61;
            this.lblPmtTo.Text = "To:";
            // 
            // lblPmtFrom
            // 
            this.lblPmtFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblPmtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPmtFrom.Location = new System.Drawing.Point(283, 160);
            this.lblPmtFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPmtFrom.Name = "lblPmtFrom";
            this.lblPmtFrom.Size = new System.Drawing.Size(73, 30);
            this.lblPmtFrom.TabIndex = 60;
            this.lblPmtFrom.Text = "From:";
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToAddRows = false;
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AllowUserToOrderColumns = true;
            this.dgvPayment.AllowUserToResizeRows = false;
            this.dgvPayment.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPayment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPayment.ColumnHeadersHeight = 25;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invoice,
            this.Client,
            this.Date,
            this.dataGridViewTextBoxColumn1,
            this.Balance});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPayment.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPayment.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPayment.Location = new System.Drawing.Point(208, 316);
            this.dgvPayment.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPayment.MultiSelect = false;
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.ReadOnly = true;
            this.dgvPayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPayment.RowHeadersVisible = false;
            this.dgvPayment.RowTemplate.Height = 25;
            this.dgvPayment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPayment.Size = new System.Drawing.Size(533, 222);
            this.dgvPayment.TabIndex = 6;
            this.dgvPayment.Visible = false;
            // 
            // Invoice
            // 
            this.Invoice.HeaderText = "Invoice No";
            this.Invoice.Name = "Invoice";
            this.Invoice.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.Visible = false;
            // 
            // Date
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // btnOutstanding
            // 
            this.btnOutstanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutstanding.Location = new System.Drawing.Point(483, 252);
            this.btnOutstanding.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutstanding.Name = "btnOutstanding";
            this.btnOutstanding.Size = new System.Drawing.Size(127, 42);
            this.btnOutstanding.TabIndex = 5;
            this.btnOutstanding.Text = "Outstanding";
            this.btnOutstanding.UseVisualStyleBackColor = true;
            // 
            // cbPmtClient
            // 
            this.cbPmtClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPmtClient.FormattingEnabled = true;
            this.cbPmtClient.Location = new System.Drawing.Point(364, 106);
            this.cbPmtClient.Margin = new System.Windows.Forms.Padding(4);
            this.cbPmtClient.Name = "cbPmtClient";
            this.cbPmtClient.Size = new System.Drawing.Size(300, 28);
            this.cbPmtClient.TabIndex = 1;
            // 
            // lblPmtClient
            // 
            this.lblPmtClient.BackColor = System.Drawing.Color.Transparent;
            this.lblPmtClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPmtClient.Location = new System.Drawing.Point(279, 107);
            this.lblPmtClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPmtClient.Name = "lblPmtClient";
            this.lblPmtClient.Size = new System.Drawing.Size(77, 25);
            this.lblPmtClient.TabIndex = 1;
            this.lblPmtClient.Text = "Client :";
            // 
            // tabProduct
            // 
            this.tabProduct.BackColor = System.Drawing.Color.Silver;
            this.tabProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabProduct.BackgroundImage")));
            this.tabProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabProduct.Controls.Add(this.dtpPurchase);
            this.tabProduct.Controls.Add(this.lnkEditPdt);
            this.tabProduct.Controls.Add(this.cbDrugType);
            this.tabProduct.Controls.Add(this.lblMRPError);
            this.tabProduct.Controls.Add(this.txtMRP);
            this.tabProduct.Controls.Add(this.txtInvoice);
            this.tabProduct.Controls.Add(this.txtMfr);
            this.tabProduct.Controls.Add(this.txtQty);
            this.tabProduct.Controls.Add(this.txtBatch);
            this.tabProduct.Controls.Add(this.txtProduct);
            this.tabProduct.Controls.Add(this.lblMRP);
            this.tabProduct.Controls.Add(this.lblProductError);
            this.tabProduct.Controls.Add(this.cbVAT);
            this.tabProduct.Controls.Add(this.lblVATError);
            this.tabProduct.Controls.Add(this.lblBatchError);
            this.tabProduct.Controls.Add(this.lblQtyError);
            this.tabProduct.Controls.Add(this.btnClear);
            this.tabProduct.Controls.Add(this.btnSubmit);
            this.tabProduct.Controls.Add(this.dtpExpiry);
            this.tabProduct.Controls.Add(this.dtpMfg);
            this.tabProduct.Controls.Add(this.lblPurchase);
            this.tabProduct.Controls.Add(this.lblInvoice);
            this.tabProduct.Controls.Add(this.lblMfr);
            this.tabProduct.Controls.Add(this.lblBatch);
            this.tabProduct.Controls.Add(this.lblMfg);
            this.tabProduct.Controls.Add(this.lblExpiry);
            this.tabProduct.Controls.Add(this.lblQty);
            this.tabProduct.Controls.Add(this.lblVat);
            this.tabProduct.Controls.Add(this.lblProduct);
            this.tabProduct.Location = new System.Drawing.Point(4, 22);
            this.tabProduct.Margin = new System.Windows.Forms.Padding(4);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Padding = new System.Windows.Forms.Padding(4);
            this.tabProduct.Size = new System.Drawing.Size(927, 607);
            this.tabProduct.TabIndex = 0;
            this.tabProduct.Text = "Products";
            // 
            // dtpPurchase
            // 
            this.dtpPurchase.CustomFormat = "dd-MMM-yyyy";
            this.dtpPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchase.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchase.Location = new System.Drawing.Point(392, 428);
            this.dtpPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPurchase.Name = "dtpPurchase";
            this.dtpPurchase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpPurchase.Size = new System.Drawing.Size(143, 26);
            this.dtpPurchase.TabIndex = 9;
            // 
            // lnkEditPdt
            // 
            this.lnkEditPdt.AutoSize = true;
            this.lnkEditPdt.BackColor = System.Drawing.Color.Transparent;
            this.lnkEditPdt.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEditPdt.LinkColor = System.Drawing.Color.Gray;
            this.lnkEditPdt.Location = new System.Drawing.Point(812, 4);
            this.lnkEditPdt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkEditPdt.Name = "lnkEditPdt";
            this.lnkEditPdt.Size = new System.Drawing.Size(48, 25);
            this.lnkEditPdt.TabIndex = 44;
            this.lnkEditPdt.TabStop = true;
            this.lnkEditPdt.Text = "Edit";
            // 
            // cbDrugType
            // 
            this.cbDrugType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrugType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDrugType.FormattingEnabled = true;
            this.cbDrugType.Items.AddRange(new object[] {
            "Tablet",
            "Syrup"});
            this.cbDrugType.Location = new System.Drawing.Point(680, 124);
            this.cbDrugType.Margin = new System.Windows.Forms.Padding(4);
            this.cbDrugType.Name = "cbDrugType";
            this.cbDrugType.Size = new System.Drawing.Size(115, 28);
            this.cbDrugType.TabIndex = 2;
            // 
            // lblMRPError
            // 
            this.lblMRPError.AutoSize = true;
            this.lblMRPError.BackColor = System.Drawing.Color.Transparent;
            this.lblMRPError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRPError.ForeColor = System.Drawing.Color.Red;
            this.lblMRPError.Location = new System.Drawing.Point(665, 345);
            this.lblMRPError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMRPError.Name = "lblMRPError";
            this.lblMRPError.Size = new System.Drawing.Size(0, 20);
            this.lblMRPError.TabIndex = 37;
            // 
            // txtMRP
            // 
            this.txtMRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRP.Location = new System.Drawing.Point(392, 347);
            this.txtMRP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(264, 26);
            this.txtMRP.TabIndex = 7;
            // 
            // txtInvoice
            // 
            this.txtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.Location = new System.Drawing.Point(392, 460);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(264, 26);
            this.txtInvoice.TabIndex = 10;
            // 
            // txtMfr
            // 
            this.txtMfr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMfr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMfr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMfr.Location = new System.Drawing.Point(392, 386);
            this.txtMfr.Margin = new System.Windows.Forms.Padding(4);
            this.txtMfr.Name = "txtMfr";
            this.txtMfr.Size = new System.Drawing.Size(264, 26);
            this.txtMfr.TabIndex = 8;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(392, 271);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(264, 26);
            this.txtQty.TabIndex = 5;
            // 
            // txtBatch
            // 
            this.txtBatch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(392, 162);
            this.txtBatch.Margin = new System.Windows.Forms.Padding(4);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(264, 26);
            this.txtBatch.TabIndex = 2;
            // 
            // txtProduct
            // 
            this.txtProduct.AcceptsReturn = true;
            this.txtProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(392, 124);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(264, 26);
            this.txtProduct.TabIndex = 1;
            // 
            // lblMRP
            // 
            this.lblMRP.BackColor = System.Drawing.Color.Transparent;
            this.lblMRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRP.Location = new System.Drawing.Point(169, 345);
            this.lblMRP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(191, 30);
            this.lblMRP.TabIndex = 35;
            this.lblMRP.Text = "MRP";
            // 
            // lblProductError
            // 
            this.lblProductError.AutoSize = true;
            this.lblProductError.BackColor = System.Drawing.Color.Transparent;
            this.lblProductError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductError.ForeColor = System.Drawing.Color.Red;
            this.lblProductError.Location = new System.Drawing.Point(253, 121);
            this.lblProductError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductError.Name = "lblProductError";
            this.lblProductError.Size = new System.Drawing.Size(0, 20);
            this.lblProductError.TabIndex = 34;
            // 
            // cbVAT
            // 
            this.cbVAT.AutoCompleteCustomSource.AddRange(new string[] {
            "14.5",
            "5"});
            this.cbVAT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbVAT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVAT.FormattingEnabled = true;
            this.cbVAT.Items.AddRange(new object[] {
            "12"});
            this.cbVAT.Location = new System.Drawing.Point(392, 308);
            this.cbVAT.Margin = new System.Windows.Forms.Padding(4);
            this.cbVAT.Name = "cbVAT";
            this.cbVAT.Size = new System.Drawing.Size(67, 28);
            this.cbVAT.TabIndex = 6;
            this.cbVAT.Text = "12";
            // 
            // lblVATError
            // 
            this.lblVATError.AutoSize = true;
            this.lblVATError.BackColor = System.Drawing.Color.Transparent;
            this.lblVATError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATError.ForeColor = System.Drawing.Color.Red;
            this.lblVATError.Location = new System.Drawing.Point(665, 305);
            this.lblVATError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVATError.Name = "lblVATError";
            this.lblVATError.Size = new System.Drawing.Size(0, 20);
            this.lblVATError.TabIndex = 32;
            // 
            // lblBatchError
            // 
            this.lblBatchError.AutoSize = true;
            this.lblBatchError.BackColor = System.Drawing.Color.Transparent;
            this.lblBatchError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchError.ForeColor = System.Drawing.Color.Red;
            this.lblBatchError.Location = new System.Drawing.Point(665, 162);
            this.lblBatchError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatchError.Name = "lblBatchError";
            this.lblBatchError.Size = new System.Drawing.Size(0, 20);
            this.lblBatchError.TabIndex = 31;
            // 
            // lblQtyError
            // 
            this.lblQtyError.AutoSize = true;
            this.lblQtyError.BackColor = System.Drawing.Color.Transparent;
            this.lblQtyError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyError.ForeColor = System.Drawing.Color.Red;
            this.lblQtyError.Location = new System.Drawing.Point(665, 268);
            this.lblQtyError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtyError.Name = "lblQtyError";
            this.lblQtyError.Size = new System.Drawing.Size(0, 20);
            this.lblQtyError.TabIndex = 30;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(461, 528);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 36);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(309, 528);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(111, 36);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnAddProduct_click);
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.CustomFormat = "MMM-yy";
            this.dtpExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiry.Location = new System.Drawing.Point(392, 239);
            this.dtpExpiry.Margin = new System.Windows.Forms.Padding(4);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Size = new System.Drawing.Size(99, 26);
            this.dtpExpiry.TabIndex = 4;
            // 
            // dtpMfg
            // 
            this.dtpMfg.CustomFormat = "MMM-yy";
            this.dtpMfg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMfg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMfg.Location = new System.Drawing.Point(391, 199);
            this.dtpMfg.Margin = new System.Windows.Forms.Padding(4);
            this.dtpMfg.Name = "dtpMfg";
            this.dtpMfg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMfg.Size = new System.Drawing.Size(100, 26);
            this.dtpMfg.TabIndex = 3;
            // 
            // lblPurchase
            // 
            this.lblPurchase.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchase.Location = new System.Drawing.Point(169, 418);
            this.lblPurchase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(191, 30);
            this.lblPurchase.TabIndex = 8;
            this.lblPurchase.Text = "Date of Purchase";
            // 
            // lblInvoice
            // 
            this.lblInvoice.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.Location = new System.Drawing.Point(169, 455);
            this.lblInvoice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(191, 30);
            this.lblInvoice.TabIndex = 7;
            this.lblInvoice.Text = "Invoice Number";
            // 
            // lblMfr
            // 
            this.lblMfr.BackColor = System.Drawing.Color.Transparent;
            this.lblMfr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMfr.Location = new System.Drawing.Point(169, 382);
            this.lblMfr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMfr.Name = "lblMfr";
            this.lblMfr.Size = new System.Drawing.Size(191, 30);
            this.lblMfr.TabIndex = 6;
            this.lblMfr.Text = "Manufacturer";
            // 
            // lblBatch
            // 
            this.lblBatch.BackColor = System.Drawing.Color.Transparent;
            this.lblBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatch.Location = new System.Drawing.Point(169, 158);
            this.lblBatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(191, 30);
            this.lblBatch.TabIndex = 5;
            this.lblBatch.Text = "Batch No";
            // 
            // lblMfg
            // 
            this.lblMfg.BackColor = System.Drawing.Color.Transparent;
            this.lblMfg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMfg.Location = new System.Drawing.Point(169, 194);
            this.lblMfg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMfg.Name = "lblMfg";
            this.lblMfg.Size = new System.Drawing.Size(191, 30);
            this.lblMfg.TabIndex = 4;
            this.lblMfg.Text = "Mfg Date";
            // 
            // lblExpiry
            // 
            this.lblExpiry.BackColor = System.Drawing.Color.Transparent;
            this.lblExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiry.Location = new System.Drawing.Point(169, 231);
            this.lblExpiry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(191, 30);
            this.lblExpiry.TabIndex = 3;
            this.lblExpiry.Text = "Expiry Date";
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.Transparent;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(169, 268);
            this.lblQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(191, 30);
            this.lblQty.TabIndex = 2;
            this.lblQty.Text = "Quantity";
            // 
            // lblVat
            // 
            this.lblVat.BackColor = System.Drawing.Color.Transparent;
            this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat.Location = new System.Drawing.Point(169, 305);
            this.lblVat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(191, 30);
            this.lblVat.TabIndex = 1;
            this.lblVat.Text = "VAT";
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(169, 121);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(191, 30);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Product";
            // 
            // tabClient
            // 
            this.tabClient.BackColor = System.Drawing.Color.Silver;
            this.tabClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabClient.BackgroundImage")));
            this.tabClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabClient.Controls.Add(this.lblClientAddressError);
            this.tabClient.Controls.Add(this.lnkEditClnt);
            this.tabClient.Controls.Add(this.lblDispError);
            this.tabClient.Controls.Add(this.txtDisplay);
            this.tabClient.Controls.Add(this.txtTINNo);
            this.tabClient.Controls.Add(this.txtDLNo);
            this.tabClient.Controls.Add(this.txtAddress);
            this.tabClient.Controls.Add(this.txtClient);
            this.tabClient.Controls.Add(this.lblDisplay);
            this.tabClient.Controls.Add(this.lblClientError);
            this.tabClient.Controls.Add(this.btnCltClear);
            this.tabClient.Controls.Add(this.btnAddClient);
            this.tabClient.Controls.Add(this.lblTINNo);
            this.tabClient.Controls.Add(this.lblDLNo);
            this.tabClient.Controls.Add(this.lblAddress);
            this.tabClient.Controls.Add(this.lblClient);
            this.tabClient.Location = new System.Drawing.Point(4, 22);
            this.tabClient.Margin = new System.Windows.Forms.Padding(4);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(4);
            this.tabClient.Size = new System.Drawing.Size(927, 607);
            this.tabClient.TabIndex = 1;
            this.tabClient.Text = "Clients";
            // 
            // lblClientAddressError
            // 
            this.lblClientAddressError.AutoSize = true;
            this.lblClientAddressError.BackColor = System.Drawing.Color.Transparent;
            this.lblClientAddressError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientAddressError.ForeColor = System.Drawing.Color.Red;
            this.lblClientAddressError.Location = new System.Drawing.Point(696, 224);
            this.lblClientAddressError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientAddressError.Name = "lblClientAddressError";
            this.lblClientAddressError.Size = new System.Drawing.Size(109, 20);
            this.lblClientAddressError.TabIndex = 50;
            this.lblClientAddressError.Text = "* Max 5 lines.";
            this.lblClientAddressError.Visible = false;
            // 
            // lnkEditClnt
            // 
            this.lnkEditClnt.AutoSize = true;
            this.lnkEditClnt.BackColor = System.Drawing.Color.Transparent;
            this.lnkEditClnt.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEditClnt.LinkColor = System.Drawing.Color.Gray;
            this.lnkEditClnt.Location = new System.Drawing.Point(816, 17);
            this.lnkEditClnt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkEditClnt.Name = "lnkEditClnt";
            this.lnkEditClnt.Size = new System.Drawing.Size(48, 25);
            this.lnkEditClnt.TabIndex = 49;
            this.lnkEditClnt.TabStop = true;
            this.lnkEditClnt.Text = "Edit";
            // 
            // lblDispError
            // 
            this.lblDispError.AutoSize = true;
            this.lblDispError.BackColor = System.Drawing.Color.Transparent;
            this.lblDispError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDispError.ForeColor = System.Drawing.Color.Red;
            this.lblDispError.Location = new System.Drawing.Point(697, 182);
            this.lblDispError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDispError.Name = "lblDispError";
            this.lblDispError.Size = new System.Drawing.Size(0, 20);
            this.lblDispError.TabIndex = 48;
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(416, 178);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(264, 26);
            this.txtDisplay.TabIndex = 2;
            // 
            // txtTINNo
            // 
            this.txtTINNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTINNo.Location = new System.Drawing.Point(415, 399);
            this.txtTINNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTINNo.Name = "txtTINNo";
            this.txtTINNo.Size = new System.Drawing.Size(264, 26);
            this.txtTINNo.TabIndex = 6;
            // 
            // txtDLNo
            // 
            this.txtDLNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLNo.Location = new System.Drawing.Point(415, 358);
            this.txtDLNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDLNo.Name = "txtDLNo";
            this.txtDLNo.Size = new System.Drawing.Size(264, 26);
            this.txtDLNo.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.AcceptsReturn = true;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(415, 215);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(264, 132);
            this.txtAddress.TabIndex = 3;
            // 
            // txtClient
            // 
            this.txtClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.Location = new System.Drawing.Point(415, 138);
            this.txtClient.Margin = new System.Windows.Forms.Padding(4);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(264, 26);
            this.txtClient.TabIndex = 1;
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(193, 174);
            this.lblDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(191, 30);
            this.lblDisplay.TabIndex = 46;
            this.lblDisplay.Text = "Display name";
            // 
            // lblClientError
            // 
            this.lblClientError.AutoSize = true;
            this.lblClientError.BackColor = System.Drawing.Color.Transparent;
            this.lblClientError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientError.ForeColor = System.Drawing.Color.Red;
            this.lblClientError.Location = new System.Drawing.Point(696, 142);
            this.lblClientError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientError.Name = "lblClientError";
            this.lblClientError.Size = new System.Drawing.Size(0, 20);
            this.lblClientError.TabIndex = 45;
            // 
            // btnCltClear
            // 
            this.btnCltClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCltClear.Location = new System.Drawing.Point(484, 465);
            this.btnCltClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCltClear.Name = "btnCltClear";
            this.btnCltClear.Size = new System.Drawing.Size(148, 41);
            this.btnCltClear.TabIndex = 8;
            this.btnCltClear.Text = "Clear";
            this.btnCltClear.UseVisualStyleBackColor = true;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.Location = new System.Drawing.Point(316, 465);
            this.btnAddClient.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(148, 41);
            this.btnAddClient.TabIndex = 7;
            this.btnAddClient.Text = "Add";
            this.btnAddClient.UseVisualStyleBackColor = true;
            // 
            // lblTINNo
            // 
            this.lblTINNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTINNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTINNo.Location = new System.Drawing.Point(192, 396);
            this.lblTINNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTINNo.Name = "lblTINNo";
            this.lblTINNo.Size = new System.Drawing.Size(191, 30);
            this.lblTINNo.TabIndex = 39;
            this.lblTINNo.Text = "TIN No";
            // 
            // lblDLNo
            // 
            this.lblDLNo.BackColor = System.Drawing.Color.Transparent;
            this.lblDLNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLNo.Location = new System.Drawing.Point(192, 358);
            this.lblDLNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDLNo.Name = "lblDLNo";
            this.lblDLNo.Size = new System.Drawing.Size(191, 30);
            this.lblDLNo.TabIndex = 38;
            this.lblDLNo.Text = "D/L No";
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(192, 215);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(191, 30);
            this.lblAddress.TabIndex = 33;
            this.lblAddress.Text = "Address";
            // 
            // lblClient
            // 
            this.lblClient.BackColor = System.Drawing.Color.Transparent;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(192, 134);
            this.lblClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(191, 30);
            this.lblClient.TabIndex = 32;
            this.lblClient.Text = "Client Name";
            // 
            // tabStock
            // 
            this.tabStock.BackColor = System.Drawing.Color.Silver;
            this.tabStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabStock.BackgroundImage")));
            this.tabStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabStock.Controls.Add(this.btnShow);
            this.tabStock.Controls.Add(this.dtpStkTo);
            this.tabStock.Controls.Add(this.dtpStkFrom);
            this.tabStock.Controls.Add(this.lblStkTo);
            this.tabStock.Controls.Add(this.lblStkFrom);
            this.tabStock.Controls.Add(this.cbStkProduct);
            this.tabStock.Controls.Add(this.lblStkProduct);
            this.tabStock.Location = new System.Drawing.Point(4, 22);
            this.tabStock.Margin = new System.Windows.Forms.Padding(4);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(4);
            this.tabStock.Size = new System.Drawing.Size(927, 607);
            this.tabStock.TabIndex = 4;
            this.tabStock.Text = "Stock";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(464, 206);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(109, 36);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "show";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // dtpStkTo
            // 
            this.dtpStkTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpStkTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStkTo.Location = new System.Drawing.Point(289, 225);
            this.dtpStkTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStkTo.Name = "dtpStkTo";
            this.dtpStkTo.Size = new System.Drawing.Size(135, 26);
            this.dtpStkTo.TabIndex = 3;
            // 
            // dtpStkFrom
            // 
            this.dtpStkFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpStkFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStkFrom.Location = new System.Drawing.Point(291, 193);
            this.dtpStkFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStkFrom.Name = "dtpStkFrom";
            this.dtpStkFrom.Size = new System.Drawing.Size(133, 26);
            this.dtpStkFrom.TabIndex = 2;
            this.dtpStkFrom.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // lblStkTo
            // 
            this.lblStkTo.BackColor = System.Drawing.Color.Transparent;
            this.lblStkTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStkTo.Location = new System.Drawing.Point(228, 225);
            this.lblStkTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStkTo.Name = "lblStkTo";
            this.lblStkTo.Size = new System.Drawing.Size(55, 30);
            this.lblStkTo.TabIndex = 57;
            this.lblStkTo.Text = "To:";
            // 
            // lblStkFrom
            // 
            this.lblStkFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblStkFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStkFrom.Location = new System.Drawing.Point(209, 192);
            this.lblStkFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStkFrom.Name = "lblStkFrom";
            this.lblStkFrom.Size = new System.Drawing.Size(73, 30);
            this.lblStkFrom.TabIndex = 56;
            this.lblStkFrom.Text = "From:";
            // 
            // cbStkProduct
            // 
            this.cbStkProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStkProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbStkProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStkProduct.FormattingEnabled = true;
            this.cbStkProduct.Location = new System.Drawing.Point(291, 128);
            this.cbStkProduct.Margin = new System.Windows.Forms.Padding(4);
            this.cbStkProduct.Name = "cbStkProduct";
            this.cbStkProduct.Size = new System.Drawing.Size(367, 28);
            this.cbStkProduct.TabIndex = 1;
            // 
            // lblStkProduct
            // 
            this.lblStkProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblStkProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStkProduct.Location = new System.Drawing.Point(180, 126);
            this.lblStkProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStkProduct.Name = "lblStkProduct";
            this.lblStkProduct.Size = new System.Drawing.Size(103, 30);
            this.lblStkProduct.TabIndex = 54;
            this.lblStkProduct.Text = "Product:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 630);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Nostrum";
            this.tabControl.ResumeLayout(false);
            this.tabBilling.ResumeLayout(false);
            this.tabBilling.PerformLayout();
            this.pnlBilling.ResumeLayout(false);
            this.pnlBilling.PerformLayout();
            this.pnlExpired.ResumeLayout(false);
            this.pnlExpired.PerformLayout();
            this.tabPayment.ResumeLayout(false);
            this.tabPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.tabProduct.ResumeLayout(false);
            this.tabProduct.PerformLayout();
            this.tabClient.ResumeLayout(false);
            this.tabClient.PerformLayout();
            this.tabStock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.Panel pnlBilling;
        private System.Windows.Forms.Label lblBlgClient;
        private System.Windows.Forms.Label lblBlgDate;
        private System.Windows.Forms.Label lblBlgTerms;
        private System.Windows.Forms.Label lblBlgInvoice;
        private System.Windows.Forms.TextBox txtBlgTerms;
        private System.Windows.Forms.Label lblblgClientError;
        private System.Windows.Forms.TextBox txtBlgInvoice;
        private System.Windows.Forms.Label lblInvoiceError;
        private System.Windows.Forms.DateTimePicker dtpBlgDate;
        private System.Windows.Forms.Label lblTermDays;
        private System.Windows.Forms.ComboBox cbBlgClient;
        private System.Windows.Forms.Panel pnlExpired;
        private System.Windows.Forms.ComboBox cbDCBatch;
        private System.Windows.Forms.Label lblDCProductError;
        private System.Windows.Forms.DateTimePicker dtpDCDate;
        private System.Windows.Forms.Label lblDCProduct;
        private System.Windows.Forms.Label lblDCQtyError;
        private System.Windows.Forms.Label lblDCBatch;
        private System.Windows.Forms.Label lblDCQty;
        private System.Windows.Forms.Label lblDCBatchError;
        private System.Windows.Forms.Label lblDCDate;
        private System.Windows.Forms.ComboBox cbDCProduct;
        private System.Windows.Forms.TextBox txtDCQty;
        private System.Windows.Forms.RadioButton rbSale;
        private System.Windows.Forms.RadioButton rbDonated;
        private System.Windows.Forms.LinkLabel lnkViewOld;
        private System.Windows.Forms.Button btnBlgClear;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.TabPage tabPayment;
        private System.Windows.Forms.Label lblPmtInfo;
        private System.Windows.Forms.Button btnPmtView;
        private System.Windows.Forms.DateTimePicker dtpPmtTo;
        private System.Windows.Forms.DateTimePicker dtpPmtFrm;
        private System.Windows.Forms.Label lblPmtTo;
        private System.Windows.Forms.Label lblPmtFrom;
        protected System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.Button btnOutstanding;
        private System.Windows.Forms.ComboBox cbPmtClient;
        private System.Windows.Forms.Label lblPmtClient;
        private System.Windows.Forms.TabPage tabProduct;
        private System.Windows.Forms.DateTimePicker dtpPurchase;
        private System.Windows.Forms.LinkLabel lnkEditPdt;
        private System.Windows.Forms.ComboBox cbDrugType;
        private System.Windows.Forms.Label lblMRPError;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtMfr;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblProductError;
        private System.Windows.Forms.ComboBox cbVAT;
        private System.Windows.Forms.Label lblVATError;
        private System.Windows.Forms.Label lblBatchError;
        private System.Windows.Forms.Label lblQtyError;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.DateTimePicker dtpMfg;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblMfr;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.Label lblMfg;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.Label lblClientAddressError;
        private System.Windows.Forms.LinkLabel lnkEditClnt;
        private System.Windows.Forms.Label lblDispError;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.TextBox txtTINNo;
        private System.Windows.Forms.TextBox txtDLNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblClientError;
        private System.Windows.Forms.Button btnCltClear;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Label lblTINNo;
        private System.Windows.Forms.Label lblDLNo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtpStkTo;
        private System.Windows.Forms.DateTimePicker dtpStkFrom;
        private System.Windows.Forms.Label lblStkTo;
        private System.Windows.Forms.Label lblStkFrom;
        private System.Windows.Forms.ComboBox cbStkProduct;
        private System.Windows.Forms.Label lblStkProduct;
    }
}

