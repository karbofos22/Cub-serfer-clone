using DG.Tweening;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private float hoverDistance = 5.1f;
    [SerializeField] private float hoverDuration = 0.6f;

    void Start()
    {
        transform.DOMoveY(hoverDistance, hoverDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
