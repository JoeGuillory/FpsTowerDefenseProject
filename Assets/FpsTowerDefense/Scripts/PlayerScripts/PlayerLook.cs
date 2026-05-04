using Unity.Netcode;
using Unity.Services.Matchmaker.Models;
using UnityEngine;

public class PlayerLook : NetworkBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraObject;
    private InputManager _input;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;


    public float currentRotation = 0f;

   
    private void Awake()
    {
        _input = GetComponent<InputManager>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(IsOwner)
        {
            _camera.enabled = true;
        }
        else
        {
            _camera.enabled = false;
        }
    }

    private void LateUpdate()
    {

        if (!IsOwner) return;

        ProccessLook(_input.look);
    }

    public void ProccessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        _cameraObject.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        Vector3 newRotation = Vector3.up * (mouseX * Time.deltaTime) * xSensitivity;
        currentRotation = newRotation.y;
        transform.Rotate(newRotation);
    }
}
