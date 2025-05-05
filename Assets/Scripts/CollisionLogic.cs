using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionLogic : MonoBehaviour
{
    bool collidable = true;

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
        if (!collidable)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You reached the end!!");
                GetComponent<Movement>().enabled = false;
                audioSource.Stop();
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
            case "Start":

                break;
            default:
                collidable = false;
                GetComponent<Movement>().enabled = false;
                audioSource.Stop();
                audioSource.PlayOneShot(crashSound);
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
        }
    }

}
