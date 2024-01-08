using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private ArrayList target = new ArrayList();
    private float _time = 0.0f;
    private float interpolationPeriod = 1.0f;
    private int dmg = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= interpolationPeriod)
        {
            bool test = true;
            _time = 0.0f;
            while (test && target.Count>0)
            {
                if ((GameObject)target[0] == null)
                    target.RemoveAt(0);
                else
                    test = false;
            } 
             if(target.Count>0)
                 if (((GameObject)target[0]).TryGetComponent<Health>(out Health healthCompoment))
                 {
                     healthCompoment.TakeDamage(dmg);
                 }
             Debug.Log(target.Count);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        {
            if (transform.parent != null && transform.parent.CompareTag("Base_A"))
                if (collision.CompareTag("Enemy"))
                {
                    target.Add(collision.gameObject);
                }
            
            if (transform.parent != null && transform.parent.CompareTag("Base_B")) 
                if (collision.CompareTag("Ally")){
                    target.Add(collision.gameObject);
                } 
        }
        
    }
}
