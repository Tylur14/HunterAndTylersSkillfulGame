using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Player_Motor : MonoBehaviour
{
    [SerializeField] private float _xInput;
    public float _yInput;
    [SerializeField] private float _moveSpeed;
    

    [Header("Gravity Settings")] 
    [SerializeField] private float gravNormal;      // How gravity should affect the player in most circumstances
    [SerializeField] private float gravHoldJump;    // How gravity affects the player while jumping
    [HideInInspector] public Rigidbody2D rb;

    [Header("Jump Settings")] 
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpsRemaining;
    [SerializeField] private int _maxJumps;

    [Header("MotorStatus")] 
    // public bool isDead; // Need to implement this into the Player class
    public bool isCrouching;
    
    
    [Header("Temp SFX holder")]
    public AudioSource walkSfx;
    public AudioSource jumpSfx;
    
    private Collider2D col;
    
    // Init refs
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Input call
    private void Update()
    {
        
        // Get horizontal input
        _xInput = Input.GetAxisRaw("Horizontal");
        
        // Handle crouching input
        if (Input.GetButton("Fire3") && IsGrounded())
            isCrouching = true;
        else isCrouching = false;
        
        // Handle jump input
        if (Input.GetButtonDown("Jump"))   // Get button down, call Jump
            Jump();
        else if(Input.GetButtonUp("Jump") || rb.velocity.y <= 0.0f) // Get button up, handle gravity
            rb.gravityScale = gravNormal;
        
        /*
        if(rb.velocity.x != 0.0f && rb.velocity.y == 0.0f)
            print("Player is walking on ground!"); 
        */
    }

    // Physics calls
    private void FixedUpdate()
    {
        Vector2 vel = new Vector2();
        vel.x += _xInput * _moveSpeed;

        if(!isCrouching)
            Move(vel);
    }

    void Move(Vector2 incMovement)
    {
        rb.AddForce(incMovement,ForceMode2D.Impulse);
    }

    void Jump()
    {
        if (IsGrounded())
            _jumpsRemaining = _maxJumps;
        if (_jumpsRemaining > 0)
        {
            // jumpSfx.Play(); // Include player jumping sfx?
            _jumpsRemaining--;
            rb.gravityScale = gravHoldJump;
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);    
            print("Jumped?");
        }
        
    }

    bool IsGrounded()
    {
        //https://www.youtube.com/watch?v=c3iEl5AwUF8
        float rayLength = 0.04f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, rayLength, groundMask);
        Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0), Vector2.down * (col.bounds.extents.y + rayLength), Color.green);
        Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0), Vector2.down * (col.bounds.extents.y + rayLength), Color.green);
        Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, col.bounds.extents.y + rayLength), Vector2.right * (col.bounds.extents.x * 2f), Color.green);

        return raycastHit.collider != null;
    }
}
