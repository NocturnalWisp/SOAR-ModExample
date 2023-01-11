# SOAR-ModExample
Scholars of the Arcane Arts mod example using Melon Loader.

Adding or altering scripts for SOAR is fairly simple using Melon Loader.

Note: all the relative file paths below reference the steam game location "C:\Program Files (x86)\Steam\steamapps\common\Scholar of the Arcane Arts"

1. Viewing the SOAR source code.
    - Viewing the code is quite easy using dotPeek. Download Jetbrains DotPeek from here: https://www.jetbrains.com/decompiler/. With it you should be able to direct it to the games Scholar_Data/Managed/Assembly-CSharp.dll file.
    - Dot Peek will allow you to view the games code and files. Use this information to act on it during runtime.
2. Using Melon Loader
    - Download melon loader following the instructions here: https://melonwiki.xyz/#/?id=requirements
    - use the Scholar.exe file in melon loader.
    - Most of the documentation created by the melon loader team will describe to you the best way to use runtime attributes and change values.
3. Creating a mod.
    - Following this will help you the most: https://melonwiki.xyz/#/modders/quickstart
    - You can use the example provided in this git to create your own mod. This example is a small cheat menu to change health and speed values.
