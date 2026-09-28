using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public PlayerSpawner playerSpawner;
    [SerializeField] float speed;
    [SerializeField] Transform player;

    private void Awake()
    {
        playerSpawner = FindFirstObjectByType<PlayerSpawner>();
    }

    //Moves meteor down
    void Update()
    {
        //Get player position
        if (player)
        {
            player = playerSpawner.player.transform;
        }

        MoveDownward();
    }

    private void MoveDownward()
    {
        //Calculate Distance
        Vector3 offSet = transform.position - player.position;
        offSet.z = 0;
        float distance = offSet.magnitude;

        //Calculate angle
        float angle = Mathf.Atan2(offSet.y, offSet.x);

        //Convert speed to radians
        float radSpeed = speed * Mathf.Deg2Rad;

        //Increase angle for movement
        angle += radSpeed * Time.deltaTime;

        // Slowly move towards the player
        distance -= 0.5f * Time.deltaTime;

        // Prevent the meteor from going past the player
        distance = Mathf.Max(distance, 0);

        //Finds the new position of the enemy
        Vector3 newPosition = new Vector3(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance, 0);

        //Sets new position
        transform.position = player.position + newPosition;
    }
}
