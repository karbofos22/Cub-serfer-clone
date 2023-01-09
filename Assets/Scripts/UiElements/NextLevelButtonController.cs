using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButtonController : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject boxSprite;
    [SerializeField] private int levelRewardAmount;
    [SerializeField] private float flyTime = 0.2f;

    [SerializeField] private RectTransform nextLevelButtonPos;
    [SerializeField] RectTransform targetPointVar;
    #endregion

    public void OnLevelComplete()
    {
        BonusStarSpawn();
    }
    private void BonusStarSpawn()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(SpawnSprite)
            .AppendInterval(0.2f)
            .SetLoops(levelRewardAmount)
            .OnComplete(() => EventManager.SendLevelComplete());
    }
    private void SpawnSprite()
    {
        var bonusStar = Instantiate(boxSprite, nextLevelButtonPos.position, Quaternion.identity, transform);

        bonusStar.transform.DOMove(targetPointVar.position, flyTime);
        bonusStar.GetComponent<Image>().DOFade(0.5f, flyTime);
        EventManager.SendBoxCollected();
        Destroy(bonusStar, flyTime);
    }
}
