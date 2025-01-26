using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Components")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected AudioClip clip;

    [Header("Enemy Attributes")]
    [SerializeField] protected float attackSpeed;

    protected Vector3 playerPos;
    protected bool seePlayer;
    protected Transform playerTransform;
    protected bool tookPlayersPos;
    protected bool isAttacking;


    //This is the vision range of each enemy (the collider)
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            seePlayer = true;
            playerTransform = other.transform;

            StartCoroutine(LookingAtPlayer(playerTransform));
            if (!isAttacking)
            {
                StartCoroutine(AttackPlayerCoroutine());
            }
        }

    }
    private IEnumerator AttackPlayerCoroutine()
    {
        isAttacking = true;
        while (seePlayer)
        {
            AttackPlayer(playerTransform);
            yield return new WaitForSeconds(2f);
        }
        isAttacking = false;
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
