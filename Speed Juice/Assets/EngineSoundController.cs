using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundController : MonoBehaviour
{
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
        curSpeed = rb.velocity.magnitude;

        factor = Mathf.Clamp((curSpeed - minFactorSpeed) / (maxFactorSpeed - minFactorSpeed), 0, 1);

        //set volume based on factor
        a.volume = CalculateVolume(factor);
        //set pitch based on factor
        a.pitch = CalculatePitch(factor, numOfGears);
    }

    float CalculateVolume(float f) {
        return maxVolume * f;
    }

    float CalculatePitch(float f, int g) {
        float curGear = Mathf.Floor(f / (1f/g));

        float facInGear = f % (1f/g);

        return maxPitch * (curGear/g + facInGear);
    }
}
