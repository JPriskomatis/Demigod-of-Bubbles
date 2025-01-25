using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Components")]
    [SerializeField] Animator anim;
    [SerializeField] AudioClip clip;

    [Header("Enemy Attributes")]
    [SerializeField] float attackSpeed;

    protected bool seePlayer;
    private Transform playerTransform;

    //This is the vision range of each enemy (the collider)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("sdf");
            seePlayer = true;
            playerTransform = other.transform;
            AttackPlayer(playerTransform);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        seePlayer = false;
    }

    public abstract void AttackPlayer(Transform playerTransform);

}
