# WUMyCustom
Examples demonstrating how to easily extend the WordPress For Unity asset with your own custom functionality

# High level overview
WordPress For Unity implements the back end and does all the grunt work for you meaning that as long as you have that plugin (or wuss_login) active on your website, adding custom functionality to your Unity project will be super simple. This asset was made with the promise that it will never be updated and in so doing it ensures that you can simply add your custom code to this plugin directly and never fear that your code might be removed by an update from our end.

# How to use this repo
Get the zip file (a WordPress plugin) from here and install/activate it like any normal plugin on your website. You only need to do this once, obviously. Be sure you have either the WordPress Login or the WordPress for Unity plugins active also.

Check out the sample Unity code to learn how to use this if you are not already familiar with it. Basically, you just have to call your functions using the WPServer.ContactServer() functionand tell it to run your code. It can be as simple as 1 line of code. See the included source or any of the other WordPress calling functions included by WordPress Login or WordPress For Unity to see examples of how to use this function. In most cases you can just copy paste any one of them and just change the name of the funciton to call. That easy! :D 

# Steps for customizing WordPress for Unity with your own functionality
1. Edit the unity_functions.php script to contain your custom functionality. Just remember the following few rules:
    <ul><li>The function you call from Unity must start with the word `custom`. For example: `customFetchAllUsers()`</li>
    <li>Your function must return with `SendToUnity($response)` in order to send back the response of your function to Unity</li>
    <li>If your function returns an error use `PrintError($message)`. For example: `SendToUnity( PrintError("User not logged in") );`</li>
    <li>To send back multiple responses (if NOT returning an error), concatenate your responses using `SendField($name, $value)`</li>
    <li>You can optionally categorize/group responses with the `SendNode($name [,$combinedFields])` function</li></ul>
    
    EXAMPLE:
    ```
    function customFetchAllUsers()
    {
        $response = '';
        $users = $wpdb->get_results("SELECT * FROM $wpdb->users");
        if (!$users) return SendToUnity( PrintError("How can there ever NOT be any users in the user database?!") );        
        foreach($users as $user)
        {
          $response .= SendNode("User","uid={$user->ID};user_login={$user->user_login}");
          $response .= SendField("email", $user->user_email);
        }
        return SendToUnity($response);
      }
    ```
      
2. Inside Unity, find the Assets/myBad Studios/WUSS/Scripts.Custom/WUExpansion.cs and modify the WUExpActions enum. 
Your enum value must perfectly match the name of your function from step 1 except it must not have the `custom` prefix. 
Example: Change WUExpActions from `{isSubscribed}` to `{isSubscribed, FetchAllUsers}`
_NOTE: This step is entirely optional but I like to list my online actions in an enum to avoid typos later in the project. the enum is converted to a string in step 3 so you can skip this step if you like and just use a string directly 

3. Duplicate one of the existing functions in WUExpansion.cs and just replace the enum value it passes with the one you created

Done. You can now use your custom functionality inside your Unity project. 
Enjoy!

# Compatibility
Unity broke the WWW class in 2017.3 and thus the WordPress for Unity and WULogin assets were recreated with 2017.3 as the minimum Unity version. As such I suppose it is fair to say that Unity 2017.3 is theminimum Unity version required since you DO require either of those assets to make use of this... but technically speaking this will work with any version of the assets you may have. The first WULogin was made in Unity 4 so if you are still using that version then feel free to use this with that.

As for WordPress and PHP versions, if you have a WordPress website then you have compatible versions for this kit. As simple as that :)

# Compatibility Disclaimer
If you are still using the _WULogin_ or _WordPress for Unity_ assets from the Unity Asset Store then this will work just fine as is. If you are using the updated version of WordPress for Unity found on https://mybadstudios.com then you will have to modify the path in unity_functions.php to `../wordpress_for_unity/` from the current path of `../wuss_login/`
