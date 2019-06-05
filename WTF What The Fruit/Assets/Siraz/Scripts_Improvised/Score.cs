using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance { get; set; }
    HealthAndLock healthscript;

	public GameObject Player_ref;
	public int Current_Score=0; 
	public int Best_Score=0;

    [Header("Score")]
    public TextMeshProUGUI IngamescoreTXT;
    public TextMeshProUGUI IngameBestScoreTXT;

	public void ResetAll()
	{
        //PlayerPrefs.DeleteAll(); 
	}

	//For initial scores
	void Awake()
	{
        Instance = this;
        healthscript = GameObject.FindObjectOfType<HealthAndLock>();    
	}

    private void Start()
    {
        IngameBestScoreTXT.text = PlayerPrefs.GetInt("Best_Score").ToString();
        IngamescoreTXT.text = Current_Score.ToString();
    }

    void Check()
	{
		
		if (Current_Score > Best_Score) 
		{

			PlayerPrefs.SetInt ("Best_Score", Current_Score);
            IngameBestScoreTXT.text = Best_Score.ToString();
            PlayerPrefs.SetString("HighScore_Name",PlayerPrefs.GetString("New_Name","Default Player"));


            IngameBestScoreTXT.text = Current_Score.ToString();
        }

    }
    

	// Update is called once per frame
	void Update () 
	{
        
		Check ();

        Best_Score = PlayerPrefs.GetInt("Best_Score", 0);

        IngamescoreTXT.text = Current_Score.ToString();
        

    }
}
