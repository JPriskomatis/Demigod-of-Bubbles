using DG.Tweening;
using UnityEngine;


public class Bubble : MonoBehaviour
{
    [Header("Bubble's Components")]
    [SerializeField] Transform bubbleTransform;
    [SerializeField] AudioClip bubbleAudio;

    [Header("Force attributes")]
    [SerializeField] private float power;

    //I made these static since we want all bubble prefabs
    //to have access to them once the first bubble gets a 
    //reference to them, so that we don't have to GetComponent
    //everytime the player jumps in a bubble;
    private static Rigidbody playerRB;
    private static Transform playerTransform;



    //Animation
    private void BubbleAnimation()
    {
        //Move the bubble slowly for 2 seconds before disappearing;
        bubbleTransform.DOScale(new Vector3(4.6092f, 3.3409f, 4.52855f),1f);
        //Move the bubble slowly for 2 seconds before disappearing;
        bubbleTransform.DOMoveY(bubbleTransform.position.y - 3f, 1f);

        Destroy(gameObject, 2f);

    }

    //Audio
    private void PlayerAudio()
    {
        AudioManager.instance.PlayAudio(bubbleAudio);
    }

    //Boost player to top
    private void BoostPlayer()
    {
        //First reset the velocity so our player don't becomes a rocket;
        playerRB.linearVelocity = Vector3.zero;
        //We get the player's rigidbody;
        playerRB.AddForce(playerTransform.up * power,ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if(playerRB == null)
            {
                
                playerRB = other.transform.GetComponent<Rigidbody>();
                playerTransform = other.GetComponent<Transform>();
            }

            
            BubbleAnimation();
            BoostPlayer();
        }
    }
}
