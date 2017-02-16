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

- Create a new script called ProjectileShooter that shoots projectiles periodically. Attach it to a new enemy type that shoots out projectiles that cause damage.
  - Hint: Instantiate<>() is what you should use to create projectiles.
  - Hint: You will need a prefab that you will instantiate. Take a look at SpriteTiledArea for an example. You will need to position the new projectile after creating it.
  - Hint: Give the projectile a Destructor to make it cause damage, or make it similar to the damaging Pickup you created earlier.
