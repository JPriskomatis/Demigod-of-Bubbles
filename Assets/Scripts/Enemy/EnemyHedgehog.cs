using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyHedgehog : Enemy
{
    Vector3 playerPos;


    public override void AttackPlayer(Transform playerTransform)
    {
        if (seePlayer)
        {
            anim.SetTrigger("Point");
        }
    }

    //This function is called from the Animator as an event;
    private void StartRolling()
    {
        //Move towards player;
        tookPlayersPos = true;
        StartCoroutine(MoveToPlayer(playerPos, attackSpeed));
        anim.SetTrigger("Roll");
    }

    IEnumerator MoveToPlayer(Vector3 targetPos, float speed)
    {
        targetPos = playerTransform.position;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
    }
}
