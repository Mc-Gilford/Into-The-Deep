using System.Collections;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] private float missileSpeed = 30f;
    [SerializeField] private float lifeTime = 5f;

    private void Start()
    {
        StartCoroutine(Explode());
    }

    private void Update()
    {
        transform.position +=
            transform.forward * missileSpeed * Time.deltaTime;
    }

    IEnumerator Explode()
    {
        Debug.Log("Tiempo antes de detonación");
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}