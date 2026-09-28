using UnityEngine;

public class MeteorHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] MeteorDestroy meteorDestroy;

    private void Awake()
    {
        meteorDestroy = GetComponent<MeteorDestroy>();
    }

    //Lose health
    public void LoseHealth(int amountLost)
    {
        health -= amountLost;
        //Check if dead
        if(health <= 0)
        {
            Death();
        }
    }

    //Handles death
    public void Death()
    {
        meteorDestroy.DestroyMeteor(true);
    }
}
