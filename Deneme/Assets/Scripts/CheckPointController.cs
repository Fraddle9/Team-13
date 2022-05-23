using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public bool checkpointReached;
    private PlayerManager playerManager;
    private PlayerController playerController;

    //Animations
    private Animator animator;
    private string currentState;
    const string idle = "CheckPoint";
    const string activated = "CheckPointActivated";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimations();
        SetCheckpoint();
    }

    void ChangeAnimations()
    {

        if (checkpointReached)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ChangeAnimationState(activated);
            }

        }
    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    void SetCheckpoint()
    {
        if (checkpointReached)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                playerManager.currentCheckPoint = gameObject;
                Debug.Log("Checkpoint Degisti");
            }
        }
        if(!checkpointReached)
        {
            if(playerManager.currentCheckPoint != gameObject)
            {
                ChangeAnimationState(idle);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointReached = true;
            playerController.inCheckpointRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointReached = false ;
            playerController.inCheckpointRange = false;
        }
    }

}
