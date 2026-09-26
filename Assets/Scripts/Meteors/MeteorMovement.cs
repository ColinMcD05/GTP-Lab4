using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
