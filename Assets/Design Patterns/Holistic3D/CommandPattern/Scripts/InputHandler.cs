using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    Animator anim;
    Command KeyQ, KeyW, KeyE;

    // Start is called before the first frame update
    void Start()
    {
        KeyQ = new PerformJump();
        KeyW = new PerformKicking();
        KeyE = new PerformPunch();

        anim = actor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            KeyQ.Execute(anim);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            KeyW.Execute(anim);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            KeyE.Execute(anim);
        }
    }
}
