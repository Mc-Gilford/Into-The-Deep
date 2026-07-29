using UnityEngine;

public class FishManager : MonoBehaviour
{
    private float baseSpeed = 1.0f;
    public float speedBoost;
    private FishSpawner fishSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishSpawner = GameObject.Find("FishSpawner").GetComponent<FishSpawner>();
        GetBoost();
    }

    void GetBoost(){
        speedBoost = fishSpawner.speedBoost;
        baseSpeed += speedBoost; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
