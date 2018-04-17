using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int winningPlayer = -1;

	// Use this for initialization
	void Awake () {
		if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(winningPlayer > -1 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            SceneManager.LoadScene(2);
        }
	}
}
