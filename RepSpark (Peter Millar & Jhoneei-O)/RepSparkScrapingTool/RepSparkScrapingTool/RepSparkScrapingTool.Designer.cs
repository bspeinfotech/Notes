namespace RepSparkScrapingTool
{
    partial class RepSparkScrapingTool
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepSparkScrapingTool));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.br = new AxSHDocVw.AxWebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltotalcount = new System.Windows.Forms.Label();
            this.txtPrdStart = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCurrentProduct = new System.Windows.Forms.Label();
            this.lblStartedDateTime = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblEndtime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.rbtnPaterMillar = new System.Windows.Forms.RadioButton();
            this.rbtnJohnnieO = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtlocation = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtLogview = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblAction = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.br)).BeginInit();
            this.panel3.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(7, 42);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1282, 593);
            this.TabControl1.TabIndex = 101;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.br);
            this.TabPage2.Controls.Add(this.panel3);
            this.TabPage2.Controls.Add(this.Panel4);
            this.TabPage2.Controls.Add(this.panel2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabPage2.Size = new System.Drawing.Size(1274, 567);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Main Screen";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // br
            // 
            this.br.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.br.Enabled = true;
            this.br.Location = new System.Drawing.Point(598, 11);
            this.br.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("br.OcxState")));
            this.br.Size = new System.Drawing.Size(670, 552);
            this.br.TabIndex = 127;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbltotalcount);
            this.panel3.Controls.Add(this.txtPrdStart);
            this.panel3.Controls.Add(this.Label3);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.lblCurrentProduct);
            this.panel3.Controls.Add(this.lblStartedDateTime);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.lblEndtime);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lblProducts);
            this.panel3.Location = new System.Drawing.Point(9, 132);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 68);
            this.panel3.TabIndex = 126;
            // 
            // lbltotalcount
            // 
            this.lbltotalcount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbltotalcount.AutoSize = true;
            this.lbltotalcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalcount.ForeColor = System.Drawing.Color.Black;
            this.lbltotalcount.Location = new System.Drawing.Point(440, 28);
            this.lbltotalcount.Name = "lbltotalcount";
            this.lbltotalcount.Size = new System.Drawing.Size(16, 17);
            this.lbltotalcount.TabIndex = 148;
            this.lbltotalcount.Text = "0";
            // 
            // txtPrdStart
            // 
            this.txtPrdStart.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrdStart.Enabled = false;
            this.txtPrdStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrdStart.ForeColor = System.Drawing.Color.Black;
            this.txtPrdStart.Location = new System.Drawing.Point(368, 5);
            this.txtPrdStart.Name = "txtPrdStart";
            this.txtPrdStart.Size = new System.Drawing.Size(68, 23);
            this.txtPrdStart.TabIndex = 160;
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label3.Location = new System.Drawing.Point(232, 27);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(215, 17);
            this.Label3.TabIndex = 147;
            this.Label3.Text = "Total written records in .csv file : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(232, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 17);
            this.label9.TabIndex = 159;
            this.label9.Text = "Product Start from : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(8, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 17);
            this.label12.TabIndex = 149;
            this.label12.Text = "Started DateTime  :";
            // 
            // lblCurrentProduct
            // 
            this.lblCurrentProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentProduct.AutoSize = true;
            this.lblCurrentProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentProduct.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentProduct.Location = new System.Drawing.Point(126, 27);
            this.lblCurrentProduct.Name = "lblCurrentProduct";
            this.lblCurrentProduct.Size = new System.Drawing.Size(18, 17);
            this.lblCurrentProduct.TabIndex = 152;
            this.lblCurrentProduct.Text = "--";
            // 
            // lblStartedDateTime
            // 
            this.lblStartedDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartedDateTime.AutoSize = true;
            this.lblStartedDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartedDateTime.ForeColor = System.Drawing.Color.Black;
            this.lblStartedDateTime.Location = new System.Drawing.Point(136, 45);
            this.lblStartedDateTime.Name = "lblStartedDateTime";
            this.lblStartedDateTime.Size = new System.Drawing.Size(18, 17);
            this.lblStartedDateTime.TabIndex = 150;
            this.lblStartedDateTime.Text = "--";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(8, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 17);
            this.label15.TabIndex = 151;
            this.label15.Text = "Current Product :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(6, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 17);
            this.label16.TabIndex = 155;
            this.label16.Text = "Total Products   :";
            // 
            // lblEndtime
            // 
            this.lblEndtime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEndtime.AutoSize = true;
            this.lblEndtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndtime.ForeColor = System.Drawing.Color.Black;
            this.lblEndtime.Location = new System.Drawing.Point(378, 48);
            this.lblEndtime.Name = "lblEndtime";
            this.lblEndtime.Size = new System.Drawing.Size(18, 17);
            this.lblEndtime.TabIndex = 154;
            this.lblEndtime.Text = "--";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(276, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 17);
            this.label17.TabIndex = 153;
            this.label17.Text = "End DateTime :  ";
            // 
            // lblProducts
            // 
            this.lblProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProducts.AutoSize = true;
            this.lblProducts.Enabled = false;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.ForeColor = System.Drawing.Color.Black;
            this.lblProducts.Location = new System.Drawing.Point(123, 8);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(18, 17);
            this.lblProducts.TabIndex = 156;
            this.lblProducts.Text = "--";
            this.lblProducts.Visible = false;
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.label5);
            this.Panel4.Controls.Add(this.lblAction);
            this.Panel4.Controls.Add(this.rbtnPaterMillar);
            this.Panel4.Controls.Add(this.rbtnJohnnieO);
            this.Panel4.Controls.Add(this.btnStart);
            this.Panel4.Controls.Add(this.txtUsername);
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.txtPassword);
            this.Panel4.Controls.Add(this.Label18);
            this.Panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Panel4.Location = new System.Drawing.Point(9, 11);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(582, 115);
            this.Panel4.TabIndex = 78;
            // 
            // rbtnPaterMillar
            // 
            this.rbtnPaterMillar.AutoSize = true;
            this.rbtnPaterMillar.Checked = true;
            this.rbtnPaterMillar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPaterMillar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPaterMillar.Location = new System.Drawing.Point(137, 6);
            this.rbtnPaterMillar.Name = "rbtnPaterMillar";
            this.rbtnPaterMillar.Size = new System.Drawing.Size(109, 21);
            this.rbtnPaterMillar.TabIndex = 128;
            this.rbtnPaterMillar.TabStop = true;
            this.rbtnPaterMillar.Text = "Pater Millar";
            this.rbtnPaterMillar.UseVisualStyleBackColor = true;
            this.rbtnPaterMillar.CheckedChanged += new System.EventHandler(this.rbtnPaterMillar_CheckedChanged);
            // 
            // rbtnJohnnieO
            // 
            this.rbtnJohnnieO.AutoSize = true;
            this.rbtnJohnnieO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnJohnnieO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnJohnnieO.Location = new System.Drawing.Point(256, 7);
            this.rbtnJohnnieO.Name = "rbtnJohnnieO";
            this.rbtnJohnnieO.Size = new System.Drawing.Size(98, 21);
            this.rbtnJohnnieO.TabIndex = 127;
            this.rbtnJohnnieO.Text = "Johnnie-o";
            this.rbtnJohnnieO.UseVisualStyleBackColor = true;
            this.rbtnJohnnieO.CheckedChanged += new System.EventHandler(this.rbtnJohnnieO_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(137, 87);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(89, 23);
            this.btnStart.TabIndex = 125;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtUsername.Enabled = false;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(137, 34);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(431, 23);
            this.txtUsername.TabIndex = 124;
            this.txtUsername.Text = "kgiron";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Maroon;
            this.Label4.Location = new System.Drawing.Point(10, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(88, 17);
            this.Label4.TabIndex = 123;
            this.Label4.Text = "User Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(137, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(430, 23);
            this.txtPassword.TabIndex = 122;
            this.txtPassword.Text = "nike20552";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label18.ForeColor = System.Drawing.Color.Maroon;
            this.Label18.Location = new System.Drawing.Point(12, 60);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(77, 17);
            this.Label18.TabIndex = 120;
            this.Label18.Text = "Password";
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
            this.panel2.Location = new System.Drawing.Point(9, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 357);
            this.panel2.TabIndex = 76;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Maroon;
            this.Label6.Location = new System.Drawing.Point(6, 252);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(95, 17);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Output Path";
            // 
            // txtlocation
            // 
            this.txtlocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlocation.BackColor = System.Drawing.SystemColors.Info;
            this.txtlocation.Enabled = false;
            this.txtlocation.Location = new System.Drawing.Point(9, 272);
            this.txtlocation.Multiline = true;
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtlocation.Size = new System.Drawing.Size(558, 79);
            this.txtlocation.TabIndex = 6;
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Maroon;
            this.Label7.Location = new System.Drawing.Point(10, 5);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(113, 17);
            this.Label7.TabIndex = 5;
            this.Label7.Text = "View Log Here";
            // 
            // txtLogview
            // 
            this.txtLogview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogview.BackColor = System.Drawing.Color.LightGray;
            this.txtLogview.Location = new System.Drawing.Point(9, 25);
            this.txtLogview.Multiline = true;
            this.txtLogview.Name = "txtLogview";
            this.txtLogview.Size = new System.Drawing.Size(560, 224);
            this.txtLogview.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.SlateGray;
            this.Label2.Location = new System.Drawing.Point(805, 19);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 13);
            this.Label2.TabIndex = 100;
            this.Label2.Text = "Version 1.0";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Maroon;
            this.Label1.Location = new System.Drawing.Point(481, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(331, 31);
            this.Label1.TabIndex = 99;
            this.Label1.Text = "RepSpark Scraping Tool";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAction.ForeColor = System.Drawing.Color.Maroon;
            this.lblAction.Location = new System.Drawing.Point(12, 87);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(53, 17);
            this.lblAction.TabIndex = 129;
            this.lblAction.Text = "Action";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 130;
            this.label5.Text = "Select Website";
            // 
            // RepSparkScrapingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 641);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "RepSparkScrapingTool";
            this.Text = "RepSpark Scraping Tool";
            this.TabControl1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.br)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Label lbltotalcount;
        private System.Windows.Forms.TextBox txtPrdStart;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label lblCurrentProduct;
        internal System.Windows.Forms.Label lblStartedDateTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label lblEndtime;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label lblProducts;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtlocation;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txtLogview;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private AxSHDocVw.AxWebBrowser br;
        private System.Windows.Forms.RadioButton rbtnPaterMillar;
        private System.Windows.Forms.RadioButton rbtnJohnnieO;
        private System.Windows.Forms.Timer timer;
        internal System.Windows.Forms.Label lblAction;
        internal System.Windows.Forms.Label label5;
    }
}

