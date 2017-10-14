using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] private GameObject bullet;

    public void Shoot()
    {
        Instantiate(bullet, transform.position, FindObjectOfType<PlayerController>().transform.rotation);
    }
}
