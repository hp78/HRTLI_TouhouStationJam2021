using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_TypeC : MonoBehaviour
{
    // Start is called before the first frame update

    public AI_TypeA typeA;
    public AI_TypeB typeB;

    public float swapAIUpperCooldown;
    public float swapAILowerCooldown;
    float swapCD;

    void Start()
    {
        float rand = Random.Range(0f, 1f);
        if (rand < 0.5f)
        {
            typeA.enabled = true;
            typeB.enabled = false;
        }
        else
        {
            typeB.enabled = true;
            typeA.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        swapCD -= Time.deltaTime; 
        
        if(swapCD<0.0f)
        {
            float rand = Random.Range(swapAILowerCooldown, swapAIUpperCooldown);
            swapCD = rand;
            SwapAI();
        }
    }

    void SwapAI()
    {
        bool temp = typeA.enabled;
        typeA.enabled = typeB.enabled;
        typeB.enabled = temp;
    }
}
