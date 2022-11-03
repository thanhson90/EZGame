using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum BallMovingDirection
{
    Vertical,
    Horizontal
}

[Serializable]
public class Limit
{
    public float StartPos;
    public float EndPos;
}
public class MovingBall : MonoBehaviour
{
    // [SerializeField]
    // private BallMovingDirection _direction;
    [SerializeField]
    private Limit xLimit;
    [SerializeField]
    private Limit zLimit;

    [SerializeField] private float speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(xLimit.StartPos, transform.localPosition.y, zLimit.StartPos);

        transform.DOMove(new Vector3(xLimit.EndPos, transform.localPosition.y, zLimit.EndPos), 3)
            .SetLoops(-1, LoopType.Yoyo);

    }
    
    

    // Update is called once per frame
    void Update()
    {

    }
    
}
