using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PreloadingLevel : MonoBehaviour {

    public Slider slider;
    public Button btn;
    AsyncOperation publicMain;
    public GameObject[] gos;
    private void Awake()
    {
       
    }

    // Use this for initialization
    public void Start()
    {
        gos =  SceneManager.GetActiveScene().GetRootGameObjects();
        StartCoroutine(LoadSceneAsynchronously());
    }


    public void ActivateTheScene()
    {
        
        publicMain.allowSceneActivation = true;
        foreach(GameObject go in gos)
        {
            Destroy(go, 0f);
        }
    }

    

 
    IEnumerator LoadSceneAsynchronously()
    {
        AsyncOperation MainSceneLoading = SceneManager.LoadSceneAsync("New_Improvise", LoadSceneMode.Additive);
        publicMain = MainSceneLoading;
        MainSceneLoading.allowSceneActivation = false;
        while(MainSceneLoading.progress<0.9f)
        {
           // Mathf.Lerp(slider.value, MainSceneLoading.progress / 0.9f, Time.deltaTime*5f);
            slider.value = MainSceneLoading.progress/0.9f;
        }
        if(MainSceneLoading.progress >= 0.9f)
        {
            if (btn.interactable == false)
            {
                btn.interactable = true;
            }
        }
        
        yield return null;
    }
}
