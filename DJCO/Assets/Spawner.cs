using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rapidFire;
    public Transform spawner;
    private float powerUpTimer = 0.0f;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("createRapidFire",10.0f,10.0f);
    }

    void createRapidFire()
    {
        GameObject go = Instantiate(rapidFire, new Vector3(spawner.transform.position.x, Random.Range(-4f, 4f)), spawner.rotation);
    }
}
