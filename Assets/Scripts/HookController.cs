using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public enum HookState { CAST, SINK, REEL, BREAK, END };
    public HookState currHookState = HookState.SINK;

    public float reelSpeed = 1.0f;
    public float hookSpeed = 1.0f;
    public float positionEpsilon = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currHookState)
        {
            case HookState.CAST:
                Cast();
                break;

            case HookState.SINK:
                Sink();
                break;

            case HookState.REEL:
                Reel();
                break;

            case HookState.BREAK:
                Break();
                break;

            case HookState.END:
                End();
                break;
        }

        GameManager.instance.depthText.text = (transform.position.y * -1).ToString("#");
    }

    void Cast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currHookState = HookState.SINK;
        }
    }
    void Sink()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currHookState = HookState.REEL;
        }

        if (transform.position.y > -100f)
        {
            transform.position -= new Vector3(0, 10, 0) * Time.deltaTime;
        }
        else
        {
            currHookState = HookState.REEL;
        }
    }

    void Reel()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mouseWorldPos.x > transform.position.x + positionEpsilon)
            {
                transform.position += new Vector3(1, 0) * hookSpeed * Time.deltaTime;
            }
            else if (mouseWorldPos.x < transform.position.x - positionEpsilon)
            {
                transform.position += new Vector3(-1, 0) * hookSpeed * Time.deltaTime;
            }

            if(mouseWorldPos.y > transform.position.y + positionEpsilon)
            {
                transform.position += new Vector3(0, 1) * reelSpeed * Time.deltaTime;
            }
        }

        if(transform.position.y > -1)
        {
            currHookState = HookState.END;
        }
    }

    void Break()
    {
        currHookState = HookState.CAST;
    }

    void End()
    {
        currHookState = HookState.CAST;
    }
}
