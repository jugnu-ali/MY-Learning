using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SetBits : MonoBehaviour
{
    int bSequence = 128 + 32 + 8 + 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Convert.ToString(bSequence, 2));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
