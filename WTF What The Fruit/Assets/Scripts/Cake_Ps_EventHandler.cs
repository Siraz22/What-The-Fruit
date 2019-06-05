using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
public class Cake_Ps_EventHandler : MonoBehaviour {
	public ParticleSystem psSprinkle1;
	public ParticleSystem psSprinkle2;
	// Use this for initialization
	void Start(){
		SkeletonAnimation anim = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<SkeletonAnimation>();
		anim.state.Event += HandleEvent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void HandleEvent(Spine.TrackEntry entry ,Spine.Event e)
	{

		if(e.Data.name == "Sprinkle")
		{
			psSprinkle1.Play();
			psSprinkle2.Play();
		}
	}
}
