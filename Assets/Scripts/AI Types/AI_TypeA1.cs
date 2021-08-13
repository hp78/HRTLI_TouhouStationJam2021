using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_TypeA1 : MonoBehaviour
{
    public float accelerationUpperLimit;
    public float accelerationLowerLimit;
    float currAccel;

    public float maxSpeed;


    public float directionChangeCooldownUpperLimit;
    public float directionChangeCooldownLowerLimit;
    float directionChangeCD = 0f;

    public Rigidbody2D rb;

    Vector2 direction;

    public float patrolLimitRangeX;
    public float patrolLimitRangeY;
    float limitUpperRangeX;
    float limitLowerRangeX;
    float limitUpperRangeY;
    float limitLowerRangeY;
    

    FishAIController aIController;
    // Start is called before the first frame update
    void Start()
    {
        aIController = GetComponent<FishAIController>();
        limitUpperRangeX = this.transform.position.x + patrolLimitRangeX;
        limitLowerRangeX = this.transform.position.x - patrolLimitRangeX;
        limitUpperRangeY = this.transform.position.y + patrolLimitRangeY;
        limitLowerRangeY = this.transform.position.y - patrolLimitRangeY;
        SelectDirection();
    }

    // Update is called once per frame
    void Update()
    {

        if(directionChangeCD < 0.0f)
        {
            SelectDirection();
        }

        if (rb.velocity.magnitude < maxSpeed)
            rb.AddForce(direction.normalized * currAccel * Time.deltaTime, ForceMode2D.Impulse);

        directionChangeCD -= Time.deltaTime;

        LimitChecker();
    }


    void SelectDirection()
    {
        float ranX = Random.Range(-1f, 1f);
        float ranY = Random.Range(-1f, 1f);
        direction = new Vector2(ranX, ranY);

        directionChangeCD = Random.Range(directionChangeCooldownLowerLimit, directionChangeCooldownUpperLimit);

        //if (ranX < 0.0f) aIController.spriteRenderer.flipX = true;
        //else aIController.spriteRenderer.flipX = false;

        currAccel = Random.Range(accelerationLowerLimit, accelerationUpperLimit);
    }

    void LimitChecker()
    {
        if(this.transform.position.x > limitUpperRangeX)
        {
            float ranX = Random.Range(-1f, -0.25f);
            direction = new Vector2(ranX, direction.y);

            directionChangeCD = Random.Range(directionChangeCooldownLowerLimit, directionChangeCooldownUpperLimit);
            //aIController.spriteRenderer.flipX = true;
        }

        else if (this.transform.position.x < limitLowerRangeX)
        {
            float ranX = Random.Range(.25f, 1f);
            direction = new Vector2(ranX, direction.y);

            directionChangeCD = Random.Range(directionChangeCooldownLowerLimit, directionChangeCooldownUpperLimit);
            //aIController.spriteRenderer.flipX = false;
        }

        if (this.transform.position.y > limitUpperRangeY)
        {
            float ranY = Random.Range(-1f, -0.25f);
            direction = new Vector2(direction.x, ranY);

            directionChangeCD = Random.Range(directionChangeCooldownLowerLimit, directionChangeCooldownUpperLimit);
        }

        else if (this.transform.position.y < limitLowerRangeY)
        {
            float ranY = Random.Range(.25f, 1f);
            direction = new Vector2(direction.x, ranY);

            directionChangeCD = Random.Range(directionChangeCooldownLowerLimit, directionChangeCooldownUpperLimit);
        }
    }
}
