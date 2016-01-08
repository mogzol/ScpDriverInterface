# ScpDriverInterface

ScpDriverInterface uses Scarlet.Crush's SCP Virtual Bus Driver to emulate XBox 360 controllers. Credits and major props go to  [Scarlet.Crush](http://forums.pcsx2.net/User-Scarlet-Crush) for his awesome [SCP Server software](http://forums.pcsx2.net/Thread-XInput-Wrapper-for-DS3-and-Play-com-USB-Dual-DS2-Controller), without his work this wouldn't be possible.

## Downloads

Head over to the project's [releases page](https://github.com/mogzol/ScpDriverInterface/releases) to download the latest compiled version of ScpDriverInterface, along with an installer for the SCP Virtual Bus Driver (credit to Scarlet.Crush) and a tester application.

## Usage

The binary for ScpDriverInterface is a .NET DLL file written in C#. You can get this file in the downloads section above, along with XML documentation and some other useful apps.

Just a note, the example code here is all in C#, but it should be pretty similar for other languages.

### A Note on Return Values

Before we begin, I just want to mention that ScpBus's `PlugIn()`, `Unplug()`, `UnplugAll()`, and `Report()` methods will all return boolean values indicating whether or not the operation was successful (i.e. True if the operation was successful, False otherwise). While you aren't required to use these returned values, I would recommend that you do use them whenever you want to make sure that what you wanted to happen actually happened.

### Creating a New ScpBus Object

After adding the DLL to your project, usage is very straightforward. First you must create a new ScpBus object:

```C#
ScpBus scpBus = new ScpBus();
```
Note that this will throw an IOException if ScpBus isn't able to get a handle to the SCP Virtual Bus Device (Usually this is because the SCP Virtual Bus Driver isn't installed).

### Plugging In and Unplugging Virtual Controllers

Next you will want to plug in a virtual controller. Plugging in and unplugging is done with the `PlugIn()`, `Unplug()` and `UnplugAll()` methods. Multiple controllers can be plugged in at the same time, just use a unique `controllerNumber` for each separate controller. For example, this code will plug in 4 controllers:

```C#
scpBus.PlugIn(1);
scpBus.PlugIn(2);
scpBus.PlugIn(3);
scpBus.PlugIn(4);
```

Unplugging controllers works much the same way. If you wanted to unplug controller 3, you would use `scpBus.Unplug(3);`. If you wanted to unplug all currently plugged in controllers, you would use `scpBus.UnplugAll();`.

### Sending Inputs to the Virtual Controllers

To send inputs to a controller, you use the `Report()` method. This method takes a 20-byte XBox 360 controller input report, as specified [here](http://free60.org/wiki/GamePad#Input_report). To make this easier, ScpDriverInterface includes the X360Controller class, which can generate the report for you. To use it, first create a new X360Controller object:

```C#
X360Controller controller = new X360Controller();
```

Now you need to set up the state of the controller. Analog inputs (triggers and thumbsticks) are easy, just set them to the desired value (triggers use 8-bit unsigned integers, thumbsticks use 16-bit signed integers). For example, this code would set the left trigger to be fully pushed in, the right trigger to be halfway pushed in, and the right thumbstick to be pointing diagonally up and to the right:

```C#
controller.LeftTrigger = 255;
controller.RightTrigger = 128;
controller.RightStickX = 32767;
controller.RightStickY = 32767;
```

Buttons are also very straightforward; you can use them like flags. For example, to set A to be pressed, without affecting the states of any of the other buttons, you would use the bitwise or operator:

```C#
controller.Buttons |= X360Buttons.A;
```

You can assign multiple buttons in a single statement. For example, this code would set A, B, Up, and the left bumper to be pressed, again not affecting the state of any other buttons:

```C#
controller.Buttons |= X360Buttons.A | X360Buttons.B | X360Buttons.Up | X360Buttons.LeftBumper;
```

If instead of setting a button to be pressed, you just wanted to toggle its state, you would use the bitwsise xor operator. For example, this would toggle the A button:
```C#
controller.Buttons ^= X360Buttons.A;
```

And if you wanted to set a button to be **not** pressed, regardless of its initial state, you would use the bitwise and operator combined with a negation. For example, this would set A to be not pressed:

```C#
controller.Buttons &= ~X360Buttons.A;
```

Once you are done setting up the state of the controller, you can use the `GetReport()` method to get the 20-byte input report that can be used with ScpBus's `Report()` method. For example, if you had set up `controller` to be the state you wanted controller 2 to be in, then you would use this code to send that state to the virtual controller:

```C#
scpBus.Report(2, controller.GetReport());
```

### Virtual Controller Rumble Data

ScpBus's `Report()` method can also give you rumble data about the specified controller. To get this data, add a third parameter when you call `Report()`, an 8-byte array that will have the controller's output report written to it. After calling `Report()`, you should verify that the output report it gives you is a rumble report by verifying that the second byte is equal to 0x08. If it is, then the fourth byte will have the speed for the rumble motor with the big weight, and the fifth byte will have the speed for the rumble motor with the small weight (0x00 to 0xFF in both cases).

**IMPORTANT NOTE**: The SCP Virtual Bus Device only returns rumble data with when the controller's rumble values have changed. This means that whenever the rumble values change, **only the next call** to `Report()` will receive those values. All subsequent calls will not receive any rumble report at all, at least not until the controller gets new rumble values. So, if you care about rumble data, you should **always** use the 3-parameter version of `Report()` (the one with the output report byte-array as the third parameter), and you should check the output report for new rumble data after **every** call to `Report()`.

Here is some example code that will print the rumble data for controller 1 to the console, provided that `Report()` gives an output report with rumble data:

```C#
byte[] outputReport = new byte[8];
scpBus.Report(1, controller.GetReport(), outputReport);

if (outputReport[1] == 0x08)
{
	byte bigMotor = outputReport[3];
    byte smallMotor = outputReport[4];
    
    Console.WriteLine("Big Motor: {0}, Small Motor: {1}", bigMotor, smallMotor);
}
```

### Disposing of ScpBus objects

Each instance of ScpBus contains a SafeFileHandle to an SCP Virtual Bus Device. If you call `Close()` or `Dispose()` on an ScpBus instance, then that SafeFileHandle will be closed immediately, and that ScpBus instance will become unusable. Whenever you are done with an ScpBus instance, you should call one of those methods to dispose of it and free up memory. If you don't then the .NET garbage collector should eventually dispose of it for you, but you have no control over how long this will take, so the object will just hang around taking up memory for some indeterminate amount of time.

## Credits

Again, I want to stress that I am not the creator of the SCP Virtual Bus Driver, all I did was create this library that allows you to use it easily. The driver itself was made by pcsx2 forum user [Scarlet.Crush](http://forums.pcsx2.net/User-Scarlet-Crush). For more details, check out his awesome [SCP Server software](http://forums.pcsx2.net/Thread-XInput-Wrapper-for-DS3-and-Play-com-USB-Dual-DS2-Controller), which is what I based most of the code for this project off of.

Thank You!