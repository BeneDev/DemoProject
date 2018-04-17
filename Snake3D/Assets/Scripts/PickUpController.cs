using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    GameObject[] snakes = new GameObject[2];
    FoodSpawner foodScript;
    GameObject foodManager;
    [SerializeField] AudioClip eat;
    [SerializeField] ParticleSystem spawnParticles;

    private void Awake()
    {
        snakes[0] = GameObject.FindGameObjectWithTag("Player");
        snakes[1] = GameObject.FindGameObjectWithTag("Player2");
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
        foreach(GameObject snake in snakes)
        {
            if (snake)
            {
                if (transform.position == snake.GetComponent<SnakeController>().Entities.First.Value.transform.position)
                {
                    snake.GetComponent<SnakeController>().Expand();
                    foodScript.isSpawned = false;
                    AudioSource.PlayClipAtPoint(eat, gameObject.transform.position);
                    Destroy(gameObject);
                }
            }
        }
    }
}
