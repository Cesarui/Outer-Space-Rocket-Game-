using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // To control how fast it goes back and forth
    [SerializeField] float speed;
    // To tell where to move.
    [SerializeField] Vector3 movementVector;

    Vector3 startPos;
    Vector3 endPos;

    float movementFactor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + movementVector;
    }

    // Update is called once per frame
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPos, endPos, movementFactor);
    }
}
