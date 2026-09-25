using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetLevelScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void ResetLevel(InputAction.CallbackContext context)
    {
        if (gameManager.GetGameOver())
        {
            SceneManager.LoadScene("Week5Lab");
        }
    }
}
