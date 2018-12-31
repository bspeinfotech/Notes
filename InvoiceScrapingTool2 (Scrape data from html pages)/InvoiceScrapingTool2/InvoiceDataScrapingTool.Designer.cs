namespace InvoiceScrapingTool2
{
    partial class InvoiceDataScrapingTool
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.lblTotalfiles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltotalcount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblEndtime = new System.Windows.Forms.Label();
            this.lblStartedDateTime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtlocation = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtLogview = new System.Windows.Forms.TextBox();
            this.Panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(203, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(296, 31);
            this.Label1.TabIndex = 99;
            this.Label1.Text = "Invoice Scraping Tool";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.lblTotalfiles);
            this.Panel4.Controls.Add(this.label2);
            this.Panel4.Controls.Add(this.txtFileType);
            this.Panel4.Controls.Add(this.btnSelect);
            this.Panel4.Controls.Add(this.txtFolderPath);
            this.Panel4.Controls.Add(this.btnStart);
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.Label5);
            this.Panel4.Controls.Add(this.Label18);
            this.Panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Panel4.Location = new System.Drawing.Point(12, 52);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(660, 95);
            this.Panel4.TabIndex = 100;
            // 
            // lblTotalfiles
            // 
            this.lblTotalfiles.AutoSize = true;
            this.lblTotalfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalfiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalfiles.Location = new System.Drawing.Point(309, 67);
            this.lblTotalfiles.Name = "lblTotalfiles";
            this.lblTotalfiles.Size = new System.Drawing.Size(0, 13);
            this.lblTotalfiles.TabIndex = 128;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(240, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Total files : ";
            // 
            // txtFileType
            // 
            this.txtFileType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtFileType.Location = new System.Drawing.Point(109, 36);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(536, 20);
            this.txtFileType.TabIndex = 126;
            this.txtFileType.Text = ".html";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(109, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 23);
            this.btnSelect.TabIndex = 125;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtFolderPath.Location = new System.Drawing.Point(196, 7);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(449, 20);
            this.txtFolderPath.TabIndex = 124;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(109, 62);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(86, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label4.Location = new System.Drawing.Point(7, 10);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 13);
            this.Label4.TabIndex = 123;
            this.Label4.Text = "Select folder : ";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label5.Location = new System.Drawing.Point(10, 67);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(75, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Action       :";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label18.Location = new System.Drawing.Point(9, 37);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(94, 13);
            this.Label18.TabIndex = 120;
            this.Label18.Text = "Enter file type :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbltotalcount);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.Label3);
            this.panel3.Controls.Add(this.lblEndtime);
            this.panel3.Controls.Add(this.lblStartedDateTime);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(12, 153);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 53);
            this.panel3.TabIndex = 128;
            // 
            // lbltotalcount
            // 
            this.lbltotalcount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbltotalcount.AutoSize = true;
            this.lbltotalcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalcount.ForeColor = System.Drawing.Color.Black;
            this.lbltotalcount.Location = new System.Drawing.Point(167, 7);
            this.lbltotalcount.Name = "lbltotalcount";
            this.lbltotalcount.Size = new System.Drawing.Size(14, 13);
            this.lbltotalcount.TabIndex = 148;
            this.lbltotalcount.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(8, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 149;
            this.label12.Text = "Started Time  :";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label3.Location = new System.Drawing.Point(7, 7);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(162, 13);
            this.Label3.TabIndex = 147;
            this.Label3.Text = "Total written records in .csv file : ";
            // 
            // lblEndtime
            // 
            this.lblEndtime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEndtime.AutoSize = true;
            this.lblEndtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndtime.ForeColor = System.Drawing.Color.Black;
            this.lblEndtime.Location = new System.Drawing.Point(310, 29);
            this.lblEndtime.Name = "lblEndtime";
            this.lblEndtime.Size = new System.Drawing.Size(15, 13);
            this.lblEndtime.TabIndex = 154;
            this.lblEndtime.Text = "--";
            // 
            // lblStartedDateTime
            // 
            this.lblStartedDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartedDateTime.AutoSize = true;
            this.lblStartedDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartedDateTime.ForeColor = System.Drawing.Color.Black;
            this.lblStartedDateTime.Location = new System.Drawing.Point(82, 28);
            this.lblStartedDateTime.Name = "lblStartedDateTime";
            this.lblStartedDateTime.Size = new System.Drawing.Size(15, 13);
            this.lblStartedDateTime.TabIndex = 150;
            this.lblStartedDateTime.Text = "--";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(252, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 153;
            this.label17.Text = "End Time :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Label6);
            this.panel2.Controls.Add(this.txtlocation);
            this.panel2.Controls.Add(this.Label7);
            this.panel2.Controls.Add(this.txtLogview);
            this.panel2.Location = new System.Drawing.Point(12, 212);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 329);
            this.panel2.TabIndex = 127;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.Location = new System.Drawing.Point(6, 245);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(64, 13);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Output Path";
            // 
            // txtlocation
            // 
            this.txtlocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlocation.BackColor = System.Drawing.SystemColors.Info;
            this.txtlocation.Location = new System.Drawing.Point(9, 263);
            this.txtlocation.Multiline = true;
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.ReadOnly = true;
            this.txtlocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtlocation.Size = new System.Drawing.Size(636, 54);
            this.txtlocation.TabIndex = 6;
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.Location = new System.Drawing.Point(10, 5);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(77, 13);
            this.Label7.TabIndex = 5;
            this.Label7.Text = "View Log Here";
            // 
            // txtLogview
            // 
            this.txtLogview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogview.BackColor = System.Drawing.Color.LightGray;
            this.txtLogview.Location = new System.Drawing.Point(9, 21);
            this.txtLogview.Multiline = true;
            this.txtLogview.Name = "txtLogview";
            this.txtLogview.Size = new System.Drawing.Size(638, 221);
            this.txtLogview.TabIndex = 2;
            // 
            // InvoiceDataScrapingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 547);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel4);
            this.Controls.Add(this.Label1);
            this.Name = "InvoiceDataScrapingTool";
            this.Text = "Invoice Scraping Tool";
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.TextBox txtFolderPath;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.TextBox txtFileType;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblTotalfiles;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Label lbltotalcount;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblEndtime;
        internal System.Windows.Forms.Label lblStartedDateTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtlocation;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txtLogview;
    }
}

