using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPLayer : MonoBehaviour
{
    public Head head;
    public CameraShake cameraShake;

    public void ImpacTrue()
    {
        head.Impact();
        cameraShake.shakeDuration = 0.1f;
    }
}
