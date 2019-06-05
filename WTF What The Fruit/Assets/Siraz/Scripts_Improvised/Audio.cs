using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
	public static Audio Instance{get;set;}
    [Header("Player Movement")]
    public AudioSource Player_Movement;
    public AudioClip Down;
    public AudioClip Up;

    [Header("Eating Food")]
    public AudioSource Eating_Food;
    public AudioClip GoodFood;
    public AudioClip BadFood;

    [Header("Game Theme")]
    public AudioSource GameTheme;
    public AudioClip[] GameThemeList;

	[Header("Death Sound")]
	public AudioSource DeathAudio;

	[Header("Celebration")]
	public AudioSource CelebrationAud;
	public AudioSource CelebrationAudBandi;

    [Header("Button CLick")]
    public AudioClip buttonCLick1;
    public AudioClip buttonclick2;
    private void Awake()
    {
       Instance = this;
    }

    /*
     * 
     *PLAYER MOVEMENT SOUNDS 
     * 
     */
	public void Restart()
	{
		DeathAudio.Stop();
		GameTheme.Stop();
		GameTheme.Play();
	}
    public void PlayerMovedDown()
    {
        Player_Movement.clip = Down;
        Player_Movement.Play();
    }

    public void PlayerMovedUp()
    {
        Player_Movement.clip = Up;
        Player_Movement.Play();
    }


    /*
     * 
     *FOOD CONSUMPTION SOUNDS 
     * 
     */
    public void AteGoodFood()
    {
        Eating_Food.clip = GoodFood;
        Eating_Food.Play();
    }

    public void AteBadFood()
    {
        Eating_Food.clip = BadFood;
        Eating_Food.Play();
    }

	public void DeathAudioPlay()
	{
		DeathAudio.Play();
	}

	public void Celebration()
	{
		CelebrationAud.Play();
		CelebrationAudBandi.Play();
	}

    // Use this for initialization
    void Start ()
    {
        GameTheme.clip = GameThemeList[Random.Range(0, GameThemeList.Length)];
        GameTheme.Play();
	}
    public void ButtonClick1()
    {
        GetComponent<AudioSource>().clip = buttonCLick1;
        GetComponent<AudioSource>().Play();
    }
    public void ButtonClick2()
    {
        GetComponent<AudioSource>().clip = buttonclick2;
        GetComponent<AudioSource>().Play();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
