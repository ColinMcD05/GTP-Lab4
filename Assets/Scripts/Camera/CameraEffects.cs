using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] CinemachineCamera cinCam;
    [SerializeField] CinemachineBasicMultiChannelPerlin noise;

    // Variables for controlling how the camera acts
    [SerializeField] float normalSize = 5f;
    [SerializeField] float bigMeteorSize = 7f;
    [SerializeField] float zoomDuration = 0.5f;

    // Camera Shake variables
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeIntensity = 2f;

    private void Awake()
    {
        // Get the noise component from the Cinemachine camera
        noise = cinCam.GetComponent<CinemachineBasicMultiChannelPerlin>();

        if (noise != null)
        {
            noise.AmplitudeGain = 0f;
        }
    }

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
        // Shake camera for specified amount
        if (noise == null)
            yield break;

        noise.AmplitudeGain = shakeIntensity;

        yield return new WaitForSeconds(shakeDuration);

        noise.AmplitudeGain = 0f;

        StartCoroutine(ZoomCamera(normalSize));
    }

    private IEnumerator ZoomCamera(float targetSize)
    {
        float startingSize = cinCam.Lens.OrthographicSize;
        float elapsedTime = 0f;

        // Slowly zoom camera in/out during duration
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / zoomDuration;

            // Smooth zoom
            t = Mathf.SmoothStep(0f, 1f, t);

            cinCam.Lens.OrthographicSize = Mathf.Lerp(startingSize, targetSize, t);

            yield return null;
        }

        // End at desired size
        cinCam.Lens.OrthographicSize = targetSize;
    }
}
