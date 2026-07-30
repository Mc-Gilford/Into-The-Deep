using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    private FishSpawner fishSpawner;

    public GameObject subMenu;

    public GameObject treeHits;

    public GameObject twoHits;

    public GameObject oneHit;

    [SerializeField] private string timerText;
    
    [SerializeField] private float timeBeforeHelp = 90f;

    public TextMeshProUGUI timerDisplay;

    public TextMeshProUGUI resultText;

    private bool isAlive = true;

    private bool gameOver = false;

    private bool victory = false;

    private int fishCount =0;

    [SerializeField] private int nohits=0;

    private string finalMessage;
    private string winMessage="Sobreviviste";
    private string defeatMessage="Perdiste";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishSpawner = GameObject.Find("FishSpawner").GetComponent<FishSpawner>();
        subMenu.SetActive(false);
        resultText.text="Juego en curso";
        treeHits.SetActive(true);
        twoHits.SetActive(false);
        oneHit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fishCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(fishCount == 0){
            fishSpawner.NewWave();
        }

        if(GameObject.Find("Submarino") == null)
        {
            gameOver = true;
            isAlive = false;
            resultText.text = defeatMessage;
        }

        if (isAlive && timeBeforeHelp > 0)
        {
            timeBeforeHelp-=Time.deltaTime;   
        }
        else if(timeBeforeHelp <0 && isAlive)
        {
            timeBeforeHelp = 0;
            victory = true;
            resultText.text = winMessage; 
        }
        

        int minutes = Mathf.FloorToInt(timeBeforeHelp / 60);
        int seconds = Mathf.FloorToInt(timeBeforeHelp % 60);

        timerText = string.Format("{0:00}:{1:00}", minutes,seconds);
        timerDisplay.text = "Time before rescue: "+timerText;
        //resultText.text = "Time before rescue: "+timerText;
        //Debug.Log(timerText);

        if (gameOver || victory)
        {
            subMenu.SetActive(true);
        }

    }

    public void getHit()
    {
        switch(nohits)
        {
            case 0:
                treeHits.SetActive(false);
                twoHits.SetActive(true);
                oneHit.SetActive(false);
                break;
            case 1:
                treeHits.SetActive(false);
                twoHits.SetActive(false);
                oneHit.SetActive(true);
                break;
            case 2:
                treeHits.SetActive(false);
                twoHits.SetActive(false);
                oneHit.SetActive(false);
                break;
        }
        nohits++;
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
