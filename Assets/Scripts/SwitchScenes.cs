using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    [SerializeField] GameObject _panel;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(_panel.activeInHierarchy)
            {
                _panel.SetActive(false);
                Time.timeScale = 1;
            }
           else
            {
                Time.timeScale = 0;
                _panel.SetActive(true);
            }
           
        }
    }

    public void Mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void ReStartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
