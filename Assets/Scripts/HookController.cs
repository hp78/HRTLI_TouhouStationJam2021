using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public enum HookState { CAST, SINK, REEL, BREAK };
    public HookState currHookState = HookState.SINK;

    public float moveSpeed = 1.0f;
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
                break;

            case HookState.SINK:
                Sink();
                break;

            case HookState.REEL:
                Reel();
                break;

            case HookState.BREAK:
                break;
        }

        GameManager.instance.depthText.text = (transform.position.y * -1).ToString("#");
    }

    void Sink()
    {
        if(transform.position.y > -100f)
        {
            transform.position -= new Vector3(0, 10, 0) * Time.deltaTime;
        }
    }

    void Reel()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mouseWorldPos.x > transform.position.x + positionEpsilon)
            {
                transform.position += new Vector3(1, 0) * moveSpeed * Time.deltaTime;
            }
            else if (mouseWorldPos.x < transform.position.x - positionEpsilon)
            {
                transform.position += new Vector3(-1, 0) * moveSpeed * Time.deltaTime;
            }
        }
    }
}
