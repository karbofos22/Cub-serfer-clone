using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        GameActive,
        Win,
        Lose
    }
    private GameState state;

    void Start()
    {
        UpdateGameState(GameState.Menu);
        EventManager.PlayerDead.AddListener(ChangeGameStateOnPlayerDeath);
        EventManager.PlayerWin.AddListener(ChangeGameStateOnPlayerWin);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        EventManager.SendGameStateChanged(state);
    }
    public void GameStart()
    {
        UpdateGameState(GameState.GameActive);
    }
    public void GameRestart()
    {
        UpdateGameState(GameState.Menu);
        EventManager.PlayerDead.RemoveAllListeners();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    private void ChangeGameStateOnPlayerDeath()
    {
        UpdateGameState(GameState.Lose);
    }
    private void ChangeGameStateOnPlayerWin()
    {
        UpdateGameState(GameState.Win);
    }
}
