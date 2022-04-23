using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDemo : MonoBehaviour
{
    // Vars
    public Animator CharacterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            CharacterAnimator.SetBool("IsRunning", true);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            CharacterAnimator.SetBool("IsRunning", false);
        }
    }
}
