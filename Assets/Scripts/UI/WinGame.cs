using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
