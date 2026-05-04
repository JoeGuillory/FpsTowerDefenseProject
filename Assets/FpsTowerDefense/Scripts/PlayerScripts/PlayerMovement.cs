using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float MoveSpeed = 5;
    public float SprintSpeed = 9;
    public float Gravity = -15.0f;
    public float JumpHeight = 1.6f;



    private bool _isGrounded = true;

    private CharacterController _controller;
    private InputManager _input;
    private Vector3 playerVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;
        _isGrounded = _controller.isGrounded;
        ProcessMove(_input.move);
        //Jump();
    }


    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;

        if (_isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2;

        _controller.Move(transform.TransformDirection(moveDirection) * MoveSpeed * Time.deltaTime);
        playerVelocity.y += Gravity * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(_isGrounded && _input.jump)
        {
            playerVelocity.y = Mathf.Sqrt(JumpHeight * -3 * Gravity);
        }
    }
}
