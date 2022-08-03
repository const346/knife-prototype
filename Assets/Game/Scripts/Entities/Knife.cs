using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 320;
    [SerializeField]
    private float jumpAngle = -10;
    [SerializeField]
    private float maxAngV = 560;

    private Rigidbody2D body;

    private float targetAngle = -90;
    private bool isJumped;
    private bool isBladeStick;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        BladeStick();
    }

    public void Jump()
    {
        if (IsBladeRight() && (!isJumped || isBladeStick))
        {
            isBladeStick = false;
            isJumped = true;

            body.velocity = Vector3.zero;
            var direction = Quaternion.AngleAxis(jumpAngle, Vector3.forward) * Vector3.up;
            body.AddForce(direction  * jumpForce);

            Wave();
        }
    }

    private void FixedUpdate()
    {
        if (!isBladeStick || !IsBladeRight())
        {
            UpdateWave();
        }

        if (isJumped && !IsBladeRight())
        {
            isJumped = false;
        }
    }

    private void UpdateWave()
    {
        var distance = targetAngle - body.rotation;

        var k = -30f / Mathf.Clamp(distance, -90f, -120f);
        var n = Mathf.Lerp(2.2f, 0.4f, k);

        var angV = distance * n;
        angV = Mathf.Clamp(angV, maxAngV * -1f, -60);

        body.angularVelocity = angV;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsBladeRight() && collision.otherCollider.name == "Blade")
        {
            BladeStick();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var destructible = collider.gameObject.GetComponentInParent<Destructible>();
        destructible?.Destruct(transform.position.z);
    }

    private void Wave()
    {
        var distance = GetDistanceToTA();

        Debug.Log($"TryWave => angle: {body.rotation}, targetAngle: {targetAngle}, distance: {distance}");

        if (distance < 180)
        {
            targetAngle -= 360f;
        }
    }

    private void BladeStick()
    {
        isBladeStick = true;
        body.Sleep();
    }

    private float GetDistanceToTA()
    {
        return body.rotation - targetAngle;
    }

    private bool IsBladeRight()
    {
        var deltaA = Mathf.DeltaAngle(body.rotation, 0);
        return deltaA > -90 && deltaA < 90;
    }
}
