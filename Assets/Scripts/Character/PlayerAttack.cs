using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _shieldBubble;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private bool _isPowerful = false;
    [SerializeField] private float maxSecondsToHavePowerUP;
    private GameObject _currentShield;
    private float _currentPowerUPTimer;

    void Start()
    {
        _currentPowerUPTimer = 0f;
        _currentShield = null;
    }

    void Update()
    {
        if (_isPowerful)
        {
            _currentPowerUPTimer += Time.deltaTime;

            if (_currentPowerUPTimer <= maxSecondsToHavePowerUP)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _currentShield = Instantiate(_shieldBubble, _targetPoint);
                    // Create Reflective Bubble
                    Debug.Log("Down");
                }
                if (Input.GetMouseButtonUp(0))
                {
                    // Shoot The nail if any
                    // And destroy Bubble
                    Debug.Log("Up");
                    Destroy(_currentShield);
                }
                
            }
            else
            {
                SetHimToPowerless();
            }
        }
        else
        {
            _currentPowerUPTimer = 0f;
            _currentShield = null;
        }  
    }

    public void SetHimToPowerful()
    {
        _isPowerful = true;
    }
    public void SetHimToPowerless()
    {
        _isPowerful = false;

        if (_currentShield != null)
        {
            Destroy(_currentShield);
        }
        _currentShield = null;
    }
}
