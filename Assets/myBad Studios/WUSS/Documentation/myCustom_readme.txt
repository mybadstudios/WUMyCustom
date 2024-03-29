﻿WUSS myCustom explained
========================
All my assets are extendible to include any custom functionality you might need but if you add that
functionality to one of my scripts then all your work will be lost the next time I release an update.

WUSS myCustom gives you a basic skeleton package that shows you how to create the Unity and the
WordPress side code to add your own custom extensions to the kit.

HOW TO USE
==========
To see this kit in action:
1. Make sure to install WordPress for Unity Bridge into the project and follow it's setup instructions
2. Install the included package on your website if you haven't done so yet
3. Open up the demo scene in Unity and drag the login prefab into the scene
4. Hit the play button.

Included in this asset is an extension for WordPress money to show you how to setup a custom product.
Please note it is for demonstration purposes only and can be greatly improved upon so it is not meant
as a production ready script.

HOW TO USE THE CUSTOM WUMoney SCRIPT?
=====================================
Go to WooComerce and create a new product.
Make sure to configure the product with these settings: 
	1. Simple product
	2. Virtual 
	3. Not downloadable
Give it an SKU of WUSKU_5_months or WUSKU_5_weeks or WUSKU_5_days (replace 5 with your game's actual ID).
*NOTE: The Game's ID can be found on the WUSS configuration panel in your WordPress dashboard

That is it. You can now go sell that product in WooCommerce. The number of months, weeks or days
(respectively) that this sample subscription product should last for is determined by the qty entered
into the cart.

Inside the demo scene you should now see a message in the console after login that indicates if you have
a subscription or not.

HOW TO EXTEND THIS KIT?
=======================
As explained above, the very reason why this kit was made was for you to have a place to add custom
extensions to my existing kits without having to worry about me overwriting your functions when I
release updates to any of my assets. 

Thus, for that reason, this kit will never receive any updates and the kit, as it is now, is yours to
mod to your heart's content. This kit includes a demonstration of how to extend my kits so just continue
to do what I have done to create your own custom extensions.

1. Look in WUExpansion for the WUExpActions enum and add more actions into there.
2. Now simply call the server like I do in that samescript and be sure to specify what should happen
upon success and failure as reported by the function you called
3. In the unity_functions.php file simply create a function that matches your enum action and that is
prefixed with "custom". Example, if you add "FetchExpiryDate" to the enum then create a function named
customFetchExpiryDate in unity_functions.php

That's it. Go forth and make whatever functions you need.
Enjoy
