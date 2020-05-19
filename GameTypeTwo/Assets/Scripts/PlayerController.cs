using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce = 2;
    private float jumpTimeCounter;
    public float jumpTime;
    float move;
    bool isJumping;
    public GameObject Sword;
    float attackTime = 1;
    float attackTimeCounter;
    bool isAtacking = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if (Input.GetKey(KeyCode.X))
        {
            isAtacking = true;
            while(attackTimeCounter > 0)
            {
                Sword.SetActive(true);
                attackTimeCounter -= Time.deltaTime;
                Debug.Log(attackTimeCounter);
            }
            isAtacking = false;
        }
        if (isAtacking)
        {
            Sword.SetActive(false);
            attackTimeCounter = attackTime;
        }

        if (move < 0) { transform.eulerAngles = new Vector3(0, 0, 0); }
        else { transform.eulerAngles = new Vector3(0, 180, 0); }
    }
}
