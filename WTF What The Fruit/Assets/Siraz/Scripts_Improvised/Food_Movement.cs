using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
public class Food_Movement : MonoBehaviour
{
    Audio AudioManager_Script;
    Multiplier multiplier_Script;
    Score Score_Script;
    HealthAndLock HealthbarScript;
    public float Speed=1;
	SkeletonAnimation skel;
    public float timeScale;
    bool speedbadhao = false;
    public int currentMultiplier = 1;

    void Awake()
	{
		skel = GetComponent<SkeletonAnimation>();
        AudioManager_Script = GameObject.FindObjectOfType<Audio>();
        multiplier_Script = GameObject.FindObjectOfType<Multiplier>();
        Score_Script = GameObject.FindObjectOfType<Score>();
        HealthbarScript = GameObject.FindObjectOfType<HealthAndLock>();

        Speed = multiplier_Script.multiplier_value;
	}
    private void Start()
    {

        


    }

    // Update is called once per frame
    void Update () 
	{
       
        int y = multiplier_Script.multiplier_value;
        

        //if Multiplier changes  this is for etecting multipuier change
        if (y > multiplier_Script.prev_multiplier)
        {
            multiplier_Script.prev_multiplier = y;
         
        }

        // transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }
    public void SetSpeed(int currentMultiplier)
    {
        
        if(currentMultiplier > 999)
        {

            timeScale = skel.timeScale + 0.4f * (currentMultiplier - 1);  // animation increment value is 1
            skel.timeScale = timeScale;
        }
    
    }
}
