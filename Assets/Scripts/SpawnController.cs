using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public Collider2D spawnCircle;
    public float spawnCircleRadius;

    public float FishSpawnCooldown;
    float fishCD;

    public int fishLimit;
    public GameObject fishParent;
    public GameObject trashParent;

    public Transform topLimit;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform bottomLimit;

    bool crRunning = false;

    public FishSO[] SpawnFishPool;

    List<GameObject> fishList = new List<GameObject>();
    List<GameObject> trashList = new List<GameObject>();

    int fishCount;

    float trashResetCD;


 
    // Start is called before the first frame update
    void Start()
    {
        StartingSpawn();
        StartCoroutine(UpdateList());

    }

    // Update is called once per frame
    void Update()
    {

        if (fishCount < fishLimit)
            if(fishCD < 0.0f && !crRunning) StartCoroutine(CheckSpawnZone());

        fishCD -= Time.deltaTime;
        trashResetCD -= Time.deltaTime;

        if(trashResetCD < 0.0f)
        {
            foreach (Transform child in trashParent.transform)
            {
               Destroy(child.gameObject);
            }
            trashResetCD = 5f;
        }
    }


    IEnumerator CheckSpawnZone()
    {
        crRunning = true;
        spawnCircle.enabled = true;
        float ranY = Random.Range(bottomLimit.position.y, topLimit.position.y);
        float ranX = Random.Range(leftLimit.position.x, rightLimit.position.x);

        Vector2 spawnpoint = new Vector2(ranX, ranY);
        spawnCircle.gameObject.transform.position = spawnpoint;

        yield return new WaitForSeconds(0.2f);

        if (spawnCircle.enabled)
        {
            SpawnFish();
            fishCD = FishSpawnCooldown;
            crRunning = false;
        }

        else StartCoroutine(CheckSpawnZone());
    }

    void SpawnFish()
    {

        foreach (GameObject fish in trashList)
            if (fishList.Contains(fish))
            {
                fishList.Remove(fish);             
            }
        trashList.Clear();
        fishList.Add(Instantiate(SelectFish().fishPrefab, spawnCircle.transform.position, spawnCircle.transform.rotation));
        fishCount = fishList.Count;

    }


    void StartingSpawn()
    {
        for (int i = 0; i < fishLimit; i++)
        {
            float ranY = Random.Range(bottomLimit.position.y, topLimit.position.y);
            float ranX = Random.Range(leftLimit.position.x, rightLimit.position.x);

            Vector2 spawnpoint = new Vector2(ranX, ranY);

            fishList.Add(Instantiate(SelectFish().fishPrefab, spawnpoint, spawnCircle.transform.rotation));
        }
        fishCount = fishList.Count;

    }

    IEnumerator UpdateList()
    {
        foreach(GameObject fish in fishList)
            if(!fish.activeSelf)
            {
                trashList.Add(fish);
                fish.transform.SetParent(trashParent.transform);
                fishCount--;
            }
        yield return new WaitForSeconds(2f);
        StartCoroutine(UpdateList());
    }


    FishSO SelectFish()
    {
        float totalRate = 0;

        foreach(FishSO i in SpawnFishPool)
        {
            totalRate += i.spawnRate;
        }

        foreach (FishSO i in SpawnFishPool)
        {
            float chance = Random.Range(0f, totalRate);

            if(chance <= i.spawnRate)
            {
                return i;
            }
            else
            {
                totalRate -= i.spawnRate;
            }
        }

        return null;


    }





}
