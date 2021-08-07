using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform tfHook;

    // Update is called once per frame
    void Update()
    {
        float yPos = tfHook.position.y + 3f;
        if (yPos > 0) yPos = 0f;
        transform.position = new Vector3(0, yPos, -10);
    }
}
