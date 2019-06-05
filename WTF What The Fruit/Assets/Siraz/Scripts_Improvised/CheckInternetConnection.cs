using UnityEngine;
using System.Collections;
using System.Net;
using System;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class CheckInternetConnection : MonoBehaviour
{

    public Button RetryConnection;

    public bool NetworkFound = false;
    
    public Button[] AdButtons;
    public TextMeshProUGUI[] CheckNetTEXT;

    public string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {

                    using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        //We are limiting the array to 80 so we don't have
                        //to parse the entire html document feel free to 
                        //adjust (probably stay under 300)
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }

    public void AdIsInitialized()
    {
        CheckNetTEXT[0].text = "Watch Ad\n\n\n\nOr";
        CheckNetTEXT[1].text = "Watch Ad\n\n\n\nOr";

        foreach (Button Adbutton in AdButtons)
        {
            Adbutton.interactable = true;
        }

        RetryConnection.gameObject.SetActive(false);
    }

    public void CheckNetwork()
    {
        string HtmlText = GetHtmlFromUri("http://google.com");
        if (HtmlText == "")
        {
            //No connection
            Debug.Log("Connection Not Found");

            CheckNetTEXT[0].text = "\n\n\n\nConnection Not Found for Ad Reward";
            CheckNetTEXT[1].text = "\n\n\n\nConnection Not Found for Ad Reward";

            foreach (Button Adbutton in AdButtons )
            {
                Adbutton.interactable = false;
            }

            RetryConnection.gameObject.SetActive(true);

        }
        else if (!HtmlText.Contains("schema.org/WebPage"))
        {
            //Redirecting since the beginning of googles html contains that 
            //phrase and it was not found
        }
        else
        {
            NetworkFound = true;
            //success
            Debug.Log("Connection Found");
        }
    }
}
