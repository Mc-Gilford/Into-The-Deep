using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : Character
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float verticalSpeed = 20f;
    [SerializeField] private float maxSpeed = 10f;
    private float verticalInput = 0f;
    private Rigidbody rb;
    private InputSystem_Actions controls;
    private Vector3 position;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSourceAttack;
    [SerializeField] protected AudioClip attackSound;
    [Header("Sparkles")]
    [SerializeField] protected ParticleSystem attackEffect;
    [Header("Attacking")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float missileSpeed = 30f;
    [SerializeField] private GameObject missile;
    public int lifeLevel;
    //private bool isGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controls = new InputSystem_Actions();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    void Start()
    {
        setMaxHealth(lifeLevel);
        setHealth();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(getHealth());
        Attack();
    }
    private void FixedUpdate()
    {
        Driving();
    }
    public void Driving()
    {
        /*Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float forwardInput = moveInput.y; //Moverse al frente
        rb.AddRelativeForce(Vector3.forward*moveSpeed*forwardInput);
        transform.Rotate(Vector3.up*Time.deltaTime*rotationSpeed*moveInput.x);
        verticalMovement();*/
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();

        float forwardInput = moveInput.y;

        rb.AddRelativeForce(
            Vector3.forward * moveSpeed * forwardInput,
            ForceMode.Force
        );

        Quaternion rotation = Quaternion.Euler(
            0f,
            rotationSpeed * moveInput.x * Time.fixedDeltaTime,
            0f
        );

        rb.MoveRotation(rb.rotation * rotation);

        VerticalMovement();
    }
    public void VerticalMovement(){
         verticalInput = 0f;
        if (Keyboard.current.qKey.isPressed)//Bajar
        {
            verticalInput = 1f;
        }
        else if (Keyboard.current.eKey.isPressed)
        {
            verticalInput =-1f;
        }
        rb.AddForce(
        Vector3.up * verticalSpeed * verticalInput,
        ForceMode.Force);
    }
    public void Attack()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (audioSourceAttack != null && attackSound != null)
            {
                audioSourceAttack.PlayOneShot(attackSound);
            }
            if (attackEffect != null)
            {
                attackEffect.Play();
            }
            GameObject fireMissile = Instantiate(
                missile,
                firePoint.position,
                firePoint.rotation
            );
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(2);
            Debug.Log(getHealth());
        }
    }
}
