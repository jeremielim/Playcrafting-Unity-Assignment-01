# Assignment 1
Complete as many of these items as you can. If something sounds challenging, then that’s a good one to try!

Have a look at and get familiar with the Unity documentation:
https://docs.unity3d.com/

✔ Create an entire level that lasts 3 minutes of gameplay.

✔ Change it so you must collect 5 gems, not 3.
  - Hint: the changes should be in GameGUI.cs, and inside the Canvas itself.

✔ Apply different acceleration when in the air vs on the ground.

✔ Using a PhysicsMaterial, change the ground friction so it feels better.

✔ Create a second PhysicsMaterial to make another terrain type that is more slippery, and a third that is super sticky.

✔ Add a new enemy type, and create a Controller script for it that causes it to jump periodically.
 - Hint: it’s a lot like the PatrolController, but simple since it doesn’t have to change direction. All it has to do is call Jump() on the Mover.

✔  Make a Pickup that damages you when you get it.
  - Hint: You shouldn’t need to write any new code to do this.

✔ Make a Pickup that causes you to jump higher.
  - Hint: When the Pickup is grabbed, it can increase the jumpImpulse of the Mover attached to the PickupGetter.

✔ Make it so that the player and the snake SpriteRenderers set flipX to true when they’re moving in the other direction.
  - Hint: GetComponent<SpriteRenderer>().flipX = true
  - Hint: “Moving in the other direction” means “has a negative X velocity.”

✔  Create a new script called ProjectileShooter that shoots projectiles periodically. Attach it to a new enemy type that shoots out projectiles that cause damage.
  - Hint: Instantiate<>() is what you should use to create projectiles.
  - Hint: You will need a prefab that you will instantiate. Take a look at SpriteTiledArea for an example. You will need to position the new projectile after creating it.
  - Hint: Give the projectile a Destructor to make it cause damage, or make it similar to the damaging Pickup you created earlier.

- Fix our collision bug – store a list of stuff we’re colliding instead of isOnGround. We’re considered on the ground if we’re colliding with anything at all. Add to the list when collision starts, remove from the list when it ends.
- Also only add to the collision list of we’re on top of the collider. Use the normal in Collision2D.contacts to do this, or do a Raycast.
	- Hint, the normal is the angle of the surface we collided with. So an angle where Y is > 0 is more or less on top.
	- Bonus: If you know vector math, you can use the dot product to do this even better.
	- https://docs.unity3d.com/ScriptReference/Collision2D-contacts.html
✔ Change the heart and gem sprites in the GameGUI to only update when things have changed.
	- HINT: You’ll need to store off the last health and gem count values that you used to update the GUI. Then, if they have changed, you should change the sprites.
✔ Increase the efficiency of the PickupGetter’s FindPickupCount function by storing running totals of each item type as they change.
	- Hint: a Dictionary is great for this. You could create a Dictionary<string,int> that uses the type as the key, and then adds to the int as it’s changed.
- Fix the SinePositionChanger so that it maintains the same Z position it started with.
- Extra credit: use a Raycast2D to walk the PatrolController to the edge of the platform and then turn around.

