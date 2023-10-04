using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Economy : MonoBehaviour
{
    private float _time = 0.0f;
    private float interpolationPeriod = 0.15f;
    public int cash=0;
    public TextMeshProUGUI _textMeshProUGUI;
    
    

    
    
    private void Example()
    {
        _textMeshProUGUI = FindObjectOfType<TextMeshProUGUI>();
        _textMeshProUGUI.SetText(cash+"$", 4, 6.345f, 3.5f);
        // The text displayed will be:
        // The first number is 4 and the 2nd is 6.35 and the 3rd is 4.
    }

    public bool spendMoney(int x)
    {
        if (cash > x)
        {
            cash -= x;
            return true;
        }

        return false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= interpolationPeriod)
        {
            _time = 0.0f;
            cash++;
        }

    }
    
    
}
