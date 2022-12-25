using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateStarsCountText : MonoBehaviour
{
    private TextMeshProUGUI starsCountText;
    private int stars;

    void Start()
    {
        starsCountText = GetComponent<TextMeshProUGUI>();
        EventManager.OnStarCollected.AddListener(ScoreIncrease);
    }

    private void ScoreIncrease()
    {
        stars++;
        starsCountText.text = $"{stars}";
    }
}
