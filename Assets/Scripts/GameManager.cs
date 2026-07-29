using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private FishSpawner fishSpawner;
    
    [SerializeField] private float timeBeforeHelp = 60f;

    [SerializeField] private string timeText;

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
    }
}
