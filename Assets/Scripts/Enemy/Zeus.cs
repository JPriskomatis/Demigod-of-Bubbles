using UnityEngine;

public class Zeus : MonoBehaviour
{
    [SerializeField] GameObject spawnLightning;

    private void ActivateZeus()
    {
        spawnLightning.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {

            ActivateZeus();
        }
    }
}
