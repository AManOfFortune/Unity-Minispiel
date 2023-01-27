using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerClass : MonoBehaviour
{
    // The playerIndex used to match the PlayerController with the PlayerInput
    [SerializeField] private int playerIndex = 0;
    // The jump height in units
    [SerializeField] private float jumpHeight = 2f;
    // The gravity affecting the player in units per second
    [SerializeField] private float gravity = 20f;
    // The mass of the player
    [SerializeField] private float mass = 5f;

    // The getter for the playerIndex
    public int PlayerIndex => playerIndex;

    private float movespeed = 2.0f;

    // The cached reference to the CharacterController
    private CharacterController _characterController;

    // The current movement direction
    private Vector3 _moveDirection = Vector3.zero;
    private Vector2 move;

    // The current impact direction for knockback
    private Vector3 _impactDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        // Cache the CharacterController
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bring the movement down by applying the gravity over time
        _moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        _characterController.Move(_moveDirection * Time.deltaTime);

        // Apply impact force
        if (_impactDirection.magnitude > 0.2)
        {
            _characterController.Move(_impactDirection * Time.deltaTime);
        }

        _impactDirection = Vector3.Lerp(_impactDirection, Vector3.zero, 5 * Time.deltaTime);

    }
    public void AddImpact(Vector3 direction, float force)
    {
        direction.Normalize();

        if (direction.y < 0) direction.y = -direction.y;

        _impactDirection += direction.normalized * force / mass;
    }

    public void PlayerJump()
    {
        Debug.Log("Reached PlayerJump");
        // Calculate the amount of upward speed needed to achieve desired jump height
        if (_characterController.isGrounded)
        {
            _moveDirection.y = Mathf.Sqrt(2f * gravity * jumpHeight);
        }
    }

    public void PlayerMove(InputValue value)
    {
        //updates movespeed
        move = value.Get<Vector2>();
        _moveDirection.x = move.x * movespeed;
        _moveDirection.z = move.y * movespeed;
    }
}
