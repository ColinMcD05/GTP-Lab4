using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //References
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerFire playerFire;

    //Input action variables
    private InputSystem_Actions mapping;
    private InputAction move;
    private InputAction fire;
    
    void Awake()
    {
        //Sets up mapping
        mapping = new InputSystem_Actions();
        move = mapping.Player.Move;
        fire = mapping.Player.Attack;
    }

    void OnEnable()
    {
        //Enables and sets actions
        move.Enable();
        move.performed += playerMovement.SetMovementVector;
        move.canceled += playerMovement.ResetMovementVector;

        fire.Enable();
        fire.performed += playerFire.Fire;
    }

    void OnDisable()
    {
        //Disables actions
        move.Disable();
        move.performed -= playerMovement.SetMovementVector;
        move.canceled -= playerMovement.ResetMovementVector;

        fire.Disable();
        fire.performed -= playerFire.Fire;
    }

    void Update()
    {
        //Move player
        playerMovement.MovePlayer();
    }
}
