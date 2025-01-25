using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private MenuSettings _mouseSensitivityController;
    [SerializeField] private Transform _orientation;

    private float _xRotation;
    private float _yRotation;

    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        //Remove Cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    {
        

        // Get sensitivity values from MouseSensitivityController
        float sensitivityX = _mouseSensitivityController.mouseSensitivity;
        float sensitivityY = _mouseSensitivityController.mouseSensitivity;

        // Take mouse axis with sensitivity
        _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        _yRotation += _mouseX;
        _xRotation -= _mouseY;

        // Clamp xRotation
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        // Apply rotation to camera and orientation
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
