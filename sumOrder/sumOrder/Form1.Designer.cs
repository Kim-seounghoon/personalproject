namespace sumOrder
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxPrice1 = new System.Windows.Forms.TextBox();
            this.addFileBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sumFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxOption = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.HeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Headeroption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Headerprice1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Headerprice2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.textBoxPrice2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxPrice1
            // 
            this.textBoxPrice1.Location = new System.Drawing.Point(72, 213);
            this.textBoxPrice1.Name = "textBoxPrice1";
            this.textBoxPrice1.Size = new System.Drawing.Size(92, 21);
            this.textBoxPrice1.TabIndex = 10;
            // 
            // addFileBtn
            // 
            this.addFileBtn.Location = new System.Drawing.Point(225, 38);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(62, 40);
            this.addFileBtn.TabIndex = 1;
            this.addFileBtn.Text = "파일\r\n불러오기";
            this.addFileBtn.UseVisualStyleBackColor = true;
            this.addFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(23, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 52);
            this.listBox1.TabIndex = 2;
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox1_DragEnter);
            // 
            // sumFileBtn
            // 
            this.sumFileBtn.Location = new System.Drawing.Point(193, 407);
            this.sumFileBtn.Name = "sumFileBtn";
            this.sumFileBtn.Size = new System.Drawing.Size(104, 28);
            this.sumFileBtn.TabIndex = 13;
            this.sumFileBtn.Text = "엑셀 합산";
            this.sumFileBtn.UseVisualStyleBackColor = true;
            this.sumFileBtn.Click += new System.EventHandler(this.SumFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "공급단가 :";
            // 
            // comboBoxName
            // 
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Items.AddRange(new object[] {
            "절임배추",
            "방울토망고"});
            this.comboBoxName.Location = new System.Drawing.Point(72, 143);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(92, 20);
            this.comboBoxName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "상품명 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "옵션 :";
            // 
            // comboBoxOption
            // 
            this.comboBoxOption.FormattingEnabled = true;
            this.comboBoxOption.Items.AddRange(new object[] {
            "0.5kg",
            "1kg",
            "1.5kg",
            "2kg",
            "3kg",
            "5kg",
            "10kg",
            "20kg"});
            this.comboBoxOption.Location = new System.Drawing.Point(72, 178);
            this.comboBoxOption.Name = "comboBoxOption";
            this.comboBoxOption.Size = new System.Drawing.Size(92, 20);
            this.comboBoxOption.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HeaderName,
            this.Headeroption,
            this.Headerprice1,
            this.Headerprice2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(11, 20);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(264, 112);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // HeaderName
            // 
            this.HeaderName.Text = "상품명";
            this.HeaderName.Width = 78;
            // 
            // Headeroption
            // 
            this.Headeroption.Text = "옵션";
            this.Headeroption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Headeroption.Width = 62;
            // 
            // Headerprice1
            // 
            this.Headerprice1.Text = "공급단가";
            this.Headerprice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Headerprice2
            // 
            this.Headerprice2.Text = "판매단가";
            this.Headerprice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(209, 224);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(66, 40);
            this.addBtn.TabIndex = 12;
            this.addBtn.Text = "상세정보\r\n추가";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delBtn);
            this.groupBox1.Controls.Add(this.textBoxPrice2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxPrice1);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.comboBoxName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxOption);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 282);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "제품별 상세정보";
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(209, 146);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(66, 34);
            this.delBtn.TabIndex = 18;
            this.delBtn.Text = "삭제";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // textBoxPrice2
            // 
            this.textBoxPrice2.Location = new System.Drawing.Point(72, 249);
            this.textBoxPrice2.Name = "textBoxPrice2";
            this.textBoxPrice2.Size = new System.Drawing.Size(92, 21);
            this.textBoxPrice2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "판매단가 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 36);
            this.label2.TabIndex = 14;
            this.label2.Text = "       제품명, 옵션은 \r\n엑셀과 반드시 일치해야 함\r\n         (공백 포함)\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "       저장위치\r\n내문서 > 발주서합산";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 438);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.sumFileBtn);
            this.Controls.Add(this.addFileBtn);
            this.Name = "Form1";
            this.Text = "sumExcel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxPrice1;
        private System.Windows.Forms.Button addFileBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button sumFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxOption;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader HeaderName;
        private System.Windows.Forms.ColumnHeader Headeroption;
        private System.Windows.Forms.ColumnHeader Headerprice1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader Headerprice2;
        private System.Windows.Forms.TextBox textBoxPrice2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Label label6;
    }
}

