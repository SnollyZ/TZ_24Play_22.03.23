using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]private GameObject tryAgain;
    [SerializeField]private GameObject tapToPlay;

    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.instance;
    }

    public void HideTapToPlay(){
        tapToPlay.SetActive(false);
    }

    public void ShowTryAgain(){
        tryAgain.SetActive(true);
    }

    public void TryAgain(){
        gameManager.StartNewGame();
    }
}
