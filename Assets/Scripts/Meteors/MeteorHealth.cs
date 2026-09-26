using UnityEngine;

public class MeteorHealth : MonoBehaviour
{
    [SerializeField] int health;
    private MeteorDestroy meteorDestroy;

    public void LoseHealth(int amountLost)
    {
        health -= amountLost;
    }

    public void Death()
    {
        meteorDestroy.DestroyMeteor();
    }
}
