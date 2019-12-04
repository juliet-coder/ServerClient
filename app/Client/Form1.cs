using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;

namespace Client
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : Form
    {
		private Socktes.ConnectSocket Socket_Connection;
		private ListBox lstb_RecievedData;
		private Label lb_RecievedData;
		private Button btn_Connect;
		private Button btn_Subscribe;
		private TextBox txt_UserIP;
		private Label lb_UserIP;
        private Label lb_Port;
        private TextBox txt_UserPort;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public Form1()
        {
            InitializeComponent();

        }	

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.Socket_Connection = new Socktes.ConnectSocket();
            this.lstb_RecievedData = new ListBox();
            this.lb_RecievedData = new Label();
            this.btn_Connect = new Button();
            this.btn_Subscribe = new Button();
            this.txt_UserIP = new TextBox();
            this.lb_UserIP = new Label();
            this.lb_Port = new Label();
            this.txt_UserPort = new TextBox();
            this.SuspendLayout();
            // 
            // Socket_Connection
            // 
            this.Socket_Connection.IsBlocked = false;
            this.Socket_Connection.recieve += new Socktes.RecieveEventHandler(this.Socket_Connection_recieve);
            // 
            // lstb_RecievedData
            // 
            this.lstb_RecievedData.Location = new System.Drawing.Point(0, 160);
            this.lstb_RecievedData.Name = "lstb_RecievedData";
            this.lstb_RecievedData.Size = new System.Drawing.Size(288, 95);
            this.lstb_RecievedData.TabIndex = 0;
            // 
            // lb_RecievedData
            // 
            this.lb_RecievedData.AllowDrop = true;
            this.lb_RecievedData.Location = new System.Drawing.Point(0, 144);
            this.lb_RecievedData.Name = "lb_RecievedData";
            this.lb_RecievedData.Size = new System.Drawing.Size(100, 16);
            this.lb_RecievedData.TabIndex = 1;
            this.lb_RecievedData.Text = "Recived Data";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(205, 12);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Subscribe
            // 
            this.btn_Subscribe.Location = new System.Drawing.Point(97, 12);
            this.btn_Subscribe.Name = "btn_Subscribe";
            this.btn_Subscribe.Size = new System.Drawing.Size(75, 23);
            this.btn_Subscribe.TabIndex = 3;
            this.btn_Subscribe.Text = "Subscribe";
            this.btn_Subscribe.Click += new System.EventHandler(this.btn_Subscribe_Click);
            // 
            // txt_UserIP
            // 
            this.txt_UserIP.Location = new System.Drawing.Point(8, 55);
            this.txt_UserIP.Name = "txt_UserIP";
            this.txt_UserIP.Size = new System.Drawing.Size(272, 20);
            this.txt_UserIP.TabIndex = 4;
            
            // 
            // lb_UserIP
            // 
            this.lb_UserIP.Location = new System.Drawing.Point(5, 36);
            this.lb_UserIP.Name = "lb_UserIP";
            this.lb_UserIP.Size = new System.Drawing.Size(100, 16);
            this.lb_UserIP.TabIndex = 5;
            this.lb_UserIP.Text = "IP";
            // 
            // lb_Port
            // 
            this.lb_Port.Location = new System.Drawing.Point(5, 89);
            this.lb_Port.Name = "lb_Port";
            this.lb_Port.Size = new System.Drawing.Size(100, 16);
            this.lb_Port.TabIndex = 7;
            this.lb_Port.Text = "Port";
            // 
            // txt_UserPort
            // 
            this.txt_UserPort.Location = new System.Drawing.Point(8, 108);
            this.txt_UserPort.Name = "txt_UserPort";
            this.txt_UserPort.Size = new System.Drawing.Size(272, 20);
            this.txt_UserPort.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.lb_Port);
            this.Controls.Add(this.txt_UserPort);
            this.Controls.Add(this.lb_UserIP);
            this.Controls.Add(this.txt_UserIP);
            this.Controls.Add(this.btn_Subscribe);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.lb_RecievedData);
            this.Controls.Add(this.lstb_RecievedData);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
        }

		private void btn_Connect_Click(object sender, System.EventArgs e)
		{
            Regex rgx = new Regex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
            if (rgx.IsMatch(txt_UserIP.Text) != true)

            {
                MessageBox.Show("Invalid IP Address!");
            }
            Socket_Connection.Connect("127.0.0.1", Convert.ToInt32(txt_UserPort.Text));
		}

		private void btn_Subscribe_Click(object sender, System.EventArgs e)
		{
			byte[] b = Socktes.ByesConvertor.GetBytes(txt_UserIP.Text);
			Socket_Connection.Send(b);
		}

		private void Socket_Connection_recieve(object Sender, Socktes.RecieveEventArgs e)
		{
			string s = Socktes.ByesConvertor.BytesToString(e.Data);
			lstb_RecievedData.Items.Add(s);
		}
	}
}
