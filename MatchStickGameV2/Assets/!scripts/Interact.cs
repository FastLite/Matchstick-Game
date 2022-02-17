using System;
using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public enum MyEnum
    {
        WithTorch,Without
    }
    
    public Transform playerParent;
    public Transform rayPoint;
    public Transform currentBox;
    public AdvancedWalkerController controller;
    private TurnTowardControllerVelocity TTCV;
    private UIManager ui;
    
    [Header("Torch")]
    public MyEnum state;
    public GameObject torchGO;


    private void Awake()
    {
        TTCV = GetComponentInChildren<TurnTowardControllerVelocity>();
        
    }

    private void Start()
    {
        ui =UIManager.instance;
        
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(rayPoint.transform.position, rayPoint.forward, Color.green);
        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, .5f ))
        {
            GameObject go = hit.collider.gameObject;

            var tag = go.tag;
            switch (tag)
            {
                default:
                    ui.HideTip();
                    break;
                case "Box":
                    ui.ShowTip();
                    if (Input.GetButtonDown("Jump"))
                        PickUpBox(go.transform);
                    if (Input.GetButtonUp("Jump"))
                        ReleaseBox();
                    break;
                
                case "Button":
                    ui.ShowTip();
                    if (Input.GetButtonDown("Jump"))
                        go.GetComponent<enterButton>().Activate();
                    break;
                
                case "TorchPile":
                    ui.ShowTip();
                    if(Input.GetButtonDown("Jump"))
                        GrabTorch();
                    break;
                
                case "SSButton":
                    if(Input.GetButtonDown("Jump"))
                        go.GetComponent<enterButton>().StartSimonSaysGame();
                    break;
                
                case "SSBoxes":
                    if (Input.GetButtonDown("Jump"))
                        go.GetComponent<enterButton>().ChangeColor();
                    break;
                
                case "FirePlace":
                    ui.ShowTip();
                    if (state == MyEnum.Without)
                     return;
                    if (Input.GetButtonDown("Jump"))
                        go.GetComponent<Fire>().InteractWithFire();
                    break;
            }
        }
        
    }

    void PickUpBox(Transform box)
    {
        currentBox = box;
        currentBox.position.Set(0,0,0);
        currentBox.parent = playerParent;
        int y = Mathf.FloorToInt(playerParent.transform.eulerAngles.y) ;
        TTCV.enabled = false;
        if ((y< 95 && y >85) ||(y> 265 && y <280 ))
        {
            controller.ignoreHorizontal = true;
        }
        else if ((y> -1 && y <2) || (y >175 && y <185))
        {
            controller.ignoreVertical = true;
        }
    }
    private void ReleaseBox()
    {
        if (currentBox ==null)
        {
            return;
        }
        GetComponentInChildren<TurnTowardControllerVelocity>().enabled = true;
        controller.ignoreHorizontal = false;
        controller.ignoreVertical = false;
        currentBox.parent = null;
        currentBox = null;
    }

    void GrabTorch()
    {
        if (state == MyEnum.WithTorch)
            return;
        state = MyEnum.WithTorch;
        torchGO.SetActive(true);
        torchGO.GetComponent<IgniteFireAbove>().enabled = true;

    }

}
