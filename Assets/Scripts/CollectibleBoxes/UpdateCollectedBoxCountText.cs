using TMPro;
using UnityEngine;

public class UpdateCollectedBoxCountText : MonoBehaviour
{
    private TextMeshProUGUI boxesCountText;
    private int boxes;

    void Start()
    {
        boxesCountText = GetComponent<TextMeshProUGUI>();
        EventManager.OnBoxCollected.AddListener(ScoreIncrease);
    }

    private void ScoreIncrease()
    {
        boxes++;
        boxesCountText.text = $"{boxes}";
    }
}
