using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The playerIndex used to match the PlayerController with the PlayerInput
    [SerializeField] private int playerIndex = 0;
    // The jump height in units
    [SerializeField] private float jumpHeight = 2f;
    // The gravity affecting the player in units per second
    [SerializeField] private float gravity = 20f;
    
    // The getter for the playerIndex
    public int PlayerIndex => playerIndex;
    // The property set by the inputManager that determines whether the player is jumping or not
    public bool IsJumping { get; set; }

    // The cached reference to the CharacterController
    private CharacterController _characterController;
    // The current movement direction
    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        // Cache the CharacterController
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is grounded
        if (_characterController.isGrounded)
        {
            // Check if the jump button is pressed
            if (IsJumping)
            {
                // Calculate the amount of upward speed needed to achieve desired jump height
                _moveDirection.y = Mathf.Sqrt(2f * gravity * jumpHeight);
            }
            else
            {
                // Set downward momentum to 0 if grounded and not jumping
                _moveDirection.y = 0f;
            }
        }
        
        // Bring the movement down by applying the gravity over time
        _moveDirection.y -= gravity * Time.deltaTime;
        
        // Move the controller
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
