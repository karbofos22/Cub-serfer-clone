using UnityEngine.Events;
using UnityEngine;
using static GameStateController;

public class EventManager
{
    public static UnityEvent OnStarCollected = new();
    public static UnityEvent<GameState> OnGameStateChanged = new();

    public static UnityEvent PlayerWin = new();
    public static UnityEvent PlayerDead = new();

    public static void SendGameStateChanged(GameState newState)
    {
        OnGameStateChanged.Invoke(newState);
    }
    public static void SendPlayerDead()
    {
        PlayerDead.Invoke();
    }
    public static void SendPlayerWin()
    {
        PlayerWin.Invoke();
    }

    public static void SendStarCollected()
    {
        OnStarCollected.Invoke();
    }
}

