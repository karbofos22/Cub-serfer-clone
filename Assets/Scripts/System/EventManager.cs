using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<int> OnBoxCollected = new();
    public static UnityEvent GameIsActive = new();
    public static UnityEvent GameOver = new();

    public static void SendBoxCollected(int amount)
    {
        OnBoxCollected.Invoke(amount);
    }
    public static void SendGameIsActive()
    {
        GameIsActive.Invoke();
    }
    public static void SendGameIsOver()
    {
        GameOver.Invoke();
    }
}

