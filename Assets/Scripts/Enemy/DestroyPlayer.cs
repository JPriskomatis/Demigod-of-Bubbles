using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMaskToSlow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Killed player");
        }
        if (((1 << other.gameObject.layer) & _targetMaskToSlow.value) != 0)
        {
            Destroy(other.gameObject);
        }
    }
}
