using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static GameStateController;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject getReadyScreen;

    private void Awake()
    {
        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }
    private void OnGameStateChanged(GameState state)
    {
        titleScreen.SetActive(state == GameState.Menu);
        getReadyScreen.SetActive(state == GameState.GetReady);
        winScreen.SetActive(state == GameState.Win);
        loseScreen.SetActive(state == GameState.Lose);
    }
}
