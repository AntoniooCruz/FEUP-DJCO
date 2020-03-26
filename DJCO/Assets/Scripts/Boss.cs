using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public float Health = 1f;
    }

    public EnemyStats stats = new EnemyStats();

    public float speed;
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public GameObject explosion;

    private float currentSpeed;

    public Slider healthBar;
    public float maxHeath;
    public float cumulativeDamage = 0;
    public bool canBeHit = true;
    private float targetManeuver;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0.0f);
        stats.Health *= 1 + (0.2f * WaveSpawner.instance.waveLoopingStage);
        StartCoroutine(Evade());
        healthBar.gameObject.SetActive(true);
        healthBar.maxValue = stats.Health;
        maxHeath = stats.Health;
    }

    // **** Movement **** // 

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

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2.5f);
        currentSpeed = 0;
    }

    void Update()
    {
        healthBar.value = stats.Health;
    }


    void FixedUpdate()
    {

        float newManeuver = Mathf.MoveTowards(rb.velocity.y, targetManeuver, Time.deltaTime * smoothing);

        currentSpeed = rb.velocity.x - rb.velocity.x * 0.01f;

        rb.velocity = new Vector3(currentSpeed, newManeuver, 0.0f);
        rb.position = new Vector3
        (
            rb.position.x,
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }

    public void resetCumulativeDamage() {
        cumulativeDamage = 0;
    }


    // **** Collisions **** // 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            other.GetComponentInParent<Player>().TakeDamage(50 + 50 * 0.1f * WaveSpawner.instance.waveLoopingStage);
        }

    }

    // **** Health **** // 

    public void DamageBoss(float damage)
    {
        if(!canBeHit && !this.GetComponentInChildren<DrEggmanBoss>().gotHit)
            return;

        stats.Health -= damage;
        cumulativeDamage += damage;
        Debug.Log("This boss just took " + damage + " damage!!" + stats.Health);
        if (stats.Health <= 0)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            healthBar.gameObject.SetActive(false);
            GameController.GetInstance().KillBoss(this);
        }
    }

}
