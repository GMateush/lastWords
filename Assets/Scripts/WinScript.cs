using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown("return"))
        {
            Application.LoadLevel("Game");
        }
        else if(Input.GetKeyDown("escape"))
        {
            Application.LoadLevel("Start Menu");
        }
	}
}
