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
    DistanceJoint2D joint;
    Vector3 grapPos;
    RaycastHit2D hit;
    public float distance = 10;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grapPos.z = 0;

            hit = Physics2D.Raycast(transform.position, grapPos - transform.position, distance, mask);
            if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            joint.enabled = false;
        }
    }
}
