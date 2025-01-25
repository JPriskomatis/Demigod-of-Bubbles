using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Components")]
    [SerializeField] protected Animator anim;
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
            
            seePlayer = true;
            playerTransform = other.transform;

            StartCoroutine(LookingAtPlayer(playerTransform));
            AttackPlayer(playerTransform);
        }

    }

    IEnumerator LookingAtPlayer(Transform playerTransform)
    {
        while (seePlayer)
        {
            transform.LookAt(playerTransform);
            yield return null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        seePlayer = false;
    }

    public abstract void AttackPlayer(Transform playerTransform);

}
