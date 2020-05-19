using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromasplosion : MonoBehaviour
{

    public Bullet bulletType;
    public int rounds = 10;
    public int shotsPerRound = 20;
    public float fireCoolDown;
    float timeSinceLastFire;
    int round = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire > fireCoolDown)
        {
            Fire();
            round++;
            timeSinceLastFire = 0;
        }
        if (round >= rounds)
        {
            Destroy(gameObject);

        }
    }

    void Fire()
    {
        for (int i = 0; i < shotsPerRound; i++)
        {
            Instantiate(bulletType, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + (360 / shotsPerRound) * i));
        }
    }
}
