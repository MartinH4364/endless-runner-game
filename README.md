# **Endless Runner Game**
An endless platformer focused on movement mechanics and abilities.

<img width="400" height="225" alt="Video Project" src="https://github.com/user-attachments/assets/ec34c4bd-6800-4f45-9c10-d01cede10292" />

## **https://drcooke123.itch.io/endless-runner-test**
^^Open Link Above^^

Features

*Core movement system with sprinting, jumping, and sliding

*Endlessly generating rooms

*Slow (but with increasing speed) destruction of the world behind you

*Two random abilities given at the start of the game

*Upgrades that are selectable once in a while that will increase the player's stats, and silver upgrades that give special abilities

*Corrupted rooms generating once in a while after upgrades are selected

## Technical choices
I have no idea if these choices are advanced or not because this is the first game I made using Unity. I chose to use a static variable for the score so that when the player dies and switches to the game over scene, the score can be displayed. I also wrote a script that applies an upgrade from the name of the upgrade so that all of the upgrades could have the same script attached to them. I also used a system that found the error between the target and current camera y position/FOV and changed the corresponding value by a fraction of that error to create a smooth camera movement when crouching/sprinting.

I think the most important technical decision was to use variables for x, y, and z velocity instead of applying Vector3.forward to the player. I wanted to make it so that the player would keep moving in the direction that they were moving in when they left the ground when in the air and also have less control over their movement when in the air. Using Vector3.forward would have allowed the code to be much simpler, but turning left or right while in the air would change the direction of "forward," allowing the player to turn midair. The added complexity of having a velocity system also allowed me to put different amounts of drag on the variables depending on if the player is in the air or sliding. To implement the movement abilities, I made it so that a change in the velocity would be queued when the key to activate an ability was pressed. That queued value would later be applied at a fixed time in the loop so that the resulting movement would be consistent every time the ability was used.

To run this project locally, download the files and then open them using the latest version of unity.

## Credits

Brackeys for various tutorials
Gabriel Aguiar Prod. for VFX tutorials
Pixabay for sound effects
Unity discussions and docs for help
Inspired by Grace and White Knuckle
