using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        fadePanel.alpha = 1;

        while (fadePanel.alpha > 0)
        {
            fadePanel.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        fadePanel.alpha = 0;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        while (fadePanel.alpha < 1)
        {
            fadePanel.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}