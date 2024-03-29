# Create Synthetic Event Camera footage in Unity.

![ezgif com-gif-maker (1)](https://user-images.githubusercontent.com/32450751/189521542-46781f2d-123e-45d9-a4b3-60b7f9ab2530.gif)


This is the GitHub page relative to the paper **"Event Camera Simulator in Unity"**, my Computer Vision course project. A copy of the paper can be found in this repository, it provides all the details of the project. In this repository you can find:

- code: the two necessary scripts
- a simple installation guide,
- how to use indications,
- a video-tutorial.

### System Requirements

For the project I've used:

- OS: Ubuntu 18.04
- ROS melodic
- Unity 2019.4.11f1
- ESIM: an Open Event Camera Simulator [https://github.com/uzh-rpg/rpg_esim](https://github.com/uzh-rpg/rpg_esim)

The OS and ROS version decision was imposed by ESIM, since these are the latest versions supported by the software.

### Setup process/ installation guide

- Install and try out the ESIM event camera simulator. The GitHub page [https://github.com/uzh-rpg/rpg_esim](https://github.com/uzh-rpg/rpg_esim) gives all the necessary instructions to do so (including a link to ROS software installation and set-up).
- Install Unity and create a scene (even very simple, with some motion of course).
- Add in your Unity project, through the Unity Package Manager, the Unity Recorder package (may be still in preview).
- In this GitHub repository two scripts have been loaded, a C# and bash script, called RecordImageSeq.cs and scriptRos.sh. Add them in your Scripts folder. Please remember to change the properties of the bash script, allowing it to execute as a program.
- Attach the "RecordImageSeq.cs" script to a gameObject (any).

### How To use

- In the gameObject's Inspector (the same gameObject on which the C# script has been attached to), the user can adjust some basic event camera parameters.
- By entering play mode, the game view will display two buttons, one to start recording and one to stop it. Once the recording stops, the conversion into simulated event camera footage starts automatically.

### Explanatory video tutorial: [https://youtu.be/c93DNSUmXrE](https://youtu.be/c93DNSUmXrE)
<a href="http://www.youtube.com/watch?feature=player_embedded&v=c93DNSUmXrE
" target="_blank"><img src="http://img.youtube.com/vi/c93DNSUmXrE/0.jpg" 
alt="ESIM with Unity Tutorial" width="300" height="180" border="10" /></a>
