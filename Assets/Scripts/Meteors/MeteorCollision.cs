using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    //References
    [SerializeField] private MeteorHealth meteorHealth;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        //If hits player, game over
        if (whatIHit.tag == "Player")
        {
            if (gameManager)
            {
                gameManager.SetGameOver(true);
                Destroy(whatIHit.gameObject);
                if (meteorHealth)
                {
                    meteorHealth.LoseHealth(100);
                }
            }
        }
        //else, run destroy logic
        else if (whatIHit.tag == "Laser")
        {
            if (meteorHealth)
            {
                meteorHealth.LoseHealth(1);
                Destroy(whatIHit.gameObject);
            }
        }
    }
}
