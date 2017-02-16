using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupJumper : Pickup {

	public override void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<Mover>().jumpImpulse = 12;
	}

    public override void PickUp( PickupGetter getter )
    {
        base.PickUp( getter );
    }
}
