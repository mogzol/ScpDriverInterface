using System.ComponentModel;
using System.Windows.Forms;

namespace ScpDriverInstaller
{
	partial class DriverInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

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
			this.credits = new System.Windows.Forms.Label();
			this.install = new System.Windows.Forms.Button();
			this.uninstall = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// credits
			// 
			this.credits.Cursor = System.Windows.Forms.Cursors.Hand;
			this.credits.Font = new System.Drawing.Font("Segoe Print", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.credits.ForeColor = System.Drawing.Color.White;
			this.credits.Location = new System.Drawing.Point(12, 163);
			this.credits.Name = "credits";
			this.credits.Size = new System.Drawing.Size(279, 36);
			this.credits.TabIndex = 0;
			this.credits.Text = "Driver by Scarlet.Crush";
			this.credits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.credits.Click += new System.EventHandler(this.credits_Click);
			// 
			// install
			// 
			this.install.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.install.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
			this.install.FlatAppearance.BorderSize = 2;
			this.install.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
			this.install.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.install.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.install.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.install.Location = new System.Drawing.Point(12, 12);
			this.install.Name = "install";
			this.install.Size = new System.Drawing.Size(279, 71);
			this.install.TabIndex = 1;
			this.install.Text = "Install Driver";
			this.install.UseVisualStyleBackColor = false;
			this.install.Click += new System.EventHandler(this.install_Click);
			// 
			// uninstall
			// 
			this.uninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.uninstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
			this.uninstall.FlatAppearance.BorderSize = 2;
			this.uninstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
			this.uninstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.uninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.uninstall.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.uninstall.Location = new System.Drawing.Point(12, 89);
			this.uninstall.Name = "uninstall";
			this.uninstall.Size = new System.Drawing.Size(279, 71);
			this.uninstall.TabIndex = 2;
			this.uninstall.Text = "Uninstall Driver";
			this.uninstall.UseVisualStyleBackColor = false;
			this.uninstall.Click += new System.EventHandler(this.uninstall_Click);
			// 
			// DriverInstaller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
			this.ClientSize = new System.Drawing.Size(303, 204);
			this.Controls.Add(this.uninstall);
			this.Controls.Add(this.install);
			this.Controls.Add(this.credits);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "DriverInstaller";
			this.Text = "SCP Driver Installer";
			this.ResumeLayout(false);

		}

		#endregion

		private Label credits;
		private Button install;
		private Button uninstall;
	}
}

