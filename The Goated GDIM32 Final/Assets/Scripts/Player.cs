using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    

    [SerializeField] public float _jumpVelocity = 3f;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] Transform cameraTransform;

    [SerializeField] private GameObject _canvas;

    private bool _isGrounded;

    [SerializeField] float sensitivity = 150f;

    float xRotation;
    float yRotation;


    [SerializeField] private List<Item> _inventory;

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

        Cursor.lockState = CursorLockMode.Locked;
        

        xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
    yRotation += Input.GetAxis("Mouse X") * sensitivity;

    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);



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

