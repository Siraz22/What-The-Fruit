using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
public class SpawnPopUp : MonoBehaviour {
    public GameObject popUP;
    public GameObject diamondsPop;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnPopUPfunction(int fillvalue)   // For text information on what is the amount
    {
        int x = fillvalue;
        GameObject popUpGameObject = (GameObject)Instantiate(popUP, transform.position, transform.rotation);
        TextMesh popupText = popUpGameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>();
        popupText.text = "+" + x.ToString();
        Destroy(popUpGameObject, 2f);
    }
    public void DiamondsPopUpfunction(int numberofdiamonds)  //  Yeh particle system wala hai
    {
        ParticleSystem ps = diamondsPop.GetComponent<ParticleSystem>();
        //ps.emission.SetBurst(0, new ParticleSystem.Burst(0, numberofdiamonds));
        ParticleSystem.Burst bursttt = ps.emission.GetBurst(0);
        if (numberofdiamonds < 5)
        {
            bursttt.count = numberofdiamonds;
        }
        else
        {
            bursttt.count = 5;
        }
        ps.emission.SetBurst(0, bursttt);
        GameObject popUpGameObject = (GameObject)Instantiate(diamondsPop, transform.position, transform.rotation);
       // Destroy(popUpGameObject, 0.7f);
    }
	public IEnumerator BigBite()
	{
		SkeletonAnimation skel = GetComponent<SkeletonAnimation>();
		skel.AnimationName = "bigbite";
		skel.loop = false;
		yield return new WaitForSeconds(0.41f);
		skel.loop = true;
		skel.AnimationName = "Biting";

	}

}
