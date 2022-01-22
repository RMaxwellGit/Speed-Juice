using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundController : MonoBehaviour
{
    public SimpleCarController myCar;
    public Rigidbody rb;
    public AudioSource a;
    public float maxVolume;
    public float maxPitch;
    public float[] gearPitchBases;
    public float minFactorSpeed, maxFactorSpeed;

    private float curSpeed, factor;
    private int numOfGears;

    void Start() {
        numOfGears = gearPitchBases.Length;
    }

    void Update()
    {
        curSpeed = GetHorizontalSpeed(rb.velocity);

        factor = Mathf.Clamp((curSpeed - minFactorSpeed) / (maxFactorSpeed - minFactorSpeed), 0, 1);

        //set volume based on factor
        a.volume = CalculateVolume(factor);
        //set pitch based on factor
        a.pitch = CalculatePitch(factor, numOfGears);
    }

    float GetHorizontalSpeed(Vector3 curVelocity) {
        Vector3 horizontalVelocity = new Vector3(curVelocity.x, 0, curVelocity.z);

        return horizontalVelocity.magnitude;
    }

    float CalculateVolume(float f) {
        return maxVolume * f;
    }

    float CalculatePitch(float f, int g) {
        float curGear = Mathf.Floor(f / (1f/g));

        float facInGear = Input.GetAxis("Vertical") / g;

        return maxPitch * (curGear/g + facInGear);
    }
}
