using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInput : MonoBehaviour
{
    public Action<Vector2> MovingInputCallback;

    private Vector2 currentInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("press W");
            // currentInput.z  =
        }
    }
}
