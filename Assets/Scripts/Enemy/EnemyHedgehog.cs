using DG.Tweening;
using UnityEngine;

public class EnemyHedgehog : Enemy
{


    public override void AttackPlayer(Transform playerTransform)
    {
        if (seePlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}
