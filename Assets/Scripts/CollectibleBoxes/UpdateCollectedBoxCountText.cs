using TMPro;
using UnityEngine;

public class UpdateCollectedBoxCountText : MonoBehaviour
{
    #region Injection
    public void Construct(TotalScores totalScores)
    {
        _totalScores = totalScores;
    }
    private TotalScores _totalScores;
    #endregion

    private TextMeshProUGUI boxesCountText;

    void Start()
    {
        boxesCountText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        ScoresUpdate();
    }
    private void ScoresUpdate()
    {
        boxesCountText.text = $"{_totalScores.scoresForUi}";
    }
}
