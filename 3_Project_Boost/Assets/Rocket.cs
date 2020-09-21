
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting");
        }
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotation Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotation Right");
        }
    }
}
