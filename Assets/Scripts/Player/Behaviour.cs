using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Behaviour : MonoBehaviour
{
    private Movement playerMovement;
    private BodyController playerBody;

    void Start()
    {
        playerBody = GetComponent<BodyController>();
        playerMovement = GetComponent<Movement>();

        
        EventManager.GameIsActive.AddListener(GameStart);
        EventManager.GameOver.AddListener(GameOver);
    }

    void Update()
    {
    }
    private void GameOver()
    {
        //uiManager.GameOverScreenChange();
        //isGameActive = false;
        playerMovement.enabled = false;
        playerBody.enabled = false;


        EventManager.GameOver.RemoveListener(GameOver);
    }
    private void GameStart()
    {
        playerMovement.enabled = true;
        playerBody.enabled = true;
        EventManager.GameOver.RemoveListener(GameStart);
    }
}
