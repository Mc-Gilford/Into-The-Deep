using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Cargar la escena del juego
    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }

    //cargar la escena del tutorial
    public void OpenTutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    //Salir del juego
    public void QuitGame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }    
}
