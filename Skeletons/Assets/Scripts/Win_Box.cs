using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Win_Box : MonoBehaviour
{

    private float timer = 0.0f;
    private bool restart = false;

    // called when this GameObject collides with GameObject2.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boss")
        {
            Debug.Log("Player collided with " + col.name);
            restart = true;
            timer = 0.0f;
        }
    }

    void FixedUpdate()
    {
        if (restart == true)
        {
            timer = timer + Time.deltaTime;
            if (timer > 0.25f)
            {
                gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                restart = false;
            }
        }
    }
}