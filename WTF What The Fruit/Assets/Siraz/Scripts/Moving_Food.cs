using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Food : MonoBehaviour {

	//public Game_Stats StatScript;

	//private int StatScore = StatScript.Score;
	private float Speed = 3f;
	public BoxCollider2D Endpoint;
	public BoxCollider2D Player;

	void OnTriggerEnter2D(Collider2D colinfo)
	{
		//Debug.Log ("Found a collision");
		if (colinfo.gameObject.tag == "Player") 
		{
		//	Debug.Log ("Plus one point!");
			Destroy (gameObject);

		}
		else if(colinfo.gameObject.tag == "End_Point")
			Destroy(gameObject);
	}

	void Awake()
	{
		Endpoint = GameObject.FindGameObjectWithTag ("End_Point").GetComponent<BoxCollider2D>();
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update () 
	{
		//if(Endpoint== null || Player== null)
			
		transform.Translate (Vector2.left*Time.deltaTime*Speed);
	}
}
