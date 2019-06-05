using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleWTF : MonoBehaviour
{

    public float scaleRate = 1.0f;
    public float minScale = 775.0f;
    public float maxScale = 1.0f;

    // Update is called once per frame
    void Update ()
    {
        Scale();
	}

  
    private void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate;
    }

    public void Scale()
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }
    
}
