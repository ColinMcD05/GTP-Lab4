using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //References
    [SerializeField]PlayerMovement playerMovement;
    [SerializeField]PlayerFire playerFire;

    //Input action variables
    private InputSystem_Actions mapping;
    private InputAction move;
    private InputAction fire;
    
    void Awake()
    {
        mapping = new InputSystem_Actions();
        move = mapping.Player.Move;
        fire = mapping.Player.Attack;
    }

    void OnEnable()
    {
        move.Enable();
        move.performed += playerMovement.SetMovementVector;
        move.canceled += playerMovement.ResetMovementVector;

        fire.Enable();
        fire.performed += playerFire.Fire;
    }

    void OnDisable()
    {
        move.Disable();
        move.performed -= playerMovement.SetMovementVector;
        move.canceled -= playerMovement.ResetMovementVector;

        fire.Disable();
        fire.performed -= playerFire.Fire;
    }

    void Update()
    {
        playerMovement.MovePlayer();
    }
}
