using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    void Update()
    {
        transform.rotation = _cameraTransform.rotation;
    }


}
