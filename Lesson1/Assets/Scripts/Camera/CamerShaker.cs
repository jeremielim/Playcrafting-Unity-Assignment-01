using UnityEngine;
using System.Collections;

public class CamerShaker : MonoBehaviour
{
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private float magnitude = 0.1f;
    private Vector3 originalObject;
    public static bool isShaking = false;

    void Start()
    {
        originalObject = transform.position;
    }

    void Update()
    {
        if (isShaking)
        {
            StartCoroutine(ShakeThatCam());
        }
    }


    IEnumerator ShakeThatCam()
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.position = new Vector3(x, y, originalObject.z);

            yield return null;
        }
    }
}
