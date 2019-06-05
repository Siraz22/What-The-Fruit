using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPositionAtRetry : MonoBehaviour
{

    public GameObject ResetPos;
    public GameObject Player;

    public void ResetPosition()
    {
        Player.transform.position = ResetPos.transform.position;
    }
}
