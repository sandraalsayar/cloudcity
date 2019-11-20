using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo: camera collision w walls

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
    public bool nearPlant;

    //for enhanced character camera movement
    private float speed = 0.0f;
    private float direction = 0f;
    [SerializeField]
    CameraFollow gamecam;
    [SerializeField]
    private float directionSpeed=1.0f;
    private int locomotionId = 0;
    [SerializeField]
    private float rotationDegreePerSecond = 120f;
    private AnimatorStateInfo stateInfo;

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
    public bool ActionThrow
    {
        get;
        private set;
    }

    public float Speed
    {
        get{
            return this.speed;
        }

    }
    public float LocomotionThreshold
    {
        get
        {
            return 0.2f;
        }

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

    float forwardVelocity = 0;
    float sidewaysVelocity = 0;

    public float movementSmoothing = 0.15f;


    float h;
    float v;

    void Start(){
        // Reference to the starcollector
        starCollector = GetComponent<StarCollector>();
        anim = GetComponent<Animator>();

        locomotionId = Animator.StringToHash("Base Layer.BlendTreeForward");

    }
    void Update()
    {

        if (anim)
        {
            stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        }
        //GetAxisRaw() so we can do filtering here instead of the InputManager
        //h = Input.GetAxisRaw("Horizontal");// setup h variable as our horizontal input axis
        v = Input.GetAxisRaw("Vertical"); // setup v variables as our vertical input axis
        h = Input.GetAxisRaw("Horizontal");
        speed = v;
        direction = h;

        if (InputMapToCircular)
        {
            // make coordinates circular
            //based on http://mathproofs.blogspot.com/2005/07/mapping-square-to-circle.html
            //h = h * Mathf.Sqrt(1f - 0.5f * v * v);
            //v = v * Mathf.Sqrt(1f - 0.5f * h * h);

        }

        //do some filtering of our input as well as clamp to a speed limit
        filteredForwardInput = Mathf.Clamp(Mathf.Lerp(filteredForwardInput, v,
            Time.deltaTime * forwardInputFilter), -forwardSpeedLimit, forwardSpeedLimit);

        filteredTurnInput = Mathf.Lerp(filteredTurnInput, h,
            Time.deltaTime * turnInputFilter);


        //Forward = filteredForwardInput;
        //Turn = filteredTurnInput;

        //unfiltered input
        //DONT ALLOW MOVEMENT WHEN @ ENDGAME DIALOGUE
        if(!starCollector.endgame){
            //Forward = v;
            //Turn = h; 
            //Turn = Mathf.SmoothDamp(Turn, h, ref forwardVelocity, movementSmoothing);
            //Forward = Mathf.SmoothDamp(Forward, v, ref sidewaysVelocity, movementSmoothing);

            //mess with this to simulate joystick
            //StickToWorldSpace(this.transform, gamecam.transform, ref direction, ref speed);
            Forward = filteredForwardInput;
            Turn = filteredTurnInput;
            //Forward = speed;
            //Turn = speed;
        }


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
        //ActionInteract = Input.GetButtonDown("Interact") && starCollector.canCollect && !activeAnim;
        //if (ActionInteract)
        //{
        //    activeAnim = true;
        //    anim.SetTrigger("pickUp");
        //    StartCoroutine(WaitForAnim());

        //}

        //Interaction for star collections
        //ActionInteract = Input.GetButtonDown("Interact") && starCollector.canCollect && !activeAnim;
        if (Input.GetButtonDown("Interact") && !activeAnim)
        {
            activeAnim = true;
            //regular collecting the actual star
            if (starCollector.canCollect)
            {
                Debug.Log("isstar");
                anim.SetFloat("interaction", 1.0f);
                anim.SetTrigger("interact");
                StartCoroutine(WaitForAnim());
            }
            //plant interaction
            else if (starCollector.isNearPlant)
            {
                Debug.Log("plant");
                anim.SetFloat("interaction", 2.0f);
                anim.SetTrigger("interact");
                StartCoroutine(WaitForInteract(2.3f));
            }
            //tree interaction
            else if (starCollector.isNearTree)
            {
                Debug.Log("tree");
                anim.SetFloat("interaction", 3.0f);
                anim.SetTrigger("interact");
                StartCoroutine(WaitForInteract(0.0f)); //TODO: adjust time based on anim&whether needed
            }
            //rock interaction
            else if(starCollector.isNearRock)
            {
                Debug.Log("rock");
                anim.SetFloat("interaction", 4.0f);
                anim.SetTrigger("interact");
                StartCoroutine(WaitForInteract(2.3f)); //TODO: adjust time based on anim&whether needed
            }
            else{ //talking/next interaction
                activeAnim = false;
            }
        }
        //throw newspaper if in quest
        // && starCollector.inQuest
        //dont allow rapid pressing
        if (Input.GetKeyDown("s") && starCollector.remainingNews>=1 && starCollector.inQuest)
        {
            Debug.Log("throw");
            anim.SetTrigger("isThrowing");
            //make newspaper fly
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
    IEnumerator WaitForInteract(float time){
        yield return new WaitForSeconds(time);
        starCollector.interacted = true; // used to trigger whatever needs to be done AFTER animation is complete
        activeAnim = false;
    }

    void FixedUpdate(){
        //if(IsInLocomotion() && (direction>=0 && h>=0) || (direction<0 && h<0)){
        //    Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond*(h<0f?-1f:1f),0f), Mathf.Abs(h));
        //    Quaternion deltaRotation = Quaternion.Euler(rotationAmount*Time.deltaTime);
        //    this.transform.rotation = (this.transform.rotation * deltaRotation);
        //}
    }

    public bool IsInLocomotion(){
        Debug.Log("loco");
        return stateInfo.nameHash == locomotionId;
    }

    public void StickToWorldSpace(Transform root, Transform camera, ref float directionOut, ref float speedOut){
        Vector3 rootDxn = root.forward;
        Vector3 stickDxn = new Vector3(h,0,v);
        speedOut = stickDxn.sqrMagnitude;
        Vector3 cameraDxn = camera.forward;
        cameraDxn.y = 0.0f;
        Quaternion refShift = Quaternion.FromToRotation(Vector3.forward, cameraDxn);

        Vector3 moveDirection = refShift * stickDxn;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDxn);
        float angleRootToMove = Vector3.Angle(rootDxn, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);
        angleRootToMove /= 180f;
        directionOut = angleRootToMove * directionSpeed;

    }
}