using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float speed;
	private Vector3 movementVector;
	    
	public void SetMovementVector(InputAction.CallbackContext context)
	{
		Vector3 newPosition = context.ReadValue<Vector2>();

		movementVector = newPosition;
	}

	public void ResetMovementVector(InputAction.CallbackContext context)
	{
		movementVector = Vector3.zero;
	}

	public void MovePlayer()
	{
		transform.position += movementVector  * speed * Time.deltaTime;
	}
}
