using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    Waiting,
    InGame,
    Result
}
public class GameLogic : SingletonMono<GameLogic>
{
    

    // [SerializeField] private Transform SpawnPoint;

    [SerializeField] private Transform mainCharacter;
    [SerializeField] private Vector3 startPos;

    private GameState currentGameState = GameState.Waiting;

    public Action<GameState, bool> OnEndGameCallback;
    public Action OnKeyCollectCallback;
    public Action<int> OnKeyChangedCallback;

    private int keyCount;

    private void setKeyCount(int key)
    {
        keyCount = key;
        OnKeyChangedCallback?.Invoke(keyCount);
    }

    private void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        Debug.Log("Start Game");
        // mainCharacter.GetComponent<PlayerInput>().enabled = true;
        resetGame();
        currentGameState = GameState.InGame;
        setKeyCount(0);
        mainCharacter.GetComponent<ThirdPersonController>().enabled = true;
        UIManager.Instance.StartGame();
    }


    private void resetGame()
    {
        mainCharacter.gameObject.SetActive(false);
        mainCharacter.localPosition = startPos;
        mainCharacter.gameObject.SetActive(true);

        Debug.Log("reset game : " + mainCharacter.localPosition +"===" + startPos);
        setKeyCount(0);
    }

    public void EndGame(bool result)
    {
        Debug.Log("end game : " + result);
        currentGameState = GameState.Result;
        OnEndGameCallback?.Invoke(currentGameState, result);
        // mainCharacter.GetComponent<PlayerInput>().enabled = false;
        mainCharacter.GetComponent<ThirdPersonController>().enabled = false;

        UIManager.Instance.ShowResult(result);
    }


    public void OnTouchBall()
    {
        Debug.Log("[GameLogic] OnTouchBall");
        if (currentGameState != GameState.InGame)
        {
            return;
        }
        // game over
        EndGame(false);
    }

    public void OnTouchEndPoint()
    {
        if (currentGameState != GameState.InGame)
        {
            return;
        }
        
        if (keyCount >= 1)
        {
            // win
            setKeyCount(keyCount-1);
            EndGame(true);
        }
    }

    public void OnTouchKey()
    {
        if (currentGameState != GameState.InGame)
        {
            return;
        }
        if (keyCount < 3)
        {
            setKeyCount(keyCount+1);
            OnKeyCollectCallback?.Invoke();
        }
    }


}
