using UnityEngine;

public class Floating : MonoBehaviour
{
    public float amplitude = 15f;
    public float speed = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = startPos +
            Vector3.up * Mathf.Sin(Time.time * speed) * amplitude;
    }
}