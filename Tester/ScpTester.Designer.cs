using System.ComponentModel;
using System.Windows.Forms;

namespace ScpTester
{
	partial class ScpTester
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScpTester));
			this.controllerNum_lbl = new System.Windows.Forms.Label();
			this.controllerNum = new System.Windows.Forms.NumericUpDown();
			this.plugin = new System.Windows.Forms.Button();
			this.unplug = new System.Windows.Forms.Button();
			this.unplugAll = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.status_lbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.status = new System.Windows.Forms.ToolStripStatusLabel();
			this.spacer = new System.Windows.Forms.ToolStripStatusLabel();
			this.resetInputs = new System.Windows.Forms.ToolStripSplitButton();
			this.buttonGroup = new System.Windows.Forms.GroupBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnXbox = new System.Windows.Forms.Button();
			this.btnRightBumper = new System.Windows.Forms.Button();
			this.btnLeftBumper = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnY = new System.Windows.Forms.Button();
			this.btnX = new System.Windows.Forms.Button();
			this.btnB = new System.Windows.Forms.Button();
			this.btnA = new System.Windows.Forms.Button();
			this.axisGroup = new System.Windows.Forms.GroupBox();
			this.rightStick = new System.Windows.Forms.Button();
			this.leftStick = new System.Windows.Forms.Button();
			this.rightStickY = new System.Windows.Forms.TrackBar();
			this.rightStickX = new System.Windows.Forms.TrackBar();
			this.leftStickY = new System.Windows.Forms.TrackBar();
			this.leftStickX = new System.Windows.Forms.TrackBar();
			this.rightTrigger_lbl = new System.Windows.Forms.Label();
			this.rightTrigger = new System.Windows.Forms.TrackBar();
			this.leftTrigger_lbl = new System.Windows.Forms.Label();
			this.leftTrigger = new System.Windows.Forms.TrackBar();
			this.rumbleInfo = new System.Windows.Forms.ToolStripSplitButton();
			this.separator = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.controllerNum)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.buttonGroup.SuspendLayout();
			this.axisGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rightStickY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rightStickX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.leftStickY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.leftStickX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rightTrigger)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.leftTrigger)).BeginInit();
			this.SuspendLayout();
			// 
			// controllerNum_lbl
			// 
			this.controllerNum_lbl.AutoSize = true;
			this.controllerNum_lbl.Location = new System.Drawing.Point(12, 17);
			this.controllerNum_lbl.Name = "controllerNum_lbl";
			this.controllerNum_lbl.Size = new System.Drawing.Size(94, 13);
			this.controllerNum_lbl.TabIndex = 0;
			this.controllerNum_lbl.Text = "Controller Number:";
			// 
			// controllerNum
			// 
			this.controllerNum.Location = new System.Drawing.Point(112, 13);
			this.controllerNum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.controllerNum.Name = "controllerNum";
			this.controllerNum.Size = new System.Drawing.Size(42, 20);
			this.controllerNum.TabIndex = 1;
			this.controllerNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.controllerNum.ValueChanged += new System.EventHandler(this.controllerNum_ValueChanged);
			// 
			// plugin
			// 
			this.plugin.Location = new System.Drawing.Point(160, 12);
			this.plugin.Name = "plugin";
			this.plugin.Size = new System.Drawing.Size(75, 22);
			this.plugin.TabIndex = 2;
			this.plugin.Text = "Plug In";
			this.plugin.UseVisualStyleBackColor = true;
			this.plugin.Click += new System.EventHandler(this.plugin_Click);
			// 
			// unplug
			// 
			this.unplug.Location = new System.Drawing.Point(241, 12);
			this.unplug.Name = "unplug";
			this.unplug.Size = new System.Drawing.Size(75, 22);
			this.unplug.TabIndex = 3;
			this.unplug.Text = "Unplug";
			this.unplug.UseVisualStyleBackColor = true;
			this.unplug.Click += new System.EventHandler(this.unplug_Click);
			// 
			// unplugAll
			// 
			this.unplugAll.Location = new System.Drawing.Point(322, 12);
			this.unplugAll.Name = "unplugAll";
			this.unplugAll.Size = new System.Drawing.Size(92, 22);
			this.unplugAll.TabIndex = 4;
			this.unplugAll.Text = "Unplug All";
			this.unplugAll.UseVisualStyleBackColor = true;
			this.unplugAll.Click += new System.EventHandler(this.unplugAll_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_lbl,
            this.status,
            this.spacer,
            this.rumbleInfo,
            this.separator,
            this.resetInputs});
			this.statusStrip1.Location = new System.Drawing.Point(0, 251);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(426, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// status_lbl
			// 
			this.status_lbl.Name = "status_lbl";
			this.status_lbl.Size = new System.Drawing.Size(76, 17);
			this.status_lbl.Text = "Latest Status:";
			// 
			// status
			// 
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(29, 17);
			this.status.Text = "N/A";
			this.status.TextChanged += new System.EventHandler(this.status_TextChanged);
			// 
			// spacer
			// 
			this.spacer.Name = "spacer";
			this.spacer.Size = new System.Drawing.Size(91, 17);
			this.spacer.Spring = true;
			// 
			// resetInputs
			// 
			this.resetInputs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.resetInputs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.resetInputs.DropDownButtonWidth = 0;
			this.resetInputs.ForeColor = System.Drawing.Color.Red;
			this.resetInputs.Image = ((System.Drawing.Image)(resources.GetObject("resetInputs.Image")));
			this.resetInputs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resetInputs.Name = "resetInputs";
			this.resetInputs.Size = new System.Drawing.Size(76, 20);
			this.resetInputs.Text = "Reset Inputs";
			this.resetInputs.ButtonClick += new System.EventHandler(this.resetInputs_ButtonClick);
			// 
			// buttonGroup
			// 
			this.buttonGroup.Controls.Add(this.btnStart);
			this.buttonGroup.Controls.Add(this.btnBack);
			this.buttonGroup.Controls.Add(this.btnXbox);
			this.buttonGroup.Controls.Add(this.btnRightBumper);
			this.buttonGroup.Controls.Add(this.btnLeftBumper);
			this.buttonGroup.Controls.Add(this.btnLeft);
			this.buttonGroup.Controls.Add(this.btnDown);
			this.buttonGroup.Controls.Add(this.btnRight);
			this.buttonGroup.Controls.Add(this.btnUp);
			this.buttonGroup.Controls.Add(this.btnY);
			this.buttonGroup.Controls.Add(this.btnX);
			this.buttonGroup.Controls.Add(this.btnB);
			this.buttonGroup.Controls.Add(this.btnA);
			this.buttonGroup.Location = new System.Drawing.Point(12, 40);
			this.buttonGroup.Name = "buttonGroup";
			this.buttonGroup.Size = new System.Drawing.Size(190, 203);
			this.buttonGroup.TabIndex = 6;
			this.buttonGroup.TabStop = false;
			this.buttonGroup.Text = "Button Toggles";
			// 
			// btnStart
			// 
			this.btnStart.BackColor = System.Drawing.Color.Transparent;
			this.btnStart.Location = new System.Drawing.Point(98, 145);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(86, 23);
			this.btnStart.TabIndex = 12;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnBack
			// 
			this.btnBack.BackColor = System.Drawing.Color.Transparent;
			this.btnBack.Location = new System.Drawing.Point(98, 174);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(86, 23);
			this.btnBack.TabIndex = 11;
			this.btnBack.Text = "Back";
			this.btnBack.UseVisualStyleBackColor = false;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnXbox
			// 
			this.btnXbox.BackColor = System.Drawing.Color.Transparent;
			this.btnXbox.Location = new System.Drawing.Point(98, 116);
			this.btnXbox.Name = "btnXbox";
			this.btnXbox.Size = new System.Drawing.Size(86, 23);
			this.btnXbox.TabIndex = 10;
			this.btnXbox.Text = "XBox Logo";
			this.btnXbox.UseVisualStyleBackColor = false;
			this.btnXbox.Click += new System.EventHandler(this.btnXbox_Click);
			// 
			// btnRightBumper
			// 
			this.btnRightBumper.BackColor = System.Drawing.Color.Transparent;
			this.btnRightBumper.Location = new System.Drawing.Point(144, 65);
			this.btnRightBumper.Name = "btnRightBumper";
			this.btnRightBumper.Size = new System.Drawing.Size(40, 40);
			this.btnRightBumper.TabIndex = 9;
			this.btnRightBumper.Text = "R B";
			this.btnRightBumper.UseVisualStyleBackColor = false;
			this.btnRightBumper.Click += new System.EventHandler(this.btnRightBumper_Click);
			// 
			// btnLeftBumper
			// 
			this.btnLeftBumper.BackColor = System.Drawing.Color.Transparent;
			this.btnLeftBumper.Location = new System.Drawing.Point(98, 65);
			this.btnLeftBumper.Name = "btnLeftBumper";
			this.btnLeftBumper.Size = new System.Drawing.Size(40, 40);
			this.btnLeftBumper.TabIndex = 8;
			this.btnLeftBumper.Text = "L B";
			this.btnLeftBumper.UseVisualStyleBackColor = false;
			this.btnLeftBumper.Click += new System.EventHandler(this.btnLeftBumper_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.BackColor = System.Drawing.Color.Transparent;
			this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLeft.Location = new System.Drawing.Point(6, 111);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(40, 40);
			this.btnLeft.TabIndex = 7;
			this.btnLeft.Text = "←";
			this.btnLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnLeft.UseVisualStyleBackColor = false;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnDown
			// 
			this.btnDown.BackColor = System.Drawing.Color.Transparent;
			this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDown.Location = new System.Drawing.Point(29, 157);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(40, 40);
			this.btnDown.TabIndex = 6;
			this.btnDown.Text = "  ↓";
			this.btnDown.UseVisualStyleBackColor = false;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnRight
			// 
			this.btnRight.BackColor = System.Drawing.Color.Transparent;
			this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRight.Location = new System.Drawing.Point(52, 111);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(40, 40);
			this.btnRight.TabIndex = 5;
			this.btnRight.Text = "→";
			this.btnRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnRight.UseVisualStyleBackColor = false;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnUp
			// 
			this.btnUp.BackColor = System.Drawing.Color.Transparent;
			this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUp.Location = new System.Drawing.Point(29, 65);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(40, 40);
			this.btnUp.TabIndex = 4;
			this.btnUp.Text = "  ↑";
			this.btnUp.UseVisualStyleBackColor = false;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnY
			// 
			this.btnY.BackColor = System.Drawing.Color.Transparent;
			this.btnY.Location = new System.Drawing.Point(144, 19);
			this.btnY.Name = "btnY";
			this.btnY.Size = new System.Drawing.Size(40, 40);
			this.btnY.TabIndex = 3;
			this.btnY.Text = "Y";
			this.btnY.UseVisualStyleBackColor = false;
			this.btnY.Click += new System.EventHandler(this.btnY_Click);
			// 
			// btnX
			// 
			this.btnX.BackColor = System.Drawing.Color.Transparent;
			this.btnX.Location = new System.Drawing.Point(98, 19);
			this.btnX.Name = "btnX";
			this.btnX.Size = new System.Drawing.Size(40, 40);
			this.btnX.TabIndex = 2;
			this.btnX.Text = "X";
			this.btnX.UseVisualStyleBackColor = false;
			this.btnX.Click += new System.EventHandler(this.btnX_Click);
			// 
			// btnB
			// 
			this.btnB.BackColor = System.Drawing.Color.Transparent;
			this.btnB.Location = new System.Drawing.Point(52, 19);
			this.btnB.Name = "btnB";
			this.btnB.Size = new System.Drawing.Size(40, 40);
			this.btnB.TabIndex = 1;
			this.btnB.Text = "B";
			this.btnB.UseVisualStyleBackColor = false;
			this.btnB.Click += new System.EventHandler(this.btnB_Click);
			// 
			// btnA
			// 
			this.btnA.BackColor = System.Drawing.Color.Transparent;
			this.btnA.Location = new System.Drawing.Point(6, 19);
			this.btnA.Name = "btnA";
			this.btnA.Size = new System.Drawing.Size(40, 40);
			this.btnA.TabIndex = 0;
			this.btnA.Text = "A";
			this.btnA.UseVisualStyleBackColor = false;
			this.btnA.Click += new System.EventHandler(this.btnA_Click);
			// 
			// axisGroup
			// 
			this.axisGroup.Controls.Add(this.rightStick);
			this.axisGroup.Controls.Add(this.leftStick);
			this.axisGroup.Controls.Add(this.rightStickY);
			this.axisGroup.Controls.Add(this.rightStickX);
			this.axisGroup.Controls.Add(this.leftStickY);
			this.axisGroup.Controls.Add(this.leftStickX);
			this.axisGroup.Controls.Add(this.rightTrigger_lbl);
			this.axisGroup.Controls.Add(this.rightTrigger);
			this.axisGroup.Controls.Add(this.leftTrigger_lbl);
			this.axisGroup.Controls.Add(this.leftTrigger);
			this.axisGroup.Location = new System.Drawing.Point(208, 40);
			this.axisGroup.Name = "axisGroup";
			this.axisGroup.Size = new System.Drawing.Size(206, 203);
			this.axisGroup.TabIndex = 7;
			this.axisGroup.TabStop = false;
			this.axisGroup.Text = "Axis Controls";
			// 
			// rightStick
			// 
			this.rightStick.BackColor = System.Drawing.Color.Transparent;
			this.rightStick.Location = new System.Drawing.Point(139, 97);
			this.rightStick.Name = "rightStick";
			this.rightStick.Size = new System.Drawing.Size(48, 48);
			this.rightStick.TabIndex = 9;
			this.rightStick.Text = "Right Stick";
			this.rightStick.UseVisualStyleBackColor = false;
			this.rightStick.Click += new System.EventHandler(this.rightStick_Click);
			// 
			// leftStick
			// 
			this.leftStick.BackColor = System.Drawing.Color.Transparent;
			this.leftStick.Location = new System.Drawing.Point(39, 97);
			this.leftStick.Name = "leftStick";
			this.leftStick.Size = new System.Drawing.Size(48, 48);
			this.leftStick.TabIndex = 8;
			this.leftStick.Text = "Left Stick";
			this.leftStick.UseVisualStyleBackColor = false;
			this.leftStick.Click += new System.EventHandler(this.leftStick_Click);
			// 
			// rightStickY
			// 
			this.rightStickY.Location = new System.Drawing.Point(106, 80);
			this.rightStickY.Maximum = 32767;
			this.rightStickY.Minimum = -32768;
			this.rightStickY.Name = "rightStickY";
			this.rightStickY.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.rightStickY.Size = new System.Drawing.Size(45, 79);
			this.rightStickY.TabIndex = 7;
			this.rightStickY.TickFrequency = 13107;
			this.rightStickY.ValueChanged += new System.EventHandler(this.rightStickY_ValueChanged);
			// 
			// rightStickX
			// 
			this.rightStickX.Location = new System.Drawing.Point(106, 156);
			this.rightStickX.Maximum = 32767;
			this.rightStickX.Minimum = -32768;
			this.rightStickX.Name = "rightStickX";
			this.rightStickX.Size = new System.Drawing.Size(94, 45);
			this.rightStickX.TabIndex = 6;
			this.rightStickX.TickFrequency = 13107;
			this.rightStickX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.rightStickX.ValueChanged += new System.EventHandler(this.rightStickX_ValueChanged);
			// 
			// leftStickY
			// 
			this.leftStickY.Location = new System.Drawing.Point(6, 80);
			this.leftStickY.Maximum = 32767;
			this.leftStickY.Minimum = -32768;
			this.leftStickY.Name = "leftStickY";
			this.leftStickY.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.leftStickY.Size = new System.Drawing.Size(45, 79);
			this.leftStickY.TabIndex = 5;
			this.leftStickY.TickFrequency = 13107;
			this.leftStickY.ValueChanged += new System.EventHandler(this.leftStickY_ValueChanged);
			// 
			// leftStickX
			// 
			this.leftStickX.Location = new System.Drawing.Point(6, 156);
			this.leftStickX.Maximum = 32767;
			this.leftStickX.Minimum = -32768;
			this.leftStickX.Name = "leftStickX";
			this.leftStickX.Size = new System.Drawing.Size(94, 45);
			this.leftStickX.TabIndex = 4;
			this.leftStickX.TickFrequency = 13107;
			this.leftStickX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.leftStickX.ValueChanged += new System.EventHandler(this.leftStickX_ValueChanged);
			// 
			// rightTrigger_lbl
			// 
			this.rightTrigger_lbl.Location = new System.Drawing.Point(106, 45);
			this.rightTrigger_lbl.Name = "rightTrigger_lbl";
			this.rightTrigger_lbl.Size = new System.Drawing.Size(94, 19);
			this.rightTrigger_lbl.TabIndex = 3;
			this.rightTrigger_lbl.Text = "Right Trigger";
			this.rightTrigger_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rightTrigger
			// 
			this.rightTrigger.Location = new System.Drawing.Point(106, 19);
			this.rightTrigger.Maximum = 255;
			this.rightTrigger.Name = "rightTrigger";
			this.rightTrigger.Size = new System.Drawing.Size(94, 45);
			this.rightTrigger.TabIndex = 2;
			this.rightTrigger.TickFrequency = 51;
			this.rightTrigger.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.rightTrigger.ValueChanged += new System.EventHandler(this.rightTrigger_ValueChanged);
			// 
			// leftTrigger_lbl
			// 
			this.leftTrigger_lbl.Location = new System.Drawing.Point(6, 45);
			this.leftTrigger_lbl.Name = "leftTrigger_lbl";
			this.leftTrigger_lbl.Size = new System.Drawing.Size(94, 19);
			this.leftTrigger_lbl.TabIndex = 1;
			this.leftTrigger_lbl.Text = "Left Trigger";
			this.leftTrigger_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// leftTrigger
			// 
			this.leftTrigger.Location = new System.Drawing.Point(6, 19);
			this.leftTrigger.Maximum = 255;
			this.leftTrigger.Name = "leftTrigger";
			this.leftTrigger.Size = new System.Drawing.Size(94, 45);
			this.leftTrigger.TabIndex = 0;
			this.leftTrigger.TickFrequency = 51;
			this.leftTrigger.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.leftTrigger.ValueChanged += new System.EventHandler(this.leftTrigger_ValueChanged);
			// 
			// rumbleInfo
			// 
			this.rumbleInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.rumbleInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.rumbleInfo.DropDownButtonWidth = 0;
			this.rumbleInfo.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.rumbleInfo.Image = ((System.Drawing.Image)(resources.GetObject("rumbleInfo.Image")));
			this.rumbleInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.rumbleInfo.Name = "rumbleInfo";
			this.rumbleInfo.Size = new System.Drawing.Size(98, 20);
			this.rumbleInfo.Text = "Get Rumble Info";
			this.rumbleInfo.ButtonClick += new System.EventHandler(this.rumbleInfo_ButtonClick);
			// 
			// separator
			// 
			this.separator.Name = "separator";
			this.separator.Size = new System.Drawing.Size(10, 17);
			this.separator.Text = "|";
			// 
			// ScpTester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 273);
			this.Controls.Add(this.axisGroup);
			this.Controls.Add(this.buttonGroup);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.unplugAll);
			this.Controls.Add(this.unplug);
			this.Controls.Add(this.plugin);
			this.Controls.Add(this.controllerNum);
			this.Controls.Add(this.controllerNum_lbl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ScpTester";
			this.Text = "SCP Emulated X360 Controller Tester";
			((System.ComponentModel.ISupportInitialize)(this.controllerNum)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.buttonGroup.ResumeLayout(false);
			this.axisGroup.ResumeLayout(false);
			this.axisGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.rightStickY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rightStickX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.leftStickY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.leftStickX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rightTrigger)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.leftTrigger)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label controllerNum_lbl;
		private NumericUpDown controllerNum;
		private Button plugin;
		private Button unplug;
		private Button unplugAll;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel status_lbl;
		private ToolStripStatusLabel status;
		private GroupBox buttonGroup;
		private Button btnStart;
		private Button btnBack;
		private Button btnXbox;
		private Button btnRightBumper;
		private Button btnLeftBumper;
		private Button btnLeft;
		private Button btnDown;
		private Button btnRight;
		private Button btnUp;
		private Button btnY;
		private Button btnX;
		private Button btnB;
		private Button btnA;
		private GroupBox axisGroup;
		private Button rightStick;
		private Button leftStick;
		private TrackBar rightStickY;
		private TrackBar rightStickX;
		private TrackBar leftStickY;
		private TrackBar leftStickX;
		private Label rightTrigger_lbl;
		private TrackBar rightTrigger;
		private Label leftTrigger_lbl;
		private TrackBar leftTrigger;
		private ToolStripSplitButton resetInputs;
		private ToolStripStatusLabel spacer;
		private ToolStripSplitButton rumbleInfo;
		private ToolStripStatusLabel separator;
	}
}

