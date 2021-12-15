using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(ItemManager)) as ItemManager;
                if (instance == null)
                    Debug.Log("No Singleton obj");
            }
            return instance;
        }
    }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public GameObject[] majorItems;  // 생성할 전공 아이템
    public GameObject[] clubItems; // 생성할 동아리 관련 아이템 0-band, 1-soccer, 2-star, 3-volunteer
    public GameObject[] activityItems; // 기타 활동 아이템

    public GameObject labItem, fItem;

    //private List<GameObject> itemObject = new List<GameObject>();
    private List<int> xPoses = new List<int>();
    private float[] yPoses = new float[2] {-1f, 0.5f};

    [SerializeField]
    private int count = 20;
    private int fItemCount = 5;
    private int clubItemCount = 10;

    private void Start()
    {
        // 아이템 x좌표 Add
        for (int i = 0; i < 65; i++)
            xPoses.Add(i);

        // Item 생성
        for (int i = 0; i < count; i++)
            ItemCreate();

        for (int i = 0; i < fItemCount; i++)
            FItemCreate();
    }

    private void ItemCreate()
    {
        int index = Random.Range(0, majorItems.Length);
        Vector2 spawnPos = GetRandomPosition();

        GameObject item = majorItems[index];
        GameObject instance = Instantiate(item, spawnPos, Quaternion.identity);
    }

    private void FItemCreate()
    {
        int index = Random.Range(0, majorItems.Length);
        Vector2 spawnPos = GetRandomPosition();
        GameObject instance = Instantiate(fItem, spawnPos, Quaternion.identity);
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePos = transform.position;
        
        int rand = Random.Range(0, xPoses.Count);
        float posX = basePos.x + xPoses[rand];
        float posY = basePos.y + yPoses[Random.Range(0, 2)];
        xPoses.RemoveAt(rand);

        Vector2 spawnPos = new Vector2(posX, posY);
        return spawnPos;
    }

    public void ClubItemCreate(string club)
    {
        GameObject clubItem = clubItems[0];
        switch(club)
        {
            case "Band":
                clubItem = clubItems[0];
                break;
            case "Soccer":
                clubItem = clubItems[1];
                break;
            case "Star":
                clubItem = clubItems[2];
                break;
            case "Volunteer":
                clubItem = clubItems[3];
                break;
        }
        for(int i = 0; i<clubItemCount; i++)
        {
            int index = Random.Range(0, majorItems.Length);
            Vector2 spawnPos = GetRandomPosition();
            GameObject instance = Instantiate(clubItem, spawnPos, Quaternion.identity);
        }
    }
}
