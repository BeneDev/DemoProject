using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    public GameObject FoodPrefab;

    public Transform topBorder;
    public Transform botBorder;
    public Transform leftBorder;
    public Transform rightBorder;
    [SerializeField] float spawnDelay = 3f;
    float spawnTimer;
    
    public bool isSpawned;
	
	// Update is called once per frame
	void Update () {
        if (!isSpawned)
        {
            Spawn();
        }
        //Debug.Log(targetTime);
	}

    void Spawn()
    {
        if (spawnTimer <= 0)
        {

        int z = (int)Random.Range(botBorder.position.z,topBorder.position.z);

        int x = (int)Random.Range(leftBorder.position.x, rightBorder.position.x);

        Instantiate(FoodPrefab, new Vector3(x, 0, z), Quaternion.identity);
        isSpawned = true;
        
        }
        if(isSpawned == true)
        {
            spawnTimer = spawnDelay;
        }
        spawnTimer -= Time.deltaTime;
    }
}
