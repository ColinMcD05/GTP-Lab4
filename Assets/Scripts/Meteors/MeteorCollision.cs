using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    private MeteorDestroy meteor;

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().SetGameOver(true);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
