using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Game
    {
        Active,
        Over
    }

    public Game gamePhase;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GameStart()
    {
        EventManager.SendGameIsActive();
        gamePhase = Game.Active;
    }
}
