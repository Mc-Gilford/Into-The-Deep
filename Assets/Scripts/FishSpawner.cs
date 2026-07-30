using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishSpawner : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    [SerializeField] public GameObject objectToFollow;
    [SerializeField] private int numberFish=1;
    [SerializeField] private int wave=0;
    public float speedBoost = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewWave(){
        wave++;
        numberFish++;
        SpawnWave();
    }

    public void SpawnWave(){
        Debug.Log("Comienza la oleada "+wave);
        for(int f=0; f<numberFish; f++){

            GameObject newFish = FishToSpawn();
            Instantiate(newFish,SpawnPosition(),newFish.transform.rotation);            

        }

        if(wave > 1)
        {
            speedBoost += 0.2f;
        }
        
    }

    private GameObject FishToSpawn(){
        
        int fish = Random.Range(0,fishPrefabs.Count);    
        return fishPrefabs[fish];

    }

    private Vector3 SpawnPosition(){
        return new Vector3(randomDistance(),RandomHeight(),randomAproach());
    }

    private float RandomHeight()
    {
        float playerPositionY= objectToFollow.transform.position.y;
        float rangeY = playerPositionY-25; 
        return Random.Range(rangeY,(rangeY+10));
        
    }

    private float randomDistance()
    {
        float playerPositionX= objectToFollow.transform.position.x;
        float rangeX = playerPositionX+30;
        float minusRangeX =  playerPositionX-30;
        return Random.Range(minusRangeX,rangeX);
    }

    private float randomAproach()
    {
        float playerPositionZ= objectToFollow.transform.position.z;
        float rangeZ = playerPositionZ+20;
        float minusRangeZ =  playerPositionZ-20;
        return Random.Range(minusRangeZ,rangeZ);
    }
}
