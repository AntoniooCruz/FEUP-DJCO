# Gotta Go FEUP - DJCO Project 1

Team:
António Nunes da Cruz 
Pedro António Ferreira Cardoso Lopes 

Trailer of the Game : https://www.youtube.com/watch?v=mVO8KcGfq8Y&feature=youtu.be


## Description:

Inspired on an a level from an old game called Sonic the Hedgehog 2, where the goal was
only to dodge obstacles. We created a side-scroller shooter which gives the player the same
nostalgic “Sonic themed feeling” but with completely different game mechanics and goal.
The player controls a plane which initially shoots weak slow bullets and his goal is to get the
highest score by surviving the longest and destroying as many enemies as possible
including the final boss. To do so he can collect power ups which increase his power and
rings to regain health.

## Installation:

There is no need to install the game, to run the game there is only the need to run the
executable file. There are several executables, all of them with the name GottaGoFEUP,
with different extensions depending on the operating system, the user just has to choose
accordingly.

## Playing instructions:

The player’s ship can be controlled with WASD or the arrow keys, and can shoot by pressing
the left mouse button. The player has a health and power bar in the top left corner, this
health is removed every time he crashes with an enemy or gets hit by one of their bullets.
There are 3 types of enemies: Fast but weak ones (with less HP), Slow but bulky (with more
HP) and a final boss which keeps appearing getting increasingly stronger. Destroying these
enemies earns 40 and 400 points respectively.
Rings, besides earning the player 100 points also regenerate health. The player’s objective
is to obtain the highest possible score. The score is also increased by 10 points for every 10
seconds survived.


Waves get increasingly harder, so in order to be able to keep surviving the waves the player
must collect power ups: Emeralds increase the bullets size and damage, yellow orbs
increase its fire rate, and red orbs add 2 bullets fired diagonally.

## Highlights of development Process:

### Player’s mechanics:

The player’s movement and shooting mechanics turned out to be quite easy considering
there are plenty of tutorials and explanations for this as it is very common in many games.
Collisions and physics are quite simple to implement on Unity as it has many components to
deal with these.

### PowerUps:

The power up implementation is one we are quite proud of as it is very modular, and more
power ups can be easily added to the game without much code required. We have an
abstract class for a game object that only interacts with the player. Each power up
implements a method that is called upon colliding with the player, which increases the
amount of collected power ups of its type on the player, allowing power ups to be stacked.

### Enemies and Waves:

Enemies are essentially composed of three main components: the sprite, the movement and
the weapon. All these three are separated inside each object, so both the movement and
weapon code are used in all enemies, also allowing for more extensibility in terms of
diversity. To create more than one type of enemies and to balance the game, we only
needed to change the arguments for each class like health, speed, evade angle, damage
and fire rate.
As for the waves of enemies, they are a completely separate system, also very easy to
extend and balance since the wave system only needs to know the type of enemies it needs
to spawn, its quantity and spawn rate. This allows at any stage to easily create new levels
with different kinds of waves

### Final Boss:

The base of the final boss is essentially an enemy, where the movement and evasion is
similar, and the health has a bigger value. However, on top of that, we have a state machine,
where the boss has 3 stages: a normal one, a weaker one, where he opens his head and
shows a weak point, and an enraged, where he shoots much faster.
The biggest upgrade the boss has related to the other enemies is his weapon, not only it
shoots bigger and faster projectiles, it also aims at the player with strict precision, not
allowing him just to shoot him freely. He has two different attacks: one similar to the shotgun
fire from the player, and another one with a big charged projectile.


### UI and Menus:

The way the UI and the canvas works with Unity ended up being one of the biggest
obstacles in the game development, as it took us a bit of time to understand how the canvas
scales properly on different screens as well as change some components of the UI based on
the actions of the player and interactions with the world.

### Sounds / Assets / Animations:

Most of the assets and sounds were from many different versions of Sonic games
throughout the years, however many animations ended up taking a lot of time, including the
scene transition animation as it required to learn about the animations state machine.

## Resources:

Besides all the youtube and Unity tutorials we watched to understand how Unity works and
its capabilities, we also used:

- https://www.spriters-resource.com/​ : This was a website from where we download the
    sprites for the game, and then edited them to fit our game
- https://assetstore.unity.com/​ : From where we downloaded the explosion assets
- https://youtu.be/wkKsl1Mfp5M​: Unity Tutorial in shooting
- https://www.youtube.com/watch?v=zc8ac_qUXQY​ : Menu Tutorial Unity


