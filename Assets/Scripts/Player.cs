using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Header("General")]
    [Tooltip("m/s ^-1")][SerializeField] float xSpeed = 4f;
    [SerializeField] float xRange = 4f;

    [Tooltip("m/s ^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("m")] [SerializeField] float yRange = 4f;

    [Header("Screen Position Base")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float throwPitchFactor = -5f;

    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float throwRollFactor = -5f;

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * throwPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * throwRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float xClamp = Mathf.Clamp(xRawPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yRawPos = transform.localPosition.y + yOffset;
        float yClamp = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(xClamp, yClamp, transform.localPosition.z);
    }

    void OnPlayerDeath()
    {
        print("Yup Dead!");
        isControlEnabled = false;
    }
}
