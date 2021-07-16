using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayGameButton()
    {
        // khi nhan vao thi chuyen man hinh
        Application.LoadLevel("GamePlay");  
    }

    public void QuitGameButton()
    {
        Application.Quit();
        
    }
}
