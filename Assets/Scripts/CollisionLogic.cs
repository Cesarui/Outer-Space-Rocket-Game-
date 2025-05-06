using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionLogic : MonoBehaviour
{
    bool collidable = true;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashEffect;

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
                collidable = false;
                Debug.Log("You reached the end!!");
                GetComponent<Movement>().enabled = false;
                audioSource.Stop();
                audioSource.PlayOneShot(successSound);
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
            case "Start":

                break;
            default:
                collidable = false;
                GetComponent<Movement>().enabled = false;
                audioSource.Stop();
                audioSource.PlayOneShot(crashSound);
                crashEffect.Play();
                movement.GetComponentInChildren<ParticleSystem>().Stop();
                break;
        }
    }

}
