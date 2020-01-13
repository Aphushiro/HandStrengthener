﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBehavior : MonoBehaviour
{

    [SerializeField]
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y+0.05f, this.transform.eulerAngles.z);
    }

    public void onGameDecision(InputTypes inputType) {
        if (inputType == InputTypes.AcceptAllInput) {
            ActivateSuccessFeedback();
            Debug.Log("Showing Feedback from Real Input.");
        } else if (inputType == InputTypes.FabInput) {
            ActivateSuccessFeedback();
            Debug.Log("Showing Feedback from Fabricated Input.");
        }

    }

    public void ActivateSuccessFeedback() {
        StartCoroutine("Squeeze");
        //anim.Play("ballSqueeze");

    }

    public void ActivateBioFeedback() {
        anim.Play("SmallSqueeze");
    }

    // TODO: Present a stimuli

    IEnumerator Squeeze() {
        //transform.localScale = new Vector3(0.5f,1f,1f);
        yield return new WaitForSeconds(0.02f);
        anim.Play("Squeezed");
        //Reset();
    }

    public void Reset() {
        transform.localScale = new Vector3(1f,1f,1f);
    }
}