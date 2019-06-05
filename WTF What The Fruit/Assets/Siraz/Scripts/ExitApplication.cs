using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitApplication : MonoBehaviour {

    public GameObject Panel_Exit;
    

	// Use this for initialization
	public void ExitAppPanel()
	{
        Panel_Exit.gameObject.SetActive(true);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

}
