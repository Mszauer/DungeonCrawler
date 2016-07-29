# Dungelot Clone
##Screenshots
![alt text](https://github.com/Mszauer/DungeonCrawler/blob/master/Screenshots/Dungelot1.PNG "Start Scene") ![alt text](https://github.com/Mszauer/DungeonCrawler/blob/master/Screenshots/Dungelot2.PNG "Hero Selection Scene")![alt text](https://github.com/Mszauer/DungeonCrawler/blob/master/Screenshots/Dungelot3.PNG "In-Game Scene")

##Purpose
Having just finished learning about how 2D frameworks function and work, it was time to implement my new knowledge into an actual game. I was playing Dungelot at the time and figured that it was a good game to try and clone for practice.

##Learning Objectives
###Planning
After having chosen the game, I had to figure out how the game was designed. It wasn't just a simple game loop anymore, but involved scenes,characters, and even data serialization. The first thing to do was start big and simple, then move onto the finer details. First the scenes had to be planned out, along with it's UI. The UI in each scene would be different, due to the nature of the scenes. Characters came next, followed lastly by the actual gameplay. There were two things that were challenging during the planning phase. The first one was figuring out how to create the in-game tiles and hidden tiles, which got solved by making them into buttons and turning on/off rather than keeping a state machine for each tile.

###Patterns
Similarly to components I have already learned about patterns. These patterns were set up mainly for class inheritance and organizational purposes.

###Components
Some components I had previously written for my previous learning lessons and I just imported whichever ones were appropriate and needed. There were some new Managers that had to be created specifically for this game, but my goal was to keep components as few as possible to have clean and easily maintainable code. 

###Managers
Having been previously written the manager code logic was already completed. I already had theoretical application of managers and how to use them from making sure they work, but the real goal was the practicle application of managers in a game setting.

###Scenes
This part was a new concept. My previous games were always just a game loop with start,update,death logic driving it. I had create a start screen followed by a hero selection scene. Each scene needed a way to access the following scene, sometimes with multiple options being available. Overall I would have to say this was one of the easier sections to create, because each scene just contained previously written information. I would just add components and their subsequent logics into the scenes.

###Debugging / QA
With so many pieces to this project, there were a lot of things that did not work on the first try. From sounds to buttons not clicking to sprites rendering wrong visually were all things that I encountered. Debugging these issues made me learn a lot, as I had to know exactly what was happening. 
