using UnityEngine;

public class BubbleShield : MonoBehaviour
{
    [SerializeField] private float _slowFactor;
    [SerializeField] private LayerMask _targetMaskToSlow;
    [SerializeField] private float _nailBackForce;
    [SerializeField] private AudioClip _bubbleCreation;
    [SerializeField] private AudioClip _bubbleDestruction;
    private Transform _playerOrientation;
    private GameObject _nailProjectile;

    void Start()
    {
        AudioManager.instance.PlayAudio(_bubbleCreation);
        _nailProjectile = null;
    }

  
    private void OnTriggerStay(Collider other)
    {
        // Check if it collided with a nail so You can move it and throw it
        if (other.gameObject.tag == "Nail")
        {
            _nailProjectile = other.gameObject;
            _nailProjectile.transform.position = this.transform.position;
        }
        // Check if it collided with the specific layer and Slow its force
        else if (((1 << other.gameObject.layer) & _targetMaskToSlow.value) != 0)
        {
            SlowObject(other.gameObject);
        }
    }
    private void SlowObject(GameObject objectToSlow)
    {
        Debug.Log(objectToSlow.name);
        objectToSlow.GetComponent<Rigidbody>().linearVelocity *= _slowFactor;
    }
    public void ShootNail()
    {
        if (_nailProjectile != null)
        {
            Debug.Log("SHOOT!");
            Vector3 nailDirection = new Vector3(_playerOrientation.forward.x, _playerOrientation.forward.y, _playerOrientation.forward.z).normalized;
            _nailProjectile.GetComponent<Rigidbody>().AddForce(nailDirection * _nailBackForce, ForceMode.Impulse);
            this.gameObject.SetActive(false);
            AudioManager.instance.PlayAudio(_bubbleDestruction);
            _playerOrientation = null;
        }
    }

    public void SetOrientation(Transform currentOrientation)
    {
        _playerOrientation = currentOrientation;
    }
    void OnDestroy()
    {
        AudioManager.instance.PlayAudio(_bubbleDestruction);
    }

}
