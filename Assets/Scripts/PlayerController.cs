using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : Character
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] private float maxSpeed = 10f;
    private Rigidbody rb;
    private GameObject misil;
    private InputSystem_Actions controls;
    private Vector3 position;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        driving();
    }
    public void driving()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float forwardInput = moveInput.y; //Moverse al frente
        rb.AddRelativeForce(Vector3.forward*moveSpeed*forwardInput);
        transform.Rotate(Vector3.up*Time.deltaTime*rotationSpeed*moveInput.x);
    }
}
