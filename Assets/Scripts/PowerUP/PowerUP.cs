using UnityEngine;

public class PowerUP : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.transform.parent.GetComponent<PlayerAttack>().SetHimToPowerful();
            Destroy(gameObject);
        }
    }
}
