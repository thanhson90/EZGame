using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{

    private enum ObjectTag
    {
        EndPoint,
        Ball,
        Key
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCharacter trigger : " + other.tag);
        if (Enum.TryParse(other.tag, out ObjectTag tag))
        {
            switch (tag) 
            {
                case ObjectTag.Ball:
                    GameLogic.Instance.OnTouchBall();
                    break;
                case ObjectTag.Key:
                    GameLogic.Instance.OnTouchKey();
                    break;
                case ObjectTag.EndPoint:
                    GameLogic.Instance.OnTouchEndPoint();

                    break;
            }
        }

    }
}
