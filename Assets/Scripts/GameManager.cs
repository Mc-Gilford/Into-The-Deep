using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private FishSpawner fishSpawner;

    [SerializeField] private string timerText;
    
    [SerializeField] private float timeBeforeHelp = 90f;


    private bool isAlive = true;

    private int fishCount =0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishSpawner = GameObject.Find("FishSpawner").GetComponent<FishSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        fishCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(fishCount == 0){
            fishSpawner.NewWave();
        }

        if (isAlive && timeBeforeHelp > 0)
        {
            timeBeforeHelp-=Time.deltaTime;   
        }
        else if(timeBeforeHelp <0)
        {
            timeBeforeHelp = 0;
        }

        int minutes = Mathf.FloorToInt(timeBeforeHelp / 60);
        int seconds = Mathf.FloorToInt(timeBeforeHelp % 60);

        timerText = string.Format("{0:00}:{1:00}", minutes,seconds);
        Debug.Log(timerText);

    }

}
