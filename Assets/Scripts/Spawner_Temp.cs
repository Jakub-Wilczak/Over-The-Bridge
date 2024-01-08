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
    private int tier = 0;
    private int spawned_ID = 0;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        setPrefabs();
        
        spawnUnit0();
    }

    // Update is called once per frame
    void Update()
    {
        
        _time += Time.deltaTime;
        if (_time >= _interpolationPeriod)
        {
            spawnUnit0();
            _time = 0.0f;
        }
        
    }
    
    void setPrefabs()
    {
        _prefabs = new GameObject[4, 4];
        char side = CompareTag("Base_A")? 'A':'B';
        

        _prefabs[0, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[0, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));
        
        _prefabs[1, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[1, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));

        _prefabs[2, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[2, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));

        _prefabs[3, 0] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_0", typeof(GameObject));
        _prefabs[3, 1] = (GameObject)Resources.Load("Prefabs/Units/Tier0_" + side + "_1", typeof(GameObject));
    }


    void spawnUnit0()
    {
        _prefabs[tier, 0].GetComponent<Movement>().setSpawnID(spawned_ID);
        Instantiate(_prefabs[tier, 0],new Vector3(transform.position.x,_prefabs[0, 0].GetComponent<BoxCollider>().bounds.size.y/2,transform.position.z),Quaternion.identity);
        spawned_ID++;
    }
    
    void spawnUnit1()
    {
        _prefabs[tier, 1].GetComponent<Movement>().setSpawnID(spawned_ID);
        Instantiate(_prefabs[tier, 1],new Vector3(transform.position.x,_prefabs[0, 0].GetComponent<BoxCollider>().bounds.size.y/2,transform.position.z),Quaternion.identity);
        spawned_ID++;
    }
    
    void spawnUnit2()
    {
        _prefabs[tier, 2].GetComponent<Movement>().setSpawnID(spawned_ID);
        Instantiate(_prefabs[tier, 2],new Vector3(transform.position.x,_prefabs[0, 0].GetComponent<BoxCollider>().bounds.size.y/2,transform.position.z),Quaternion.identity);
        spawned_ID++;
    }
    
    
    
    
    
    
    
    
    




}



