using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float ControlSpeed = 8f;
    [Tooltip("In m")] [SerializeField] float xRange = 3.3f;
    [Tooltip("In m")] [SerializeField] float yRange = 1.8f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -8f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }

    }

    void OnPlayerDeath() // אם נשנה את השם פה, צריך לשנות גם באחראי של ההתנגשות
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow ;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * ControlSpeed * Time.deltaTime;
        float yOffset = yThrow * ControlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float ClampedXPos = Mathf.Clamp(rawXPos, -xRange, +xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float ClampedYPos = Mathf.Clamp(rawYPos, -yRange, +yRange);

        transform.localPosition = new Vector3(ClampedXPos, ClampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns) // יכול להשפיע על DeathFX
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
    public void QuitGame()
    {
        if (CrossPlatformInputManager.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }
    }
