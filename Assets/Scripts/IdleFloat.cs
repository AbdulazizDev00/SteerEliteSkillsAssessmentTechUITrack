using UnityEngine;

public class IdleFloat : MonoBehaviour
{
    public float amplitude = 10f;     
    public float frequency = 1.5f;      

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0f, y, 0f);
    }
}
