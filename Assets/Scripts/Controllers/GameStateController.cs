using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        GetReady,
        NextLevelSetup,
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
        EventManager.OnLevelComplete.AddListener(ChangeGameStateOnLevelComplete);
        EventManager.OnAwaitPlayerToStart.AddListener(ChangeGameStateOnAwaitPlayerToStart);
        EventManager.OnGameActive.AddListener(ChangeGameStateOnGameActive);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        EventManager.SendGameStateChanged(state);
    }
    public void ToGetReadyScreen()
    {
        UpdateGameState(GameState.GetReady);
    }
    public void GameRestart()
    {
        UpdateGameState(GameState.Menu);
        EventManager.PlayerDead.RemoveAllListeners();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    private void ChangeGameStateOnAwaitPlayerToStart()
    {
        UpdateGameState(GameState.GetReady);
    }
    private void ChangeGameStateOnGameActive()
    {
        UpdateGameState(GameState.GameActive);
    }
    private void ChangeGameStateOnPlayerDeath()
    {
        UpdateGameState(GameState.Lose);
    }
    private void ChangeGameStateOnPlayerWin()
    {
        UpdateGameState(GameState.Win);
    }
    private void ChangeGameStateOnLevelComplete()
    {
        UpdateGameState(GameState.NextLevelSetup);
    }
}
