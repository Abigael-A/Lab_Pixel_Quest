using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        if (xInput > 0 && xInput <0)
        {
            _animator.SetBool("walk sideways", true);
            _animator.SetBool("Horizontal arrow keys", true);
        }
        else
        {
            _animator.SetBool("walking sideways", false);
            _animator.SetBool("Horizontal arrow keys", false);
        }

        if (yInput > 0 )
        {
            _animator.SetBool("walk up", true );
            _animator.SetBool("up arrow pressed", true);

        }
        else
        {
            _animator.SetBool("walk up", false);
            _animator.SetBool("up arrow pressed", false);
        }

        if (yInput < 0)
        {
            _animator.SetBool("walk down", true);
            _animator.SetBool("down arrow pressed", true);

        }
        else
        {
            _animator.SetBool("walk down", false);
            _animator.SetBool("down arrow pressed", false);
        }
    }
}
