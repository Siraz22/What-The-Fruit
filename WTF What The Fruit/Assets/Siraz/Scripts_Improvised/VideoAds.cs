using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class VideoAds : MonoBehaviour
{

    private void Awake()
    {
        Advertisement.Initialize("2621759");
    }

    public void ShowAdMainMenu()
    {
        ShowOptions so = new ShowOptions();
        so.resultCallback = CheckMenuReward;

        Advertisement.Show("rewardedVideo",so);
    }

    private void CheckMenuReward(ShowResult sr)
    {
        if(sr == ShowResult.Finished)
        {
            Debug.Log("Added 30 diamonds");
        }
        else
        {
            Debug.Log("No reward");
        }
    }

    //Advertisement

}
