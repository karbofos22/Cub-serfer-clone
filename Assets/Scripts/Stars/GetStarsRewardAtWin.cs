using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GetStarsRewardAtWin : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject starSprite;
    [SerializeField] private int levelRewardAmount;

    [SerializeField] private RectTransform nextLevelButtonPos;
    [SerializeField] RectTransform targetPointVar;

    private float startDelay = 0.1f;
    private float repeatDelay = 0.2f;

    private float spawnedBonusStarAmount = 0f;
    private float flyTime = 1f;
    #endregion

    public void OnLevelCompleteReward()
    {
        InvokeRepeating(nameof(BonusStarSpawn), startDelay, repeatDelay);
    }
    private void BonusStarSpawn()
    {
        if (spawnedBonusStarAmount != levelRewardAmount)
        {
            var bonusStar = Instantiate(starSprite, nextLevelButtonPos.position, Quaternion.identity, transform);

            bonusStar.transform.DOMove(targetPointVar.position, flyTime);
            bonusStar.GetComponent<Image>().DOFade(0.5f, flyTime);
            EventManager.SendStarCollected();
            spawnedBonusStarAmount++;
            Destroy(bonusStar, flyTime);
        }
    }
}
