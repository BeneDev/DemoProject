using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    [SerializeField] Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.winningPlayer == -1)
        {
            text.text = "Game Over.";
        }
        else
        {
            text.text = "Player " + GameManager.Instance.winningPlayer +  " won!";
        }
	}
}
