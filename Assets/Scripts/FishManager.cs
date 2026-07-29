using UnityEngine;
using System.Collections;

public class FishManager : Character
{
    [SerializeField] private float baseSpeed = 20.0f;
    public float speedBoost;
    private FishSpawner fishSpawner;
    private bool isWaiting = false;
    [SerializeField] private Rigidbody rbFish;
    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbFish = GetComponent<Rigidbody>();
        player = GameObject.Find("Submarino");
        fishSpawner = GameObject.Find("FishSpawner").GetComponent<FishSpawner>();
        GetBoost();
        setMaxHealth(10);
    }

    void GetBoost(){
        speedBoost = fishSpawner.speedBoost;
        baseSpeed += speedBoost; 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(getHealth());
        if(!isWaiting)
        {
            ChasePlayer();
        }
        
    }

    public void ChasePlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rbFish.AddForce(lookDirection* baseSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("Auch");
            rbFish.linearVelocity = Vector3.zero;
            StartCoroutine(LettingPlayerEscape());
        }
    }

    IEnumerator LettingPlayerEscape()
    {
        isWaiting=true;
        yield return new WaitForSeconds(5);
        isWaiting=false;
    }    
}
