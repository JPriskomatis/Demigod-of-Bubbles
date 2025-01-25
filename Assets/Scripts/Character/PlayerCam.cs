using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;

    [SerializeField] private Transform _orientation;

    private float _xRotation;
    private float _yRotation;

    private float _mouseX;
    private float _mouseY;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensitivityX;
        _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensitivityY;

        _yRotation += _mouseX;
        _xRotation -= _mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(_xRotation,_yRotation,0);
        _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);

    }
}
