using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float currenthealth;
    public float maxhealth;
    public bool isPlayer;
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currenthealth/maxhealth;
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
