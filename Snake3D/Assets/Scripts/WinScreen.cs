using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

    public Text winner;

    private bool p1;
    private bool p2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (p1)
        {
            winner.text = "Player 1 Win!";
        }

        if (p2)
        {
            winner.text = "Player 2 Win!";
        }
	}
}
