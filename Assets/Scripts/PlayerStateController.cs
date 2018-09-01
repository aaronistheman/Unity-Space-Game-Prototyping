using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour {

    public enum playerStates
    {
        idle = 0,
        left,
        right,
        jump,
        landing,
        falling,
        kill,
        resurrect
    }

    public delegate void playerStateHandler(PlayerStateController.playerStates newState);

    public static event playerStateHandler onStateChange;

    public float horizontal;
    
    void LateUpdate()
    {
        // Detect the current input of the Horizontal axis, then
        // broadcast a state update for the player as needed.
        // Do this on each frame to make sure the state is always
        // set properly based on the current user input.
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0f)
        {
            if(horizontal < 0f)
            {
                if (onStateChange != null)
                    onStateChange(PlayerStateController.playerStates.left);
            }
            else
            {
                if (onStateChange != null)
                    onStateChange(PlayerStateController.playerStates.right);
            }
        }
        else
        {
            if (onStateChange != null)
                onStateChange(PlayerStateController.playerStates.idle);
        }
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
