using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public Animator transitionAnim;

    public void RestartScene()
    {
        StartCoroutine(LoadScene(1));
    }

    public void MainMenuScene()
    {
        StartCoroutine(LoadScene(0));
    }

    IEnumerator LoadScene(int sceneNum)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneNum);
    }
}
