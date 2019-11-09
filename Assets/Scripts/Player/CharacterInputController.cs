using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{

    public string Name = "Starboy";

    private float filteredForwardInput = 0f;
    private float filteredTurnInput = 0f;

    public bool InputMapToCircular = true;

    public float forwardInputFilter = 3f; //
    public float turnInputFilter = 3f;

    private float forwardSpeedLimit = 1f;
    public int pickUpCounter = 0;

    StarCollector starCollector;
    private Animator anim;
    private bool activeAnim;

    public float Forward
    {
        get;
        private set;
    }

    public float Turn
    {
        get;
        private set;
    }
    public bool ActionInteract
    {
        get;
        private set;

    }
    public bool ActionSneak
    {
        get;
        private set;
    }
    public bool Jump
    {
        get;
        private set;
    }
    //public bool Action
    //{
    //    get;
    //    private set;
    //}
    //public string ActionName
    //{
    //    get;
    //    private set;
    //}



    void Start(){
        // Reference to the starcollector
        starCollector = GetComponent<StarCollector>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        //GetAxisRaw() so we can do filtering here instead of the InputManager
        float h = Input.GetAxisRaw("Horizontal");// setup h variable as our horizontal input axis
        float v = Input.GetAxisRaw("Vertical"); // setup v variables as our vertical input axis


        if (InputMapToCircular)
        {
            // make coordinates circular
            //based on http://mathproofs.blogspot.com/2005/07/mapping-square-to-circle.html
            h = h * Mathf.Sqrt(1f - 0.5f * v * v);
            v = v * Mathf.Sqrt(1f - 0.5f * h * h);

        }

        //do some filtering of our input as well as clamp to a speed limit
        //filteredForwardInput = Mathf.Clamp(Mathf.Lerp(filteredForwardInput, v,
        //    Time.deltaTime * forwardInputFilter), -forwardSpeedLimit, forwardSpeedLimit);

        //filteredTurnInput = Mathf.Lerp(filteredTurnInput, h,
        //    Time.deltaTime * turnInputFilter);

        //Forward = filteredForwardInput;
        //Turn = filteredTurnInput;

        //unfiltered input
        Forward = v;
        Turn = h;

        //If z was pressed and while held, cue sneak action anim
        // ONLY if first star was collected
        if (Input.GetKeyDown(KeyCode.Z) && starCollector.stars[0])
        {
            ActionSneak = Input.GetKeyDown(KeyCode.Z);
        }

        //If z was ever not held, no more sneak
        if (Input.GetKeyUp(KeyCode.Z))
        {
            ActionSneak = false;
        }
        // interact is ONLY button press "Interact"
        // if it's within range of a star(checked by canCollect), let them press X
        // don't allow X to be pressed while it's playing
        ActionInteract = Input.GetButtonDown("Interact") && starCollector.canCollect && !activeAnim;
        if (ActionInteract)
        {
            activeAnim = true;
            anim.SetTrigger("pickUp");
            StartCoroutine(WaitForAnim());

        }
        //if (Input.GetButtonDown("Jump"))
        //{
        //    //anim.SetTrigger("jump");
        //    Jump = true;

        //} else
        //{
        //    Jump = false;
        //}

    }

    // coroutine to make star disappear when animation is done playing
    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1.6f);
        //duration based on anim length but sometimes it's off anim.GetCurrentAnimatorStateInfo(0).length+ anim.GetCurrentAnimatorStateInfo(0).normalizedTime
        starCollector.pickedUp = true;
        activeAnim = false;

    }
}