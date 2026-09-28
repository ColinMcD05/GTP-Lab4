using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] float repeatTime;
    [SerializeField] float startWaitTime;

    [SerializeField] GameObject meteorPrefab;
    [SerializeField] GameObject bigMeteorPrefab;

    [SerializeField] CameraEffects camEffect;
    
    public void StartSpawnSmallMeteor()
    {
        InvokeRepeating("SpawnSmallMeteor", startWaitTime, repeatTime);
    }

    public void StopSpawnSmallMeteor()
    {
        CancelInvoke();
    }

    public void SpawnSmallMeteor()
    {
        if (meteorPrefab)
        {
            //Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
            Instantiate(meteorPrefab, new Vector3(Random.Range(-3, 3), 3f, 0), Quaternion.identity);
        }
    }

    public void SpawnBigMeteor()
    {
        if (bigMeteorPrefab)
        {
            Debug.Log("Big Meteor Spawned");
            camEffect.BigMeteorSpawned();
            //Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
            GameObject meteor = Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-3, 3), 3f, 0), Quaternion.identity);

            MeteorDestroy meteorDestroy = meteor.GetComponent<MeteorDestroy>();

            meteorDestroy.SetAsBigMeteor();
        }
    }
}
