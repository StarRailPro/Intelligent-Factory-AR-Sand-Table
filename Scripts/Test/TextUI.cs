using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public Button btnStart;
    public GameObject barCode;
    public GameObject image;
    public Button btnClose;
    void Start()
    {
        btnStart.onClick.AddListener(() =>
        {
            barCode.SetActive(true);
            image.SetActive(true);
        });

        btnClose.onClick.AddListener(() => 
        {
            barCode.SetActive(false);
            image.SetActive(false);
        });
    }

    
}
