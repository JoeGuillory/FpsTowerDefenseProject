using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private GameObject _camera;
    [SerializeField] private Transform _cameraObject;
    private InputManager _input;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _input = GetComponent<InputManager>();
    }


    private void LateUpdate()
    {
        ProccessLook(_input.look);
    }

    public void ProccessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        _cameraObject.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);

        if(_camera)
        {
            _camera.transform.position = transform.position;
            _camera.transform.rotation = _cameraObject.rotation;
        }

    }

    
}
