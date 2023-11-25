using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Spawner_Temp : MonoBehaviour
{
    private GameObject[,] _prefabs;
    private float _time;
    private float _interpolationPeriod = 4.0f;
    private float velocity = 1.0f;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        setPrefabs();
        Instantiate(_prefabs[0, 0],new Vector3(transform.position.x,0,transform.position.z),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
        _time += Time.deltaTime;
        if (_time >= _interpolationPeriod)
        {
            Instantiate(_prefabs[0, 0],new Vector3(transform.position.x,0,transform.position.z),Quaternion.identity);
            _time = 0.0f;
        }
        
    }
    
    void setPrefabs()
    {
        _prefabs = new GameObject[4, 4];
        char side = CompareTag("Ally")? 'A':'B';

        _prefabs[0, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[0, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));
        
        _prefabs[1, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[1, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));

        _prefabs[2, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[2, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));

        _prefabs[3, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[3, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));

        

    }




}



