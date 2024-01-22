using UnityEngine;

public class Attack_Meelie : MonoBehaviour
{
    private float _time = 0.0f;
    public float interpolationPeriod;
    private bool isAttacking = false;
    private Rigidbody _rb;
    public int dmg;
    private GameObject target;
    private bool isTarget = false;

    public void Deal_Damage()
    {
        
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
 
        if (_time >= interpolationPeriod) {
            _time = 0.0f;
            if(isAttacking)
                if (target == null)
                    isAttacking = false;
                else
                {
                    if (target.TryGetComponent<Health>(out Health healthCompoment))
                    {
                        healthCompoment.TakeDamage(dmg);
                    }
                }
           

        }  
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (CompareTag("Ally")) {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Base_B"))
            {
                target = collision.gameObject;
                isAttacking = true;
            }
            _time = 0f;
        }
        if (CompareTag("Enemy")) {
            if (collision.gameObject.CompareTag("Ally")|| collision.gameObject.CompareTag("Base_A"))
            {
                target = collision.gameObject;
                isAttacking = true;
            }
            _time = 0f;
        }
    }
    
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.Equals(target))
        {
            isAttacking =false;
        }
    }
    
    
}
