using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int life;
    public int speed;
    
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 displacementVector = new Vector3(1, 0, 0);
        //transform.Translate( Time.deltaTime*speed*displacementVector);
        
       // if(life<=0)
       //     Destroy(gameObject);
    }
    
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            Debug.Log("Hello: " + gameObject.name);
        }
        Debug.Log("EEEE: " + gameObject.name);
    }

    
    
}