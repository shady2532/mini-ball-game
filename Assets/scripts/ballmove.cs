using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ballmove : MonoBehaviour
{

    public Transform cam;
    
    public float speed = 3f;
    Rigidbody rb;

    

    private float movementZ;
    private float movementX;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        var camera = Camera.main;
        var forward = camera.transform.forward;
        var right = camera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        var desiredMovement = forward * movementX + right * movementZ;

        //Vector3 desiredMovement = new Vector3(movementX, 0f,movementY);
        rb.AddForce(desiredMovement * speed);
        
    }
    private void OnRoll(InputValue input)
    {
        Vector3 rollvector = input.Get<Vector3>();
        movementZ=rollvector.x;
        movementX=rollvector.z;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        { 
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("coin");
            scoring.instance.addScore(1);
            Timer.instance.addTime(2.5f);
            StartCoroutine(spawner.instance.delay(0.5f));
        }
        if (other.gameObject.tag == "specialCoin")
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("specialCoin");
            scoring.instance.addScore(3);
            Timer.instance.addTime(5.5f);
        }
    }
}