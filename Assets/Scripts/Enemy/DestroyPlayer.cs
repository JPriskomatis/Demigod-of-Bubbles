using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMaskToSlow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (((1 << other.gameObject.layer) & _targetMaskToSlow.value) != 0)
        {
            Debug.Log("Found An enemy ! ");
            Destroy(other.transform.parent.gameObject);
        }
    }
}
