using System.Collections;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField] private float dashForce;
    [SerializeField] private float _movementForce;
    [SerializeField] private float _gravityForceSpeed;
    [SerializeField] private Transform _orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;

    [SerializeField] private float maxSeconds;
    private float _currentTimer;
    private float _multiplier = 0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }
    private void Update()
    {
        // Get Input Raw WASD
        MyInput();

        // If pressed Space Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DashPlayer();
        }
    }

    private void FixedUpdate()
    {
        // Handle Movement with forces through taken Input
        MovePlayer();

        // Check if he is falling
        if (_rigidbody.linearVelocity.y < -1)
        {
            _currentTimer += Time.deltaTime;
            //Debug.Log(_currentTimer);
            // If timer is greater than Max seconds
            if (_currentTimer > maxSeconds)
            {
                Debug.Log("AddForce");
                // Then Multiply Force To give the feeling that player is falling more and more
                _multiplier += 0.005f;
                Vector3 boost = (-transform.up) * (_gravityForceSpeed+ _multiplier);
                Debug.Log(boost);
                _rigidbody.AddForce(boost, ForceMode.Impulse);
            }
        }
        else
        {
            _multiplier = 0f;
            _currentTimer = 0;
        }
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        _rigidbody.AddForce(_moveDirection * _movementForce * 10f, ForceMode.Force);

    }
    private void DashPlayer()
    {
        Vector3 dashDirection = new Vector3(_orientation.forward.x, 0, _orientation.forward.z).normalized;
        _rigidbody.AddForce(dashDirection * dashForce, ForceMode.Impulse);
    }
    
}
