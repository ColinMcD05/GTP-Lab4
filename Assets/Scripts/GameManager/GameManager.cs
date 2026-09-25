using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Spawner References
    [SerializeField] PlayerSpawner playerSpawner;
    [SerializeField] MeteorSpawner meteorSpawner;

    //Gamemanager Functionality References
    private ResetLevelScript resetLevel;

    //Input
    private InputSystem_Actions mapping;
    private InputAction restart;

    private bool gameOver = false;
    public int meteorCount = 0;

    void Awake()
    {
        resetLevel = GetComponent<ResetLevelScript>();
        if(resetLevel)
        {
            resetLevel = gameObject.AddComponent<ResetLevelScript>();
        }
        resetLevel.Initialize(this);

        mapping = new InputSystem_Actions();
        restart = mapping.Player.Restart;
    }

    private void OnEnable()
    {
        restart.Enable();
        restart.performed += resetLevel.ResetLevel;
    }

    private void OnDisable()
    {
        restart.Disable();
        restart.performed -= resetLevel.ResetLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner.SpawnPlayer();
        meteorSpawner.StartSpawnSmallMeteor();
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public void SetGameOver(bool newGameOver) 
    {
        gameOver = newGameOver;
    }
}
