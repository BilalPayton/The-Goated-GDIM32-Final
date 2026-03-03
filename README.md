# GDIM32-Final
## Check-In
### Group Devlog
Prompt A: One of the tools that we used to solve an issue with our project
were version control techniques. The problem was that I (Bilal) committed a few changes
I made to the project and had to deal with a few merge conflicts, and after I fixed
them, my local version was missing a few important scripts and newer changes from my
team that they had pushed before my commit that I didn't have even after I had pulled
from the repositiory. To fix this, we used version control by letting my team make a new
change to their local versions of the project and commit it and push it again so I could 
pull from the repository again and get back all of the changes my local version was missing. 
However, I could have also reverted my original commit to fix this problem and fix the merge
conflicts over again before pushing, but look back at it more thoroughly to make sure there
are no issues after resolving them and our project doesn't blow up.



### Bella Sloan
Put your individual check-in Devlog here.
### Bilal Payton
I have created two different animations for the zombie npcs, that being their idle and running
animations. Currently these animations are attached to prefabs in the scene hierarchy called 
Zombie Male (Idle) and Zombie Male (Run) to clearly showcase these animations to the grading team.
I also created the first part of interacting with items by using the onMouseOver(), onMouseExit(),
and onMouseClick() methods in the item class to both debug and make interacting with items functionable.
In the scene hierarchy there is a Beans prefab that can be interacted with/picked up that has a child class
called Beans from the parent class Items which overrides the onMouseClick method to include a message to the
console that says "You have been healed for 10 health" as a placeholder for the Beans healing the player and
utilizing inheritance and polymorphism. I have also created an AudioSystem class with a member variable called
_backgroundMusic that can be tuned in the inspector that takes in audio and plays placeholder background music
when the game is started. So far our architecture plans have been consistent but many have not been implemented
yet due to them required concepts we haven't learned such as branching dialogue. Something I'll definitely improve
in my planning for future games is balancing between ambition and ability to fulfill that ambition, because it is
easy to have a bunch of cool ideas to make for a game, but also difficult to code up said ideas especially if you've
never learned how to them yet.
### Laura Liu
At this stage, I primarily completed the inventory system and basic interactive UI. For the inventory system, I utilized HotbarPanel and slots in Unity to create a bottom inventory resembling Minecraft's inventory appearance. To manage items collected into the inventory, I primarily employed two scripts. First is the Inventory script, which manages owned items. It stores items using a List<ItemData>, with Add() for adding items, Remove() for deleting items, and ResetInventory() for clearing the inventory at game start. These methods ensure players can pick up, use, and discard items. To display these actions in real-time on the Inventory Bar, I used the InventoryUI script for feedback. I used Refresh() to update the slot, displaying the corresponding item's icon. Then, through SelectSlot(), the player can choose the slot containing the item, followed by selecting subsequent actions through UseItem( ) or DropItem( ). However, both used and dropped items disappear from the Inventory Bar. Additionally, I added ItemPanel and ItemText in Unity to display the UI tips. These UI tips are managed by ItemUI and appear when the player picks up, selects, uses, or discards items. For example, after selecting an item, the UI displays its name along with prompts: pressing E to use the item and Q to drop it.


I believe the proposal has been helpful in guiding the overall project as it clearly defines the UI system and our implementation of the MVC pattern. When working on the Inventory system, I followed the MVC structure outlined in the proposal: treating Inventory and ItemData as the Model, InventoryUI as the Controller, and ItemUI as the View. This approach will make it easier to store and create different UI elements as the number of items increases in the future. However, while the proposal provided an overall structure, I found many details required further consideration and improvement during actual implementation. For instance, how to create and update the Inventory, and how to specifically display the UI step by step. These details weren't covered in the proposal, so I needed to modify the code and make adjustments in the Inspector to resolve them. However, overall I believe the structure hasn't strayed significantly from the proposal's vision. For example, I still utilized MVC as mentioned above. I simply added some new scripts during implementation. As for the Break-down, the description for the UI section was far too limited, making it not very useful to me.

### Bella Sloan
I worked on the basic player movement/keyboard input. I also tried setting up an fps style player view and movement where the player would control where to turn based on where their mouse is pointed. That still seems to have a few bugs as the camera movement feels very janky when playing the game on itch.io for some reason. (I literally just realized now that it could've been because I had written Cursor.lockState = CursorLockMode.Locked; in both Start() and Update() for some reason but maybe it's not). And I worked on getting the player to jump properly when it's in contact with the ground, using void OnCollisionEnter() and void OnCollisionExit, so the jump works perfectly fine as of now. Lastly, i've been working on setting up our game's terrain, importing 3D models from pre-made, free assets from the Unity store as well as websites like Kenny for the buildings, and building structures using those basic brick walls, roads, and whatnot given. I've also set up the two different kinds of lighting where I set up the skybox so that it mimicked a darker/nightime feel, and I added some fog that wraps around the horizon of the map. I still need to add more to the terrain and I want to expand it a bit as well as work on getting the player to climb up wraps of different steepness. 
For our proposal I'd honestly say it was probably a bit too detailed; we had a bunch of stuff in there that we didn't really end up implementing into our game, or at least haven't gotten to it yet. I think on one hand it was super helpful having everything planned out so maticulously, but I think we also bit off more than we could chew. I underestimated how much time I would have outside of my other class work, so I couldn't focus much as I wanted to on getting what I wanted done in time. We used Trello to assign roles and keep track of who's doing what which I found super helpful. Often times I'd catch myself worrying that no one had worked on a specific part of the game we needed and I'd panic just to check the Trello and think: oh phew Laura's got it done. For future games I'd honestly take a page out of one of my classmate's book and do weekly meetings outside of class or something just to keep everyone on top of things...I know that certainly helps me, also with just double checking and making sure everything is going smoothly. 



## Final Submission
### Group Devlog
Put your group Devlog here.


### Bella Sloan
Put your individual final Devlog here.
### Bilal Payton
Put your individual final Devlog here.
### Laura Liu
Put your individual final Devlog here.

## Open-Source Assets
Cite any open-source assets here. Put them in a LIST, and use correctly formatted LINKS.
- Kenny: https://kenney.nl/assets/retro-urban-kit
