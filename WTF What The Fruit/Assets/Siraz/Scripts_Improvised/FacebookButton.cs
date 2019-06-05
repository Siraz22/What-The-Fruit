using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookButton : MonoBehaviour {

    public Text userIdtext;

    private void Awake()
    {
        if(!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback:OnLogIn);
    }

    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken token = AccessToken.CurrentAccessToken;
            userIdtext.text = token.UserId;
            Debug.Log("LoggedIn Successfully");
        }
        else
            Debug.Log("Cancelled Login");
    }

    public void Share()
    {
        FB.ShareLink(
            contentTitle: "What The Fruit!",
            photoURL : new System.Uri("https://ibb.co/ndM9AT"),
            contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.PyareGames.WhatTheFruit"),
            contentDescription:"Come and beat me at this addictive and fun game!",
            callback:OnShare);
    }

    private void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {

            PlayerPrefs.SetString("FacebookShared?", "No");
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if(!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log("KHaali text bc!");
        }
        else
        {
            PlayerPrefs.SetString("FacebookShared?", "Yes");
            Debug.Log("Share succeed");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
