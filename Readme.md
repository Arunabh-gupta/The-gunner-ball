# THE GUNNER BALL

The Gunner Ball is a top down survival shooter game. This game was build on Unity game engine.

Description:

- The movement of the player is based on rigidbody physics and vector calculations.
- A random map generation algorithm was used to spawn enemies and powerups at random positions in the arena.
- An enemy AI was used (based on rigidbody physics and vector calculations) to move the enemy character towards the player and shoot when in range.
- The gun system was implemented with the help of of a gun container class which stored all the different kinds of projectile weapons. A gun class was also used to make different weapons with different properties.
- The audio manager system is made using singleton design pattern. It was easy to implement this system as I didn't have to hardcode each and every audio file in the code.
- The camera shake effect was added to add a little more juice to game. Camera shake is triggered whenever any kind of collision takes place with the bullets. It is implemented by adding a spring joint component to the main camera and adding a little force to it which decays over the time due to linear drag.
- Death animations and other particle animations were added using a particlesystem manager which was used to keep track of all kinds of particle effects/animations. These particle animations were made in the Unity's particle system.
- 
