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

    public void Destruct(float knifeDepth)
    {
        if (leftBody)
        {
            leftBody.isKinematic = false;

            var point = leftBody.transform.position;
            point.z = knifeDepth;

            leftBody.AddForceAtPosition(leftForce, point);
        }

        if (rightBody)
        {
            rightBody.isKinematic = false;

            var point = rightBody.transform.position;
            point.z = knifeDepth;

            rightBody.AddForceAtPosition(rightForce, point);
        }

        trigger.enabled = false;
    }
}
