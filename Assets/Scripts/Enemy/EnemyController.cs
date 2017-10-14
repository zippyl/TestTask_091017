using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private float timeToSpawn = 5f;
    [SerializeField] private GameObject[] _spawns;
    [SerializeField] private GameObject _halk;

	// Use this for initialization
	void Start () {
        _spawns = GameObject.FindGameObjectsWithTag("Respawn");
        InvokeRepeating("SpawnHalk", timeToSpawn, timeToSpawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnHalk()
    {
        Instantiate(_halk, _spawns[Random.Range(0, _spawns.Length)].transform.position, Quaternion.identity);
    }
}
