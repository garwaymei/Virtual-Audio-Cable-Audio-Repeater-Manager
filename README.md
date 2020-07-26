# Virtual Audio Cable Audio Repeater Manager
 A graphics application for automating Virtual Audio Cable's Audio Repeaters.
 
## Installation
This program is only really made for Windows. However, if you want to, you can look into my awful C# code and find a way to compile it for other operating systems. You will need to have Eugene Muzychenko's Virtual Audio Cable installed (duh). This program does not include VAC; however, you can find VAC [here](https://vac.muzychenko.net/en/).

Once you have installed VAC, you can do your own configuring of the cables with the VAC Control Panel. Next, download this repo. The only thing that you really need to keep is the *Program* folder.  Once you have moved the *Program* folder to a suitable location (and you can change the folder name if you would like), you will need to open up  *data\defaultrepeater* with your favorite text editor. You will see this line of text: *C:\Program Files\Virtual Audio Cable\audiorepeater.exe*. Change that to the directory of where the MME Audio Repeater is located.

If you would like to have this program run on startup, you will need to manually add a shortcut to the startup folder.

Once you have done all of that, the installation is done!

## How to use
There are two main parts of the program: the toolbar and the canvas. The toolbar contains buttons to help with editing graphs and starting or stopping the engine (the term I will be using for the running audio repeaters). The canvas helps with editing devices (a module that represents an audio device). We will be showing how to use each part with the following sections.

### Toolbar
The two tools on the top of the toolbar are the Hand (H) and Link (L) tools. You can switch selection between the two tools. When the Hand tool is selected, you can drag around devices in the graph. When the Link tool is selected, you can link devices together. Each link is its own audio repeater and you can only link two devices up to once.

The next two (under the Hand and Link tools) are Load Graph and Save Graph. These buttons allows you to save the graph into a file inside the *save* folder or load up a previously saved graph.

The tools following those are the Add Device (T) and Remove Device (Delete) buttons. The Add Device button brings up a pop-up that will ask to select a WaveIn or WaveOut device. The Remove device button will remove the selected device (more on the selected device later).

The last two tools are used for the engine. The button to the left is the Restart (R) button, which will turn off the engine (if it is not already on) and turn it back on. The next button is used for Start or Stop (P). On the start of the program, the engine will be up.

### Canvas
You are able to drag and link devices using the Hand and Link tool mentioned before. To link two devices, one device needs to be WaveIn (green) and the other needs to be WaveOut (red). While you have the Link tool selected, you will click once on one device and then click on another. If it is a valid link, a line should connect the two devices.

When you click on a device, it will make the device the selected device. It will be indicated by being the color gray. If you click any empty space in the canvas, it will clear the selected device.

When you right click on a device, you will be able to see a list of devices that it is linked to. When you click on a device from the list, it will bring up the settings for link. In that window, you can also remove the link.

### Finishing off
This program will not auto-save, so when you make any changes that you would like to keep, make sure to save the graph.

You will be able to have two devices for the same audio device. That means that if there is any reason for adding two audio repeaters to the same two audio devices, it is possible.

The engine will be on at the start of the program, so if you put it into startup, there is nothing that you will need to do to start the engine.

If you would like to restart the engine without pulling up the program, you can there is a hotkey bound to Scroll Lock.
