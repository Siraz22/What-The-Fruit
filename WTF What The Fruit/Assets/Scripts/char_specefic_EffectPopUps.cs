using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class char_specefic_EffectPopUps : MonoBehaviour {

    public static char_specefic_EffectPopUps Instance { get; set; }
    public string characterNameString = "naruto_naruto";
    [Header("Effects")]
    public GameObject CaptainAmericaShield;
    public GameObject WolverinePs;
    public GameObject WolverineScratch;
    public GameObject BatmanPs;
    public GameObject JohnnyBravo;
    public GameObject BatmanCape;
    public GameObject HarryPotter;
    public GameObject NarutoPuff;
    public GameObject SantaGifts;
    public GameObject Goku_SaiyanElectric;
    public GameObject Goku_SuperSaiyanElectric;
    public GameObject Goku_UltraInstinctElectric;


    [Header("Sounds")]
    public AudioClip jackSparrow;
    public AudioClip harryPotterSound;
    public AudioClip NarutoPuffDown;
    public AudioClip NarutoPuffUp;
    public AudioClip SantaSound;
    public AudioClip gokuUpDown;

    [Header("All Time Effects")]
    public GameObject king;
    public GameObject UltraInstinct;
    public GameObject SuperSaiyan;
    public GameObject Saiyan;


    AudioSource audioSource;
    public Transform SpawnPointForEffect;



    public GameObject publicvfxtodestroy;
	// Use this for initialization
	void Start () {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        characterNameString = GetComponent<SkeletonAnimation>().skeleton.skin.ToString();
  
    }
    public void UpDownEffects(string UpOrDown)
    {

        if (characterNameString == "naruto_naruto" || characterNameString == "naruto_sasuke" || characterNameString == "naruto_hinata")
        {
            var vfx = (GameObject)Instantiate(NarutoPuff, SpawnPointForEffect.position, Quaternion.identity);

            if (UpOrDown == "Up")
            {
                audioSource.clip = NarutoPuffUp;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = NarutoPuffDown;
                audioSource.Play();
            }
            Destroy(vfx, 1f);
        }
        if (characterNameString == "santa_claus")
        {
            var vfx = (GameObject)Instantiate(SantaGifts, SpawnPointForEffect.position, Quaternion.identity);
            PlayTheSound(SantaSound);
            Destroy(vfx, 3f);
        }
        if (characterNameString == "dbz_ultrainstinct" || characterNameString == "dbz_saiyan" || characterNameString == "dbz_supersaiyan")
        {
            PlayTheSound(gokuUpDown);
        }
        if (characterNameString == "harry_potter")
        {
            var vfx = (GameObject)Instantiate(HarryPotter, SpawnPointForEffect.position, Quaternion.identity);
            //PlayTheSound();
            Destroy(vfx, 1f);
        }
        if (characterNameString == "superhero_batman")
        {
            var vfx = (GameObject)Instantiate(BatmanPs, SpawnPointForEffect.position, Quaternion.identity);
            //PlayTheSound();
            Destroy(vfx, 1f);
            var cape = (GameObject)Instantiate(BatmanCape, SpawnPointForEffect.position, Quaternion.identity);
            cape.transform.SetParent(gameObject.transform);
            Destroy(cape, 1f);
        }
        if (characterNameString == "superhero_wolverine")
        {
            var vfx = (GameObject)Instantiate(WolverinePs, SpawnPointForEffect.position, Quaternion.identity);
            //PlayTheSound();
            Destroy(vfx, 1f);
            if (UpOrDown == "Up")
            {
                var cape = (GameObject)Instantiate(WolverineScratch, SpawnPointForEffect.position, Quaternion.identity);
                Destroy(cape, 0.5f);
            }
            if (UpOrDown == "Down")
            {
                Vector3 rot = new Vector3(0.5089153f, -0.5089153f, 0.5089153f);
                var cape = (GameObject)Instantiate(WolverineScratch, SpawnPointForEffect.position, Quaternion.identity);
                cape.transform.localScale = rot;
                Destroy(cape, 0.5f);
            }
            //cape.transform.SetParent(gameObject.transform);

        }
        if (characterNameString == "superhero_captainamerica")
        {
            var vfx = (GameObject)Instantiate(CaptainAmericaShield, SpawnPointForEffect.position, Quaternion.identity);
            vfx.transform.SetParent(gameObject.transform);
            //PlayTheSound();
            Destroy(vfx, 0.6f);

        }
        if (characterNameString == "johnny_bravo")
        {
           // PlayTheSound(johnnyBravoShine);
            var vfx = (GameObject)Instantiate(JohnnyBravo, transform.position, Quaternion.identity);
            vfx.transform.SetParent(gameObject.transform);
            Destroy(vfx, 1f);
        }
      

    }
    public void AllTimeEffect() // It is called on click on Tap To Start
    {
        if(characterNameString=="dbz_ultrainstinct")
        {
            var vfx = (GameObject)Instantiate(UltraInstinct, SpawnPointForEffect.position, Quaternion.identity);
            vfx.transform.SetParent(gameObject.transform.parent.transform);
            publicvfxtodestroy = vfx;
        }
        if (characterNameString == "dbz_saiyan")
        {
            var vfx = (GameObject)Instantiate(Saiyan, SpawnPointForEffect.position, Quaternion.identity);
            vfx.transform.SetParent(gameObject.transform.parent.transform);
            publicvfxtodestroy = vfx;
        }
        if (characterNameString == "dbz_supersaiyan")
        {
            var vfx = (GameObject)Instantiate(SuperSaiyan, SpawnPointForEffect.position, Quaternion.identity);
            vfx.transform.SetParent(gameObject.transform.parent.transform);
            publicvfxtodestroy = vfx;
        }
        if (characterNameString == "harry_potter")
        {
            PlayThemeNStopBGMusic(harryPotterSound);
        }
        if (characterNameString == "crown")
        {
            var vfx = (GameObject)Instantiate(king, SpawnPointForEffect.position, Quaternion.identity);
            vfx.transform.SetParent(gameObject.transform.parent.transform);
            publicvfxtodestroy = vfx;
        }
        if (characterNameString == "jack_sparrow")
        {
            PlayThemeNStopBGMusic(jackSparrow);
        }
    }
    
    void PlayTheSound(AudioClip clip)
    {
        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void DestroyCurrentEffects()
    {
        Destroy(publicvfxtodestroy, 0f);
        audioSource.Stop();
    }
    void PlayThemeNStopBGMusic(AudioClip clip)
    {
        audioSource.loop = true;
        audioSource.clip = clip;
        audioSource.Play();
        Audio.Instance.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Stop();
        
    }
    
}
