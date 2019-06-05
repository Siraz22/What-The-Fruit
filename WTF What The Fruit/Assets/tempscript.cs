using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearAchievementsPrefs()
    {
        PlayerPrefs.DeleteKey("AchievementsDone");
    }
}
