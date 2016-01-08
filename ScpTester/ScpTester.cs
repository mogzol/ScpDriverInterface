using System;
using System.Drawing;
using System.Windows.Forms;
using ScpDriverInterface;

namespace ScpTester
{
	public partial class ScpTester : Form
	{
		private ScpBus _scpBus;
		private X360Controller _controller = new X360Controller();

		private bool _numberChangeCheck = true;
		private bool _resetting = false;
		private byte[] _outputReport = new byte[8];
		private bool _rumbleValid = false;
		private byte _bigRumble = 0;
		private byte _smallRumble = 0;

		public ScpTester()
		{
			InitializeComponent();

			controllerNum.Tag = controllerNum.Value;
			leftTrigger.Tag = leftTrigger.Value;
			rightTrigger.Tag = rightTrigger.Value;
			leftStickX.Tag = leftStickX.Value;
			leftStickY.Tag = leftStickY.Value;
			rightStickX.Tag = rightStickX.Value;
			rightStickY.Tag = rightStickY.Value;

			try
			{
				_scpBus = new ScpBus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(1);
			}
		}

		private void controllerNum_ValueChanged(object sender, EventArgs e)
		{
			if (_numberChangeCheck && (_controller.Buttons != X360Buttons.None || _controller.LeftTrigger != 0 || _controller.RightTrigger != 0 || _controller.LeftStickX != 0 || _controller.LeftStickY != 0 || _controller.RightStickX != 0 || _controller.RightStickY != 0))
			{
				DialogResult result = MessageBox.Show("Changing controllers will reset the current controller to the default state. Continue?\n\nNote: This isn't a limitation of the driver, I just didn't want to deal with multiple controller inputs when programming this tester.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.No)
				{
					_numberChangeCheck = false;
					controllerNum.Value = (decimal)controllerNum.Tag;
					_numberChangeCheck = true;
					return;
				}

				if (!ResetControllerInputs((int)(decimal)controllerNum.Tag))
				{
					MessageBox.Show("Unable to reset controller inputs, can't switch controllers.", "Uh-oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
					_numberChangeCheck = false;
					controllerNum.Value = (decimal)controllerNum.Tag;
					_numberChangeCheck = true;
					return;
				}

				_rumbleValid = false;
				ResetControls();
			}

			controllerNum.Tag = controllerNum.Value;
		}

		private void plugin_Click(object sender, EventArgs e)
		{
			status.Text = _scpBus.PlugIn((int)controllerNum.Value).ToString();
		}

		private void unplug_Click(object sender, EventArgs e)
		{
			bool result = _scpBus.Unplug((int)controllerNum.Value);
			status.Text = result.ToString();

			if (result)
			{
				_controller = new X360Controller();
				ResetControls();
			}
		}

		private void unplugAll_Click(object sender, EventArgs e)
		{
			bool result = _scpBus.UnplugAll();
			status.Text = result.ToString();

			if (result)
			{
				_controller = new X360Controller();
				ResetControls();
			}
		}

		private void status_TextChanged(object sender, EventArgs e)
		{
			if (status.Text.ToLower() == "false")
			{
				status.ForeColor = Color.Red;
			}
			else if (status.Text.ToLower() == "true")
			{
				status.ForeColor = Color.Green;
			}
			else
			{
				status.ForeColor = SystemColors.ControlText;
			}
		}

		private bool HandleButton(Button button)
		{
			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
				return false;

			if (button.BackColor == Color.Transparent)
				button.BackColor = Color.Salmon;
			else
				button.BackColor = Color.Transparent;

			return true;
		}

		private void CheckRumble()
		{
			if (_outputReport[1] == 0x08)
			{
				_bigRumble = _outputReport[3];
				_smallRumble = _outputReport[4];
				_rumbleValid = true;
			}
		}

		private void btnA_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.A;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.A;
		}

		private void btnB_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.B;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.B;
		}

		private void btnX_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.X;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.X;
		}

		private void btnY_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Y;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Y;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Up;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Up;
		}

		private void btnLeft_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Left;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Left;
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Right;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Right;
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Down;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Down;
		}

		private void btnLeftBumper_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.LeftBumper;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.LeftBumper;
		}

		private void btnRightBumper_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.RightBumper;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.RightBumper;
		}

		private void btnXbox_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Logo;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Logo;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Start;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Start;
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.Back;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.Back;
		}

		private void leftStick_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.LeftStick;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.LeftStick;
		}

		private void rightStick_Click(object sender, EventArgs e)
		{
			_controller.Buttons ^= X360Buttons.RightStick;
			if (!HandleButton((Button)sender))
				_controller.Buttons ^= X360Buttons.RightStick;
		}

		private void leftTrigger_ValueChanged(object sender, EventArgs e)
		{
			if (_resetting)
				return;

			_controller.LeftTrigger = (byte)leftTrigger.Value;

			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
			{
				leftTrigger.Value = (int)leftTrigger.Tag;
			}
			else
			{
				leftTrigger.Tag = leftTrigger.Value;
			}
		}

		private void rightTrigger_ValueChanged(object sender, EventArgs e)
		{
			if (_resetting)
				return;

			_controller.RightTrigger = (byte)rightTrigger.Value;

			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
			{
				rightTrigger.Value = (int)rightTrigger.Tag;
			}
			else
			{
				rightTrigger.Tag = rightTrigger.Value;
			}
		}

		private void leftStickY_ValueChanged(object sender, EventArgs e)
		{
			if (_resetting)
				return;

			_controller.LeftStickY = (short)leftStickY.Value;

			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
			{
				leftStickY.Value = (int)leftStickY.Tag;
			}
			else
			{
				leftStickY.Tag = leftStickY.Value;
			}
		}

		private void leftStickX_ValueChanged(object sender, EventArgs e)
		{
			if (_resetting)
				return;

			_controller.LeftStickX = (short)leftStickX.Value;

			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
			{
				leftStickX.Value = (int)leftStickX.Tag;
			}
			else
			{
				leftStickX.Tag = leftStickX.Value;
			}
		}

		private void rightStickY_ValueChanged(object sender, EventArgs e)
		{
			if (_resetting)
				return;

			_controller.RightStickY = (short)rightStickY.Value;

			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
			{
				rightStickY.Value = (int)rightStickY.Tag;
			}
			else
			{
				rightStickY.Tag = rightStickY.Value;
			}
		}

		private void rightStickX_ValueChanged(object sender, EventArgs e)
		{
			if (_resetting)
				return;

			_controller.RightStickX = (short)rightStickX.Value;

			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (!result)
			{
				rightStickX.Value = (int)rightStickX.Tag;
			}
			else
			{
				rightStickX.Tag = rightStickX.Value;
			}
		}

		private void resetInputs_ButtonClick(object sender, EventArgs e)
		{
			bool result = ResetControllerInputs((int)controllerNum.Value);
			status.Text = result.ToString();

			if (result)
				ResetControls();
		}

		private void rumbleInfo_ButtonClick(object sender, EventArgs e)
		{
			bool result = _scpBus.Report((int)controllerNum.Value, _controller.GetReport(), _outputReport);
			CheckRumble();
			status.Text = result.ToString();

			if (result && _rumbleValid)
			{
				MessageBox.Show("Big Motor: " + _bigRumble + "\nSmall Motor: " + _smallRumble, "Rumble Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (result)
			{
				MessageBox.Show("Controller has not yet received any rumble data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool ResetControllerInputs(int controllerNumber)
		{
			X360Controller temp = new X360Controller(_controller);
			_controller = new X360Controller();

			bool result = _scpBus.Report(controllerNumber, _controller.GetReport(), _outputReport);
			CheckRumble();

			if (!result)
				_controller = temp;

			return result;
		}

		private void ResetControls()
		{
			_resetting = true;

			foreach (Control control in buttonGroup.Controls)
			{
				if (control is Button && ((Button)control).BackColor == Color.Salmon)
				{
					((Button)control).BackColor = Color.Transparent;
				}
			}

			foreach (Control control in axisGroup.Controls)
			{
				if (control is Button && ((Button)control).BackColor == Color.Salmon)
				{
					((Button)control).BackColor = Color.Transparent;
				}

				if (control is TrackBar)
				{
					((TrackBar)control).Value = 0;
				}
			}

			_resetting = false;
		}
	}
}
