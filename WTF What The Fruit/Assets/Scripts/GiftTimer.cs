using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class GiftTimer : MonoBehaviour
{
    public GameObject RewardPanel;
	public Button giftButton;
	double intervalInsec=1800;
	ulong lastChestOpen;
    public GameObject[] thingsToActivate;
    public TextMeshProUGUI gifttimertext;
    private void Awake()
    {
        giftButton = GetComponent<Button>();
    }
    void Start()
	{
        if (PlayerPrefs.HasKey("LastGiftOpenString")) 
		lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastGiftOpenString")) ;


		if(!IsGiftReady())
		{
			giftButton.interactable = false;
		}
	}


	void Update()
	{
		if(!giftButton.IsInteractable())
		{
			if(IsGiftReady())
			{
               
				giftButton.interactable = true;
                return;
			}
            

		}
	}
	public void GiftClick()
	{

		lastChestOpen = (ulong)DateTime.Now.Ticks;
		PlayerPrefs.SetString("LastGiftOpenString", lastChestOpen.ToString());
        giftButton.interactable = false;
        RewardPanel.SetActive(true);
        RewardPanel.transform.GetChild(0).gameObject.SetActive(false); //Back button false here
        foreach(GameObject go in thingsToActivate)
        {
            go.SetActive(true);
        }
        
	
	}
	public bool IsGiftReady()
	{
		ulong diff = (ulong)DateTime.Now.Ticks  - lastChestOpen;
		ulong deltaTicksPerMillisec = diff / TimeSpan.TicksPerMillisecond;
		double secondslLeft = (intervalInsec*1000 - deltaTicksPerMillisec)/1000;

        string r = "";
        r += ((int)secondslLeft / 60).ToString("00") + "m";
        r += ((int)secondslLeft % 60).ToString("00") + "s";
        gifttimertext.text = r;
		if(secondslLeft<=0)
		{
            gifttimertext.text = "Ready!!";
            return true;
		}
		return false;

	}
}
