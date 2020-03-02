using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rapidFire;
    public GameObject shotgunShot;
    public GameObject[] emeralds = new GameObject[7];
    public Transform spawner;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("createRandomPower", 2.0f, 2.0f);
    }

    void createRandomPower()
    {
        int power = Random.Range(0, 3);
        switch (power)
        {
            case 0: GameObject pwr0 = Instantiate(rapidFire, new Vector3(spawner.transform.position.x, Random.Range(-4f, 4f)), spawner.rotation);
                break;
            case 1: GameObject pwr1 = Instantiate(shotgunShot, new Vector3(spawner.transform.position.x, Random.Range(-4f, 4f)), spawner.rotation);
                break;
            case 2: int emerald = Random.Range(0, 7);
                GameObject pwr2 = Instantiate(emeralds[emerald], new Vector3(spawner.transform.position.x, Random.Range(-4f, 4f)), spawner.rotation);
                break;
            default:
                break;
        }
    }
}