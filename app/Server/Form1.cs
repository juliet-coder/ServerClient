using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace Server
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : Form
	{
		private Socktes.ConnectSocket Socket_Connection;
		private Socktes.ListenSocket Socket_Listen;
		private Button btn_Listen;
		private ListBox lstb_UsersList;
		private Label lb_UsersList;
		private TextBox txt_DatatoClient;
		private Label lb_DatatoClient;
		private Button btn_Send;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
            this.Socket_Listen = new Socktes.ListenSocket();
            this.btn_Listen = new System.Windows.Forms.Button();
            this.lstb_UsersList = new System.Windows.Forms.ListBox();
            this.lb_UsersList = new System.Windows.Forms.Label();
            this.txt_DatatoClient = new System.Windows.Forms.TextBox();
            this.lb_DatatoClient = new System.Windows.Forms.Label();
            this.btn_Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Socket_Connection
            // 
            this.Socket_Connection.IsBlocked = false;
            this.Socket_Connection.recieve += new Socktes.RecieveEventHandler(this.Socket_Connection_recieve);
            // 
            // Socket_Listen
            // 
            this.Socket_Listen.Port = 7000;
            this.Socket_Listen.accept += new Socktes.AcceptEvenetHandler(this.Socket_Listen_accept);
            // 
            // btn_Listen
            // 
            this.btn_Listen.Location = new System.Drawing.Point(184, 12);
            this.btn_Listen.Name = "btn_Listen";
            this.btn_Listen.Size = new System.Drawing.Size(75, 23);
            this.btn_Listen.TabIndex = 0;
            this.btn_Listen.Text = "Listen";
            this.btn_Listen.Click += new System.EventHandler(this.btn_Listen_Click);
            // 
            // lstb_UsersList
            // 
            this.lstb_UsersList.Location = new System.Drawing.Point(12, 172);
            this.lstb_UsersList.Name = "lstb_UsersList";
            this.lstb_UsersList.Size = new System.Drawing.Size(280, 82);
            this.lstb_UsersList.TabIndex = 1;
            // 
            // lb_UsersList
            // 
            this.lb_UsersList.Location = new System.Drawing.Point(9, 153);
            this.lb_UsersList.Name = "lb_UsersList";
            this.lb_UsersList.Size = new System.Drawing.Size(136, 16);
            this.lb_UsersList.TabIndex = 2;
            this.lb_UsersList.Text = "List of IP connected";
            // 
            // txt_DatatoClient
            // 
            this.txt_DatatoClient.Location = new System.Drawing.Point(12, 79);
            this.txt_DatatoClient.Name = "txt_DatatoClient";
            this.txt_DatatoClient.Size = new System.Drawing.Size(272, 20);
            this.txt_DatatoClient.TabIndex = 3;
            // 
            // lb_DatatoClient
            // 
            this.lb_DatatoClient.Location = new System.Drawing.Point(12, 60);
            this.lb_DatatoClient.Name = "lb_DatatoClient";
            this.lb_DatatoClient.Size = new System.Drawing.Size(112, 16);
            this.lb_DatatoClient.TabIndex = 4;
            this.lb_DatatoClient.Text = "Send Data to Client";
            this.lb_DatatoClient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(184, 136);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Send";
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.lb_DatatoClient);
            this.Controls.Add(this.txt_DatatoClient);
            this.Controls.Add(this.lb_UsersList);
            this.Controls.Add(this.lstb_UsersList);
            this.Controls.Add(this.btn_Listen);
            this.Name = "Form1";
            this.Text = "Server";
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

		private void btn_Listen_Click(object sender, System.EventArgs e)
		{
			Socket_Listen.StratListen(false);
		}

		private void btn_Send_Click(object sender, System.EventArgs e)
		{
			byte[] buff = Socktes.ByesConvertor.GetBytes(txt_DatatoClient.Text);
			Socket_Connection.Send(buff);
		}

		private void Socket_Listen_accept(object Sender, Socktes.AcceptEventArgs e)
		{
			Socket_Connection.SocketHandle = e.ConnectedSocket;
		}

		private void Socket_Connection_recieve(object Sender, Socktes.RecieveEventArgs e)
		{
			string s = Socktes.ByesConvertor.BytesToString(e.Data);
			lstb_UsersList.Items.Add(s);
		}
	}
}
