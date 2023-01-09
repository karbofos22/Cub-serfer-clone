using UnityEngine;
using static GameStateController;

public class MenuCamera : MonoBehaviour
{
    void Start()
    {
        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }
    private void OnGameStateChanged(GameState state)
    {
        gameObject.SetActive(state == GameState.Menu);
    }
}
