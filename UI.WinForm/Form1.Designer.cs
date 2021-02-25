using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI.WinForm
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.btnSortOperationsByRemainingDay = new System.Windows.Forms.Button();
            this.btnUpdateOperation = new System.Windows.Forms.Button();
            this.tbOperation = new System.Windows.Forms.TextBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.gbxReminder = new System.Windows.Forms.GroupBox();
            this.btnRemindDate = new System.Windows.Forms.Button();
            this.cbReminder = new System.Windows.Forms.ComboBox();
            this.gbxOperation = new System.Windows.Forms.GroupBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.btnInsertOperation = new System.Windows.Forms.Button();
            this.lblReminderDate = new System.Windows.Forms.Label();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.lblPaid = new System.Windows.Forms.Label();
            this.tbPaid = new System.Windows.Forms.TextBox();
            this.dtpReminderDate = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteOperation = new System.Windows.Forms.Button();
            this.dtpOperationDate = new System.Windows.Forms.DateTimePicker();
            this.lblOperationDate = new System.Windows.Forms.Label();
            this.gbxContact = new System.Windows.Forms.GroupBox();
            this.btnSendErrorLog = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.lblTelNo = new System.Windows.Forms.Label();
            this.tbTelNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxSpecial = new System.Windows.Forms.GroupBox();
            this.gbxTotal = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGetAllDebtor = new System.Windows.Forms.Button();
            this.btnSortByName = new System.Windows.Forms.Button();
            this.btnGetAllCustomers = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxCustomer = new System.Windows.Forms.GroupBox();
            this.btnGetOperationsByCustomerID = new System.Windows.Forms.Button();
            this.lblAdress = new System.Windows.Forms.Label();
            this.btnInsertCustomer = new System.Windows.Forms.Button();
            this.btnGetCustomerByName = new System.Windows.Forms.Button();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxReminder.SuspendLayout();
            this.gbxOperation.SuspendLayout();
            this.gbxContact.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.gbxSpecial.SuspendLayout();
            this.gbxTotal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbxCustomer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbInfo.Location = new System.Drawing.Point(271, 332);
            this.tbInfo.MaxLength = 255;
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(277, 119);
            this.tbInfo.TabIndex = 9;
            // 
            // btnSortOperationsByRemainingDay
            // 
            this.btnSortOperationsByRemainingDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSortOperationsByRemainingDay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSortOperationsByRemainingDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSortOperationsByRemainingDay.Location = new System.Drawing.Point(645, 361);
            this.btnSortOperationsByRemainingDay.Name = "btnSortOperationsByRemainingDay";
            this.btnSortOperationsByRemainingDay.Size = new System.Drawing.Size(155, 65);
            this.btnSortOperationsByRemainingDay.TabIndex = 36;
            this.btnSortOperationsByRemainingDay.Text = "İşlemleri Kalan Güne Göre Sırala";
            this.btnSortOperationsByRemainingDay.UseVisualStyleBackColor = true;
            this.btnSortOperationsByRemainingDay.Click += new System.EventHandler(this.btnSortOperationsByRemainingDay_Click);
            // 
            // btnUpdateOperation
            // 
            this.btnUpdateOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateOperation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateOperation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateOperation.Location = new System.Drawing.Point(645, 151);
            this.btnUpdateOperation.Name = "btnUpdateOperation";
            this.btnUpdateOperation.Size = new System.Drawing.Size(155, 65);
            this.btnUpdateOperation.TabIndex = 32;
            this.btnUpdateOperation.Text = "İşlem Güncelle";
            this.btnUpdateOperation.UseVisualStyleBackColor = true;
            this.btnUpdateOperation.Click += new System.EventHandler(this.btnUpdateOperation_Click);
            // 
            // tbOperation
            // 
            this.tbOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbOperation.Location = new System.Drawing.Point(280, 35);
            this.tbOperation.MaxLength = 255;
            this.tbOperation.Multiline = true;
            this.tbOperation.Name = "tbOperation";
            this.tbOperation.Size = new System.Drawing.Size(277, 119);
            this.tbOperation.TabIndex = 11;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAbout.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAbout.Location = new System.Drawing.Point(209, 37);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(155, 65);
            this.btnAbout.TabIndex = 33;
            this.btnAbout.Text = "Hakkında";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // gbxReminder
            // 
            this.gbxReminder.BackColor = System.Drawing.Color.Transparent;
            this.gbxReminder.Controls.Add(this.btnRemindDate);
            this.gbxReminder.Controls.Add(this.cbReminder);
            this.gbxReminder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxReminder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxReminder.ForeColor = System.Drawing.Color.White;
            this.gbxReminder.Location = new System.Drawing.Point(3, 3);
            this.gbxReminder.Name = "gbxReminder";
            this.gbxReminder.Size = new System.Drawing.Size(393, 125);
            this.gbxReminder.TabIndex = 51;
            this.gbxReminder.TabStop = false;
            this.gbxReminder.Text = "Hatırlatıcı";
            // 
            // btnRemindDate
            // 
            this.btnRemindDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemindDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRemindDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemindDate.Location = new System.Drawing.Point(209, 36);
            this.btnRemindDate.Name = "btnRemindDate";
            this.btnRemindDate.Size = new System.Drawing.Size(155, 65);
            this.btnRemindDate.TabIndex = 27;
            this.btnRemindDate.Text = "Günden Az Kalanlar";
            this.btnRemindDate.UseVisualStyleBackColor = true;
            this.btnRemindDate.Click += new System.EventHandler(this.btnRemindDate_Click);
            // 
            // cbReminder
            // 
            this.cbReminder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbReminder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReminder.FormattingEnabled = true;
            this.cbReminder.Items.AddRange(new object[] {
            "1",
            "3",
            "7",
            "15",
            "30"});
            this.cbReminder.Location = new System.Drawing.Point(44, 56);
            this.cbReminder.Name = "cbReminder";
            this.cbReminder.Size = new System.Drawing.Size(121, 26);
            this.cbReminder.TabIndex = 0;
            // 
            // gbxOperation
            // 
            this.gbxOperation.BackColor = System.Drawing.Color.Transparent;
            this.gbxOperation.Controls.Add(this.btnSortOperationsByRemainingDay);
            this.gbxOperation.Controls.Add(this.btnUpdateOperation);
            this.gbxOperation.Controls.Add(this.tbOperation);
            this.gbxOperation.Controls.Add(this.lblCost);
            this.gbxOperation.Controls.Add(this.lblOperation);
            this.gbxOperation.Controls.Add(this.btnInsertOperation);
            this.gbxOperation.Controls.Add(this.lblReminderDate);
            this.gbxOperation.Controls.Add(this.tbCost);
            this.gbxOperation.Controls.Add(this.lblPaid);
            this.gbxOperation.Controls.Add(this.tbPaid);
            this.gbxOperation.Controls.Add(this.dtpReminderDate);
            this.gbxOperation.Controls.Add(this.btnDeleteOperation);
            this.gbxOperation.Controls.Add(this.dtpOperationDate);
            this.gbxOperation.Controls.Add(this.lblOperationDate);
            this.gbxOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxOperation.Enabled = false;
            this.gbxOperation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxOperation.ForeColor = System.Drawing.Color.White;
            this.gbxOperation.Location = new System.Drawing.Point(841, 3);
            this.gbxOperation.Name = "gbxOperation";
            this.gbxOperation.Size = new System.Drawing.Size(832, 474);
            this.gbxOperation.TabIndex = 49;
            this.gbxOperation.TabStop = false;
            this.gbxOperation.Text = "İşlem";
            // 
            // lblCost
            // 
            this.lblCost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(43, 207);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(58, 18);
            this.lblCost.TabIndex = 12;
            this.lblCost.Text = "Tutar:";
            // 
            // lblOperation
            // 
            this.lblOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOperation.AutoSize = true;
            this.lblOperation.Location = new System.Drawing.Point(43, 38);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(125, 18);
            this.lblOperation.TabIndex = 10;
            this.lblOperation.Text = "Yapılan İşlem:";
            // 
            // btnInsertOperation
            // 
            this.btnInsertOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsertOperation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInsertOperation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInsertOperation.Location = new System.Drawing.Point(645, 54);
            this.btnInsertOperation.Name = "btnInsertOperation";
            this.btnInsertOperation.Size = new System.Drawing.Size(155, 65);
            this.btnInsertOperation.TabIndex = 28;
            this.btnInsertOperation.Text = "İşlem Ekle";
            this.btnInsertOperation.UseVisualStyleBackColor = true;
            this.btnInsertOperation.Click += new System.EventHandler(this.btnInsertOperation_Click);
            // 
            // lblReminderDate
            // 
            this.lblReminderDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblReminderDate.AutoSize = true;
            this.lblReminderDate.Location = new System.Drawing.Point(43, 422);
            this.lblReminderDate.Name = "lblReminderDate";
            this.lblReminderDate.Size = new System.Drawing.Size(151, 18);
            this.lblReminderDate.TabIndex = 19;
            this.lblReminderDate.Text = "Hatırlatma Tarihi:";
            // 
            // tbCost
            // 
            this.tbCost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCost.Location = new System.Drawing.Point(280, 204);
            this.tbCost.MaxLength = 6;
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(277, 26);
            this.tbCost.TabIndex = 13;
            // 
            // lblPaid
            // 
            this.lblPaid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPaid.AutoSize = true;
            this.lblPaid.Location = new System.Drawing.Point(43, 275);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(77, 18);
            this.lblPaid.TabIndex = 14;
            this.lblPaid.Text = "Ödenen:";
            // 
            // tbPaid
            // 
            this.tbPaid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPaid.Location = new System.Drawing.Point(280, 270);
            this.tbPaid.MaxLength = 6;
            this.tbPaid.Name = "tbPaid";
            this.tbPaid.Size = new System.Drawing.Size(277, 26);
            this.tbPaid.TabIndex = 15;
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpReminderDate.Location = new System.Drawing.Point(280, 416);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.Size = new System.Drawing.Size(277, 26);
            this.dtpReminderDate.TabIndex = 18;
            // 
            // btnDeleteOperation
            // 
            this.btnDeleteOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteOperation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteOperation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteOperation.Location = new System.Drawing.Point(645, 256);
            this.btnDeleteOperation.Name = "btnDeleteOperation";
            this.btnDeleteOperation.Size = new System.Drawing.Size(155, 65);
            this.btnDeleteOperation.TabIndex = 24;
            this.btnDeleteOperation.Text = "İşlem Sil";
            this.btnDeleteOperation.UseVisualStyleBackColor = true;
            this.btnDeleteOperation.Click += new System.EventHandler(this.btnDeleteOperation_Click);
            // 
            // dtpOperationDate
            // 
            this.dtpOperationDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpOperationDate.Location = new System.Drawing.Point(280, 345);
            this.dtpOperationDate.Name = "dtpOperationDate";
            this.dtpOperationDate.Size = new System.Drawing.Size(277, 26);
            this.dtpOperationDate.TabIndex = 16;
            // 
            // lblOperationDate
            // 
            this.lblOperationDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOperationDate.AutoSize = true;
            this.lblOperationDate.Location = new System.Drawing.Point(43, 350);
            this.lblOperationDate.Name = "lblOperationDate";
            this.lblOperationDate.Size = new System.Drawing.Size(111, 18);
            this.lblOperationDate.TabIndex = 17;
            this.lblOperationDate.Text = "İşlem Tarihi:";
            // 
            // gbxContact
            // 
            this.gbxContact.BackColor = System.Drawing.Color.Transparent;
            this.gbxContact.Controls.Add(this.btnSendErrorLog);
            this.gbxContact.Controls.Add(this.btnAbout);
            this.gbxContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxContact.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxContact.ForeColor = System.Drawing.Color.White;
            this.gbxContact.Location = new System.Drawing.Point(3, 351);
            this.gbxContact.Name = "gbxContact";
            this.gbxContact.Size = new System.Drawing.Size(393, 121);
            this.gbxContact.TabIndex = 53;
            this.gbxContact.TabStop = false;
            this.gbxContact.Text = "İletişim";
            // 
            // btnSendErrorLog
            // 
            this.btnSendErrorLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSendErrorLog.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendErrorLog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendErrorLog.Location = new System.Drawing.Point(31, 37);
            this.btnSendErrorLog.Name = "btnSendErrorLog";
            this.btnSendErrorLog.Size = new System.Drawing.Size(155, 65);
            this.btnSendErrorLog.TabIndex = 34;
            this.btnSendErrorLog.Text = "Hata Kaydını Raporla";
            this.btnSendErrorLog.UseVisualStyleBackColor = true;
            this.btnSendErrorLog.Click += new System.EventHandler(this.btnSendErrorLog_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(42, 57);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(117, 18);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Müşteri İsim:";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCustomerName.Location = new System.Drawing.Point(271, 54);
            this.tbCustomerName.MaxLength = 50;
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(277, 26);
            this.tbCustomerName.TabIndex = 3;
            // 
            // lblTelNo
            // 
            this.lblTelNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTelNo.AutoSize = true;
            this.lblTelNo.Location = new System.Drawing.Point(42, 121);
            this.lblTelNo.Name = "lblTelNo";
            this.lblTelNo.Size = new System.Drawing.Size(157, 18);
            this.lblTelNo.TabIndex = 4;
            this.lblTelNo.Text = "Telefon Numarası:";
            // 
            // tbTelNo
            // 
            this.tbTelNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbTelNo.Location = new System.Drawing.Point(271, 118);
            this.tbTelNo.MaxLength = 20;
            this.tbTelNo.Name = "tbTelNo";
            this.tbTelNo.Size = new System.Drawing.Size(277, 26);
            this.tbTelNo.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.12F));
            this.tableLayoutPanel3.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 489);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 481F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1676, 481);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1265, 472);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.gbxContact, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.gbxReminder, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.gbxSpecial, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1274, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.57895F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.68421F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.52632F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(399, 475);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // gbxSpecial
            // 
            this.gbxSpecial.BackColor = System.Drawing.Color.Transparent;
            this.gbxSpecial.Controls.Add(this.gbxTotal);
            this.gbxSpecial.Controls.Add(this.btnGetAllDebtor);
            this.gbxSpecial.Controls.Add(this.btnSortByName);
            this.gbxSpecial.Controls.Add(this.btnGetAllCustomers);
            this.gbxSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSpecial.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxSpecial.ForeColor = System.Drawing.Color.White;
            this.gbxSpecial.Location = new System.Drawing.Point(3, 134);
            this.gbxSpecial.Name = "gbxSpecial";
            this.gbxSpecial.Size = new System.Drawing.Size(393, 211);
            this.gbxSpecial.TabIndex = 52;
            this.gbxSpecial.TabStop = false;
            this.gbxSpecial.Text = "Özel";
            // 
            // gbxTotal
            // 
            this.gbxTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbxTotal.Controls.Add(this.lblTotal);
            this.gbxTotal.ForeColor = System.Drawing.Color.White;
            this.gbxTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbxTotal.Location = new System.Drawing.Point(209, 107);
            this.gbxTotal.Name = "gbxTotal";
            this.gbxTotal.Size = new System.Drawing.Size(155, 76);
            this.gbxTotal.TabIndex = 38;
            this.gbxTotal.TabStop = false;
            this.gbxTotal.Text = "Toplam";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.Location = new System.Drawing.Point(6, 32);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(143, 22);
            this.lblTotal.TabIndex = 37;
            this.lblTotal.Text = "total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetAllDebtor
            // 
            this.btnGetAllDebtor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetAllDebtor.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetAllDebtor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetAllDebtor.Location = new System.Drawing.Point(209, 36);
            this.btnGetAllDebtor.Name = "btnGetAllDebtor";
            this.btnGetAllDebtor.Size = new System.Drawing.Size(155, 65);
            this.btnGetAllDebtor.TabIndex = 29;
            this.btnGetAllDebtor.Text = "Borcu Olanları Görüntüle";
            this.btnGetAllDebtor.UseVisualStyleBackColor = true;
            this.btnGetAllDebtor.Click += new System.EventHandler(this.btnGetAllDebtor_Click);
            // 
            // btnSortByName
            // 
            this.btnSortByName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSortByName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSortByName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSortByName.Location = new System.Drawing.Point(31, 118);
            this.btnSortByName.Name = "btnSortByName";
            this.btnSortByName.Size = new System.Drawing.Size(155, 65);
            this.btnSortByName.TabIndex = 0;
            this.btnSortByName.Text = "Ada Göre Sırala";
            this.btnSortByName.UseVisualStyleBackColor = true;
            this.btnSortByName.Click += new System.EventHandler(this.btnSortByName_Click);
            // 
            // btnGetAllCustomers
            // 
            this.btnGetAllCustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetAllCustomers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetAllCustomers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetAllCustomers.Location = new System.Drawing.Point(31, 36);
            this.btnGetAllCustomers.Name = "btnGetAllCustomers";
            this.btnGetAllCustomers.Size = new System.Drawing.Size(155, 65);
            this.btnGetAllCustomers.TabIndex = 35;
            this.btnGetAllCustomers.Text = "Müşterileri Görüntüle";
            this.btnGetAllCustomers.UseVisualStyleBackColor = true;
            this.btnGetAllCustomers.Click += new System.EventHandler(this.btnGetAllCustomers_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gbxOperation, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbxCustomer, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1676, 480);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Click += new System.EventHandler(this.tableLayoutPanel2_Click);
            // 
            // gbxCustomer
            // 
            this.gbxCustomer.BackColor = System.Drawing.Color.Transparent;
            this.gbxCustomer.Controls.Add(this.lblCustomerName);
            this.gbxCustomer.Controls.Add(this.tbCustomerName);
            this.gbxCustomer.Controls.Add(this.lblTelNo);
            this.gbxCustomer.Controls.Add(this.tbTelNo);
            this.gbxCustomer.Controls.Add(this.btnGetOperationsByCustomerID);
            this.gbxCustomer.Controls.Add(this.lblAdress);
            this.gbxCustomer.Controls.Add(this.btnInsertCustomer);
            this.gbxCustomer.Controls.Add(this.btnGetCustomerByName);
            this.gbxCustomer.Controls.Add(this.tbAdress);
            this.gbxCustomer.Controls.Add(this.btnDeleteCustomer);
            this.gbxCustomer.Controls.Add(this.lblInfo);
            this.gbxCustomer.Controls.Add(this.btnUpdateCustomer);
            this.gbxCustomer.Controls.Add(this.tbInfo);
            this.gbxCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxCustomer.ForeColor = System.Drawing.Color.White;
            this.gbxCustomer.Location = new System.Drawing.Point(3, 3);
            this.gbxCustomer.Name = "gbxCustomer";
            this.gbxCustomer.Size = new System.Drawing.Size(832, 474);
            this.gbxCustomer.TabIndex = 47;
            this.gbxCustomer.TabStop = false;
            this.gbxCustomer.Text = "Müşteri Bilgiler";
            // 
            // btnGetOperationsByCustomerID
            // 
            this.btnGetOperationsByCustomerID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetOperationsByCustomerID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetOperationsByCustomerID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetOperationsByCustomerID.Location = new System.Drawing.Point(636, 386);
            this.btnGetOperationsByCustomerID.Name = "btnGetOperationsByCustomerID";
            this.btnGetOperationsByCustomerID.Size = new System.Drawing.Size(155, 65);
            this.btnGetOperationsByCustomerID.TabIndex = 30;
            this.btnGetOperationsByCustomerID.Text = "Müşteri İşlem Görüntüle";
            this.btnGetOperationsByCustomerID.UseVisualStyleBackColor = true;
            this.btnGetOperationsByCustomerID.Click += new System.EventHandler(this.btnGetOperationsByCustomerID_Click);
            // 
            // lblAdress
            // 
            this.lblAdress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAdress.AutoSize = true;
            this.lblAdress.Location = new System.Drawing.Point(42, 177);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(62, 18);
            this.lblAdress.TabIndex = 6;
            this.lblAdress.Text = "Adres:";
            // 
            // btnInsertCustomer
            // 
            this.btnInsertCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsertCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInsertCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInsertCustomer.Location = new System.Drawing.Point(636, 25);
            this.btnInsertCustomer.Name = "btnInsertCustomer";
            this.btnInsertCustomer.Size = new System.Drawing.Size(155, 65);
            this.btnInsertCustomer.TabIndex = 25;
            this.btnInsertCustomer.Text = "Müşteri Ekle";
            this.btnInsertCustomer.UseVisualStyleBackColor = true;
            this.btnInsertCustomer.Click += new System.EventHandler(this.btnInsertCustomer_Click);
            // 
            // btnGetCustomerByName
            // 
            this.btnGetCustomerByName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetCustomerByName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetCustomerByName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetCustomerByName.Location = new System.Drawing.Point(636, 294);
            this.btnGetCustomerByName.Name = "btnGetCustomerByName";
            this.btnGetCustomerByName.Size = new System.Drawing.Size(155, 65);
            this.btnGetCustomerByName.TabIndex = 23;
            this.btnGetCustomerByName.Text = "İsimden Müşteri Ara";
            this.btnGetCustomerByName.UseVisualStyleBackColor = true;
            this.btnGetCustomerByName.Click += new System.EventHandler(this.btnGetCustomerByName_Click);
            // 
            // tbAdress
            // 
            this.tbAdress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbAdress.Location = new System.Drawing.Point(271, 177);
            this.tbAdress.MaxLength = 150;
            this.tbAdress.Multiline = true;
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(277, 119);
            this.tbAdress.TabIndex = 7;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(636, 204);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(155, 65);
            this.btnDeleteCustomer.TabIndex = 22;
            this.btnDeleteCustomer.Text = "Müşteri Sil";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(42, 335);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(88, 18);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Açıklama:";
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(636, 118);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(155, 65);
            this.btnUpdateCustomer.TabIndex = 21;
            this.btnUpdateCustomer.Text = "Müşteri Güncelle";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1682, 973);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1682, 973);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Hatırlatıcı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxReminder.ResumeLayout(false);
            this.gbxOperation.ResumeLayout(false);
            this.gbxOperation.PerformLayout();
            this.gbxContact.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.gbxSpecial.ResumeLayout(false);
            this.gbxTotal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbxCustomer.ResumeLayout(false);
            this.gbxCustomer.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Timer timer1;
        private TextBox tbInfo;
        private Button btnSortOperationsByRemainingDay;
        private Button btnUpdateOperation;
        private TextBox tbOperation;
        private Button btnAbout;
        private GroupBox gbxReminder;
        private Button btnRemindDate;
        private ComboBox cbReminder;
        private GroupBox gbxOperation;
        private Label lblCost;
        private Label lblOperation;
        private Button btnInsertOperation;
        private Label lblReminderDate;
        private TextBox tbCost;
        private Label lblPaid;
        private TextBox tbPaid;
        private DateTimePicker dtpReminderDate;
        private Button btnDeleteOperation;
        private DateTimePicker dtpOperationDate;
        private Label lblOperationDate;
        private GroupBox gbxContact;
        private Button btnSendErrorLog;
        private Label lblCustomerName;
        private TextBox tbCustomerName;
        private Label lblTelNo;
        private TextBox tbTelNo;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox gbxCustomer;
        private Button btnGetOperationsByCustomerID;
        private Label lblAdress;
        private Button btnInsertCustomer;
        private Button btnGetCustomerByName;
        private TextBox tbAdress;
        private Button btnDeleteCustomer;
        private Label lblInfo;
        private Button btnUpdateCustomer;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private GroupBox gbxSpecial;
        private GroupBox gbxTotal;
        private Label lblTotal;
        private Button btnGetAllDebtor;
        private Button btnSortByName;
        private Button btnGetAllCustomers;
    }
}