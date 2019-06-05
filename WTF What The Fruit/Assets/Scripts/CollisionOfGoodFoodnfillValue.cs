using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Spine;
using Spine.Unity;
public class CollisionOfGoodFoodnfillValue : MonoBehaviour

{
    public static CollisionOfGoodFoodnfillValue Instance { get; set; }

    Audio AudioManager_Script;
    Multiplier multiplier_Script;
    Score Score_Script;
	SpawnPopUp playerSpawnPopUpscript;
	HealthAndLock HealthbarScript;
    ShopManager shopmanagerscript;

   

	public GameObject PS;
	public GameObject BoomPS;

    public int CashReward;
    private int prev_multiplier = 1;

    // Use this for initialization
    void Awake ()
    {
        shopmanagerscript = GameObject.FindObjectOfType<ShopManager>();
        Instance = this;
        AudioManager_Script = GameObject.FindObjectOfType<Audio>();
        multiplier_Script = GameObject.FindObjectOfType<Multiplier>();
        Score_Script = GameObject.FindObjectOfType<Score>();
        HealthbarScript = GameObject.FindObjectOfType<HealthAndLock>();
        playerSpawnPopUpscript = GameObject.FindGameObjectWithTag("Player_Spine").GetComponent<SpawnPopUp>();
    }
	
	// Update is called once per frame
	
    void Check()
    {
        if (gameObject.tag == "Good_Food_Normal")
        {
			//	---------------------------------------------- Rewarding and sound 	------------------------------
			AudioManager_Script.AteGoodFood();
			int x = multiplier_Script.multiplier_value;
            playerSpawnPopUpscript.SpawnPopUPfunction(CashReward+x);
            playerSpawnPopUpscript.DiamondsPopUpfunction(CashReward+x);
            // idhar text ko change krnsa hai
            Score.Instance.Current_Score += CashReward + x;
            shopmanagerscript.EarningDiamonds += CashReward + x;


            HealthbarScript.Good_Food_Fill(20);
			

			//	---------------------------------------------- Effects 	----------------------------------------------
			GameObject SuperParent = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
			var rot = Quaternion.identity;
			//rot.x = -90;
			GameObject PS_temp = (GameObject)Instantiate(PS,transform.position , rot);
			Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject, 0.2f);
			//rot.x = -90;

		}

        else if (gameObject.tag == "Bad_Food_Normal")
        {
			EZCameraShake.CameraShaker.Instance.ShakeOnce(8f,10f,0.1f,1f);
			AudioManager_Script.AteBadFood();
            Handheld.Vibrate();
            HealthbarScript.Bad_Food_Eaten();

            GameObject SuperParent = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

            var rot = Quaternion.identity;

            GameObject PS_temp = (GameObject)Instantiate(BoomPS, transform.position, rot);
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject, 0.2f);
            
        }



    }
    void OnTriggerEnter2D(Collider2D colinfo)
    {

        if (colinfo.gameObject.tag == "Player")
        {
            
  			playerSpawnPopUpscript.StartCoroutine("BigBite");
            Check();
        }
        else if (colinfo.gameObject.tag == "End_Point")
        {
            
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }

}
