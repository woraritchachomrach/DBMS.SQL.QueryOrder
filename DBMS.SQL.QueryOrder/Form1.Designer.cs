﻿namespace DBMS.SQL.QueryOrder
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
            dgvOrders = new DataGridView();
            dgvDetails = new DataGridView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(148, 43);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(992, 243);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(146, 323);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.Size = new Size(994, 195);
            dgvDetails.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(400, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "ใบสั่งซื้อ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(389, 290);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(138, 27);
            textBox2.TabIndex = 3;
            textBox2.Text = "รายการสั่งซื้อ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(985, 243);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 4;
            textBox3.Text = "dgvOrders";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(985, 471);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 5;
            textBox4.Text = "dgvDetails";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 632);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dgvDetails);
            Controls.Add(dgvOrders);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private DataGridView dgvDetails;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}
