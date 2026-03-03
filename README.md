# GDIM32-Final
## Check-In
### Group Devlog
Put your group Devlog here.


### Bella Sloan
Put your individual check-in Devlog here.
### Bilal Payton
Put your individual check-in Devlog here.
### Laura Liu
At this stage, I primarily completed the inventory system and basic interactive UI. For the inventory system, I utilized HotbarPanel and slots in Unity to create a bottom inventory resembling Minecraft's inventory appearance. To manage items collected into the inventory, I primarily employed two scripts. First is the Inventory script, which manages owned items. It stores items using a List<ItemData>, with Add() for adding items, Remove() for deleting items, and ResetInventory() for clearing the inventory at game start. These methods ensure players can pick up, use, and discard items. To display these actions in real-time on the Inventory Bar, I used the InventoryUI script for feedback. I used Refresh() to update the slot, displaying the corresponding item's icon. Then, through SelectSlot(), the player can choose the slot containing the item, followed by selecting subsequent actions through UseItem( ) or DropItem( ). However, both used and dropped items disappear from the Inventory Bar. Additionally, I added ItemPanel and ItemText in Unity to display the UI tips. These UI tips are managed by ItemUI and appear when the player picks up, selects, uses, or discards items. For example, after selecting an item, the UI displays its name along with prompts: pressing E to use the item and Q to drop it.


I believe the proposal has been helpful in guiding the overall project as it clearly defines the UI system and our implementation of the MVC pattern. When working on the Inventory system, I followed the MVC structure outlined in the proposal: treating Inventory and ItemData as the Model, InventoryUI as the Controller, and ItemUI as the View. This approach will make it easier to store and create different UI elements as the number of items increases in the future. However, while the proposal provided an overall structure, I found many details required further consideration and improvement during actual implementation. For instance, how to create and update the Inventory, and how to specifically display the UI step by step. These details weren't covered in the proposal, so I needed to modify the code and make adjustments in the Inspector to resolve them. However, overall I believe the structure hasn't strayed significantly from the proposal's vision. For example, I still utilized MVC as mentioned above. I simply added some new scripts during implementation. As for the Break-down, the description for the UI section was far too limited, making it not very useful to me.






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
