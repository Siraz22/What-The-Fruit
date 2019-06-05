using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Multiplier : MonoBehaviour
{

    public GameObject[] Comments;
    public GameObject multipliercelebrationTXT;
    public GameObject BGshine;

    public static Multiplier Instance{get;set;}

    Spawner_new SpawnScript;

    private bool ShowMultiplier = false;
	public int prev_multiplier=1;

    public TextMeshProUGUI Multiplier_ValueTEXT;

    public int multiplier_value =1;
    public bool More_Platform;

    public GameObject[] Platforms_Temp;

    private void Start()
    {
		Instance=this;
        More_Platform = false;
        Multiplier_ValueTEXT.gameObject.SetActive(false);
        SpawnScript = GameObject.FindObjectOfType<Spawner_new>();
    }

    public void ClosePinkandGreenatdeath()
    {
        if(More_Platform)
        {
            multiplier_value = 1;
            More_Platform = false;

            foreach (GameObject platform_diable in Platforms_Temp)
            {
                platform_diable.SetActive(false);
                
            }
        }

    }

    void Update ()
    {
        if(ShowMultiplier == false)
        {
            if (multiplier_value > 1)
            {
                ShowMultiplier = true;
                Multiplier_ValueTEXT.gameObject.SetActive(true);
            }
        }



        //PLATFORM RELATED
        if (multiplier_value < 2)
        {

            SpawnScript.minPlatformNo = 1;
            SpawnScript.maxPlatformNo = 3;

            More_Platform = false;
        }
        if (multiplier_value >= 2)
        {
            
            SpawnScript.minPlatformNo = 0;
            SpawnScript.maxPlatformNo = 4;

            More_Platform = true;  
        }

        if (More_Platform)
        {
            foreach (GameObject platform_enable in Platforms_Temp)
            {
                platform_enable.SetActive(true);
            }
        }

        int x = multiplier_value;

        if (x > prev_multiplier)
		{
            // ----------------      ----------------                   MULTIPLIER INCREASED      ----------------                     ----------------
            // Pop up celebration
            // Speed = Speed + 5 / 3f;

            StartCoroutine("CelebrationPause");

            //CelebrationCommentsAndMultiplier celebrationScript = FindObjectOfType<CelebrationCommentsAndMultiplier>().GetComponent<CelebrationCommentsAndMultiplier>();

            Comments[Random.Range(0,8)].SetActive(true);

            if (multiplier_value == 3)
			{
				multipliercelebrationTXT.GetComponent<TextMeshProUGUI>().color = Color.black;
			}
			else
            {
				multipliercelebrationTXT.GetComponent<TextMeshProUGUI>().color = Color.red;
			}

            multipliercelebrationTXT.GetComponent<TextMeshProUGUI>().text = "X" + multiplier_value.ToString();
			multipliercelebrationTXT.SetActive(true);

			BGshine.SetActive(true);
			Audio.Instance.Celebration();

			//----------------     ----------------CELEBRATION ----------------      ----------------                  



			//prev_multiplier = x;
			
		
		}
        
        Multiplier_ValueTEXT.text = "x"+ multiplier_value.ToString();
    }

	public void ResetMultiplier()
	{
		Spawnner.Instance.Speed = 2;
		multiplier_value =1;
		prev_multiplier =1;
		HealthAndLock.Instance.Current_HealthLevel = 1;
		HealthAndLock.Instance.HealthFillImg.fillAmount = 1/100f;
	}

	IEnumerator CelebrationPause()
	{
		Time.timeScale = 0.2f;
		yield return new WaitForSecondsRealtime(1.3f);
		Time.timeScale =1f;
	}
}
