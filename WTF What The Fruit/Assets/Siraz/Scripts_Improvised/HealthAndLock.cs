using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndLock : MonoBehaviour
{
    public GameObject turnThisOnBaby;
    public GameObject turnThisOnBaby2;
    public GameObject turnThisOnBaby3;

    //Prevent the bug where player can tap pause and restart game when the player dies in middle of the game at the last moment
    public Button PauseButtonIngame;

    public GameObject spawnner;
    public static HealthAndLock Instance {get;set;}

    public GameObject MutiplierBar;

    ControlForPlayer controlscript;
    ShopManager shopmanagerscript;

    Multiplier multiplier_script;
    public Image DeathPanel;

    //public Image First;
    //public Image Second;

    //Renewed Health System
    public Image[] HealthAttempts;
    private int whichHealth = 0;

    public bool clear_food = false;

    public Image PauseandRestartPanel;
    public Image HealthFillImg;
    public GameObject Player_Spine;
    Score scorescript;
    public int LerpSpeed = 10;

    public float Current_HealthLevel;
    public float Max_HealthLevel=100f ;

    //For the Lock and Unlock System
    public GameObject UnlockedFruit;
    
    public Animator LockandUnlockFruit;

    public ParticleSystem Boom;

    public Sprite[] FruitsInLockedOrder;

    [SerializeField] private Toggle EnableToggle;

    private void Awake()
    {
        controlscript = GameObject.FindObjectOfType<ControlForPlayer>();

        shopmanagerscript = GameObject.FindObjectOfType<ShopManager>();
		Instance = this;
        multiplier_script = GameObject.FindObjectOfType<Multiplier>();
        scorescript = GameObject.FindObjectOfType<Score>();
        
    }

    private void Start()
    {
        //LockandUnlockAnim = LockImage.GetComponent<Animator>();
        Current_HealthLevel = 1f;
        HealthFillImg.fillAmount = Current_HealthLevel / Max_HealthLevel;
    }

    public void Good_Food_Fill(float fill)
    {
		Current_HealthLevel = Current_HealthLevel + fill   ;
    }

    public void TapToStartResetAlpha()
    {   

        if (!EnableToggle.isOn)
        {
            foreach (Image healthdisplay in HealthAttempts)
            {
                Debug.Log("TapToStart Alpha Reset");
                healthdisplay.GetComponent<Image>().color = new Color32(255, 255, 255, 75);
                PauseButtonIngame.interactable = true;

                //resetting health array index when no tutorial and tap to start is pressed
                whichHealth = 0;

                MutiplierBar.gameObject.SetActive(true);
            }
        }
        
    }

    public void PauseRetryHealthReset()
    {
        foreach (Image healthdisplay in HealthAttempts)
        {
            //Debug.Log("TapToStart Alpha Reset");
            healthdisplay.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }

        //when we click on pause retry button
        whichHealth = 0;

        MutiplierBar.gameObject.SetActive(false);
    }

    public void ResetHealthAlpha()
    {
        foreach (Image healthdisplay in HealthAttempts)
        {
            healthdisplay.GetComponent<Image>().color = new Color32(255, 255, 255, 75);
        }

        MutiplierBar.gameObject.SetActive(true);

        //For A natural start with tutorial enabled
        whichHealth = 0;

    }

    public void Bad_Food_Eaten()
    {

        HealthAttempts[whichHealth].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        whichHealth++;
        //StartCoroutine("Wait");

        if (whichHealth == 3)
        {
            HealthFillImg.fillAmount = 0;
            PauseButtonIngame.interactable = false;

            StartCoroutine("DeathWait");
            StartCoroutine("Countdown");

            clear_food = true;
            
        }
         
    }

    // *********************************
    // MAKES THE TAP BUTTON BRING THE INITIAL LOCK AND LOCKED FRUIT DOWN
    public void StartLockAndUnlock()
    {
        StartCoroutine("LockAndUnlock");
    }

    public void ResetLockAndUnlockForRestart()
    {
        StopCoroutine("LockAndUnlock");

        LockandUnlockFruit.Play("UnlockedFruitSwipeUp");
    }

    IEnumerator LockAndUnlock()
    {
        yield return new WaitForSeconds(2.4f);

        //update fruit sprite at every multiplier value
        UnlockedFruit.GetComponent<SpriteRenderer>().sprite = FruitsInLockedOrder[multiplier_script.multiplier_value-1];

        UnlockedFruit.GetComponent<SpriteRenderer>().color = new Color32(82, 82, 82, 255);

        LockandUnlockFruit.Play("LockedFruitSwipeDown");
    }

    //Countdown after player has died for the deathpanel to show up
    IEnumerator Countdown()
    {

        

        yield return new WaitForSeconds(1f);
        Audio.Instance.DeathAudioPlay();
		Audio.Instance.GameTheme.Pause();
        controlscript.TapControls.SetActive(false);
        char_specefic_EffectPopUps.Instance.DestroyCurrentEffects();
        // Destroy(char_specefic_EffectPopUps.Instance.publicvfxtodestroy, 0f);

        GameObject.FindObjectOfType<CheckInternetConnection>().CheckNetwork();

        //GameObject.FindObjectOfType<RewardedVideo>().RetryConnection();

        Player_Spine.gameObject.SetActive(false);
        DeathPanel.gameObject.SetActive(true);
        turnThisOnBaby.SetActive(true);
        turnThisOnBaby2.SetActive(true);
        turnThisOnBaby3.SetActive(true);
        //HERE THE MONEY WAS ADDED BUT ITS NOW DISABLED
        shopmanagerscript.AddDiamond(0);
    }
    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(1f);

        foreach(Image healthdisplay in HealthAttempts)
        {
            healthdisplay.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }

    }

    //Lock and Unlock Animation Couroutines

    /*
    IEnumerator WaitforLockAnimation()
    {
        yield return new WaitForSeconds(2.2f);
        //A gap of two seconds
        Debug.Log("This part is causing the problem");
        StartCoroutine("LockAndUnlock");
        
    }
    */
    
    private void Update()
    {
        Max_HealthLevel = multiplier_script.multiplier_value * 100*0.75f;
        HealthFillImg.fillAmount = Mathf.Lerp(HealthFillImg.fillAmount, Current_HealthLevel/Max_HealthLevel, LerpSpeed * Time.deltaTime);

        if (clear_food == true)
        {
            Spawner_new spawnscript = spawnner.GetComponent<Spawner_new>();

            spawnscript.enabled = false;
            spawnner.SetActive(false);

            PauseandRestartPanel.enabled = false;

            DelAllRemFood();
            clear_food = false;
        }

        if (HealthFillImg.fillAmount >= 1 && whichHealth < 3)
        {

            //Player has cleared first multiplier value and moved to next
            multiplier_script.multiplier_value++;
            Current_HealthLevel = 1;

            Boom.Play();

            UnlockedFruit.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);

            //Animation to get the Lock and Unlocked Fruit up
            LockandUnlockFruit.Play("UnlockedFruitSwipeUp");

            Debug.Log("Health fillmaount is " + HealthFillImg.fillAmount);
            Debug.Log("Pressed Restart and I bring the food down ... Error ");

            //Wait for sometime and then play the animation which brings back the lock and the star
            //StartCoroutine("WaitforLockAnimation");
            StartCoroutine("LockAndUnlock");

        }

    }

    IEnumerator ParticleBoom()
    {
        yield return new WaitForSeconds(1f);
    }

    //NEW ADDITIONS FOR COMPACT SCRIPT FROM OTHER SCRIPTS
    //1) STOP FOOD AT DEATH

    public void ExplicitRetryHealthFix()
    {
        Current_HealthLevel = 1;
    }

    void DelAllRemFood()
    {
        GameObject[] fooditems_bad;
        GameObject[] fooditems_good;

        fooditems_bad = GameObject.FindGameObjectsWithTag("Bad_Food_Normal");
        fooditems_good = GameObject.FindGameObjectsWithTag("Good_Food_Normal");

        foreach (GameObject food in fooditems_bad)
        {
            Destroy(food);
        }

        foreach (GameObject food in fooditems_good)
        {
            Destroy(food);
        }
    }

}