using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEggs : MonoBehaviour
{
    // Start is called before the first frame update
    private float cooldown;
    public float start;
    public GameObject projectile;
    public GameObject snail;

    void Start()
    {
        cooldown = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            cooldown = start;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
