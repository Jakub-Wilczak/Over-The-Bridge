using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
    private Rigidbody _rb;
    public bool isMoving;
    public int spawnedID = 0;
    public GameObject target;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (TryGetComponent<Health>(out Health healthComponent)) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            if (Vector3.Distance(transform.position, target.transform.position) > GetComponent<MeshRenderer>().bounds.size.x*1.5 )
                target = null;
            else
            {
                Debug.Log(Vector3.Distance(transform.position, target.transform.position));
            }
        
        if (target == null)
            isMoving = true;


        if (isMoving)
        {
            Vector3 displacementVector = Vector3.zero;
            if (CompareTag("Ally"))
            {
                displacementVector = new Vector3(1, 0, 0);
            }
            else if (CompareTag("Enemy"))
            {
                displacementVector = new Vector3(-1, 0, 0);
            }

            transform.Translate(Time.deltaTime * speed * displacementVector);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (CompareTag("Ally"))
        {
            if (collision.gameObject.CompareTag("Base_A"))
            {
                //Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }

            // if (collision.gameObject.CompareTag("Ally") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Base_B"))
            if (collision.gameObject.CompareTag("Ally"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                isMoving = false;
                target = collision.gameObject;
            }
        }

        if (CompareTag("Enemy"))
        {

            if (collision.gameObject.CompareTag("Base_B"))
            {
                //Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Ally"))
            {
                isMoving = false;
                target = collision.gameObject;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (CompareTag("Ally"))
        {
            if (collision.gameObject.CompareTag("Base_A"))
            {
                //Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }

            // if (collision.gameObject.CompareTag("Ally") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Base_B"))
            if (collision.gameObject.CompareTag("Ally"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                isMoving = false;
                target = collision.gameObject;
            }
        }

        if (CompareTag("Enemy"))
        {

            if (collision.gameObject.CompareTag("Base_B"))
            {
                //Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Ally"))
            {
                isMoving = false;
                target = collision.gameObject;
            }
        }


    }

    private void OnCollisionExit(Collision collision)
    {

        // if (CompareTag("Ally"))
        // {
        //
        //     if (collision.gameObject.CompareTag("Ally"))
        //     {
        //         if (spawnedID < collision.gameObject.GetComponent<Movement>().spawnedID)
        //             isMoving = true;
        //     }
        // }
        //
        // if (CompareTag("Enemy"))
        // {
        //
        //     if (collision.gameObject.CompareTag("Enemy"))
        //     {
        //         if (collision.gameObject.GetComponent<Movement>().spawnedID < spawnedID)
        //             isMoving = true;
        //     }
        // }


    }

public void setSpawnID(int id) {
    spawnedID = id;
}

}
