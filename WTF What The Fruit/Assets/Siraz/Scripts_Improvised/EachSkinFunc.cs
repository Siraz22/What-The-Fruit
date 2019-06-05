using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class EachSkinFunc : MonoBehaviour
{

    ChangeSkinInGame ChangeSkinScript;
    ShopManager Shop;

    private string NewBuySkin = null;

    public TextMeshProUGUI BuySetTEXTofCurrentSkin;

    public void ShowButton()
    {
        
        Shop.CurrentButton_clicked.gameObject.SetActive(true);

        if ( PlayerPrefs.GetInt("Diamonds") >= Shop.diamond_cost )
        {
            Debug.Log("Can Buy");
            
            Shop.CurrentButton_clicked.interactable = true;
        }
        else
        {
            Debug.Log("Can't Buy");
            Shop.CurrentButton_clicked.interactable = false;
        }
    }

    public void BuyThisSkin()
    {
        if (BuySetTEXTofCurrentSkin.text == "BUY")
        {
            Shop.SkinBuySplit[Shop.IDSelected] = '1';

            //ForAchievements
            PlayerPrefs.SetInt("SkinCounter", PlayerPrefs.GetInt("SkinCounter") + 1);
            
            //Error
            //Debug.Log("The String BuyState after buying is " + Shop.SkinBuySplit.ToString());

            for (var i = 0; i < 23; i++)
            {
                NewBuySkin = NewBuySkin + Shop.SkinBuySplit[i].ToString();
            }

            //This string perfectly stores the result
            //Debug.Log(NewBuySkin);

            Shop.SkinBuy = NewBuySkin;

            PlayerPrefs.SetString("SkinBuy", NewBuySkin);

            //Give explicitly, Diamond the value stored in playerprefs, reduce it and then set that new value as the new diamond prefab value

            //TO Make sure now that the skin forever shows it's skin colors, we reset every color back to full white and 255 aplha
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255,255);

            for (int j = 0; j < transform.childCount; j++)
            {
                transform.GetChild(j).gameObject.SetActive(false);
            }

            Shop.Diamond = PlayerPrefs.GetInt("Diamonds");
            Shop.Diamond -= Shop.diamond_cost;

            PlayerPrefs.SetInt("Diamonds", Shop.Diamond);

            Shop.Current_DiamondTEXT.text = PlayerPrefs.GetInt("Diamonds").ToString();
            
            BuySetTEXTofCurrentSkin.text = "EQUIPPED";

            if(Shop.Prev_Equipped!=null)
            {
                Shop.Prev_Equipped.text = "EQUIP";
            }

            //The Currently Equipped and active skin text will be stored here
            Shop.Prev_Equipped = BuySetTEXTofCurrentSkin;

            PlayerPrefs.SetInt("SkinID", Shop.IDSelected);
            ChangeSkinScript.Change();
        }

        else if (BuySetTEXTofCurrentSkin.text == "EQUIP")
        {
            //Khel khelna hai
            //If we enconunter an EQUIP, then we need to reset the previouslly equipped skin text to EQUIP to reset
            Shop.Prev_Equipped.text = "EQUIP";

            //Now, like before we hand out the title of Prev Equipped to the current skin button being equipped for future references
            Shop.Prev_Equipped = BuySetTEXTofCurrentSkin;
            
            BuySetTEXTofCurrentSkin.text = "EQUIPPED";
            
            PlayerPrefs.SetInt("SkinID", Shop.IDSelected);
            ChangeSkinScript.Change();
        }
    }

    // Use this for initialization
    void Start ()
    {
        Shop = GameObject.FindObjectOfType<ShopManager>();
        ChangeSkinScript = GameObject.FindObjectOfType<ChangeSkinInGame>();

        BuySetTEXTofCurrentSkin.transform.parent.gameObject.SetActive(false);
    }

}
