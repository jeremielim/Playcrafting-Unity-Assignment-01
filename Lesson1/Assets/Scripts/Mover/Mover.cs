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
    private List<string> collisionList = new List<string>();
    private bool isOnGround;

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
            calcAcceleration = aerialAcceleration;
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

        print ( "Am I on the ground? " + isOnGround );

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
        //we collided, so that means we're on the ground
        //note that this is a pretty poor way of doing it, since if we hit our head it would also mean we had
        //jumped... maybe you'd fix that by checking collision.normal?
        //this also doesn't work well when we collide with multiple objects, and can fully break.
        //how might we handle multiple collisions? Maybe a list?
        
        if ( collision.collider.gameObject.layer == 8 )
        {
            isOnGround = true;
        }

        // Fix our collision bug – store a list of stuff we’re colliding instead of isOnGround.
        // We’re considered on the ground if we’re colliding with anything at all. 
        // Add to the list when collision starts, remove from the list when it ends.
;

        collisionList.Add(collision.collider.name);
        
        print ( collisionList.Count );


    }

    // void OnCollisionStay2D(Collision2D collision)
    // {
    // //    foreach (ContactPoint2D contact in collision.contacts) {
    // //         print(contact.collider.name + " hit " + contact.otherCollider.name);
    // //         Debug.DrawRay(contact.point, contact.normal, Color.white);
    // //     }
    //     Collider2D collider = collision.collider;
    //     Vector3 contactPoint = collision.contacts[0].point;
        

    //     //print ( "Colliding with " + collider + " at location " + contactPoint );
    // }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collisionList.Remove(collision.collider.name);
        print ( collisionList.Count );

   
        if ( collision.collider.gameObject.layer == 8 )
        {
            // isOnGround = false;
        }
    }

    //this is convenient for controllers to know. we're walking if we have any x velocity.
    public bool IsWalking()
    {
        return Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x ) >= minimumWalkSpeed;
    }
}