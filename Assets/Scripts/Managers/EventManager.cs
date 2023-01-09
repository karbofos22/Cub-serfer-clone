using UnityEngine.Events;
using UnityEngine;
using static GameStateController;

public class EventManager
{
    public static UnityEvent OnBoxCollected = new();
    public static UnityEvent<GameState> OnGameStateChanged = new();
    public static UnityEvent OnAwaitPlayerToStart = new();
    public static UnityEvent OnGameActive = new();
    public static UnityEvent OnLevelComplete = new();

    public static UnityEvent PlayerWin = new();
    public static UnityEvent PlayerDead = new();

    public static void SendGameStateChanged(GameState newState)
    {
        OnGameStateChanged.Invoke(newState);
    }
    public static void SendAwaitPlayerToStart()
    {
        OnAwaitPlayerToStart.Invoke();
    }
    public static void SendPlayerIsReady()
    {
        OnGameActive.Invoke();
    }
    public static void SendLevelComplete()
    {
        OnLevelComplete.Invoke();
    }
    public static void SendPlayerDead()
    {
        PlayerDead.Invoke();
    }
    public static void SendPlayerWin()
    {
        PlayerWin.Invoke();
    }
    public static void SendBoxCollected()
    {
        OnBoxCollected.Invoke();
    }
}

