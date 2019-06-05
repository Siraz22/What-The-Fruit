using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Sahil_UI : MonoBehaviour {

    public GameObject playerRef;

	void Awake()
    {
        
    }
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadHomeScreen()
    {
        SceneManager.LoadScene("Main_Menu");
    }
	public void LoadPlayScreen()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(2);
	}
	public void PauseGame()
	{
		Time.timeScale = 0;
	}
	public void ResumeGame()
	{
		Time.timeScale = 1;
	}
    public void RestartGame()
    {
        //yahan pe spawning and platforms ka change
        playerRef.SetActive(true);
        Score.Instance.Current_Score = 0;

    }
}