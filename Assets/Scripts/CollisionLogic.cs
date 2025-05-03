using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionLogic : MonoBehaviour
{
    [SerializeField] AudioClip crashSound;

    AudioSource audioSource;
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
                GetComponent<Movement>().enabled = false;
                audioSource.enabled = false;
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
            case "Start":

                break;
            default:
                GetComponent<Movement>().enabled = false;
                audioSource.enabled = false;
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
        }
    }

}
