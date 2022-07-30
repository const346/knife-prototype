using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    public void Jump()
    {
        body.velocity = Vector3.zero;
        body.angularVelocity = 0;

        var force = Quaternion.AngleAxis(-10, Vector3.forward) * Vector3.up * 350;

        body.AddForce(force);
        body.AddTorque(-20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var destructible = collision.gameObject.GetComponentInParent<Destructible>();
        if (destructible)
        {
            destructible.Destruct();
        }
    }
}
