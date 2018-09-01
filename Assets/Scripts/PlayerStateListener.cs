using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateListener : MonoBehaviour {

    public float playerWalkSpeed = 0.5f;
    private PlayerStateController.playerStates currentState =
        PlayerStateController.playerStates.idle;

    void OnEnable()
    {
        PlayerStateController.onStateChange += onStateChange;
    }

    void OnDisable()
    {
        PlayerStateController.onStateChange -= onStateChange;
    }

    void LateUpdate()
    {
        onStateCycle();
    }

    // Every cycle of the engine, process the current state.
    void onStateCycle()
    {
        switch(currentState)
        {
            case PlayerStateController.playerStates.idle:
                break;

            case PlayerStateController.playerStates.left:
                transform.Translate(new Vector3((playerWalkSpeed * -1.0f) * Time.deltaTime,
                    0.0f, 0.0f));
                break;

            case PlayerStateController.playerStates.right:
                transform.Translate(new Vector3(playerWalkSpeed * Time.deltaTime,
                    0.0f, 0.0f));
                break;
        }
    }

    // onStateChange is called whenever we make a change to the player's state 
    // from anywhere within the game's code.
    public void onStateChange(PlayerStateController.playerStates newState)
    {
        playerWalkSpeed = 100f;
        // If the current state and the new state are the same, abort - no
        // need to change to the state we're already in.
        if (newState == currentState)
             return;

        // Check if the current state is allowed to transition into // this
        // state.If it's not, abort.
        if (!checkForValidStatePair(newState))
            return;

        // Having reached here, we now know that this state change is
        // allowed.So let's perform the necessary actions depending
        // on what the new state is.
        switch (newState)
        {
            case PlayerStateController.playerStates.idle:
                break;
            case PlayerStateController.playerStates.left:
                break;
            case PlayerStateController.playerStates.right:
                break;
        }

        // And finally, assign the new state to the player object
        currentState = newState;
    }

    // Compare the desired new state against the current, and see if we are 
    // allowed to change to the new state. This is a powerful system that ensures 
    // we only allow the actions to occur that we want to occur.
    bool checkForValidStatePair(PlayerStateController.playerStates newState)
    {
        bool returnVal = false;

        // Compare the current against the new desired state.
        switch(currentState)
        {
            case PlayerStateController.playerStates.idle:
                // Any state can take over from idle.
                returnVal = true;
                break;
            case PlayerStateController.playerStates.left:
                // Any state can take over from the player moving // left.
                returnVal = true;
                break;
            case PlayerStateController.playerStates.right:
                // Any state can take over from the player moving // right.
                returnVal = true;
                break;
        }
        return returnVal;
    }

    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */
}
