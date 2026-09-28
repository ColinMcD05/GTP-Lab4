using UnityEngine;

public class MeteorDestroy : MonoBehaviour
{
    //References
    private GameManager gameManager;
    private CameraEffects camEffects;

    [SerializeField] int amountGained;
    private bool isBigMeteor;

    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        camEffects = GameObject.FindFirstObjectByType<CameraEffects>();
    }

    // See if its a Big Meteor so the effects work
    public void SetAsBigMeteor()
    {
        isBigMeteor = true;
    }

    //Handles destroying meteor
    public void DestroyMeteor(bool destroyedByPlayer)
    {
        if(destroyedByPlayer && gameManager)
        {
            gameManager.GainScore(amountGained);

            if (isBigMeteor)
            {
                Debug.Log("Big Meteor Destoyed");
                camEffects.BigMeteorDestroyed();
            }
        }
        Destroy(gameObject);
    }

    //Once out of camera, destroy
    public void OnBecameInvisible()
    {
        DestroyMeteor(false);

        if (isBigMeteor)
        {
            Debug.Log("Big Meteor Destroyed");
            camEffects.BigMeteorDestroyed();
        }
    }
}
