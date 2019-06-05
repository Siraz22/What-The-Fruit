using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShine : MonoBehaviour
{
    public GameObject ShineObject;

    public void Shine()
    {
        ShineObject.gameObject.SetActive(true);

        //For Achievements
        PlayerPrefs.SetInt("MenuShine", PlayerPrefs.GetInt("MenuShine") + 1);

        Debug.Log("Active Now");
    }
}
