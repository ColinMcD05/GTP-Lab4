using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;

    // Cinemachine related scripts
    [SerializeField] CinemachineCamera virtualCamera;
    [SerializeField] float normFoV = 60f;
    [SerializeField] float stretchedFoV = 75f;
    [SerializeField] float transitionTime = 1f;

    // To call the function that shrinks an grows the camera fov
    [SerializeField] BigMeteor bigMeteor;
    public bool gameOver = false;

    public int meteorCount = 0;

    // Start is called before the first frame update
    void Start()
    { 
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CineMachineTarget();
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }

        if (meteorCount == 5)
        {
            BigMeteor();
        }

        if (bigMeteor.bigSpawned == true)
        {
            CameraStretch();
        }
    }

    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
        bigMeteor.bigSpawned = true;
    }

    void CineMachineTarget()
    {
        virtualCamera.Follow = GameObject.Find("Player(Clone)").transform;
        virtualCamera.LookAt = GameObject.Find("Player(Clone)").transform;
    }

    void CameraStretch()
    {

    }
}
