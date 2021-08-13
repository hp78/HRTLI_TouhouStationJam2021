using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public enum PlayerState { IDLE, CASTING, SINK, REELING, CAUGHT, TIMEOUT, END };
    public PlayerState currState = PlayerState.IDLE;

    [Space(5)]
    public PlayerStatSO playerStat;
    public GameStatSO gameStat;
    public CameraController cameraControl;

    [Space(5)]
    public LineRenderer lineRend;
    public Transform tfRodEnd;
    public Transform tfHook;
    public Transform tfSuwako;

    [Space(5)]
    public SpriteRenderer sprSuwako;
    public SpriteRenderer sprBoat;
    public SpriteRenderer sprCooler;
    public SpriteRenderer sprRodUpper;
    public SpriteRenderer sprRodLower;
    public SpriteRenderer sprHook;

    [Header("Hook Variables")]
    public HookController hookControl;

    public float reelSpeed = 20.0f;
    public float autoReelSpeed = 10.0f;
    public float hookSpeed = 10.0f;
    public float sinkSpeed = 10.0f;
    public float positionEpsilon = 0.5f;

    [Header("Cut-ins")]
    public GameObject cutinCast;
    public GameObject cutinFail;
    public GameObject cutinSucc;
    float cutinTimer = 0.0f;

    //
    Vector3 mouseWorldPos;

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = 2;
        sprRodUpper.sprite = ((RodSO)gameStat.currRod).UpperRod;
        sprRodLower.sprite = ((RodSO)gameStat.currRod).LowerRod;
        sprCooler.sprite = (gameStat.currCooler).itemSprite;
    }

    void OnApplicationQuit()
    {
        playerStat.ClearStats();
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
            cutinTimer = 0.0f;
            cutinCast.gameObject.SetActive(true);
        }
    }

    void Casting()
    {
        cutinTimer += Time.deltaTime;

        if(cutinTimer > 1.9f)
        {
            cutinCast.gameObject.SetActive(false);
            currState = PlayerState.SINK;
            cameraControl.isDiving = true;
            hookControl.SetCollider(false);
        }
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
            hookControl.ClearWeight();
            lineRend.enabled = false;
            currState = PlayerState.CAUGHT;

            cutinTimer = 0.0f;
            cutinSucc.gameObject.SetActive(true);
        }

        HookHorizontalMovement();
        /*
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
        */

        if (Input.GetMouseButton(0))
        {
            if (mouseWorldPos.y > tfHook.position.y - positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(tfHook.position.x, tfHook.position.y + 1f, tfHook.position.z), 0.5f * reelSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(0, 1) * reelSpeed * Time.deltaTime;
            }
            hookControl.SetCollider(true);
        }
        else
        {
            if (mouseWorldPos.y > tfHook.position.y - positionEpsilon)
            {
                tfHook.position = Vector3.Lerp(tfHook.position,
                    new Vector3(tfHook.position.x, tfHook.position.y + 1f, tfHook.position.z), 0.5f * autoReelSpeed * Time.deltaTime);
                //tfHook.position += new Vector3(0, 1) * reelSpeed * Time.deltaTime;
            }
            hookControl.SetCollider(true);
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
        cutinTimer += Time.deltaTime;

        if (cutinTimer > 1.9f)
        {
            cutinSucc.gameObject.SetActive(false);
            currState = PlayerState.IDLE;
        }
    }

    void Timeout()
    {

    }

    void HookHorizontalMovement()
    {
        if (mouseWorldPos.x > tfHook.position.x + positionEpsilon)
        {
            tfHook.position = new Vector3(Mathf.Min(tfHook.position.x + hookSpeed * Time.deltaTime, Mathf.Lerp(tfHook.position.x, mouseWorldPos.x, 0.5f * hookSpeed * Time.deltaTime)), tfHook.position.y, tfHook.position.z);
        }
        else if (mouseWorldPos.x < tfHook.position.x - positionEpsilon)
        {
            tfHook.position = new Vector3(Mathf.Max(tfHook.position.x - hookSpeed* Time.deltaTime, Mathf.Lerp(tfHook.position.x, mouseWorldPos.x, 0.5f * hookSpeed* Time.deltaTime)), tfHook.position.y, tfHook.position.z);
        }
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
