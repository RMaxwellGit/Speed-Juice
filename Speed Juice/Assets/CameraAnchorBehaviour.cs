using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchorBehaviour : MonoBehaviour
{
    public Rigidbody rbCam;
    public Transform tPivot;
    public float shakeForce;
    public bool doShake;

    // Update is called once per frame
    void Update()
    {
        tPivot.rotation = transform.rotation; //replace this with camera lerping towards looking at the car

        if (doShake) Shake();
    }

    public void SetShakeForce(float newSF) {
        shakeForce = newSF;
    }
    public void SetDoShake(bool newDS) {
        doShake = newDS;
    }

    public void Shake() {
        Shake(1);
    }

    public void Shake(float speedMultiplier) {
        Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f));
        rbCam.AddForce(dir * shakeForce);
    }
}
