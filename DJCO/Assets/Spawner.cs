using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rapidFire;
    public GameObject shotgunShot;
    public Transform spawner;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("createRandomPower", 5.0f, 5.0f);
    }

    void createRandomPower()
    {
        int power = Random.Range(0, 2);
        switch (power)
        {
            case 0: GameObject pwr0 = Instantiate(rapidFire, new Vector3(spawner.transform.position.x, Random.Range(-4f, 4f)), spawner.rotation);
                break;
            case 1: GameObject pwr1 = Instantiate(shotgunShot, new Vector3(spawner.transform.position.x, Random.Range(-4f, 4f)), spawner.rotation);
                break;
            default:
                break;
        }
    }
}