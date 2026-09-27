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
        player = playerSpawner.player.transform;

        MoveDownward();
        FacePlayer();
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

    private void FacePlayer()
    {
        // Get the difference in positions
        Vector3 dir = playerSpawner.player.transform.position - transform.position;

        // Normalize current Z direction
        dir.z = 0;
        dir.Normalize();

        // Get the dot
        float dot = Vector3.Dot(dir, Vector3.up);

        // Get the angle with arc cosine
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // Find if player is to the left or right enemy
        float cross = Vector3.Cross(Vector3.up, dir).z;

        // If player is left, make the angle negative
        if (cross < 0)
        {
            angle = -angle;
        }

        // Rotates the enemy
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }
}
