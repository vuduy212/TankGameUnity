using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {

	public void _PlayButton(){
        SceneManager.LoadScene("GamePlay");
	}
    public void QuitGameButton()
    {
		Application.Quit();

    }
}
