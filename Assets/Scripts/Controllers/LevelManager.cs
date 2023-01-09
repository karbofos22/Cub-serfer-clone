using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateController;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;

    private Vector3 spawnPoint = new(80, 0, 0);

    private void Start()
    {
        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }
    private void RandomPathSpawn()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(levels[RandomNum()], spawnPoint, Quaternion.identity, transform);
    }
    private void TutorialPathSpawn()
    {
        Instantiate(levels[0], spawnPoint, Quaternion.identity, transform);
    }

    private int RandomNum()
    {
        int num = Random.Range(1, levels.Length);
        return num;
    }
    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                TutorialPathSpawn();
                break;
            case GameState.GetReady:
                break;
            case GameState.NextLevelSetup:
                RandomPathSpawn();
                EventManager.SendAwaitPlayerToStart();
                break;
            case GameState.GameActive:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }
    }
}
