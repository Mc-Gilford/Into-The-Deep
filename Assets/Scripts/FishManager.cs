using UnityEngine;
using System.Collections;

public class FishManager : Character
{
    [SerializeField] private float baseSpeed = 20.0f;
    public float speedBoost;
    private FishSpawner fishSpawner;
    private bool isWaiting = false;
    public int lifeLevel;
    [SerializeField] private Rigidbody rbFish;
    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbFish = GetComponent<Rigidbody>();
        player = GameObject.Find("Submarino");
        fishSpawner = GameObject.Find("FishSpawner").GetComponent<FishSpawner>();
        GetBoost();
        setMaxHealth(lifeLevel);
        
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
            
        }

        switch(collision.gameObject.tag)
        {
            case "Player":
                Debug.Log("Munch");
                rbFish.linearVelocity = Vector3.zero;
                StartCoroutine(LettingPlayerEscape());
                break;
            case "Missil":
                Debug.Log("Auch");
                takeDamage(2);
                break;
        }
    }

    IEnumerator LettingPlayerEscape()
    {
        isWaiting=true;
        yield return new WaitForSeconds(5);
        isWaiting=false;
    }

}
