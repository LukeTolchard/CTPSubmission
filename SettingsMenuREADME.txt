ProceduralCityGenerator - Window Help

By default, the project should have a 'City Settings' tab open next to the inspector. If it doesn't, click on the 'Windows' dropdown at the top left and click 'CityGenerator'.

Both the population map and water map must be filled in to create the first start point. 

If these are unassigned for any reason, the correct textures to reassign are found at Assets/Art/NewPopMap, and Assets/Art/WaterMap respectively. 

Deleting all the start points from the hierarchy will require this menu to be accessed to create more.

Hover over any setting to see a brief description of how they work. If you input a value considered to be extreme, the menu will warn you and advise a 'safe limit'

New spawn points can be created from the 'New Spawn' button

=========================================================================================
Troubleshooting

If a generation only appears to spawn highways and nothing else, a common cause is the 'Dist branches' setting being turned too high. The generator does not warn about values under 50, but values close to that number may also cause problems depending on other settings with it.