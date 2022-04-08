using System;
using CMF;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //Two of the torch
    //For now only torch defines if the player can light up other objects
    public enum MyEnum
    {
        WithTorch,
        Without
    }

    [Header("General")] 
    [SerializeField]
    private AdvancedWalkerController
        controller; //We need this reference to restrict axis movement while dragging or pushing
    private UIManager ui; //Referemce to the ui manager to use methods declared there

    [Header("Raycast")] 
    public Transform rayPoint; //From where ray is being cast forward
    private TurnTowardControllerVelocity TTCV; //Reference to the controller that is responsible for turning player model
    [SerializeField] private float rayDistance = .5f; //pretty  self explanatory 

    [Header("Dragging")] 
    public Transform playerParent; //Object which will be the parent of the box and drag it along
    private Transform currentBox; //Reference to the box to attach and detach the correct box

    [Header("Torch")]
    public MyEnum state;
    public GameObject torchGO; //torch gameobject, for visual representation and FireAbove check


    private void Awake()
    {
        TTCV =
            GetComponentInChildren<TurnTowardControllerVelocity
            >(); //TurnTowardControllerVelocity is located on the child object

        //If we didn't set the reference manually script will grab it from the current gameObject
        if (controller != null)
            return;
        controller = gameObject.GetComponent<AdvancedWalkerController>();
    }

    private void Start()
    {
        //I get instance in the start() because in awake this script can load first
        //and it won't be able to find reference anymore
        ui = UIManager.instance;
    }

    void Update()
    {
        //Cast ray from the raypoint transform and draw it in scene mode as debug
        //Distance for the actual ray will be different than the one for the debug
        RaycastHit hit;
        Debug.DrawRay(rayPoint.transform.position, rayPoint.forward, Color.green);
        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            //for easier access git gameobject is stored on local variable
            GameObject go = hit.collider.gameObject;
            //since we might compare tag later on it is also stored in local variable as a string
            var tag = go.tag;
            if (go==null)
            {
             ReleaseBox();           
            }
            switch (tag)
            {
                //if it wasn't interactable hide ui tip just in case
                //TODO find where to replace repeated GetButton call
                default:
                    ui.HideTip();
                    ReleaseBox();
                    break;
                case "Box":
                    ui.ShowTip();
                    //When player holds space the box is attached to the parent transform
                    if (Input.GetButtonDown("Jump"))
                        PickUpBox(go.transform);
                    //When player releases the button box becomes immovable again and detaches from the player
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
                    if (Input.GetButtonDown("Jump"))
                        GrabTorch();
                    break;

                case "SSButton":
                    if (Input.GetButtonDown("Jump"))
                        go.GetComponent<enterButton>().StartSimonSaysGame();
                    break;

                case "SSBoxes":
                    if (Input.GetButtonDown("Jump"))
                        go.GetComponent<enterButton>().ChangeColor();
                    break;

                case "FirePlace":
                    ui.ShowTip();
                    //If player doesn't have torch - do nothing
                    if (state == MyEnum.Without)
                        return;
                    //if he has - light up fireplace
                    if (Input.GetButtonDown("Jump"))
                        go.GetComponent<Fire>().InteractWithFire();
                    break;
            }
        }
        else
        {
            //Raycast hit nothing? Hide tip and do nothing
            //ui.HideTip();
            ReleaseBox();
        }
    }

    void PickUpBox(Transform box)
    {   //get the box reference from the object that ray hit an zero out it's position
        currentBox = box;
        currentBox.position.Set(0, 0, 0);
        //set parent to the object we specified
        currentBox.parent = playerParent;
        //check the player facing direction and based on that restrict movement on one of the axis
        int y = Mathf.FloorToInt(playerParent.transform.eulerAngles.y); 
        TTCV.enabled = false;
    }
    
    //turn of everything we can to reset th box and controller states
    private void ReleaseBox()
    {
        GetComponentInChildren<TurnTowardControllerVelocity>().enabled = true;
        controller.ignoreHorizontal = false;
        controller.ignoreVertical = false;
        if (currentBox == null)
        {
            return;
        }
        currentBox.parent = null;
        currentBox = null;
    }
    
    //Change player torch state and activate torch gameobject
    void GrabTorch()
    {
        if (state == MyEnum.WithTorch)
            return;
        state = MyEnum.WithTorch;
        torchGO.SetActive(true);
        torchGO.GetComponent<IgniteFireAbove>().enabled = true;
    }

    public void ChangeTorchState(string updatedState)
    {

        object parsed = Enum.Parse(typeof(MyEnum), updatedState);
        state = (MyEnum) parsed;
    }
}
