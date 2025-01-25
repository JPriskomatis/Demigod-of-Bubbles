using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _shieldBubble;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private bool _isPowerful = false;
    [SerializeField] private float maxSecondsToHavePowerUP;
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _groupBubbles;
    [SerializeField] private Animator _handsAnimator;
    [SerializeField] private AudioClip _bubbleShieldHolding;
    [SerializeField] private Volume _globalVolume; 
    private ScreenSpaceLensFlare _lensFlare; 
    private List<GameObject> _bubblesList = new List<GameObject>();
    private GameObject _instantiatedShield;
    private BubbleShield _currentShield;
    private float _currentPowerUPTimer;

    void Start()
    {
        if (_globalVolume != null && _globalVolume.profile != null)
        {
            // Try to get the Screen Space Lens Flare component from the Volume Profile
            if (_globalVolume.profile.TryGet<ScreenSpaceLensFlare>(out _lensFlare))
            {
                Debug.Log("Screen Space Lens Flare found!");
            }
            else
            {
                Debug.LogError("Screen Space Lens Flare not found in the Volume Profile!");
            }
        }
        _currentPowerUPTimer = 0f;
        _instantiatedShield = null;
        _currentShield = null;    
    }

    void Update()
    {
        // If he has taken the PowerUP
        if (_isPowerful)
        {
            _lensFlare.active = true;
            _currentPowerUPTimer += Time.deltaTime;

            // Check if timer is less than seconds to have powerUP
            if (_currentPowerUPTimer <= maxSecondsToHavePowerUP)
            {
                // If Mouse Button Down
                if (Input.GetMouseButtonDown(0))
                {
                    _handsAnimator.SetBool("SpawnBubble", true);
                    Debug.Log("Down");
                    // Create Bubble
                    // And Move bubble accordingly to Camera Orientation
                    _instantiatedShield = Instantiate(_shieldBubble, _targetPoint);
                    _currentShield = _instantiatedShield.GetComponent<BubbleShield>();
                    _currentShield.SetOrientation(_orientation);
                    AudioManager.instance.PlayAudio(_bubbleShieldHolding);
                }
                // If Mouse Button UP
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("Up");
                    _handsAnimator.SetBool("SpawnBubble", false);
                    // Then shoot Nail if it is nail
                    _currentShield.ShootNail();
                    // Set the bubble to a group and add it to list
                    _instantiatedShield.transform.SetParent(_groupBubbles, true);
                    _bubblesList.Add(_instantiatedShield);
                    _instantiatedShield = null;
                    _currentShield = null;
                }               
            }
            else
            {
                SetHimToPowerless();
            }
        }
        else
        {
            _lensFlare.active = false;
            _currentPowerUPTimer = 0f;
            _currentShield = null;
        }  
    }

    public void SetHimToPowerful()
    {
        _currentPowerUPTimer = 0;
        _isPowerful = true;
    }
    public void SetHimToPowerless()
    {
        _handsAnimator.SetBool("SpawnBubble", false);
        // Stop PowerUP
        _isPowerful = false;
        _bubblesList.Clear();
        
        for (int i=0;i<_groupBubbles.childCount;i++)
        {
            Destroy(_groupBubbles.GetChild(i).gameObject);
        }

        if (_instantiatedShield != null)
        {
            Destroy(_instantiatedShield);
        }
        _instantiatedShield = null;
        _currentShield = null;
    }
}
