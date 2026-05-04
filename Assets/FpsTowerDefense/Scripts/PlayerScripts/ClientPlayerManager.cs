using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientPlayerManager : NetworkBehaviour
{

    [SerializeField] private PlayerLook _lookScript;
    [SerializeField] private PlayerMovement _movementScript;
    [SerializeField] private InputManager _input;
    [SerializeField] private PlayerInput _inputComponent;

    private void Awake()
    {
        _lookScript.enabled = false;
        _movementScript.enabled = false;
        _input.enabled = false;
        _inputComponent.enabled = false;
    }


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if(IsOwner)
        {
            _inputComponent.enabled = true;
            _input.enabled = true;
            _lookScript.enabled = true;
            _movementScript.enabled = true;
        }

    }

    

}
