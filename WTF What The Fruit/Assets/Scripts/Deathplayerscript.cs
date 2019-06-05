using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deathplayerscript : MonoBehaviour {

    public TextMeshProUGUI deathText;

    // Use this for initialization

    void Awake () {
        deathText = GetComponent<TextMeshProUGUI>();
        
	}
    private void Start()
    {
        deathText.text = "WTF " + PlayerPrefs.GetString("New_Name","Nameless human") + " you died!";
    }

    // Update is called once per frame
    void Update () {
       
    }
}
