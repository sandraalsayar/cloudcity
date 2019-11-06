using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Transition : MonoBehaviour
{
    private Animator anim;
    public int random_value;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(WaitUntilAnimEnds());
     
    }

    IEnumerator WaitUntilAnimEnds()
    {
        //normalizedTime: A value of 1 is the end of the animation. A value of 0.5 is the middle of the animation.
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }
     
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Happy Hand Gesture"))
        {
            random_value = Random.Range(11, 13);
            // Debug.Log("current state is happy hand gesture");
        } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Looking Behind"))
        {
            random_value = Random.Range(21, 23);
        } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Happy Idle"))
        {
            random_value = Random.Range(31, 33);
        } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Excited"))
        {
            random_value = Random.Range(41, 43);
        } else
        {
            Debug.Log("Cannot find current animator state");
        }

        anim.SetInteger("random_transition", random_value);
    }
}
