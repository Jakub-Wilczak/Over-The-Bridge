using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float currenthealth;
    public float maxhealth;
    public bool isPlayer;
    Animator anim;
    private bool hasAnimator=false;
    private GameObject unitprefab;
    
    
    public UnityEvent Is_Dead;

    public float CurrentHealth
    {
        set { currenthealth= value; }
        get { return this.currenthealth; }
    }
    public bool IsPlayer
    {
        set { isPlayer= value; }
        get { return this.isPlayer; }
    }

    public void TakeDamage(int damageNumber)
    {
        if (damageNumber >= 0)
            currenthealth -= damageNumber;
        
    }


    public void UpdateHealthBar()
    {
    }

    void Start()
    {
        if (Is_Dead == null)
            Is_Dead = new UnityEvent();
        
        unitprefab = transform.GetChild(0).gameObject;
        if(unitprefab.TryGetComponent<Animator>(out Animator animator))
        {
            anim = animator;
            hasAnimator = true;
        }
        ;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currenthealth/maxhealth;
        if (currenthealth <= 0)
        {
            
            if(hasAnimator)
                anim.SetBool("isDead", true);
            
            Is_Dead.Invoke();
            Invoke("DestroyItself",0.5f);
        }
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}
