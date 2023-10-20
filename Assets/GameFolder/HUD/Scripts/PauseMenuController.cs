using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //[SerializeField] GameObject pauseMenu;

    //private bool isGamePaused;

    //private void Start()
    //{
    //    isGamePaused = false;
    //}

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Cancel"))
    //    {
    //        Pause();
    //    }
    //}

    //public void Pause()
    //{
    //    pauseMenu.SetActive(!isGamePaused);
    //    Time.timeScale = 0f;
    //}

   public void Resume()
   {
        this.enabled = false;
        
   }

   public void Restart(int sceneID)
    {
       Time.timeScale = 1.0f;
       SceneManager.LoadScene(sceneID);
    }
}
