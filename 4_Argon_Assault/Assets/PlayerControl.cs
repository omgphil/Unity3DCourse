using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// TODO: Change this to use Unity new Input System

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // OBSOLETE its built in now
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        print(horizontalThrow);
    }
}
