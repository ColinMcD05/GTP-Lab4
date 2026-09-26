using UnityEngine;

public class MeteorDestroy : MonoBehaviour
{
    //References
    private GameManager gameManager;

    [SerializeField] int amountGained;

    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    //Handles destroying meteor
    public void DestroyMeteor(bool destroyedByPlayer)
    {
        if(destroyedByPlayer)
        {
            gameManager.GainScore(amountGained);
        }
        Destroy(this);
    }

    //Once out of camera, destroy
    public void OnBecameInvisible()
    {
        DestroyMeteor(false);
    }
}
