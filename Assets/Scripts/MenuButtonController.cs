using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public Canvas[] menus;
    public void BeginGame(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectLevel()
    {
        //select level screen
    }

    
    public void SwitchMenu(int menuIndex)
    {

        
        
        for(int i = 0; i < menus.Length; i ++)
        {
            if( i == menuIndex)
            {
                menus[i].gameObject.SetActive(true);

            }
            else
            {
                menus[i].gameObject.SetActive(false);
            }
        }
       
    }
    
}
