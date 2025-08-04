using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage: MonoBehaviour
{
    private BarrierHealths BarrierHealth;
    public int damage=2;

    public float timer = 3;
    private float current = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Touch");
        if (other.gameObject.tag == "Barrier") 
        {
            Debug.Log("Attack");
            other.gameObject.GetComponent<BarrierHealths>().TakeDamage(damage);
        
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Barrier")
        {
            current -= Time.deltaTime;
            if (current < 0)
            {
                collision.gameObject.GetComponent<BarrierHealths>().TakeDamage(damage);
                current = timer;
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("death");
        Destroy(gameObject);
    }
}
