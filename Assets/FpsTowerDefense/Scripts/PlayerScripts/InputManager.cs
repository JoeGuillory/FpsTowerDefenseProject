using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;
    public bool jump;


  
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        LookInput(value.Get<Vector2>());
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

   
    public void MoveInput(Vector2 NewMoveInput)
    {
        move = NewMoveInput;
    }

    public void LookInput(Vector2 NewLookInput)
    {
        look = NewLookInput;
    }

    public void JumpInput(bool NewJumpInput)
    {
        jump = NewJumpInput;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(hasFocus);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
