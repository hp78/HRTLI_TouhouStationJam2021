using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform tfHook;
    public bool isDiving = true;

    // Update is called once per frame
    void Update()
    {
        float yPos = tfHook.position.y + 3f;
        if (yPos > 0) yPos = 0f;

        if(isDiving)
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, tfHook.position.y - 3f, -10), 0.5f * 10f * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, tfHook.position.y + 3f, -10), 0.5f * 10f * Time.deltaTime);

    }
}
