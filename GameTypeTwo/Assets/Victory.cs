using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject victory;

    public void OnTriggerEnter2D(Collider2D x)
    {
        Debug.Log("?");
        if(x.gameObject.tag == "Player")
        {
            victory.SetActive(true);
        }
    }
}
