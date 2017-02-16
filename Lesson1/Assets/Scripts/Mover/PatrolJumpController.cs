using UnityEngine;

public class PatrolJumpController : MonoBehaviour {

	[Tooltip ("The Mover we will control.")]
    public Mover controlledMover;

    [Tooltip ("How long we will patrol in each direction before turning around.")]
    public float patrolTime = 1.0f;

    //how much time we have left before we need to turn around
    private float remainingPatrolTime;

    //the current X direction we're moving: either 1 or -1.
    private float movementDirection;

    public void Start()
    {
        remainingPatrolTime = patrolTime;
        movementDirection = 1.0f;
    }

    public void Update()
    {
        remainingPatrolTime -= Time.deltaTime;
		controlledMover.Jump();
		
        //there's still patrol time left, so accelerate in our patrol direction
        if ( remainingPatrolTime > 0.0f )
        {
            controlledMover.AccelerateInDirection( new Vector2( movementDirection, 0.0f ) );
        }
        //we're out of patrol time, so if we've come to rest by now, reverse direction and continue
        else if ( !controlledMover.IsWalking() )
        {
            movementDirection *= -1;

            remainingPatrolTime = patrolTime;
        }
    }
}
