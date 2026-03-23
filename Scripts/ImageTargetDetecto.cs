using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Android;
using System.Runtime.Serialization;
using UnityEngine.UI;

public class ImageTargetDetecto : MonoBehaviour
{
    public Button shiyongzhong;
    public Button benci;
    public Button jujue;
    
    void Start()
    {
        ImageTargetBehaviour imageTarget = GetComponent<ImageTargetBehaviour>();

        shiyongzhong.onClick.AddListener(() =>
        {
            imageTarget.enabled = false;
        });

        benci.onClick.AddListener(() =>
        {
            imageTarget.enabled = true;
        });

        jujue.onClick.AddListener(() =>
        {
            imageTarget.enabled = true;
        });
        //VuforiaApplication.Instance.OnVuforiaStarted += ActivateTarget;


    }

    //void ActivateTarget()
    //{
    //    ImageTargetBehaviour imageTarget = GetComponent<ImageTargetBehaviour>();
    //    imageTarget.enabled = true;
    //}
    void Update()
    {
        
    }
}
