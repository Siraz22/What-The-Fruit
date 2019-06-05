using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
  

  

    [Header("Game Elements")]
    public GameObject GameElementUI;
    public GameObject GameElement;
    public GameObject SpawnManager;

    ControlForPlayer controlScript;

    public void EnableControlAndGame()
    {
        Debug.Log("Tap Pressed");

        //Setting up the player controls
        controlScript.enabled = true;

        //Setting up the other game elements
        GameElement.SetActive(true);
        GameElementUI.SetActive(true);


        //Set up Spawnner Mechanics because when Spawnner is kept in Ingame object it's set to inactive and can't be set as a reference 
        //by the multiplier script which changes the max and min platform number
        SpawnManager.GetComponent<Spawner_new>().enabled = true;


        //Throw the main Menu items in effect
        //MainMenuElements.SetActive(false);
        //MainMenuElementsUI.SetActive(false);

    }

	// Use this for initialization
	void Start ()
    {
       
        controlScript = GameObject.FindObjectOfType<ControlForPlayer>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
