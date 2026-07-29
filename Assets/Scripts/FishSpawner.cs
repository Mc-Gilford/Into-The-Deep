using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishSpawner : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    [SerializeField] private int numberFish;
    [SerializeField] private int wave=1;


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
        
        for(int f=0; f<numberFish; f++){

            Instantiate(FishToSpawn());            

        }

    }

    private GameObject FishToSpawn(){
        
        int fish = Random.Range(0,fishPrefabs.Count);    
        return fishPrefabs[fish];

    }
}
