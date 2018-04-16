using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    GameObject snake;
    FoodSpawner foodScript;
    GameObject foodManager;
    [SerializeField] AudioClip eat;
    [SerializeField] ParticleSystem spawnParticles;

    private void Awake()
    {
        snake = GameObject.FindGameObjectWithTag("Player");
        foodManager = GameObject.Find("FoodController");
        foodScript = foodManager.GetComponent<FoodSpawner>();
        if (spawnParticles)
        {
            ParticleSystem partSys = Instantiate(spawnParticles, transform.position, transform.rotation);
            partSys.transform.parent = transform;
        }
    }

    private void Update()
    {
        if (transform.position == snake.GetComponent<SnakeController>().Entities.First.Value.transform.position)
        {
            snake.GetComponent<SnakeController>().Expand();
            foodScript.isSpawned = false;
            AudioSource.PlayClipAtPoint(eat,gameObject.transform.position);
            Destroy(gameObject);
        }
        
    }
}
