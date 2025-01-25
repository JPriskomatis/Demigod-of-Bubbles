using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyHedgehog : Enemy
{
    Vector3 playerPos;


    public override void AttackPlayer(Transform playerTransform)
    {
        playerPos = playerTransform.position;
        if (seePlayer)
        {
            anim.SetTrigger("Point");
        }
    }

    private void StartRolling()
    {
        //Move towards player;
        StartCoroutine(MoveToPlayer(playerPos, attackSpeed));
        anim.SetTrigger("Roll");
    }

    IEnumerator MoveToPlayer(Vector3 targetPos, float speed)
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
    }
}
