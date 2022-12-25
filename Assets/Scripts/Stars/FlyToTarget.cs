using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyToTarget : MonoBehaviour
{
    [SerializeField] float flyTime;
    private bool isCollected;

    [SerializeField] private Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected)
        {
            isCollected = true;
            transform.DOMove(target.position, flyTime).SetEase(Ease.Linear);
            EventManager.SendStarCollected();
            Destroy(gameObject, flyTime);
        }
    }
}
