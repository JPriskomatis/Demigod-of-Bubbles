using DG.Tweening;
using UnityEngine;


public class Bubble : MonoBehaviour
{
    [Header("Bubble's Components")]
    [SerializeField] Transform bubbleTransform;
    [SerializeField] AudioClip bubbleAudio;

    [Header("Force attributes")]
    [SerializeField] private float power;

    private Rigidbody playerRB;
    private Transform playerTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BubbleAnimation();
        }
    }
    //Animation
    private void BubbleAnimation()
    {
        //Move the bubble slowly for 2 seconds before disappearing;
        bubbleTransform.DOMoveY(bubbleTransform.position.y -0.3f, 2f).
            OnComplete(() => PlayerAudio());

        Destroy(gameObject, 2f);

    }

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
        playerRB.AddForce(playerTransform.up * power);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRB = other.GetComponent<Rigidbody>();
            playerTransform = other.GetComponent<Transform>();
            
            BubbleAnimation();
            BoostPlayer();
        }
    }
}
