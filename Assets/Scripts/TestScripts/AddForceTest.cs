using UnityEngine;
using UnityEngine.EventSystems;

public class AddForceTest : MonoBehaviour
{
   
    
    void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 2f, ForceMode.Force);
    }
}
