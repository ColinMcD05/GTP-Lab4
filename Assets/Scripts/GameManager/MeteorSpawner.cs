using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] float repeatTime;
    [SerializeField] float startWaitTime;

    [SerializeField] GameObject meteorPrefab;
    [SerializeField] GameObject bigMeteorPrefab;
    
    public void StartSpawnSmallMeteor()
    {
        InvokeRepeating("SpawnMeteor", startWaitTime, repeatTime);
    }

    public void StopSpawnSmallMeteor()
    {
        CancelInvoke();
    }

    public void SpawnSmallMeteor()
    {
        if (meteorPrefab)
        {
            Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
        }
    }

    public void SpawnBigMeteor()
    {
        if (bigMeteorPrefab)
        {
            Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
        }
    }
}
