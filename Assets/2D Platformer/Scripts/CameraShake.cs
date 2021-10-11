using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;

    public IEnumerator ShakeCamera(float duration)
    {
        var cameraPos = camTransform.localPosition;
        while (duration > 0.1f)
        {
            camTransform.localPosition += Random.insideUnitSphere * shakeAmount;
            duration -= Time.deltaTime;
            yield return null;
        }
        camTransform.localPosition = cameraPos;
    }
}
