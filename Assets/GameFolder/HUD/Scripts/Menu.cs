using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Transform pauseScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        pauseScreen.GetComponent<PauseMenuController>().enabled = false;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Fase1");
    }
}
