using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float distance;
    [SerializeField] private float howClose;
    [SerializeField] private Transform head,barrel_left,barrel_right;
    [SerializeField] private GameObject projectile;

    [SerializeField] private float shootForce = 300f;
    [SerializeField] private float fireRate, nextFire;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(_player.position,transform.position);
        if (distance <= howClose)
        {
            head.LookAt(_player);
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1f/fireRate;
                shoot();
            }
            
        }
    }

    void shoot()
    {
        GameObject clone_r = Instantiate(projectile, barrel_left.position,head.rotation);
        GameObject clone_l = Instantiate(projectile, barrel_right.position, head.rotation);
        clone_r.GetComponent<Rigidbody>().AddForce(head.forward * shootForce);
        clone_l.GetComponent<Rigidbody>().AddForce(head.forward * shootForce);
        Destroy(clone_r, 10);
        Destroy(clone_l, 10);
    }

   
}
