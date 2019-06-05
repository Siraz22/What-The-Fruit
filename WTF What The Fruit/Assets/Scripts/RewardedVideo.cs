using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedVideo : MonoBehaviour
{
    
    public GameObject bagOfDiamonds;
    public GameObject[] thingsToDeactivate;

    private bool InitializeAdAgain = false;

    private void Start()
    {
        if(GameObject.FindObjectOfType<CheckInternetConnection>().NetworkFound)
        {
            Advertisement.Initialize("2621759");
            Debug.Log("tried to initilaize death reward");
        }
    }

    public void RetryConnection()
    {
        if (GameObject.FindObjectOfType<CheckInternetConnection>().NetworkFound)
        {
            Advertisement.Initialize("2621759");
        }
        else
        {
            InitializeAdAgain = true;
        }

    }

    public void ResetAdbool()
    {
        InitializeAdAgain = false;
    }

    public void PlayAdForDiamonds()
    {
        Advertisement.Show("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult }  );
           
    }
    private void HandleAdResult( ShowResult result )
    {
        switch(result)
        {
            case ShowResult.Finished :
                Debug.Log("Finished ad");
                bagOfDiamonds.SetActive(true);
                bagOfDiamonds.transform.GetChild(0).gameObject.SetActive(true);
                bagOfDiamonds.transform.GetChild(1).gameObject.SetActive(true);
                bagOfDiamonds.transform.GetChild(2).gameObject.SetActive(true);
                //bagOfDiamonds.GetComponent<Animator>().SetTrigger("Entry");
                bagOfDiamonds.transform.GetComponentInChildren<Animator>().SetTrigger("Entry");
                for(int i =0;i<thingsToDeactivate.Length; i++ )
                {
                    thingsToDeactivate[i].SetActive(false);
                }
                break;

            case ShowResult.Skipped:
                Debug.Log("skipped");
                break;

            case ShowResult.Failed:
                Debug.Log("failed");
                break;
        }
    }

    void Update()
    {

        if (InitializeAdAgain)
        {
            if (!Advertisement.isInitialized && GameObject.FindObjectOfType<CheckInternetConnection>().NetworkFound)
            {
                GameObject.FindObjectOfType<CheckInternetConnection>().CheckNetTEXT[0].text = "\n\n\n\nINITIALIZING AD, PLEASE WAIT...";
                GameObject.FindObjectOfType<CheckInternetConnection>().CheckNetTEXT[1].text = "\n\n\n\nINITIALIZING AD, PLEASE WAIT...";
            }
            else if (Advertisement.IsReady() && GameObject.FindObjectOfType<CheckInternetConnection>().NetworkFound)
            {
                GameObject.FindObjectOfType<CheckInternetConnection>().AdIsInitialized();

                InitializeAdAgain = false;
            }
        }
    }

}
