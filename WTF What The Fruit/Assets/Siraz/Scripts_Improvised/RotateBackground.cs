using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateBackground : MonoBehaviour {

    public Material[] Backgrounds;

    public Toggle RotateBG;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Renderer>().material = Backgrounds[Random.Range(0,Backgrounds.Length-1)]; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(RotateBG.isOn)
        {
            transform.Rotate(0f, 10 * Time.deltaTime, 0f);
        }
	}
}
