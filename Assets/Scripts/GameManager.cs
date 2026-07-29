using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public FishSpawner fishSpawner;
    
    [SerializeField] private float timeBeforeHelp = 60f;

    [SerializeField] private string timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishSpawner = GameObject.Find("FishSpawner").GetComponent<FishSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        fishCount = FindObjectsByType<FishController>(FindObjectsSortMode.None).Length;
        if(fishCount == 0){
            fishSpawner.NewWave();
        }
    }
}
