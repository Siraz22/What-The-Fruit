using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollider : MonoBehaviour {
	//BoxCollider2D fruitBox;
	public GameObject splashPS;
	public GameObject DropPS;
	// Use this for initialization
	void Start () {
		//fruitBox = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if(col.gameObject.tag == "Player")
		{
			Instantiate (splashPS, transform.position, transform.rotation);
			GameObject ps =  (GameObject)Instantiate (DropPS, col.gameObject.transform.position, col.gameObject.transform.rotation);
			GameObject superParent;
			superParent = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
			Destroy (superParent, 0f);

		}
	}
}
