using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Client
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Socktes.ConnectSocket Socket_Connection;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Socket_Connection
			// 
			this.Socket_Connection.IsBlocked = false;
			this.Socket_Connection.recieve += new Socktes.RecieveEventHandler(this.Socket_Connection_recieve);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(0, 160);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(288, 95);
			this.listBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 144);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Recived Messages";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(208, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Connect";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(208, 104);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "Send";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 72);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(272, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "textBox1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Send Message";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Client";
			this.ResumeLayout(false);

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

		private void button1_Click(object sender, System.EventArgs e)
		{
			Socket_Connection.Connect("127.0.0.1",4000);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			byte[] b = Socktes.ByesConvertor.GetBytes(textBox1.Text);
			Socket_Connection.Send(b);
		}

		private void Socket_Connection_recieve(object Sender, Socktes.RecieveEventArgs e)
		{
			string s = Socktes.ByesConvertor.BytesToString(e.Data);
			listBox1.Items.Add(s);
		}
	}
}
