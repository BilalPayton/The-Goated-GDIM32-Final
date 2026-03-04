using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Singleton Code
    public static Player Instance { get; private set; }
    public Player player { get; private set; }

    public List<ItemData> _inventory = new List<ItemData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }
    // Singleton Code

    [SerializeField] private float _speed = 1.0f;
    

    [SerializeField] public float _jumpVelocity = 3f;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] Transform cameraTransform;

    [SerializeField] private GameObject _canvas;

    private bool _isGrounded;

    [SerializeField] float sensitivity = 150f;

    float xRotation;
    float yRotation;


    //public List<ItemData> _inventory;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


   


    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.velocity = new Vector3 (_rb.velocity.x, _jumpVelocity, _rb.velocity.z);
        }

        
        

    float mouseX = Input.GetAxis("Mouse X") * sensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

   transform.Rotate(Vector3.up * mouseX);

   xRotation -= mouseY;
   xRotation = Mathf.Clamp(xRotation, -80f, 80f);
   cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void OnMouseOver()
    {
        Debug.LogFormat("mous over {0}", gameObject.name);
        _canvas.SetActive(true);
    }

    private void OnMouseExit()
    {
        _canvas.SetActive(false); 
    }












}

