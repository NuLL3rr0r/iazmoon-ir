namespace iazmoon
{
    partial class frmStudents
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
            this.ofdTxt = new System.Windows.Forms.OpenFileDialog();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabAddSR = new System.Windows.Forms.TabPage();
            this.dgvStudentsResult = new System.Windows.Forms.DataGridView();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtOpendFile = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.tabViewSR = new System.Windows.Forms.TabPage();
            this.lblEraseTo = new System.Windows.Forms.Label();
            this.nudEraseTo = new System.Windows.Forms.NumericUpDown();
            this.lblEraseFrom = new System.Windows.Forms.Label();
            this.nudEraseFrom = new System.Windows.Forms.NumericUpDown();
            this.dgvStudentsResultTotal = new System.Windows.Forms.DataGridView();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnReturnA = new System.Windows.Forms.Button();
            this.txtQTY = new System.Windows.Forms.TextBox();
            this.tabsMain.SuspendLayout();
            this.tabAddSR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsResult)).BeginInit();
            this.tabViewSR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEraseTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEraseFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsResultTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdTxt
            // 
            this.ofdTxt.RestoreDirectory = true;
            // 
            // tabsMain
            // 
            this.tabsMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabsMain.Controls.Add(this.tabAddSR);
            this.tabsMain.Controls.Add(this.tabViewSR);
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.Location = new System.Drawing.Point(0, 0);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.RightToLeftLayout = true;
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(630, 444);
            this.tabsMain.TabIndex = 0;
            this.tabsMain.SelectedIndexChanged += new System.EventHandler(this.tabsMain_SelectedIndexChanged);
            // 
            // tabAddSR
            // 
            this.tabAddSR.Controls.Add(this.txtQTY);
            this.tabAddSR.Controls.Add(this.dgvStudentsResult);
            this.tabAddSR.Controls.Add(this.btnSend);
            this.tabAddSR.Controls.Add(this.txtOpendFile);
            this.tabAddSR.Controls.Add(this.btnOpen);
            this.tabAddSR.Controls.Add(this.btnReturn);
            this.tabAddSR.Location = new System.Drawing.Point(4, 25);
            this.tabAddSR.Name = "tabAddSR";
            this.tabAddSR.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddSR.Size = new System.Drawing.Size(622, 415);
            this.tabAddSR.TabIndex = 0;
            this.tabAddSR.Text = "‰ «ÌÃ ÃœÌœ";
            this.tabAddSR.UseVisualStyleBackColor = true;
            // 
            // dgvStudentsResult
            // 
            this.dgvStudentsResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsResult.Location = new System.Drawing.Point(8, 36);
            this.dgvStudentsResult.Name = "dgvStudentsResult";
            this.dgvStudentsResult.ReadOnly = true;
            this.dgvStudentsResult.Size = new System.Drawing.Size(608, 346);
            this.dgvStudentsResult.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSend.Location = new System.Drawing.Point(89, 388);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 24);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "«—”«·";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtOpendFile
            // 
            this.txtOpendFile.Location = new System.Drawing.Point(89, 6);
            this.txtOpendFile.Name = "txtOpendFile";
            this.txtOpendFile.ReadOnly = true;
            this.txtOpendFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOpendFile.Size = new System.Drawing.Size(527, 21);
            this.txtOpendFile.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOpen.Location = new System.Drawing.Point(8, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 24);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "ê‘Êœ‰";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturn.Location = new System.Drawing.Point(8, 388);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 24);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "»«“ê‘ ";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // tabViewSR
            // 
            this.tabViewSR.Controls.Add(this.lblEraseTo);
            this.tabViewSR.Controls.Add(this.nudEraseTo);
            this.tabViewSR.Controls.Add(this.lblEraseFrom);
            this.tabViewSR.Controls.Add(this.nudEraseFrom);
            this.tabViewSR.Controls.Add(this.dgvStudentsResultTotal);
            this.tabViewSR.Controls.Add(this.btnErase);
            this.tabViewSR.Controls.Add(this.btnReturnA);
            this.tabViewSR.Location = new System.Drawing.Point(4, 25);
            this.tabViewSR.Name = "tabViewSR";
            this.tabViewSR.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewSR.Size = new System.Drawing.Size(622, 415);
            this.tabViewSR.TabIndex = 1;
            this.tabViewSR.Text = "‰ «ÌÃ ﬁ»·Ì";
            this.tabViewSR.UseVisualStyleBackColor = true;
            // 
            // lblEraseTo
            // 
            this.lblEraseTo.AutoSize = true;
            this.lblEraseTo.Location = new System.Drawing.Point(476, 393);
            this.lblEraseTo.Name = "lblEraseTo";
            this.lblEraseTo.Size = new System.Drawing.Size(13, 13);
            this.lblEraseTo.TabIndex = 4;
            this.lblEraseTo.Text = " «";
            // 
            // nudEraseTo
            // 
            this.nudEraseTo.Location = new System.Drawing.Point(371, 390);
            this.nudEraseTo.Name = "nudEraseTo";
            this.nudEraseTo.Size = new System.Drawing.Size(99, 21);
            this.nudEraseTo.TabIndex = 5;
            this.nudEraseTo.ValueChanged += new System.EventHandler(this.nudEraseTo_ValueChanged);
            // 
            // lblEraseFrom
            // 
            this.lblEraseFrom.AutoSize = true;
            this.lblEraseFrom.Location = new System.Drawing.Point(600, 393);
            this.lblEraseFrom.Name = "lblEraseFrom";
            this.lblEraseFrom.Size = new System.Drawing.Size(14, 13);
            this.lblEraseFrom.TabIndex = 2;
            this.lblEraseFrom.Text = "«“";
            // 
            // nudEraseFrom
            // 
            this.nudEraseFrom.Location = new System.Drawing.Point(495, 390);
            this.nudEraseFrom.Name = "nudEraseFrom";
            this.nudEraseFrom.Size = new System.Drawing.Size(99, 21);
            this.nudEraseFrom.TabIndex = 3;
            this.nudEraseFrom.ValueChanged += new System.EventHandler(this.nudEraseFrom_ValueChanged);
            // 
            // dgvStudentsResultTotal
            // 
            this.dgvStudentsResultTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsResultTotal.Location = new System.Drawing.Point(8, 6);
            this.dgvStudentsResultTotal.Name = "dgvStudentsResultTotal";
            this.dgvStudentsResultTotal.ReadOnly = true;
            this.dgvStudentsResultTotal.Size = new System.Drawing.Size(608, 376);
            this.dgvStudentsResultTotal.TabIndex = 1;
            // 
            // btnErase
            // 
            this.btnErase.Enabled = false;
            this.btnErase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnErase.Location = new System.Drawing.Point(290, 388);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 24);
            this.btnErase.TabIndex = 6;
            this.btnErase.Text = "Õ–›";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnReturnA
            // 
            this.btnReturnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturnA.Location = new System.Drawing.Point(8, 388);
            this.btnReturnA.Name = "btnReturnA";
            this.btnReturnA.Size = new System.Drawing.Size(75, 24);
            this.btnReturnA.TabIndex = 7;
            this.btnReturnA.Text = "»«“ê‘ ";
            this.btnReturnA.UseVisualStyleBackColor = true;
            this.btnReturnA.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txtQTY
            // 
            this.txtQTY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQTY.Enabled = false;
            this.txtQTY.Location = new System.Drawing.Point(170, 391);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(187, 21);
            this.txtQTY.TabIndex = 4;
            this.txtQTY.Text = " ⁄œ«œ Õ«÷—Ì‰ ‘—ﬂ  ﬂ‰‰œÂ œ— ﬂ· ﬂ‘Ê—";
            this.txtQTY.Enter += new System.EventHandler(this.txtQTY_Enter);
            this.txtQTY.Leave += new System.EventHandler(this.txtQTY_Leave);
            // 
            // frmStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 444);
            this.ControlBox = false;
            this.Controls.Add(this.tabsMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmStudents";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "œ«Êÿ·»";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudents_FormClosing);
            this.tabsMain.ResumeLayout(false);
            this.tabAddSR.ResumeLayout(false);
            this.tabAddSR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsResult)).EndInit();
            this.tabViewSR.ResumeLayout(false);
            this.tabViewSR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEraseTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEraseFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsResultTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdTxt;
        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabViewSR;
        private System.Windows.Forms.TabPage tabAddSR;
        private System.Windows.Forms.DataGridView dgvStudentsResult;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtOpendFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReturnA;
        private System.Windows.Forms.DataGridView dgvStudentsResultTotal;
        private System.Windows.Forms.NumericUpDown nudEraseFrom;
        private System.Windows.Forms.Label lblEraseTo;
        private System.Windows.Forms.NumericUpDown nudEraseTo;
        private System.Windows.Forms.Label lblEraseFrom;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.TextBox txtQTY;
    }
}