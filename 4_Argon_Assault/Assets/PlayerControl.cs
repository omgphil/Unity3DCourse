using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// TODO: Change this to use Unity new Input System

public class PlayerControl : MonoBehaviour
{
    [Tooltip("Meters per second -> ln ms^-1")]
    [SerializeField] float xSpeed = 4f; // Unity uses meters as a default

    [SerializeField] float xRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // OBSOLETE its built in now
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);  
    }
}
