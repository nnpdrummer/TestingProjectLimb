using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject phoneCanvas;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown("e"))
        {
            if (phoneCanvas.activeSelf) { phoneCanvas.SetActive(false); }
            else { phoneCanvas.SetActive(true); }
        }
	}
}
