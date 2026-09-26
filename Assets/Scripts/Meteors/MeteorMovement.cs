using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] float speed;

    //Moves meteor down
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
