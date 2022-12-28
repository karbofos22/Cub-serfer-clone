using DG.Tweening;
using UnityEngine;

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
            EventManager.SendBoxCollected();
            Destroy(gameObject, flyTime);
        }
    }
}
