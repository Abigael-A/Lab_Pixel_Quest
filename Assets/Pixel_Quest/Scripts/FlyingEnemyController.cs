using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int patrolIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
