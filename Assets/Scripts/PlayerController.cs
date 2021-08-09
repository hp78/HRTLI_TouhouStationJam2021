using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public enum PlayerState { IDLE, CASTING, SINK, REELING, CAUGHT, TIMEOUT, END };
    public PlayerState currState = PlayerState.IDLE;

    [Space(5)]
    public PlayerStatSO playerStat;
    public CameraController cameraControl;

    [Space(5)]
    public LineRenderer lineRend;
    public Transform tfRodEnd;
    public Transform tfHook;
    public Transform tfSuwako;

    [Space(5)]
    public SpriteRenderer sprSuwako;
    public SpriteRenderer sprBoat;
    public SpriteRenderer sprRod;
    public SpriteRenderer sprHook;

    [Header("Hook Variables")]
    public HookController hookControl;

    public float reelSpeed = 10.0f;
    public float hookSpeed = 10.0f;
    public float sinkSpeed = 10.0f;
    public float positionEpsilon = 0.5f;

    //
    Vector3 mouseWorldPos;

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameManager.instance.depthText.text = (Mathf.Clamp(tfHook.position.y, -100, 0) * -1).ToString("#");


        switch (currState)
        {
            case PlayerState.IDLE:
                Idle();
                break;

            case PlayerState.CASTING:
                Casting();
                break;

            case PlayerState.SINK:
                Sink();
                break;

            case PlayerState.REELING:
                Reeling();
                break;

            case PlayerState.CAUGHT:
                Caught();
                break;

            case PlayerState.TIMEOUT:
                Timeout();
                break;

            case PlayerState.END:
                End();
                break;

            default:
                break;
        }

        lineRend.SetPosition(0, tfRodEnd.position);
        lineRend.SetPosition(1, tfHook.position);


    }

    void Idle()
    {
        if (mouseWorldPos.x < -0.5f && tfSuwako.transform.localScale.x < 0)
        {
            tfSuwako.transform.localScale = new Vector3(1, 1, 1);
        }

        if (mouseWorldPos.x > 0.5f && tfSuwako.transform.localScale.x > 0)
        {
            tfSuwako.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            tfHook.position = tfRodEnd.position;
            currState = PlayerState.CASTING;
            hookControl.SetVisible(true);
            lineRend.enabled = true;
        }
    }

    void Casting()
    {
        currState = PlayerState.SINK;
        cameraControl.isDiving = true;
    }

    void Sink()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (mouseWorldPos.y > tfHook.position.y - positionEpsilon)
            {
                currState = PlayerState.REELING;
                cameraControl.isDiving = false;
            }

        }

        if (Input.GetMouseButton(0))
        {
            if (mouseWorldPos.x > tfHook.position.x + positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(mouseWorldPos.x, tfHook.position.y, tfHook.position.z), 0.5f * hookSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(1, 0) * hookSpeed * Time.deltaTime;
            }
            else if (mouseWorldPos.x < tfHook.position.x - positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(mouseWorldPos.x, tfHook.position.y, tfHook.position.z), 0.5f * hookSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(-1, 0) * hookSpeed * Time.deltaTime;
            }
        }
        else
        {

        }

        if (tfHook.position.y > -100f)
        {
            tfHook.position = Vector3.Lerp(tfHook.position,
                new Vector3(tfHook.position.x, tfHook.position.y - 1f, tfHook.position.z), 0.5f * sinkSpeed * Time.deltaTime);
            //tfHook.position -= new Vector3(0, sinkSpeed, 0) * Time.deltaTime;
        }
        else
        {
            cameraControl.isDiving = false;
        }
    }

    void Reeling()
    {
        if (tfHook.position.y >= -3f)
        {
            hookControl.SetVisible(false);
            lineRend.enabled = false;
            currState = PlayerState.CAUGHT;
        }
        else if (Input.GetMouseButton(0))
        {
            if (mouseWorldPos.x > tfHook.position.x + positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(mouseWorldPos.x, tfHook.position.y, tfHook.position.z), 0.5f * hookSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(1, 0) * hookSpeed * Time.deltaTime;
            }
            else if (mouseWorldPos.x < tfHook.position.x - positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(mouseWorldPos.x, tfHook.position.y, tfHook.position.z), 0.5f * hookSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(-1, 0) * hookSpeed * Time.deltaTime;
            }

            if (mouseWorldPos.y > tfHook.position.y - positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(tfHook.position.x, tfHook.position.y + 1f, tfHook.position.z), 0.5f * reelSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(0, 1) * reelSpeed * Time.deltaTime;
            }
        }


        if (tfHook.position.x < -0.5f && tfSuwako.transform.localScale.x < 0)
        {
            tfSuwako.transform.localScale = new Vector3(1, 1, 1);
        }

        if (tfHook.position.x > 0.5f && tfSuwako.transform.localScale.x > 0)
        {
            tfSuwako.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Caught()
    {
        if (Input.GetMouseButton(0))
        {

        }
        else
        {
            currState = PlayerState.IDLE;
        }
    }

    void Timeout()
    {

    }

    void End()
    {
        if (Input.GetMouseButton(0))
        {

        }
        else
        {
            currState = PlayerState.IDLE;
        }
    }

}
