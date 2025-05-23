using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction boost;
    [SerializeField] InputAction rotation;
    [SerializeField] AudioClip boostSound;
    [SerializeField] ParticleSystem boosterParticle;

    [SerializeField] float boostStrenght = 5f;
    [SerializeField] float rotationStrenght = 5f;

    AudioSource audioSource;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        boost.Enable();
        rotation.Enable();
    }
    private void OnDisable()
    {
        rb.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        Thrust();

        // less than 0 is when the button is not being pressed and greater means its being pressed.

        float rotationValue = rotation.ReadValue<float>();
        if (rotationValue < 0)
        {
            RotateLeft();
        }
        else if (rotationValue > 0)
        {
            RotateRight();
        }
        else
        {
            rb.freezeRotation = false;
        }
    }

    private void RotateRight()
    {
        rb.freezeRotation = true;
        rb.transform.Rotate(Vector3.right * rotationStrenght);
    }

    private void RotateLeft()
    {
        rb.freezeRotation = true;
        rb.transform.Rotate(Vector3.left * rotationStrenght);
    }

    private void Thrust()
    {
        if (boost.IsPressed())
        {
            rb.AddRelativeForce(Vector3.forward * boostStrenght * Time.fixedDeltaTime);
            boosterParticle.Play();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(boostSound);
            }
        }
        else
        {
            boosterParticle.Stop();
            audioSource.Stop();
        }
    }
}
