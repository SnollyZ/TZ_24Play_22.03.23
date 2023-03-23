using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]private Menu menu;
    [SerializeField]private Player player;
    [SerializeField]private GameObject InputManager;
    [SerializeField]private CameraController cameraController;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    void Start(){
        Time.timeScale = 0;
        StartCoroutine(WaitForTouch());
    }

    private IEnumerator WaitForTouch(){
        while(!Input.anyKey){
            yield return null;
        }
        StartGame();
        yield break;
    }

    public void StartGame(){
        menu.HideTapToPlay();
        Time.timeScale = 1;
    }

    public void EndGame(){
        player.Death();
        InputManager.SetActive(false);
        cameraController.StopChasing();
        menu.ShowTryAgain();
    }

    public void StartNewGame(){
        SceneManager.LoadScene(0);
    }
}
