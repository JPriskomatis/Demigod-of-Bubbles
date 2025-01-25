using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private AudioClip _powerUP;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.transform.GetComponent<PlayerAttack>().SetHimToPowerful();
            AudioManager.instance.PlayAudio(_powerUP);
            Destroy(gameObject);
        }
    }
}
