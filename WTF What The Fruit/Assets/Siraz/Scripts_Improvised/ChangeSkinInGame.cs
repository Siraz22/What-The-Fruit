using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class ChangeSkinInGame : MonoBehaviour
{

    public string[] SkinID_toSkinName;

    string ChosenSkinName = "superhero_wolverine";

    public SkeletonAnimation skeletonPlayer;

    private void Awake()
    {
        ChosenSkinName = SkinID_toSkinName[PlayerPrefs.GetInt("SkinID", 0)];
    }

    // Use this for initialization
    public void Change()
    {
        ChosenSkinName = SkinID_toSkinName[PlayerPrefs.GetInt("SkinID", 0)];
        
        skeletonPlayer.Skeleton.SetSkin(ChosenSkinName);     
    }
	
}
