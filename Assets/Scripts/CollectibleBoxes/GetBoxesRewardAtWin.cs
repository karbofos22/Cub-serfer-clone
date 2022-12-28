using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GetBoxesRewardAtWin : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject boxSprite;
    [SerializeField] private int levelRewardAmount;

    [SerializeField] private RectTransform nextLevelButtonPos;
    [SerializeField] RectTransform targetPointVar;

    private float startDelay = 0.1f;
    private float repeatDelay = 0.2f;

    private float spawnedBonusBoxAmount = 0f;
    private float flyTime = 1f;
    #endregion

    public void OnLevelCompleteReward()
    {
        InvokeRepeating(nameof(BonusStarSpawn), startDelay, repeatDelay);
    }
    private void BonusStarSpawn()
    {
        if (spawnedBonusBoxAmount != levelRewardAmount)
        {
            var bonusStar = Instantiate(boxSprite, nextLevelButtonPos.position, Quaternion.identity, transform);

            bonusStar.transform.DOMove(targetPointVar.position, flyTime);
            bonusStar.GetComponent<Image>().DOFade(0.5f, flyTime);
            EventManager.SendBoxCollected();
            spawnedBonusBoxAmount++;
            Destroy(bonusStar, flyTime);
        }
    }
}
