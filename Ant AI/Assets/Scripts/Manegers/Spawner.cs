using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform foodPrefab;
    public Transform beetlePrefab;
    public int numOfBeetle;
    public int numOfFood;
    public float spawnRadius;

	// Use this for initialization
	void Start () {
        spawn(beetlePrefab, numOfBeetle);
        spawn(foodPrefab, numOfFood);
	}
	
	// Update is called once per frame
	void spawn (Transform _prefab, int length) {
        for (int i = 0; i < length; i++)
        {
            Instantiate(_prefab, 
                new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0), 
                Quaternion.identity);
        }
	}
}
