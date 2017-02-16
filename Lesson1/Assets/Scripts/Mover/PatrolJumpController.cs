using UnityEngine;

public class PatrolJumpController : MonoBehaviour {

    public Mover controlledMover;

    public void Update()
    {
		controlledMover.Jump();
    }
}
