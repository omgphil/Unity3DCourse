using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float rcsThrust = 100f;
    [SerializeField]
    private float mainThrust = 1000f;

    [SerializeField] float LevelLoadDelay = 2f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    private Rigidbody rigidBody;
    private AudioSource audioSource;

    enum State
    {
        Alive, Dying, Transcending
    }

    State state = State.Alive;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                state = State.Transcending;
                PlaySound(success);
                successParticles.Play();
                Invoke("LoadNextLevel", LevelLoadDelay);
                break;
            default:
                state = State.Dying;
                PlaySound(death);
                deathParticles.Play();
                Invoke("LoadFirstLevel", LevelLoadDelay);
                break;
        }
    }

    private void PlaySound(AudioClip audio)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audio);
    }

    private void LoadNextLevel()
    {
        state = State.Alive;
        SceneManager.LoadScene(1);
    }

    private void LoadFirstLevel()
    {
        state = State.Alive;
        SceneManager.LoadScene(0);
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void ApplyThrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;
        rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
         mainEngineParticles.Play();
    }

    private void RespondToRotateInput()
    {
        rigidBody.freezeRotation = true; // manual control of rotation


        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // take control of physics
    }
}
