using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScissorhands : Enemy
{
    [SerializeField] private Transform spawnPoint;
    public override void AttackPlayer(Transform playerTransform)
    {
        //Start Attacking;
        anim.SetTrigger("Shoot");
    }

    //This method gets called from our animation event;
    public void SpawnScissor()
    {
        if (seePlayer)
        {
            tookPlayersPos = true;

            GameObject scissor = ScissorPool.instance.GetPooledObject();
            scissor.transform.position = spawnPoint.position;

            //This moves the scissor towards the player;
            StartCoroutine(MoveToPlayer(scissor, playerPos, attackSpeed));
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        
    }

    public void PlayScissorAudio()
    {
        AudioManager.instance.PlayAudio(clip);
    }
    IEnumerator MoveToPlayer(GameObject scissor ,Vector3 targetPos, float speed)
    {
        targetPos = playerTransform.position;
        while (Vector3.Distance(scissor.transform.position, targetPos) > 0.01f)
        {
            scissor.transform.position = Vector3.MoveTowards(scissor.transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        scissor.transform.position = targetPos;
        scissor.gameObject.SetActive(false);
    }

    public void ResetPlayerPos()
    {
        tookPlayersPos = false;
    }
}
