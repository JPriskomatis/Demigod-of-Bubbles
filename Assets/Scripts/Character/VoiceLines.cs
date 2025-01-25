using System.Collections;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

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
                
                AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

                
                audioSource.clip = randomClip;
                audioSource.Play();
            }

            
            yield return new WaitForSeconds(10f);
        }
    }

}
