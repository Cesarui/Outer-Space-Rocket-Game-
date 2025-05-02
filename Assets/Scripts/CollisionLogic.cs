using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip crashSound;

    Movement movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You reached the end!!");
                movement.enabled = false;
                movement.GetComponent<AudioSource>().Stop();
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
            case "Start":
                movement.enabled = true;
                
                break;
            default:
                movement.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
