using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject[,] _prefabs;
    private GameObject _tier1_0_1;
    private float _time;
    private float _interpolationPeriod = 4.0f;
    private int _tier =0;
    private int _spawnedID;

    void Start()
    {
        _prefabs = new GameObject[4,4];
        
        
        if(CompareTag("Ally") || CompareTag("Enemy"))
        {
            char temp='A';
            if (CompareTag("Enemy"))
                temp = 'B';
            
            _prefabs[0, 0] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));
            _prefabs[0, 1] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_1", typeof(GameObject));
            _prefabs[0, 2] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));

            _prefabs[1, 0] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));
            _prefabs[1, 1] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_1", typeof(GameObject));
            _prefabs[1, 2] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));

            _prefabs[2, 0] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));
            _prefabs[2, 1] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_1", typeof(GameObject));
            _prefabs[2, 2] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));

            _prefabs[3, 0] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));
            _prefabs[3, 1] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_1", typeof(GameObject));
            _prefabs[3, 2] = (GameObject)Resources.Load("Prefabs/Tier0_"+temp+"_0", typeof(GameObject));
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _interpolationPeriod)
        {
            _time = 0.0f;
            //Instantiate(_tier1_0_1,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            if (CompareTag("Enemy"))
            {
                spawn_A(true);
                spawn_B(true);
            }
        }
    }

    public void spawn_A(bool check)
    {
        if (check)
        {
            _spawnedID++;
            if (_tier == 0)
            { _prefabs[0, 0].GetComponent<Movement>().spawnedID = _spawnedID; Instantiate(_prefabs[0, 0], new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity);
    }else if (_tier == 1)
            Instantiate(_prefabs[1,0],new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        else if (_tier == 2)
            Instantiate(_prefabs[2,0],new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        else if (_tier == 3)
            Instantiate(_prefabs[3,0],new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        
        }
    }

    public void spawn_B(bool check)
    { 
        if (check)
        {
            _spawnedID++;
            if (_tier == 0)
                Instantiate(_prefabs[0, 1],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else if (_tier == 1)
                Instantiate(_prefabs[1, 1],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else if (_tier == 2)
                Instantiate(_prefabs[2, 1],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else if (_tier == 3)
                Instantiate(_prefabs[3, 1],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        }
    }
    public void spawn_C(bool check)
    {
        if (check)
        {
            _spawnedID++;
            if (_tier == 0)
                Instantiate(_prefabs[0, 2],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else if (_tier == 1)
                Instantiate(_prefabs[1, 2],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else if (_tier == 2)
                Instantiate(_prefabs[2, 2],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else if (_tier == 3)
                Instantiate(_prefabs[3, 2],
                    new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        }
    }
}
