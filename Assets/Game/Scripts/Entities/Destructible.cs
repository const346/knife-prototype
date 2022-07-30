using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private Rigidbody leftBody;

    [SerializeField]
    private Rigidbody rightBody;

    [SerializeField]
    private Collider2D trigger;

    [SerializeField]
    private Vector3 rightForce = Vector3.forward * 40;

    [SerializeField]
    private Vector3 leftForce = Vector3.back * 40;

    public void Destruct()
    {
        if (leftBody)
        {
            leftBody.isKinematic = false;
            leftBody.AddForce(leftForce);
        }

        if (rightBody)
        {
            rightBody.isKinematic = false;
            rightBody.AddForce(rightForce);
        }

        trigger.enabled = false;
    }
}
