using UnityEngine;

public class Character : MonoBehaviour
{
    private int health;
    private int damage;
    private int maxHealth;
    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip attackSound;
    [SerializeField] protected AudioClip hurtSound;
    [SerializeField] protected AudioClip deathSound;

    [Header("Particles")]
    [SerializeField] protected ParticleSystem attackEffect;
    [SerializeField] protected ParticleSystem hitEffect;
    [SerializeField] protected ParticleSystem deathEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }


    public void setHealth()
    {
        this.health = this.maxHealth;    
    }
    
    public void setMaxHealth(int lifeLevel)
    {
        this.health = lifeLevel;    
    }
    public void setDamage(int damageLevel)
    {
        this.damage = damageLevel;
    }

    public int getHealth()
    {
        return this.health;
    }
    public int getDamage()
    {
        return this.damage;
    }

    public virtual void takeDamage(int recievedDamage)
    {
        this.health-=recievedDamage;
        if(audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
        if (hitEffect != null)
        {
            hitEffect.Play();
        }


        if(this.health<=0)
        {
            die();
        }
    }
    protected virtual void die()
    {
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
        if (deathEffect != null)
        {
            deathEffect.Play();
        }
        Destroy(gameObject);
    }

}
