namespace Mitsubishi_PLC
{
    partial class Form1
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
            this.label5 = new System.Windows.Forms.Label();
            this.Read = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.addressTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusTb = new System.Windows.Forms.TextBox();
            this.portTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipaddressTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(333, 74);
            this.label5.TabIndex = 62;
            this.label5.Text = "MITSUBISHI";
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(74, 348);
            this.Read.Margin = new System.Windows.Forms.Padding(2);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(90, 36);
            this.Read.TabIndex = 61;
            this.Read.Text = "Read";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click_1);
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(551, 348);
            this.Write.Margin = new System.Windows.Forms.Padding(2);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(83, 36);
            this.Write.TabIndex = 60;
            this.Write.Text = "Write";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click_1);
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Location = new System.Drawing.Point(436, 196);
            this.DisconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(96, 28);
            this.DisconnectBtn.TabIndex = 59;
            this.DisconnectBtn.Text = "DisConnect";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(436, 146);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(96, 30);
            this.ConnectBtn.TabIndex = 58;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // addressTb
            // 
            this.addressTb.Location = new System.Drawing.Point(315, 293);
            this.addressTb.Name = "addressTb";
            this.addressTb.Size = new System.Drawing.Size(169, 22);
            this.addressTb.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "Address";
            // 
            // StatusTb
            // 
            this.StatusTb.Location = new System.Drawing.Point(592, 206);
            this.StatusTb.Name = "StatusTb";
            this.StatusTb.Size = new System.Drawing.Size(134, 22);
            this.StatusTb.TabIndex = 55;
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(201, 203);
            this.portTb.Name = "portTb";
            this.portTb.Size = new System.Drawing.Size(169, 22);
            this.portTb.TabIndex = 54;
            this.portTb.Text = "502";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 53;
            this.label2.Text = "PORT No";
            // 
            // ipaddressTb
            // 
            this.ipaddressTb.Location = new System.Drawing.Point(201, 151);
            this.ipaddressTb.Name = "ipaddressTb";
            this.ipaddressTb.Size = new System.Drawing.Size(169, 22);
            this.ipaddressTb.TabIndex = 52;
            this.ipaddressTb.Text = "192.168.1.10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "IPAddress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Read);
            this.Controls.Add(this.Write);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.addressTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusTb);
            this.Controls.Add(this.portTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipaddressTb);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox addressTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StatusTb;
        private System.Windows.Forms.TextBox portTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipaddressTb;
        private System.Windows.Forms.Label label1;
    }
}

