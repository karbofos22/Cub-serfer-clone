using TMPro;
using DG.Tweening;
using UnityEngine;

public class GetReadyScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI getReadyText;

    private void Start()
    {
        TextFade();
    }
    public void OnPlayerIsReady()
    {
        EventManager.SendPlayerIsReady();
    }
    private void TextFade()
    {
        DOTween.Init();
        getReadyText.DOFade(1, 1).SetLoops(-1, LoopType.Yoyo);
    }
}
