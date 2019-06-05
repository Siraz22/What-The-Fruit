using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ButtonBuyState : MonoBehaviour
{

    TextMeshProUGUI ButtonState;

    private void Start()
    {
        ButtonState = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void CheckEverythnig()
    {

        //Explicit declaration of button for whenever the button is being called outside of this very script
        ButtonState = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        if(ButtonState.text == "EQUIP")
        {
            transform.localScale = new Vector3(1.09f, 1.76f, 1.36f);
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            //
        }
        else if(ButtonState.text == "EQUIPPED")
        {
            transform.localScale = new Vector3(1.72f, 2.78f, 2.15f);
            gameObject.GetComponent<Image>().color = new Color32(45, 166, 45, 255);
            //
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
