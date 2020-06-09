# Hac-A-Pac
Unity3d Project For Building Pacman levels, for all audiences.
Built on Unity3D 2019.3.9f1

Created by Norton Pengra, Patrick Sharp & Richard Tian of UW CSE 482. With special thanks to Igal, who provided us with invaluable feedback.

[**User Manual**](https://docs.google.com/document/d/1zDTbg5PcCROHcEyc_votvqFmoEFckwvYZf_-_05T2_M/edit?usp=sharing)

![](https://i.imgur.com/ar4Bcm9.png)

## How to Play
1. Navigate to https://github.com/qwergram/hacapac.
2. Click on “Clone or download”, and then click on “Download ZIP” from the drop down menu.
3. Extract the downloaded ZIP file and open the “Hac-A-Pac User Files” folder.
4. Click on the “Hac-A-Pac” executable file to run the game.


## Project Goals
To build a piece of software that allows students with any intellectual capabilities and with any physical capabailities to design a pacman level and play it.

## Project Development/User Stories Implemented

### Situation 1: Users want to be able to build their own games
Before: 

A user plays a game. They find it okay, but wish they could make some changes to it.
They might find it too complicated, or want to make a few adjustments, or change the game significantly.

![](https://imgur.com/h5gO6LC.png)

The user abandons the game because it’s not to their liking.
Perhaps the teacher helps them find another game, which might take time away from other important things.

![](https://imgur.com/IsCP3sy.png)

After:

A user plays a game. They find it okay, but wish they could make some changes to it.
They might want to make a few adjustments, or change the game significantly.
They use the icon on the left of the screen to enter editor mode.

![](https://imgur.com/16YNx8N.png)

They use the buttons and tools in the editor mode to make changes to the game.
They use the play button to the left to play the game again, with their changes.

![](https://imgur.com/dxsE5Ig.png)


They play the game they’ve made. If they want to make any more changes, they can use the wrench icon again to make further changes.

![](https://imgur.com/pw7mIAK.png)


## Constraints & Limitations
This project was completed in 10 weeks with 3 team members who are taking full course loads. In addition, due to the Corona virus pandemic, we were unable to meet face to face with our primary users and observe how they'd use the application, making user testing difficult.

## User Testing
Users were asked to perform the following tasks. Upon completion, they were asked to fill out [this form](https://docs.google.com/document/d/1PIIJ0_iiXFzCvPJKhiXqd_v9fs3ibofJi_-GZhdpUpg/edit?usp=sharing).

- Navigate through menus
  - Go to the play menu
  - Go back
  - Go to the editor menu
  - Go back
  - Go to the settings menu
  - Decrease the sound volume to 0%
  - Decrease the music volume to around 50%
  - Decrease the master volume to around 50%

- Build and play an easy level:
  - Go to the editor menu
  - Put down Pac-Man in the middle
  - Put pellets around Pac-Man
  - Put walls around the pellets
  - Go to the play menu
  - Play and beat the level you built


- Increase the difficulty:
  - Go to the settings menu
  - Increase Pac-Man’s speed
  - Go to the play menu
  - Replay and beat the same level you built before

- Build and play a basic level:
  - Go to the editor menu
  - Erase the level from before
  - Build a new level with Pac-Man, pellets, walls, and at least one power pellet and one stationary ghost
  - Go to the play menu
  - Play and beat the level you built

- Build and play an advanced level:
  - Go to the editor menu
  - Erase the level from before
  - Build a new level with Pac-Man, pellets, walls, and at least one power pellet, one horizontal and one vertical ghost
  - Go to the play menu
  - Play and beat the level you built

- Increase the difficulty:
  - Go to the settings menu
  - Increase the ghosts’ speed
  - Decrease the ghosts’ frightened timer
  - Replay and beat the same level you built before

### Preliminary Results

During testing with our three users, we learned that many users’s behaviors were heavily affected by games they typically played. For instance, users who played SimCity expected SimCity game input mechanics in the Pacman game (e.g. the ability to fill multiple spaces in the editor by dragging the mouse, visual snapping of the selected tool to a space on the grid before you place it, etc). 

We were then educated by another user of an “unspoken protocol” of game menu design, which is prevalent throughout all AAA titles. For instance, “continue/resume” should be the first item of the pause menu, settings should automatically save and accessibility should be moved into the video settings/audio settings.

In addition, Testing identified the following issues to solve. In this section, we will identify all the issues we’d like to solve. In the next section, we will discuss how we will prioritize the issues in our next development cycle. The issues discovered during testing in no particular order are:

- Editor Menu Usability Issues:
  - If you want to place down a lot of the same kind of tile, there is no quick way to do that. It requires lots of individual clicks
  - Two of our users wanted to place large amounts of walls (similar to the original pac-man level) and found the amount of clicks required to be tedious
  - No visual feedback on where the item is going to be placed.
  - The same two users are used to SimCity mechanics, where a small outline/highlight appears where the entity selected would be placed if the mouse button was pressed, right at that moment.
  - No ability to save and edit multiple levels
  - One of our users wanted to work on multiple level concepts at a time (one with enemies and one that was essentially a test of their speed at picking up pellets), but they realized that working on a different level would erase the level they were currently building
  - No ability to undo within the editor
  - All three users expressed frustration that there was no button to undo an action in the editor, and that they had to manually use the existing tools to fix a mistake
- Settings Usability Issues:
  - No reset to default settings option
  - One of our users wanted to revert to the default settings after messing around with the settings, but was unable to remember the default values
  - No numerical indication/real graphical feedback on scalar value settings (e.g. volumes, pacman speeds).
  - All users specifically wondered if they could freeze the ghosts by dragging the slider all the way to the left (set ghost speed to 0). They couldn’t get the information directly from the settings menu, and were forced to load the game to have that question answered.
  - Unexpected location of settings related to Accessible Control Schemes.
  - One user who regularly played Minecraft, voiced that the settings menu layout was too confusing, and suggested the menu layout follow Minecraft’s settings layout exactly. For instance, accessibility related menu items should be placed under video/audio/controller settings.
- Game Play Usability Issues:
  - No restart level option
  - One of our users wanted to restart a level after messing up and could only do so by pressing the back button and the play button again
  - Controller support hasn’t been added yet
  - One user wanted to test out the ability to play the game with a controller.
  - No visual feedback on which button was pressed
  - One user suggested that it should be clearer on screen when a button is pressed, to add additional feedback and information about the character’s movement on screen.

Unfortunately, due to time constraints, we created a Github Issue for each issue, but were unable to provide any meaningful fixes for  some of the issues due to time constraints. We did however, provide the following fixes and features:

- Play Menu:
  - Added a shortcut button to the editor menu
  - Added a restart level button
- Editor Menu:
  - Editor saves the edited level to a file
  - Editor loads the edited level to make further edits
  - Added a shortcut button to the play menu
  - Sprites properly clip to the right slots


## Conclusion + Future Directions

Using the experience we know now, and given unlimited resources, we'd like to address the bugs, and also provide better developer documentation for the tools we created. We'd also have liked an opportunity to meet face to face with our stakeholders, and take notes on how they used our app.

However, we've laid out important groundwork for future teams who'd like to work on this project. We've built middleware for letting users keybind any keys to any action (which is not in Unity by default), a pacman base game with interchangeable sprits, an editor that modifies the behavior of the pacman games, and a settings menu that tailors the experience to each student. Our hope is to one day for a developer (us or someone else) to continue to build off of this base, and bring the experience of gaming to heterogenous populations.
