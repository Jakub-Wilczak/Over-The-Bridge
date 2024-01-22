using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[System.Serializable]
public class BoolEvent : UnityEvent<bool>
{
}

public class Movement : MonoBehaviour
{
    public int speed;
    private Rigidbody _rb;
    public bool isMoving;
    public bool isEventMoving;
    public int spawnedID = 0;
    public GameObject target;
    
    public BoolEvent m_OnMove;
    public BoolEvent m_OnWalk;
    public UnityEvent m_OnStoppedMoving;

    private GameObject unitprefab;
    Animator anim;
    
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (TryGetComponent<Health>(out Health healthComponent)) ;
        
        if (m_OnMove == null)
            m_OnMove = new BoolEvent();
        isEventMoving = isMoving;
        
        unitprefab = transform.GetChild(0).gameObject;
        anim = unitprefab.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            if (Vector3.Distance(transform.position, target.transform.position) > GetComponent<BoxCollider>().bounds.size.x*1.5 )
                target = null;

        if (target == null)
        {
            isMoving = true;
            anim.SetBool("isMoving", true);
        }


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
            if (collision.gameObject.CompareTag("Base_B"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);
                target = collision.gameObject;
            }

            // if (collision.gameObject.CompareTag("Ally") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Base_B"))
            if (collision.gameObject.CompareTag("Ally"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    anim.SetBool("isMoving", false);
                    anim.SetBool("hasTarget", false);
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);
                target = collision.gameObject;
            }
        }

        if (CompareTag("Enemy"))
        {

            if (collision.gameObject.CompareTag("Base_A"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);
                target = collision.gameObject;
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    anim.SetBool("isMoving", false);
                    anim.SetBool("hasTarget", false);
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Ally"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);
                target = collision.gameObject;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (CompareTag("Ally"))
        {
            if (collision.gameObject.CompareTag("Base_B"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);
                target = collision.gameObject;
            }

            // if (collision.gameObject.CompareTag("Ally") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Base_B"))
            if (collision.gameObject.CompareTag("Ally"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    anim.SetBool("isMoving", false);
                    anim.SetBool("hasTarget", false);
                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);

                target = collision.gameObject;
            }
        }

        if (CompareTag("Enemy"))
        {

            if (collision.gameObject.CompareTag("Base_A"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);

                target = collision.gameObject;
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (spawnedID > collision.gameObject.GetComponent<Movement>().spawnedID)
                {
                    isMoving = false;
                    anim.SetBool("isMoving", false);
                    anim.SetBool("hasTarget", false);

                    target = collision.gameObject;
                }
            }
            else if (collision.gameObject.CompareTag("Ally"))
            {
                isMoving = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("hasTarget", true);

                target = collision.gameObject;
            }
        }


        m_OnMove.Invoke(isMoving);
        
        
        
        
        
            

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
