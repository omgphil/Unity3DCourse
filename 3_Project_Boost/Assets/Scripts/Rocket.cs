using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float rcsThrust = 100f;
    [SerializeField]
    private float mainThrust = 1000f;


    private Rigidbody rigidBody;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("ok");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                // Death
                print("Death");
                // kill player, restart level
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            float thrustThisFrame = mainThrust * Time.deltaTime;
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

            if (!audioSource.isPlaying)
            {
                audioSource.volume = 1f;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.volume > 0.001f)
            {
                audioSource.volume *= 0.1f;
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    private void Rotate()
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
