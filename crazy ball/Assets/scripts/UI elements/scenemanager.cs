using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
    // public Animator animator;
    // static private int levelIndex;
    public void MainMenuButton(){
    
        // StartCoroutine(LoadLevel(1));
        SceneManager.LoadScene(1);
    }
    public void GamePlayButton(){
        
        // StartCoroutine(LoadLevel(0));
        SceneManager.LoadScene(0);
        
    }

    public void RestartButton(){
        // StartCoroutine(LoadLevel(0));
        SceneManager.LoadScene(0);
    
        
    }
    
    // IEnumerator LoadLevel(int index){
    //     animator.SetTrigger("Start");
    //     yield return new WaitForSeconds(1f);
    //     SceneManager.LoadScene(index);
    // }
}
