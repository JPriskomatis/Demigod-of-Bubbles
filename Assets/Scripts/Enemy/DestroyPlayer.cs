using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Killed player");
        }
    }
}
