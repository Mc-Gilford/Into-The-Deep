using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialMenu : MonoBehaviour
{
    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
}
