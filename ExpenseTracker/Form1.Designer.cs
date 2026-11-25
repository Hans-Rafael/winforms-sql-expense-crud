namespace ExpenseTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtDescription = new TextBox();
            cboCategory = new ComboBox();
            numAmount = new NumericUpDown();
            dtpDate = new DateTimePicker();
            chkPaid = new CheckBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            dgvExpenses = new DataGridView();
            lblTotal = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(39, 47);
            txtDescription.Margin = new Padding(4);
            txtDescription.MaxLength = 120;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(609, 29);
            txtDescription.TabIndex = 0;
            // 
            // cboCategory
            // 
            cboCategory.Cursor = Cursors.Hand;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(692, 47);
            cboCategory.Margin = new Padding(4);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(201, 29);
            cboCategory.TabIndex = 1;
            // 
            // numAmount
            // 
            numAmount.DecimalPlaces = 2;
            numAmount.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numAmount.Location = new Point(39, 127);
            numAmount.Margin = new Padding(5, 6, 5, 6);
            numAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(198, 26);
            numAmount.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(274, 127);
            dtpDate.Margin = new Padding(4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(138, 26);
            dtpDate.TabIndex = 3;
            // 
            // chkPaid
            // 
            chkPaid.AutoSize = true;
            chkPaid.Checked = true;
            chkPaid.CheckState = CheckState.Checked;
            chkPaid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkPaid.Location = new Point(451, 124);
            chkPaid.Margin = new Padding(4);
            chkPaid.Name = "chkPaid";
            chkPaid.Size = new Size(58, 25);
            chkPaid.TabIndex = 4;
            chkPaid.Text = "Paid";
            chkPaid.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.OliveDrab;
            btnSave.Cursor = Cursors.Hand;
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(39, 197);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 32);
            btnSave.TabIndex = 5;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.HotTrack;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.ForeColor = SystemColors.Control;
            btnUpdate.Location = new Point(384, 197);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 32);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(581, 197);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 32);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.Info;
            btnClear.Cursor = Cursors.Hand;
            btnClear.Location = new Point(203, 197);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(96, 32);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(39, 307);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by description...";
            txtSearch.Size = new Size(331, 29);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Location = new Point(39, 354);
            dgvExpenses.Margin = new Padding(4);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(1006, 210);
            dgvExpenses.TabIndex = 10;
            dgvExpenses.CellClick += dgvExpenses_CellClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(949, 590);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(93, 21);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: $0.00";
            lblTotal.TextAlign = ContentAlignment.BottomRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 23);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 12;
            label1.Text = "Description: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(692, 23);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 13;
            label2.Text = "Category: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 98);
            label3.Name = "label3";
            label3.Size = new Size(73, 21);
            label3.TabIndex = 14;
            label3.Text = "Amount: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(274, 98);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 15;
            label4.Text = "Date: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 277);
            label5.Name = "label5";
            label5.Size = new Size(64, 21);
            label5.TabIndex = 16;
            label5.Text = "Search: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 673);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTotal);
            Controls.Add(dgvExpenses);
            Controls.Add(txtSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(chkPaid);
            Controls.Add(dtpDate);
            Controls.Add(numAmount);
            Controls.Add(cboCategory);
            Controls.Add(txtDescription);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personal Expense Tracker";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescription;
        private ComboBox cboCategory;
        private NumericUpDown numAmount;
        private DateTimePicker dtpDate;
        private CheckBox chkPaid;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtSearch;
        private DataGridView dgvExpenses;
        private Label lblTotal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
