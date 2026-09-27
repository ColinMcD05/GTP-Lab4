using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] CinemachineCamera cinCam;

    // Variables for controlling how the camera acts
    [SerializeField] float normalSize = 5f;
    [SerializeField] float bigMeteorSize = 7f;
    [SerializeField] float zoomDuration = 0.5f;
    public void BigMeteorSpawned()
    {
        StartCoroutine(ZoomCamera(bigMeteorSize));
    }

    public void BigMeteorDestroyed()
    {
        StartCoroutine(BigMeteorDeathEffect());
    }

    private IEnumerator BigMeteorDeathEffect()
    {


        yield return new WaitForSeconds(0.3f);

        
        yield return StartCoroutine(ZoomCamera(normalSize));
    }

    private IEnumerator ZoomCamera(float targetSize)
    {
        
        yield return null;
    }
}
