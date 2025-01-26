using System.Collections;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float delay;

    private AudioClip lastClip;

    private void Start()
    {
        StartCoroutine(StartVoiceActing());
    }

    IEnumerator StartVoiceActing()
    {
        while (true)
        {
            if (audioClips.Length > 0)
            {
                yield return new WaitForSeconds(delay);

                AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

                while (randomClip == lastClip)
                {
                    randomClip = audioClips[Random.Range(0, audioClips.Length)];
                }

                lastClip = randomClip;


                audioSource.clip = randomClip;
                audioSource.Play();
            }

            
            
        }
    }

}
