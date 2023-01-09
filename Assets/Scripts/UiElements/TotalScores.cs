using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScores : MonoBehaviour
{
    #region Fields
    private int scores;
    [HideInInspector]
    public int scoresForUi;
    #endregion

    void Start()
    {
        EventManager.OnBoxCollected.AddListener(ScoreIncrease);
    }
    private void ScoreIncrease()
    {
        scores++;
        scoresForUi = scores;
    }
}
