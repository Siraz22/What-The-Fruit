using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//Manages Overall Shop and Currency system of the game.

public class ShopManager : MonoBehaviour
{
    ButtonBuyState buttontextscript;
    public string SkinBuy = null;

    public char[] SkinBuySplit;

    //public int[] SkinsBought = new int[23];

    //SCROLLING
    public RectTransform Panel;
    public Button[] Skins;
    public RectTransform center; //center to compare distance for snapping

    private float[] distance; //all button dist to the center
    private bool dragging = false;
    private int buttonDistance; // holds the distance between the buttons
    private int minButtonNum; // num of button closest to center 

    bool valueChanging = false;
    public int valueToReach;
    public static ShopManager Instance{ get; set; }
    public Animator DiamondUiImgAnimator;

    //THE INGAME CURRENCY, depends by taking value stored in player prefab "Diamonds"
    public int Diamond = 0;

    [Header("In Game values")]
    public TextMeshProUGUI Current_DiamondTEXT;

    [Header("In Death Panel")]
    public TextMeshProUGUI Death_Earning_ValueTEXT;
    public TextMeshProUGUI Death_Earing_TripleTEXT;

    public TextMeshProUGUI Prev_Equipped = null;

    public void ClearPref()
    {
        PlayerPrefs.DeleteKey("SkinBuy");
    }

    public void LoadBoughtSkins()
    {
        for (int i = 0; i < 23; ++i)
        {
            if (SkinBuySplit[i] == '1')
            {
                Skins[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

                if (i == 0)
                {
                    SkinButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = "EQUIPPED";
                }
                else
                    SkinButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = "EQUIP";
                Debug.Log("Skin bought detected");
             
                for (int j = 0; j < Skins[i].transform.childCount; j++)
                {
                    //Done
                    Skins[i].transform.GetChild(j).gameObject.SetActive(false);
                }
                
            }
            else
            {
                SkinButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = "BUY";
            }

            //Error when no skin is set to deafult, so wolverine is kept as deafult
            

            /*
            transform.localScale = new Vector3(1.09f, 1.76f, 1.36f);
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            */

        }
    }

    void Awake ()
    {
        SkinBuy = PlayerPrefs.GetString("SkinBuy", "10000000000000000000001");
        //PlayerPrefs.SetString("SkinBuy", SkinBuy);

        Instance = this;
    }

	void Start()
	{
        int ButtonLength = Skins.Length;
        distance = new float[ButtonLength];

        SkinBuySplit = SkinBuy.ToCharArray();

        LoadBoughtSkins();

        buttonDistance = (int)Mathf.Abs(Skins[1].GetComponent<RectTransform>().anchoredPosition.x - Skins[0].GetComponent<RectTransform>().anchoredPosition.x);

        Diamond = PlayerPrefs.GetInt("Diamonds");
		Current_DiamondTEXT.text = Diamond.ToString();
    }

    public void Reset_EarningDiamondWhenRestartedFromDeath()
    {
        EarningDiamonds = 0;
    }

    public void AddDiamond(int DiamondToAdd = 0)
    {
        //if no video add is seen 0 is added to the overall diamond value
        Debug.Log("AddDIamond call hua");
        Death_Earning_ValueTEXT.text = EarningDiamonds.ToString();
        Death_Earing_TripleTEXT.text = (EarningDiamonds*3).ToString();
        valueToReach = Diamond + DiamondToAdd;



        /*Diamond = DiamondToAdd + Diamond;
        PlayerPrefs.SetInt("Diamonds", Diamond);*/


        //ANimation yahan hogi , set trigger wali, 
        //Sound effects bhi daalna hai
        if (DiamondToAdd != 0)
        {
            valueChanging = true;
            DiamondUiImgAnimator.SetTrigger("sizechange");
        }
        //The current all time display value gets changed here

        Current_DiamondTEXT.text = PlayerPrefs.GetInt("Diamonds").ToString();
    }

    //IMPORTED SCRIPTS 
    //1) CURRENCY SCRIPT

    public int EarningDiamonds = 0;

    //Whenever the player dies, the value of temp_currency is added by HealthbarScript

    private void Update()
    {
        if(valueChanging)
        {
            Diamond =  valueToReach;
            PlayerPrefs.SetInt("Diamonds", Diamond);
            Current_DiamondTEXT.text = PlayerPrefs.GetInt("Diamonds").ToString();
            if (Diamond >= valueToReach)
            {
                Diamond = valueToReach;
                valueChanging = false;
            }
        }

        //SCROLLING IN UPDATE

        for (int i = 0; i < Skins.Length; ++i)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - Skins[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance); //getting min distance

        for(int a =0; a<Skins.Length; a++)
        {
            if(minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }

        if(!dragging)
        {
            LerpToButton(minButtonNum*-buttonDistance);
        }

        Skins[minButtonNum].transform.localScale = Vector3.Lerp(Skins[minButtonNum].transform.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 7f);

        for (int z = 0; z < Skins.Length; z++)
        {
            if (z == minButtonNum)
                continue;
            else
                Skins[z].transform.localScale = Vector3.Lerp(Skins[z].transform.localScale, new Vector3(0.8f, 0.8f, 0.8f), Time.deltaTime * 7f);
        }
    }

    void LerpToButton(int position)
    {
        float newX = Mathf.Lerp(Panel.anchoredPosition.x, position, Time.deltaTime * 20f);
        Vector2 newPosition = new Vector2(newX, Panel.anchoredPosition.y);

        Panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        
        dragging = false;
    }

    //ADDON SCRIPTS : SHOPMANAGERMAINMENU

    public Button[] SkinButtonList;
    //public bool[] BGID;

    public Button prevbutton_clicked = null;
    public Button CurrentButton_clicked = null;

    public int IDSelected;
    public int diamond_cost;

    /*
     ************************************************************ SKIN SYSTEM ************************************************
     */

    private bool firstclick = true;

    public void SetDiamondPrice(int diamondPrice)
    {
        diamond_cost = diamondPrice;
    }


    public void SetSkinIDandButtonID(int ID)
    {
        IDSelected = ID;

        //To recognise the previous button clicked, whose ID is set initially in Unity inspector
        //The ID is then passed when that button is clicked in Gameplay mode and sent here to recognise the button index from
        //ButtonList array.

        if (firstclick == true)
        {
            firstclick = false;
            CurrentButton_clicked = SkinButtonList[ID];

            //Current_Skin_Purchase_StateTEXT = CurrentButton_clicked.GetComponentInChildren<TextMeshProUGUI>();
        }
        else
        {
            prevbutton_clicked = CurrentButton_clicked;

            
            prevbutton_clicked.gameObject.SetActive(false);
            CurrentButton_clicked = SkinButtonList[ID];

            //Current_Skin_Purchase_StateTEXT = CurrentButton_clicked.GetComponentInChildren<TextMeshProUGUI>();
        }

    }

}
