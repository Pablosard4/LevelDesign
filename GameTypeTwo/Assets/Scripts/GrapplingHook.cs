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
    public GameObject cursor;

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
        cursor.transform.position = mousePos;

        // Shot rope on mouse position
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 hookDirection = mousePos - transform.position;
            hit = Physics2D.Raycast(transform.position, hookDirection, distance, mask);
            Debug.DrawLine(transform.position, hookDirection, Color.cyan);
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
