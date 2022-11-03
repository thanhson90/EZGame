using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResultDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    
    public void OnShow(bool result)
    {
        resultText.text = result ? "Game Win" : "Game over";
    }

    public void OnHide()
    {
        
    }

    public void OnReplayClicked()
    {
        GameLogic.Instance.StartGame();
    }
}
