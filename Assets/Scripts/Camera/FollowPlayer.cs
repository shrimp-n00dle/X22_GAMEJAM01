using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    // /https://www.youtube.com/watch?v=ZPUtQ4pGGWs
    
  /*Camera Movement*/
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float _smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothTime);
    }

}