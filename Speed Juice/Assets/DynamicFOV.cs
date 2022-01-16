using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFOV : MonoBehaviour
{
    public Rigidbody rb;

    public float baseFOV, maxFOV;

    public float minFOVExpansionSpeed, maxFOVExpansionSpeed;

    private float curSpeed;

    private float CalculateFOV() {
        curSpeed = rb.velocity.magnitude;
        
        float newFOV;

        if (curSpeed >= minFOVExpansionSpeed) {
            // newFOV = (15f * (Mathf.Cos(((6.28f * curSpeed) / 61.3f) + 3.3f))) + 75f;
            float fovFactor = (curSpeed - minFOVExpansionSpeed) / (maxFOVExpansionSpeed - minFOVExpansionSpeed);
            newFOV = Mathf.Lerp(baseFOV, maxFOV, fovFactor);
        } else {
            newFOV = baseFOV;
        }
        return newFOV;
    }

    void Update()
    {
        Camera.main.fieldOfView = CalculateFOV();
    }
}
