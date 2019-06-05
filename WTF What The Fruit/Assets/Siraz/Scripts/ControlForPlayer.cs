using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlForPlayer : MonoBehaviour
{

    private bool DoneOnce = false;

    //SETTINGS OPTIONS

    //NOTE : Whenever the player is defeated, the HealthAndLock Script turns off the TapControls, as there is no definite variable that defines player's death except
    //the Couroutine that starts deathcount and activates death panel, so that the UI buttons for tap does't interfere with diamond click; they're anyway
    //set back to active provided their toggle ison in the settings panel whenever "Tap to Start" is clicked.

    public Toggle SwipeToggle;
    public GameObject TapControls;

    public void ChangeDoneOnceforPlayer()
    {
        //NOTE
        //Done once is a bool which states if the "platform more" has been seen and the platform positions updated. Once its done, theres
        //no need to update the platforms number again and again and thus to save resources, done once is used. It should be reset to false whenever a new
        //game is started, ie, detected whenever the player taps on " Tap To Start "
        DoneOnce = false;
    }

    Audio AudioManager_Script;

    [Header("Player_Movement_Stats")]

	public float LerpSpeed = 12f;
	public Transform[] Collection_of_Pos;
	private bool Up_Pressed = false;
	private bool Down_Pressed = false;

    [Header("Platfomr_Stat")]
    public int topmost_plat_no;
    public int lowest_plat_no;

    //player starts at middle by deafult
    public int Pos_of_Player = 2;

	private GameObject player;
	
	[Header("Swipe Variables")]
	private float max_swipetime=0.5f;
	private float min_swipeDist=25f;

	Vector2 StartPos;
	Vector2 EndPos;

	private float Starttime;
	private float Endtime;

    Multiplier multiplierscript;

    public void ResetControl()
    {
            topmost_plat_no = 1;
            lowest_plat_no = 3;
    }

	void Awake()
	{
        multiplierscript = GameObject.FindObjectOfType<Multiplier>();
        AudioManager_Script = GameObject.FindObjectOfType<Audio>();
        topmost_plat_no = 1;
        lowest_plat_no = 3;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start()
	{
		player.transform.position = Collection_of_Pos [Pos_of_Player].position;
	}
     
	public void Down()
	{
        
		if (Pos_of_Player < lowest_plat_no) 
		{
			++Pos_of_Player;

            //For Achievements
            if (!SwipeToggle.isOn)
            {
                PlayerPrefs.SetInt("TapCounts", PlayerPrefs.GetInt("TapCounts") + 1);
                //Debug.Log("This is called. We increased no of taps");
            }

            //AudioManager_Script.PlayerMovedDown();
            char_specefic_EffectPopUps.Instance.UpDownEffects("Down");
        }

	}

	public void Up()
	{
        
		if (Pos_of_Player > topmost_plat_no) 
		{
			--Pos_of_Player;

            //For Achievement
            if (!SwipeToggle.isOn)
            {
                PlayerPrefs.SetInt("TapCounts", PlayerPrefs.GetInt("TapCounts") + 1);
                //Debug.Log("This is called. We increased no of taps");
            }
            //AudioManager_Script.PlayerMovedUp();
            char_specefic_EffectPopUps.Instance.UpDownEffects("Up");
        }
	}

    public void DetectSwipe()
    {
        if(SwipeToggle.isOn)
        {
            if (Input.touches.Length > 0)
            {//If there are more than one touch detected on the screen go with the first touch
                Touch touch_var = Input.GetTouch(0);

                if (touch_var.phase == TouchPhase.Began)
                {
                    StartPos = touch_var.position;
                    Starttime = Time.time;
                }

                if (touch_var.phase == TouchPhase.Ended)
                {
                    EndPos = touch_var.position;
                    Endtime = Time.time;

                    if (Endtime - Starttime < max_swipetime && (StartPos - EndPos).magnitude > min_swipeDist)
                    {
                        //Debug.Log("Swipe Detected");

                        Vector2 Swipe_Dist = EndPos - StartPos;

                        if (Swipe_Dist.y > 0)
                        {
                           // Debug.Log("Upward Swipe successful");

                            //For Achievement
                            PlayerPrefs.SetInt("SwipeCounts", PlayerPrefs.GetInt("SwipeCounts") + 1);

                            Up();

                        }
                        if (Swipe_Dist.y < 0)
                        {
                            //Debug.Log("Downward swipe successful");

                            //For Achievement
                            PlayerPrefs.SetInt("SwipeCounts", PlayerPrefs.GetInt("SwipeCounts") + 1);

                            Down();
                        }
                        else
                            Debug.Log("Maker a longer swipe on the vertical axis ");
                    }
                }
            }
        }
        
    }

    public void CheckControlSettings()
    {
        if(!SwipeToggle.isOn)
        {
            TapControls.gameObject.SetActive(true);
        }
        else
        {
            TapControls.gameObject.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () 
	{

		player.transform.position = Vector2.Lerp (player.transform.position, Collection_of_Pos [Pos_of_Player].position, LerpSpeed * Time.deltaTime);

            DetectSwipe();
       
        if(Input.GetKeyUp(KeyCode.W))
        {
            Up();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Down();
        }

        if(multiplierscript.More_Platform && !DoneOnce)
        {
            topmost_plat_no = 0;
            lowest_plat_no = 4;

            DoneOnce = true;
        }
    }
}