using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
    
    public void MainMenuButton(){
        SceneManager.LoadScene("MainMenu");
    }
    public void GamePlayButton(){
        SceneManager.LoadScene("GameScene");
    }

    public void TutorialButton(){
        SceneManager.LoadScene("TutorialScene");
    }
    public void RestartButton(){
        SceneManager.LoadScene("GameScene");
    }
}
