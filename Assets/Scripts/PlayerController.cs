using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState { IDLE, CASTING, BAIT, REELING, CAUGHT, TIMEOUT, END };
    public PlayerState currState = PlayerState.IDLE;

    public LineRenderer lineRend;
    public Transform tfRodEnd;
    public Transform tfHook;

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState)
        {
            case PlayerState.IDLE:
                break;

            case PlayerState.CASTING:
                break;

            case PlayerState.BAIT:
                break;

            case PlayerState.REELING:
                break;

            case PlayerState.CAUGHT:
                break;

            case PlayerState.TIMEOUT:
                break;

            default:
                break;
        }

        lineRend.SetPosition(0, tfRodEnd.position);
        lineRend.SetPosition(1, tfHook.position);
    }

    void Idle()
    {
        
    }

    void Casting()
    {

    }

    void Bait()
    {

    }

    void Reeling()
    {

    }

    void Caught()
    {

    }

    void Timeout()
    {

    }

    void End()
    {

    }

}
