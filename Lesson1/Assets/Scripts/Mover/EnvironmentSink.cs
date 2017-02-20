using UnityEngine;
using System.Collections;

public class EnvironmentSink : MonoBehaviour
{

    [SerializeField] private float sinkTime = 0.1f;
    [SerializeField] private float delaySink = 0f;
    public static bool isSinking = false;

    void Update()
    {
        if (isSinking)
        {
            StartCoroutine(SinkLevel(delaySink));
        }

        if (transform.position.y < -8)
        {
            DestroyObject(gameObject);
        }

    }

    IEnumerator SinkLevel(float time) {
        time = delaySink;

        yield return new WaitForSeconds(time);

        transform.Translate(Vector3.down * sinkTime * Time.deltaTime);
    }
}
