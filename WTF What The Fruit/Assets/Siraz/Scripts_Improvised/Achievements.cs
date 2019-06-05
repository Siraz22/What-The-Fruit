using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achievements : MonoBehaviour
{
    public static Achievements Instance { get; set; }
    //List of all PLayerPrefs recorded so far

    /*
    TapCounts : No. of taps in the game
    SwipeCounts : No. of swipes in the game
    SkinCounter : No. of skins bought in game
    Diamonds : No. of currency owned by the Player
    Best_Score : The best score secured by the player
    MenuShine : Times the main menu has been shined
    Achievements : No. of achievements Unlocked
    Gift : No. of gifts opened by the user
    Ads : No. of times successful ads have been watched
    */
    public Transform spawnpoint;

    public GameObject Exclamation;

    public GameObject Particle_System;
    
    public int ArrayIndex = 0;

    public TextMeshProUGUI DiamondsText;

    public Button[] ClaimButtonsInOrder;

    private bool[] AchievementWasClickedBefore = new bool[21];

    public void AchievementsCheck()
    {

        //For TapGuru

        if (PlayerPrefs.GetInt("TapCounts") < 101)
            {
                ClaimButtonsInOrder[0].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TapCounts").ToString("0") + "%";
                ClaimButtonsInOrder[0].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("TapCounts") / 100f;
            }
        else
            {
                ClaimButtonsInOrder[0].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
                ClaimButtonsInOrder[0].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
            }

        if (PlayerPrefs.GetInt("TapCounts") > 99 && AchievementWasClickedBefore[0]==false)
            {
                ClaimButtonsInOrder[0].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
                ClaimButtonsInOrder[0].interactable = true;
                ClaimButtonsInOrder[0].transform.Find("Effect").gameObject.SetActive(true);
            }
        else
        {
            ClaimButtonsInOrder[0].interactable = false;
            ClaimButtonsInOrder[0].transform.Find("Effect").gameObject.SetActive(false);
        }

        //For TapMaster ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("TapCounts") < 1001)
        {
            ClaimButtonsInOrder[1].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("TapCounts")/10f).ToString("0") + "%";
            ClaimButtonsInOrder[1].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("TapCounts") / 1000f;
        }
        else
        {
            ClaimButtonsInOrder[1].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[1].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("TapCounts") > 999 && AchievementWasClickedBefore[1] == false)
        {
            ClaimButtonsInOrder[1].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[1].interactable = true;
            ClaimButtonsInOrder[1].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[1].interactable = false;
            ClaimButtonsInOrder[1].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For TapTycoon ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("TapCounts") < 5001)
        {
            ClaimButtonsInOrder[2].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("TapCounts") / 50f).ToString("0") + "%";
            ClaimButtonsInOrder[2].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("TapCounts") / 5000f;
        }
        else
        {
            ClaimButtonsInOrder[2].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[2].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("TapCounts") > 4999 && AchievementWasClickedBefore[2] == false)
        {
            ClaimButtonsInOrder[2].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[2].interactable = true;
            ClaimButtonsInOrder[2].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[2].interactable = false;
            ClaimButtonsInOrder[2].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Swipe Guru ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SwipeCounts") < 101)
        {
            ClaimButtonsInOrder[3].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("SwipeCounts").ToString("0") + "%";
            ClaimButtonsInOrder[3].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("SwipeCounts") / 100f;
        }
        else
        {
            ClaimButtonsInOrder[3].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[3].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("SwipeCounts") > 99 && AchievementWasClickedBefore[3] == false)
        {
            ClaimButtonsInOrder[3].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[3].interactable = true;
            ClaimButtonsInOrder[3].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[3].interactable = false;
            ClaimButtonsInOrder[3].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Cut The Rope ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SwipeCounts") < 1001)
        {
            ClaimButtonsInOrder[4].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("SwipeCounts") / 10f).ToString("0") + "%";
            ClaimButtonsInOrder[4].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("SwipeCounts") / 1000f;
        }
        else
        {
            ClaimButtonsInOrder[4].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[4].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("SwipeCounts") > 999 && !AchievementWasClickedBefore[4])
        {
            ClaimButtonsInOrder[4].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[4].interactable = true;
            ClaimButtonsInOrder[4].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[4].interactable = false;
            ClaimButtonsInOrder[4].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Fruit Ninja! ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SwipeCounts") < 5001)
        {
            ClaimButtonsInOrder[5].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("SwipeCounts") / 50f).ToString("0") + "%";
            ClaimButtonsInOrder[5].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("SwipeCounts") / 5000f;
        }
        else
        {
            ClaimButtonsInOrder[5].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[5].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("SwipeCounts") > 4999 && AchievementWasClickedBefore[5] == false)
        {
            ClaimButtonsInOrder[5].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[5].interactable = true;
            ClaimButtonsInOrder[5].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[5].interactable = false;
            ClaimButtonsInOrder[5].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For FacebookShare ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetString("FacebookShared?")=="Yes")
        {
            ClaimButtonsInOrder[6].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
            ClaimButtonsInOrder[6].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1;
        }
        else
        {
            ClaimButtonsInOrder[6].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "0%";
            ClaimButtonsInOrder[6].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 0;
        }
        
        if (PlayerPrefs.GetString("FacebookShared?") == "Yes" && AchievementWasClickedBefore[6] == false)
        {
            ClaimButtonsInOrder[6].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[6].interactable = true;
            ClaimButtonsInOrder[6].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[6].interactable = false;
            ClaimButtonsInOrder[6].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Bit-Coin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Diamonds") < 5001)
        {
            ClaimButtonsInOrder[7].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Diamonds") / 50f).ToString("0") + "%";
            ClaimButtonsInOrder[7].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Diamonds") / 5000f;
        }
        else
        {
            ClaimButtonsInOrder[7].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[7].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Diamonds") > 4999 && AchievementWasClickedBefore[7] == false)
        {
            ClaimButtonsInOrder[7].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[7].interactable = true;
            ClaimButtonsInOrder[7].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[7].interactable = false;
            ClaimButtonsInOrder[7].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Byte-Coin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Diamonds") < 10001)
        {
            ClaimButtonsInOrder[8].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Diamonds") / 100f).ToString("0") + "%";
            ClaimButtonsInOrder[8].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Diamonds") / 10000f;
        }
        else
        {
            ClaimButtonsInOrder[8].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[8].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Diamonds") > 9999 && AchievementWasClickedBefore[8] == false)
        {
            ClaimButtonsInOrder[8].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[8].interactable = true;
            ClaimButtonsInOrder[8].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[8].interactable = false;
            ClaimButtonsInOrder[8].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For MeraCoin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Diamonds") < 15001)
        {
            ClaimButtonsInOrder[9].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Diamonds") / 150f).ToString("0") + "%";
            ClaimButtonsInOrder[9].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Diamonds") / 15000f;
        }
        else
        {
            ClaimButtonsInOrder[9].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[9].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Diamonds") > 14999 && AchievementWasClickedBefore[9] == false)
        {
            ClaimButtonsInOrder[9].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[9].interactable = true;
            ClaimButtonsInOrder[9].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[9].interactable = false;
            ClaimButtonsInOrder[9].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Bronze-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") < 151)
        {
            ClaimButtonsInOrder[10].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Best_Score") / 1.5f).ToString("0") + "%";
            ClaimButtonsInOrder[10].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Best_Score") / 150f;
        }
        else
        {
            ClaimButtonsInOrder[10].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[10].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Best_Score") > 149 && AchievementWasClickedBefore[10] == false)
        {
            ClaimButtonsInOrder[10].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[10].interactable = true;
            ClaimButtonsInOrder[10].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[10].interactable = false;
            ClaimButtonsInOrder[10].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Silver-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") < 301)
        {
            ClaimButtonsInOrder[11].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Best_Score") / 3f).ToString("0") + "%";
            ClaimButtonsInOrder[11].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Best_Score") / 300f;
        }
        else
        {
            ClaimButtonsInOrder[11].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[11].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Best_Score") > 299 && AchievementWasClickedBefore[11] == false)
        {
            ClaimButtonsInOrder[11].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[11].interactable = true;
            ClaimButtonsInOrder[11].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[11].interactable = false;
            ClaimButtonsInOrder[11].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Gold-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") < 601)
        {
            ClaimButtonsInOrder[12].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Best_Score") / 6f).ToString("0") + "%";
            ClaimButtonsInOrder[12].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Best_Score") / 600f;
        }
        else
        {
            ClaimButtonsInOrder[12].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[12].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Best_Score") > 599 && AchievementWasClickedBefore[12] == false)
        {
            ClaimButtonsInOrder[12].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[12].interactable = true;
            ClaimButtonsInOrder[12].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[12].interactable = false;
            ClaimButtonsInOrder[12].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Platinum-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") < 901)
        {
            ClaimButtonsInOrder[13].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Best_Score") / 9f).ToString("0") + "%";
            ClaimButtonsInOrder[13].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Best_Score") / 900f;
        }
        else
        {
            ClaimButtonsInOrder[13].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[13].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Best_Score") > 899 && AchievementWasClickedBefore[13] == false)
        {
            ClaimButtonsInOrder[13].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[13].interactable = true;
            ClaimButtonsInOrder[13].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[13].interactable = false;
            ClaimButtonsInOrder[13].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Vibranium-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") < 1101)
        {
            ClaimButtonsInOrder[14].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Best_Score") / 11f).ToString("0") + "%";
            ClaimButtonsInOrder[14].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Best_Score") / 1100f;
        }
        else
        {
            ClaimButtonsInOrder[14].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[14].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Best_Score") > 1109 && AchievementWasClickedBefore[14] == false)
        {
            ClaimButtonsInOrder[14].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[14].interactable = true;
            ClaimButtonsInOrder[14].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[14].interactable = false;
            ClaimButtonsInOrder[14].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For New-Face ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SkinCounter") < 6)
        {
            ClaimButtonsInOrder[15].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("SkinCounter") / 0.05f).ToString("0") + "%";
            ClaimButtonsInOrder[15].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("SkinCounter") / 5f;
        }
        else
        {
            ClaimButtonsInOrder[15].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[15].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("SkinCounter") > 4 && AchievementWasClickedBefore[15] == false)
        {
            ClaimButtonsInOrder[15].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[15].interactable = true;
            ClaimButtonsInOrder[15].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[15].interactable = false;
            ClaimButtonsInOrder[15].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Two-Face ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SkinCounter") < 11)
        {
            ClaimButtonsInOrder[16].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("SkinCounter") / 0.1f).ToString("0") + "%";
            ClaimButtonsInOrder[16].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("SkinCounter") / 10f;
        }
        else
        {
            ClaimButtonsInOrder[16].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[16].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("SkinCounter") > 9 && AchievementWasClickedBefore[16] == false)
        {
            ClaimButtonsInOrder[16].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[16].interactable = true;
            ClaimButtonsInOrder[16].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[16].interactable = false;
            ClaimButtonsInOrder[16].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Deve'helper' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Ads") < 26)
        {
            ClaimButtonsInOrder[17].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Ads") / 0.25f).ToString("0") + "%";
            ClaimButtonsInOrder[17].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Ads") / 25f;
        }
        else
        {
            ClaimButtonsInOrder[17].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[17].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Ads") > 24 && AchievementWasClickedBefore[17] == false)
        {
            ClaimButtonsInOrder[17].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[17].interactable = true;
            ClaimButtonsInOrder[17].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[17].interactable = false;
            ClaimButtonsInOrder[17].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For 50 Candella ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("MenuShine") < 51)
        {
            ClaimButtonsInOrder[18].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("MenuShine") / 0.5f).ToString("0") + "%";
            ClaimButtonsInOrder[18].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("MenuShine") / 50;
        }
        else
        {
            ClaimButtonsInOrder[18].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[18].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("MenuShine") > 49 && AchievementWasClickedBefore[18] == false)
        {
            ClaimButtonsInOrder[18].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[18].interactable = true;
            ClaimButtonsInOrder[18].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[18].interactable = false;
            ClaimButtonsInOrder[18].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Birthday ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Gifts") < 26)
        {
            ClaimButtonsInOrder[19].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Gifts") / 0.25f).ToString("0") + "%";
            ClaimButtonsInOrder[19].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Gifts") / 25;
        }
        else
        {
            ClaimButtonsInOrder[19].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[19].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Gifts") > 24 && AchievementWasClickedBefore[19] == false)
        {
            ClaimButtonsInOrder[19].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[19].interactable = true;
            ClaimButtonsInOrder[19].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[19].interactable = false;
            ClaimButtonsInOrder[19].transform.Find("Effect").gameObject.SetActive(false);
        }
        //For Achiever ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Achievements") < 16)
        {
            ClaimButtonsInOrder[20].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = (PlayerPrefs.GetInt("Achievements") / 0.15f).ToString("0") + "%";
            ClaimButtonsInOrder[20].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = PlayerPrefs.GetInt("Achievements") / 15;
        }
        else
        {
            ClaimButtonsInOrder[20].transform.parent.Find("FillHelper").GetComponent<Image>().fillAmount = 1f;
            ClaimButtonsInOrder[20].transform.parent.Find("CompletePercentage").GetComponent<TextMeshProUGUI>().text = "100%";
        }

        if (PlayerPrefs.GetInt("Achievements") > 14 && AchievementWasClickedBefore[20] == false)
        {
            ClaimButtonsInOrder[20].GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255);
            ClaimButtonsInOrder[20].interactable = true;
            ClaimButtonsInOrder[20].transform.Find("Effect").gameObject.SetActive(true);
        }
        else
        {
            ClaimButtonsInOrder[20].interactable = false;
            ClaimButtonsInOrder[20].transform.Find("Effect").gameObject.SetActive(false);
        }
        //
    }

    public void SetArrayIndex(int indexno)
    {
        ArrayIndex = indexno;
    }

    private void Awake()
    {
        //COUNTER player prefs
        Instance = this;
    
        /*
        PlayerPrefs.SetInt("TapCounts", 0);
        PlayerPrefs.SetInt("SwipeCounts", 0);
        PlayerPrefs.SetInt("SkinCounter", 0);
        PlayerPrefs.SetInt("Diamonds", 50);
        PlayerPrefs.SetInt("Best_Score", 0);
        PlayerPrefs.SetInt("MenuShine", 0);
        PlayerPrefs.SetInt("Achievements", 0);
        PlayerPrefs.SetInt("Gifts", 0);
        PlayerPrefs.SetInt("Ads", 0);
        PlayerPrefs.SetString("FacebookShared?", "No");
        */

        //PlayerPrefs.SetString("AchievementsDone", "000000000000000000000");

        //Debug.Log(PlayerPrefs.GetString("AchievementsDone"));

        Achievementsdone = PlayerPrefs.GetString("AchievementsDone", "000000000000000000000");

        //Debug.Log(PlayerPrefs.GetString("AchievementsDone") + " After setting");

        AchievementsDoneSplit = Achievementsdone.ToCharArray();

    }

    private string NewAchievementsdone = null;
    private string Achievementsdone = null;
    private char[] AchievementsDoneSplit = new char[21];

    private void Start()
    {
        for (int i = 0; i < 21; ++i)
        {
            AchievementWasClickedBefore[i] = false;
        }
        //BoolCheck = PlayerPrefs.GetString("AchievementsDone").ToCharArray();

        SetAllReqBool();
    }

    //To set the achievement done as 1 in playerprefs string.
    public void AchievementsBoolToSet()
    {
        //before this function is called, array index would have been assigned already so we can use it to know which button has been pressed from the array
        AchievementsDoneSplit[ArrayIndex] = '1';
        AchievementWasClickedBefore[ArrayIndex] = true;
        ClaimButtonsInOrder[ArrayIndex].interactable = false;

        NewAchievementsdone = null;

        for (int i = 0; i < 21; ++i)
        {
            NewAchievementsdone = NewAchievementsdone + AchievementsDoneSplit[i].ToString();

            Debug.Log("Problem at..." + i);
        }

        Debug.Log(NewAchievementsdone);

        Achievementsdone = NewAchievementsdone;

        PlayerPrefs.SetString("AchievementsDone", NewAchievementsdone);
    }

    public void SetAllReqBool()
    {

        for (int j = 0; j < 21; ++j)
        {
            //Debug.Log(j);

            if (AchievementsDoneSplit[j] == '1')
            {
                ClaimButtonsInOrder[j].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
                ClaimButtonsInOrder[j].transform.Find("Effect").gameObject.SetActive(false);
                ClaimButtonsInOrder[j].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

                AchievementWasClickedBefore[j] = true;
                //ClaimButtonsInOrder[j].interactable = false;

                //Particle_System.gameObject.SetActive(false);

                //Debug.Log(j + "Done succesfully....");
            }
            else
            {
                ClaimButtonsInOrder[j].GetComponentInChildren<Image>().color = new Color32(255, 0, 0, 255);
                AchievementWasClickedBefore[j] = false;
            }
        }

        //BoolCheck = null;
    }

    public void CheckTapGuru()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192 , 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 100);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }

    public void CheckTapMaster()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 500);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }

    public void CheckTapTycoon()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 3100);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }

    public void CheckSwipeGuru()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 100);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckCutTheRope()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 400);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckFruitNinja()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 3000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }

    public void CheckFBShare()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 6500);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckBitCoin()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);
        
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1500 );

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
        
    }
    public void CheckByteCoin()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 2500);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckMeraCoin()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 8000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckBronze()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 200);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckSilver()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 300);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckGold()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 450);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckPlatinum()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckVibranium()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 3200);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckNewFace()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1300);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckTwoFace()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 5000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckDeveloperHelper()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 9000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void Check50Candela()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 150);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckBirthdayGifts()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 7000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }
    public void CheckAchiever()
    {
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<Image>().color = new Color32(70, 192, 0, 255);
        ClaimButtonsInOrder[ArrayIndex].transform.Find("Effect").gameObject.SetActive(false);
        ClaimButtonsInOrder[ArrayIndex].GetComponentInChildren<TextMeshProUGUI>().text = "Done!";

        //Particle_System.gameObject.SetActive(true);
        GameObject vfx = (GameObject)Instantiate(Particle_System, spawnpoint.position, Quaternion.identity);
        vfx.transform.SetParent(spawnpoint);

        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 5000);

        DiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();

    }

    //ForAchievements
    public void IncreaseAchievementNoPrefab()
    {
        PlayerPrefs.SetInt("Achievements", PlayerPrefs.GetInt("Achievements") + 1);
    }

    //FOR EXCLAMATION MARK CHECK
    public void CheckForExclamation()
    {
        //For TapGuru
        if (PlayerPrefs.GetInt("TapCounts") > 99 && AchievementWasClickedBefore[0] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For TapMaster ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("TapCounts") > 999 && AchievementWasClickedBefore[1] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For TapTycoon ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("TapCounts") > 4999 && AchievementWasClickedBefore[2] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Swipe Guru ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SwipeCounts") > 99 && AchievementWasClickedBefore[3] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Cut The Rope ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SwipeCounts") > 999 && !AchievementWasClickedBefore[4] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Fruit Ninja! ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SwipeCounts") > 4999 && AchievementWasClickedBefore[5] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For FacebookShare ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetString("FacebookShared?") == "Yes" && AchievementWasClickedBefore[6] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Bit-Coin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Diamonds") > 4999 && AchievementWasClickedBefore[7] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Byte-Coin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Diamonds") > 9999 && AchievementWasClickedBefore[8] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }
        //For MeraCoin ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Diamonds") > 14999 && AchievementWasClickedBefore[9] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Bronze-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") > 149 && AchievementWasClickedBefore[10] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Silver-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") > 299 && AchievementWasClickedBefore[11] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Gold-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") > 599 && AchievementWasClickedBefore[12] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Platinum-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") > 899 && AchievementWasClickedBefore[13] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Vibranium-Age ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Best_Score") > 1109 && AchievementWasClickedBefore[14] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For New-Face ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SkinCounter") > 4 && AchievementWasClickedBefore[15] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }

        //For Two-Face ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("SkinCounter") > 9 && AchievementWasClickedBefore[16] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }
      
        //For Deve'helper' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Ads") > 24 && AchievementWasClickedBefore[17] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }
     
        //For 50 Candella ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("MenuShine") > 49 && AchievementWasClickedBefore[18] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }
        
        //For Birthday ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        

        if (PlayerPrefs.GetInt("Gifts") > 24 && AchievementWasClickedBefore[19] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }
        
        //For Achiever ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (PlayerPrefs.GetInt("Achievements") > 14 && AchievementWasClickedBefore[20] == false)
        {
            Exclamation.gameObject.SetActive(true);
        }
       
    }
}