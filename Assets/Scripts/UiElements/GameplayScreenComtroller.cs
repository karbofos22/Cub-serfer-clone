using UnityEngine;
using static GameStateController;

public class GameplayScreenComtroller : MonoBehaviour
{
    void Start()
    {
        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.GetReady || state == GameState.GameActive || state == GameState.Win)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
