using DG.Tweening;
using UnityEngine;

public class FlyToTarget : MonoBehaviour
{
    #region Fields
    [SerializeField] float flyTime;
    [SerializeField] Transform target;
    private bool isCollected;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected)
        {
            isCollected = true;
            transform.DOMove(target.transform.position, flyTime).SetEase(Ease.Linear);
            EventManager.SendBoxCollected();
            Destroy(gameObject, flyTime);
        }
    }
}
