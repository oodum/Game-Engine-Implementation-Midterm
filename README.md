Singleton: in Assets/_Project/_Scripts/Singleton.cs
The singleton has a static T instance, and when the get is called, it tries fetching the instance. If it doesn't exist, it'll find any in the scene. If it still can't find one, it'll make a new one in the scene.
This was implemented in the game manager, where the player can call the gamemanager to increase the shell amount

Observer: in Assets/_Project/_Scripts/Input/PlayerInputProcessor
The input processor is a scriptableobject that incorporates itself with the default input actions (IPlayerInputActions.IPlayerActions). When an input is received, it'll broadcast the input through an Action
This was implemented in the player controller.

Factory: BulletFactory in Assets/_Project/_Scripts/BulletFactory
The factory pattern is, when called, creates a bullet at a position and shoots it in a direction. This is called from the playercontroller
