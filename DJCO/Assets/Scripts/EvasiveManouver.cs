using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManouver : MonoBehaviour
{

    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = rb.velocity.x;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.y);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {

        float newManeuver = Mathf.MoveTowards(rb.velocity.y, targetManeuver, Time.deltaTime * smoothing);
        
        currentSpeed = rb.velocity.x;
        rb.velocity = new Vector3(currentSpeed, newManeuver, 0.0f);
        rb.position = new Vector3
        (
            rb.position.x,
            Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        // rb.rotation = Quaternion.Euler (rb.velocity.y * -tilt, 0.0f, 0.0f);
    }
}
