using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// TODO: Change this to use Unity new Input System

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("Meters per second -> ln ms^-1")]
    [SerializeField] float controlSpeed = 20f; // Unity uses meters as a default
    [SerializeField] float yRange = 4.5f;
    [SerializeField] float xRange = 7f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Contol-Throw Based")]
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float controlPitchFactor = -20f;
    float xThrow, yThrow;

    bool isControlEnabled = true;
  
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void OnPlayerDeath() // message from collision Handler
    {
        isControlEnabled = false;
    }

    // fix this to move with mouse
    private void ProcessRotation()
    {
        float pitch = transform.localRotation.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localRotation.x * positionYawFactor;
        float roll = xThrow *controlRollFactor;
        // Quaternion.Euler(pitch (x), yaw (y), roll (z));
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); ; ;
    }

    // to calc how many particles will be emited its Duration * Emission rate

    private void ProcessTranslation()
    {
        // OBSOLETE its built in now
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
