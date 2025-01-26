using UnityEngine;

public class PlayVoiceOver : MonoBehaviour
{
    [SerializeField] private AudioClip _voiceOverClip;
    private bool _isHeSpeaking = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isHeSpeaking)
        {
            _isHeSpeaking = true;
            this.gameObject.GetComponent<AudioSource>().clip = _voiceOverClip;
            this.gameObject.GetComponent<AudioSource>().Play();


        }
    }
}
