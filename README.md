# MovementScriptGenerator
A tool to simplify the creation of movement scripts for Beat Saber

This tool enables you to create camera moves for the [Camera2](https://github.com/kinsi55/CS_BeatSaber_Camera2) mod and chain them together.
This can be used to create interesting and complex shots for distinct maps (dance videos / lightshows / etc.) or simpler, repeating shots as general camera movement (streaming content) all on a single camera, without needing any editing afterwards.

Check out the [wiki](https://github.com/DragonirHD/MovementScriptGenerator/wiki) to find detailed explanations on how to use the tool.

Downloads to the mod can be found on the [releases](https://github.com/DragonirHD/MovementScriptGenerator/releases) tab. Make sure to download the newest version.

See the promotional video [here](https://youtu.be/YGpfWJvm4Hs) to find out what the tool is currently capable of.

## Move Presets
There are currently two supported move presets.
Presets are here to make camera movements, which would otherwise be very difficult to make by hand, fast and easy to create.
Each preset comes with a bunch of settings which can be tweaked to create tons of variations of the base moves.
Explanations to the settings of each preset can be found in the tool itself, by hovering over the label/the name of the setting.

### Circle
Creates a move, where the camera will circle around the player/avatar.
Can be edited to make moves where the camera will only complete a certain percentage/Sector of the circle.

#### Showcase
![](Showcase/circle.gif)

### Spiral
The camera will move on a straight line towards or away from the player/avatar.
It can turn around its own axis multiple times on this path, creating a spiralling/corkscrew-like movement.
This move can be placed everywhere around the player/avatar in the shape of a dome.

#### Showcase
![](Showcase/spiral.gif)

## Coming Features
All of these features have no definitive release date and are currently only ideas for what might be made next.
- A new field where it will be possible to chain moves together and edit the chain afterwards. (This will simplify the process of creating movements for entire songs)
- saving and loading of moves
- New Move: J-Turn
- dark mode

## Why?
I wanted to use movement scripts to enhance my own videos and add more dynamics to them.
After trying to create a circular motion by hand in a movement script file and noticing that around 360 points would have to be defined
I tried to do it programmatically to simplify the process.
This idea culminated into this tool.
