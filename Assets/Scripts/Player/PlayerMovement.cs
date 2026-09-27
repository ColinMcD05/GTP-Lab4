using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Vector2 xBounds;
	[SerializeField] Vector2 yBounds;
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
		Vector3 newPosition = transform.position + movementVector * speed * Time.deltaTime;
		CheckBounds(ref newPosition);
		transform.position = newPosition;
    }

	void CheckBounds(ref Vector3 position)
	{
		position.x = Mathf.Clamp(position.x, xBounds.x, xBounds.y);
		position.y = Mathf.Clamp(position.y, yBounds.x, yBounds.y);
	}
}
