using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;


public class UI : MonoBehaviour
{
    public GameObject Spawner;
    public Label mon;
    public GameObject Tower1;

   

    private void OnEnable()
    {
        Debug.Log("XASDASDASDASDASD");
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button but1 = root.Q<Button>("but1");
        Button but2 = root.Q<Button>("but2");
        mon = root.Q<Label>("Money");
        Button but3 = root.Q<Button>("but3");
        // Button but4 = root.Q<Button>("but4");
        // Button but5 = root.Q<Button>("but5");
        // Button but6 = root.Q<Button>("but6");
        // Button but7 = root.Q<Button>("but7");
        // Button but8 = root.Q<Button>("but8");
        // Button but9 = root.Q<Button>("but9");

        
         but1.clicked += () => Spawner.GetComponent<Spawner>().spawn_A(GetComponent<Economy>().spendMoney(10));
         but2.clicked += () =>  Spawner.GetComponent<Spawner>().spawn_B(GetComponent<Economy>().spendMoney(20)); 
        
         
           but3.clicked += () =>  Tower1.SetActive(GetComponent<Economy>().spendMoney(30));
        // but4.clicked += () =>  test.transform.Translate(0, +1, 0);
        // but5.clicked += () =>  Debug.Log("Wrong button bro");
        // but6.clicked += () =>  test.transform.Translate(0, -1, 0);
        // but7.clicked += () =>  test.transform.Translate(+1, 0, 0);
        // but8.clicked += () =>  Debug.Log("Wrong button bro");
        // but9.clicked += () =>  test.transform.Translate(-1, 0, 0);
    }

    public void Update()
    {
        mon.text = GetComponent<Economy>().cash.ToString() + " $";

    }
}
