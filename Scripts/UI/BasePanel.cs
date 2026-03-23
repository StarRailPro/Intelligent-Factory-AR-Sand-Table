using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    //控制面板淡入淡出的组件
    private CanvasGroup canvasGroup;
    //面板淡入淡出速度
    private float alphaSpeed = 10;
    //开始显示
    private bool isShow;
    private UnityAction hideCallBack;

    
    protected virtual void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        if (canvasGroup == null )
        {
            canvasGroup=this.gameObject.AddComponent<CanvasGroup>();   
        }
    }

    void Start()
    {
        
        Init();
    }
    public abstract void Init();

    public virtual void Show()
    {
        isShow= true;
        canvasGroup.alpha = 0;
    }

    public virtual void Hide(UnityAction callBack)
    {
        isShow = false;
        canvasGroup.alpha = 1;
        hideCallBack = callBack;
    }

    
    
    protected virtual void Update()
    {
        //淡入
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if(canvasGroup.alpha>=1)
                canvasGroup.alpha = 1;  
        }
        else if(!isShow)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;   
            if (canvasGroup.alpha<=0)
            {
                canvasGroup.alpha = 0;
                hideCallBack?.Invoke();
            }
        }

       
        

    }
}
