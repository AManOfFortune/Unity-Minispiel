using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputHandler : MonoBehaviour
{
    // The cached reference to the PlayerInput
    private PlayerInput _playerInput;
    // The cached reference to the PlayerController
    private PlayerController _playerController;

    private void Awake()
    {
        // Cache the PlayerInput
        _playerInput = GetComponent<PlayerInput>();
        
        // Get all PlayerControllers
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();
        // Store the playerIndex
        int playerIndex = _playerInput.playerIndex;
        // Cache the PlayerController with matching playerIndex
        _playerController = playerControllers.FirstOrDefault(controller => controller.PlayerIndex == playerIndex);
    }

    public void OnJump(CallbackContext callbackContext)
    {
        // Check if _playerController exists
        if (_playerController != null)
        {
            // Set the player to jump
            _playerController.IsJumping = callbackContext.ReadValue<float>() != 0f;
        }
    }
}
