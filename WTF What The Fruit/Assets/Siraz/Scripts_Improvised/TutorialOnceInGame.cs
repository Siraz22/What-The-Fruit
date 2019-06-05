using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialOnceInGame : MonoBehaviour
{

    public Toggle TutorialToggle;

    public Toggle SwipeToggleEnabled;

    private bool PlayTapTutorialOnce = true;
    private bool PlaySwipeTutorialOnce = true;

    [Header("In Scene Tap")]
    public Animator TapLeft;
    public Animator TapRight;
    public GameObject Tap;

    [Header("In Scene Swipe")]
    public Animator SwipeUpDown;
    public GameObject Swipe;

    [Header("In Canvas Tap")]
    public GameObject TapObj;
    
    [Header("In Canvas Swipe")]
    public GameObject SwipeObj;

    private void ShowReqTutorial()
    {
        //FOR TAP
        if (PlayTapTutorialOnce)
        {
            Tap.SetActive(true);

            TapLeft.Play("LeftHandTap");
            TapRight.Play("RightHandTap");

            TapObj.SetActive(true);

            Time.timeScale = 0;
            PlayTapTutorialOnce = false;
        }

        //FOR SWIPE
        if (PlaySwipeTutorialOnce)
        {
            Swipe.SetActive(true);

            SwipeUpDown.Play("TutorialSwipe");

            SwipeObj.SetActive(true);

            Time.timeScale = 0;

            PlaySwipeTutorialOnce = false;
        }
    }

    // Update is called once per frame
    public void CheckTutorialBool()
    {
        if(TutorialToggle.isOn)
        {
            if(SwipeToggleEnabled.isOn)
            {
                PlayTapTutorialOnce = false;
                PlaySwipeTutorialOnce = true;
            }
            else if(!SwipeToggleEnabled.isOn)
            {
                PlayTapTutorialOnce = true;
                PlaySwipeTutorialOnce = false;
            }
        }
        else
        {
            PlaySwipeTutorialOnce = false;
            PlayTapTutorialOnce = false;
        }

        ShowReqTutorial();

	}

    public void ResetTimeScaleAfterTutorial()
    {
        Time.timeScale = 1;
    }

}
