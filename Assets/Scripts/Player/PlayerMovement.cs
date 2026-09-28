using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	//Player Bounds
	[SerializeField] Vector2 xBounds;
	[SerializeField] Vector2 yBounds;

	//Movement variables
	[SerializeField] float speed;
	private Vector3 movementVector;
	
	//Sets movement vector on move action
	public void SetMovementVector(InputAction.CallbackContext context)
	{
		Vector3 newPosition = context.ReadValue<Vector2>();

		movementVector = newPosition;
	}

	//Sets Movement to zero
	public void ResetMovementVector(InputAction.CallbackContext context)
	{
		movementVector = Vector3.zero;
	}

	//Moves player
	public void MovePlayer()
	{
		Vector3 newPosition = transform.position + movementVector * speed * Time.deltaTime;
		CheckBounds(ref newPosition);
		transform.position = newPosition;
    }


	//Checks and clamps bounds
	void CheckBounds(ref Vector3 position)
	{
		position.x = Mathf.Clamp(position.x, xBounds.x, xBounds.y);
		position.y = Mathf.Clamp(position.y, yBounds.x, yBounds.y);
	}
}
