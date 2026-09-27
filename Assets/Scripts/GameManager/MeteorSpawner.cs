using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] float repeatTime;
    [SerializeField] float startWaitTime;

    [SerializeField] GameObject meteorPrefab;
    [SerializeField] GameObject bigMeteorPrefab;
    private Transform player;
    


    public void StartSpawnSmallMeteor()
    {
        InvokeRepeating("SpawnSmallMeteor", startWaitTime, repeatTime);
        player = GameObject.FindFirstObjectByType<PlayerMovement>().transform;
    }

    public void StopSpawnSmallMeteor()
    {
        CancelInvoke();
    }

    public void SpawnSmallMeteor()
    {
        if (meteorPrefab)
        {
            Instantiate(meteorPrefab, new Vector3(Random.Range(player.position.x + -8, player.position.x + 8), player.position.y + 7.5f, 0), Quaternion.identity);
        }
    }

    public void SpawnBigMeteor()
    {
        if (bigMeteorPrefab)
        {
            Instantiate(bigMeteorPrefab, new Vector3(Random.Range(player.position.x + -8, player.position.x + 8), player.position.y + 7.5f, 0), Quaternion.identity);
        }
    }
}
