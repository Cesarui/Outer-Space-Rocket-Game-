using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionLogic : MonoBehaviour
{
    bool collidable = true;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] ParticleSystem successEffect;

    [SerializeField] float delayAmount;

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
                StartSuccess();
                Invoke("LoadNextLevel", delayAmount);
                break;
            case "Start":

                break;
            default:
                StartCrash();
                Invoke("ReloadLevel", delayAmount);
                break;
        }
    }

    private void StartSuccess()
    {
        collidable = false;
        Debug.Log("You reached the end!!");
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        successEffect.Play();
        movement.GetComponentInChildren<ParticleSystem>().Stop();
    }

    private void StartCrash()
    {
        collidable = false;
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashEffect.Play();
        movement.GetComponentInChildren<ParticleSystem>().Stop();
    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentScene + 1;
        int numberOfLevels = SceneManager.sceneCountInBuildSettings;
        if (nextLevel == numberOfLevels)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }
}
