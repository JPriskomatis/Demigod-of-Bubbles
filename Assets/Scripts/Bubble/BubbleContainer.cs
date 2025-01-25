using UnityEngine;

public class BubbleContainer : MonoBehaviour
{
    [SerializeField] private float _secondsToWaitToActivateTheBubble;
    private float _currentTimer;


    void Update()
    {
        if (!transform.GetChild(0).gameObject.activeInHierarchy)
        {
            // Start timer 
            _currentTimer += Time.deltaTime;
        }
        else
        {
            _currentTimer = 0;
        }
        if (_currentTimer > _secondsToWaitToActivateTheBubble)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
