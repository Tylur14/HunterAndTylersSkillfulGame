using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animator : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        var x = rb.velocity.x; // get Rigidbody2D horizontal velocity
        var y = rb.velocity.y; // get Rigidbody2D vertical velocity
        
        var scale = transform.localScale;
        if (x < -0.05f) // cant flip render because then I'd have to change the pivot for EVERY player sprite...
        {
            x *= -1; // flip the rb variable (just handles better in the anim bool setter)
            scale.x = -1; // flip the scale
        }
        else if (x > 0.05f) // just to check if player should be facing 'forward'
            scale.x = 1; // flip scale

        if (y < 0)
            y *= -1;
        
        transform.localScale = scale; // set scale
        
        anim.SetBool("isMoving",x > 0.05f);
        if (y < -0.05f || y > 0.05f)
        {
            if (anim.GetBool("isFalling") == false)
            {
                anim.SetBool("isFalling",true);
                anim.SetTrigger("Fall");
            }
        }
        else
            anim.SetBool("isFalling",false);
        
    }
}
