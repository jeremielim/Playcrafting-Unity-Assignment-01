using System.Collections.Generic;
using UnityEngine;

//this is something that can get Pickups. Pretty clear, right?
//if something without one of these passes over a Pickup, nothing happens.
//should the trigger handler have been here instead of in the Pickup?
public class PickupGetter : MonoBehaviour
{
    //we'll keep track of every Pickup we've gotten, unless they're consumable
    protected List<Pickup> pickups;

    private int count = 0;

    public virtual void Awake()
    {
        pickups = new List<Pickup>();
    }

    public virtual void PickUp(Pickup pickup)
    {
        if (!pickup.isConsumable)
        {
            pickups.Add(pickup);
        }
    }

    public virtual int FindPickupCount(string pickupId)
    {

        if (pickups[0].id == pickupId)
        {
            count++;
        }

        return count;
    }
}
