using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public DistanceJoint2D rope;
    RaycastHit2D hit;
    bool checker;
    public float distance = 100;
    public LayerMask mask;
    public LineRenderer line;
    Vector3 mousePos;
    void Start()
    {
        gameObject.GetComponent<LineRenderer>();
        rope.enabled = false;
        line.enabled = false;
    }

    void Update()
    {
        // Detect mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;


        // Shot rope on mouse position
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(transform.position, mousePos, distance, mask);
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
            if(hit == true && checker == true)
            {
                rope = gameObject.GetComponent<DistanceJoint2D>();
                rope.connectedAnchor = hit.point;
                checker = false;
            }

        }

        // Destroy rope
        else if (Input.GetMouseButtonDown(0))
        {
            rope.enabled = false;
            checker = true;
        }
    }
}
