using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{

    [SerializeField]
    private GameResultDialog resultDialog;
    [SerializeField]
    private MainGameDialog mainDialog;
    // Start is called before the first frame update


    private void Start()
    {
        mainDialog.OnShow();
    }
    

    public void ShowResult(bool result)
    {
        resultDialog.gameObject.SetActive(true);
        resultDialog.OnShow(result);
    }

    public void StartGame()
    {
        resultDialog.OnHide();
        resultDialog.gameObject.SetActive(false);
    }
}
