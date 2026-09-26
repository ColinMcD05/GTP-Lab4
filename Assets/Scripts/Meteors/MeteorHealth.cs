using UnityEngine;

public class MeteorHealth : MonoBehaviour
{
    [SerializeField] int health;
    private MeteorDestroy meteorDestroy;

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

    //Hanldes death
    public void Death()
    {
        meteorDestroy.DestroyMeteor(true);
    }
}
