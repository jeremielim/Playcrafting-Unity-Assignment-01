using UnityEngine;
using System.Collections.Generic;

//a PhysicsMover is just like a Mover except it uses Unity's built-in physics to move
public class Mover : MonoBehaviour
{
    public float acceleration = 50.0f;
    public float aerialAcceleration = 1.0f;
    public bool isFacingRight = true;
    public float jumpImpulse = 10.0f;
    public float maximumSpeed = 20.0f;
    public float minimumWalkSpeed = 0.1f;
    private float calcAcceleration;
    private List<string> collisionObjects = new List<string>();
    private bool isOnGround;

    private bool hasHitSide;

    //we need to initialize isOnGround to be false, since we start in the air.
    public void Start()
    {
        isOnGround = false;
        calcAcceleration = acceleration;
    }
    
    public void AccelerateInDirection(Vector2 direction)
    {   
        //this tells our Rigidbody to accelerate in a given direction, using our acceleration or
        //aerialAcceleration values, depending on if we're in the air or not.

        if ( isOnGround ) {
            calcAcceleration = acceleration;
        } else {
            if( hasHitSide ) {
                calcAcceleration = 0;
            } else {
                calcAcceleration = aerialAcceleration;
            }
            
        }

        if(direction.x == 1) {
            if(isFacingRight) {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            } else {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            
        } else if(direction.x == -1) {
            if(isFacingRight) {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            } else {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }

        

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 newVelocity = rb.velocity + direction * calcAcceleration * Time.deltaTime;
        
        newVelocity.x = Mathf.Clamp( newVelocity.x, -maximumSpeed, maximumSpeed );
        rb.velocity = newVelocity;
    }
    
    //applies a single burst of velocity upwards - jump!
    public void Jump()
    {
        if ( isOnGround )
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );
            isOnGround = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;    
        Vector3 contactPoint = collision.contacts[0].normal; 

        if (collision.collider.gameObject.layer == 8) {
            
            collisionObjects.Add(collision.collider.name);
            
            if (contactPoint.y > 0 && collisionObjects.Count > 0) {
                isOnGround = true;
            }
        }

        if (contactPoint.x < 0 ) {
            hasHitSide = true;
            print ( "Did I hit the side? " + hasHitSide );
        } else {
            hasHitSide = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collisionObjects.Remove(collision.collider.name);

        if(collisionObjects.Count == 0) {
            isOnGround = false;
        }
    }

    public bool IsWalking()
    {
        return Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x ) >= minimumWalkSpeed;
    }
}