using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARcontroller : MonoBehaviour
{
    public Camera ARcam;
    public Button btn;

    private float noFiv = 2f;
  
    void Start()
    {
        if (ARcam == null)
        {
            ARcam.fieldOfView = noFiv;
        }

        btn.onClick.AddListener(() =>
        {
            ARcam.fieldOfView = 60f;
        });
        
    }

    
}
