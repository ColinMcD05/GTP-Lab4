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

    // Update is called once per frame
    void Update()
    {
        
    }
}
