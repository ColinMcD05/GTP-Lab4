using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //Spawner References
    [SerializeField] PlayerSpawner playerSpawner;
    [SerializeField] MeteorSpawner meteorSpawner;

    //Gamemanager Functionality References
    private ResetLevelScript resetLevel;
    private ScoreTracker scoreTracker;

    //Input
    private InputSystem_Actions mapping;
    private InputAction restart;

    private bool gameOver = false;

    void Awake()
    {
        //Get components and check if they exist
        resetLevel = GetComponent<ResetLevelScript>();
        if(resetLevel == null)
        {
            resetLevel = gameObject.AddComponent<ResetLevelScript>();
        }
        resetLevel.Initialize(this);

        scoreTracker = GetComponent<ScoreTracker>();
        if (scoreTracker == null)
        {
            scoreTracker = gameObject.AddComponent<ScoreTracker>();
        }

        //Add reset level mapping
        mapping = new InputSystem_Actions();
        restart = mapping.Player.Restart;
    }

    //Bind event to actions
    private void OnEnable()
    {
        restart.Enable();
        restart.performed += resetLevel.ResetLevel;
    }

    //Unbind event to action
    private void OnDisable()
    {
        restart.Disable();
        restart.performed -= resetLevel.ResetLevel;
    }

    void Start()
    {
        //Spawn player and meteors
        playerSpawner.SpawnPlayer();
        meteorSpawner.StartSpawnSmallMeteor();
    }

    public void GainScore(int amountGained)
    {
        //Add score to score tracker
        scoreTracker.GainedScore(amountGained);
        //Check if score is enough to spawn big meteor
        if(scoreTracker.GetPlayerScore() % 5 == 0)
        {
            meteorSpawner.SpawnBigMeteor();
        }
    }

    //Getters
    public bool GetGameOver()
    {
        return gameOver;
    }

    //Setters
    public void SetGameOver(bool newGameOver)
    {
        gameOver = newGameOver;
        if(!gameOver)
        {
            meteorSpawner.StopSpawnSmallMeteor();
        }
    }
}
