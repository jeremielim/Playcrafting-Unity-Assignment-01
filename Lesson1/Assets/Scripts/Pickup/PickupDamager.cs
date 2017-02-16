//this is a Pickup that rewards health when picked up.
public class PickupDamager : Pickup
{
    public float damageAmount = 1.0f;

    public override void PickUp( PickupGetter getter )
    {
		Destructible hitDestructible = getter.GetComponent<Destructible>();

        if ( hitDestructible != null )
        {
            hitDestructible.TakeDamage( damageAmount );
        }

        //then, do our default behavior
        base.PickUp( getter );
    }
}
