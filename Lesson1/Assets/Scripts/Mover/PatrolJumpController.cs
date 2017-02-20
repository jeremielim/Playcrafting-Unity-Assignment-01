using UnityEngine;

public class PatrolJumpController : MonoBehaviour {

    public void Update()
    {
        GetComponent<Mover>().Jump();
    }
}