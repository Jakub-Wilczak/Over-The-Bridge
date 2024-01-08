using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public bool battery;
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ally"))
            battery = true;
        else if (other.CompareTag("Enemy"))
            battery = false;
        
        Debug.Log("something entered");
    }
}
