using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_VFX_FromTO : MonoBehaviour {
    ShopManager shopmanagerScript;
    public GameObject clickedVFX, GlowVFX, ThingToSpawn, originButton, Destination,parentForObject,RetryButton, BackButton;
    public iTween.EaseType easeType;
    Vector3 offset;
    public float time, rate, amount;
    public bool giftReward;



	// Use this for initialization
	void Start () {
        shopmanagerScript = ShopManager.Instance;
	}
	
	public void SpawnGlowVFX()
    {
        if(GlowVFX != null)
        {
            //CAMERA SHAKE
            EZCameraShake.CameraShaker.Instance.ShakeOnce(8f, 10f, 0.1f, 1f);
            var vfx = (GameObject)Instantiate(GlowVFX, originButton.transform.position, Quaternion.identity);
            vfx.transform.SetParent(parentForObject.transform);
            Destroy(vfx, 0.71f);
            
        }
    }
	void Update () {
		if(Input.GetKeyUp(KeyCode.A))
        {
            FROMTO();
        }
	}
    public void FROMTO()
    {
        StartCoroutine("FROM");
    }
    IEnumerator FROM()
    {
        for(int i =0; i<amount; i++)
        {
            var VFX = (GameObject)Instantiate(ThingToSpawn, originButton.transform.position, Quaternion.identity);
            VFX.transform.SetParent(parentForObject.transform);
            yield return new WaitForSeconds(0.3f);
            iTween.MoveTo(VFX, iTween.Hash("position",Destination.transform.position + offset , "easytype" ,easeType ,"ignoretimescale",true,"time",time ));
            Destroy(VFX, time);
            yield return new WaitForSeconds(rate);
        }
        originButton.SetActive(false);
        ShopManager.Instance.AddDiamond(shopmanagerScript.EarningDiamonds);
        Debug.Log("vfx wali script se kara add");
        
        if (giftReward != true)
        {
            RetryButton.SetActive(true);
        }
        if(giftReward==true)
        {
            BackButton.SetActive(true);
        }
        //Make the coin increase explosion here
    }
    public void DAILYGIFTCOINS()
    {
        shopmanagerScript.AddDiamond(400);
    }
}
