using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerJump : MonoBehaviour
{

    private Rigidbody2D rb;
    public float JumpForce = 10f;
    private float FallForce = -1;
    private Vector2 gravityvector;

    //capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundcheck;

    private bool watercheck;
    private string _waterTag = "Water";

  


    // Start is called before the first frame update
    void Start()
    {
        gravityvector = new Vector2(0f, rb.velocity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundcheck = Physics2D.OverlapCapsule( feetCollider.position,new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);


        if (Input.GetKeyDown(KeyCode.Space) && _groundcheck )
        {
            rb.velocity =  new Vector2(rb.velocity.x , JumpForce);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += gravityvector * (FallForce * Time.deltaTime);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
