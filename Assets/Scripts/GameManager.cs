using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    public static GameManager Instance  // 인스턴스에 접근하기 위한 프로퍼티
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (instance == null)
                    Debug.Log("No Singleton obj");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)  // 인스턴스가 존재하는 경우 새로 생기는 인스턴스를 삭제한다
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);  // 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다
    }

    private enum Major { chemistry, building, computer, machine };
    private enum EctActivity { portfolio, grade, f, award };

    [SerializeField] private int[] majorList = new int[4] { 0, 0, 0, 0 };
    [SerializeField] private int[] ectActivityList = new int[4] { 0, 0, 0, 0 };

    public void ItemCountInc(GameObject item)
    {
        switch (item.tag)
        {
            case "Chemistry":
                majorList[(int)Major.chemistry]++;
                break;
            case "Computer":
                majorList[(int)Major.computer]++;
                break;
            case "Building":
                majorList[(int)Major.building]++;
                break;
            case "Machine":
                majorList[(int)Major.machine]++;
                break;
            case "Award":
                ectActivityList[(int)EctActivity.award]++;
                break;
            case "Grade":
                ectActivityList[(int)EctActivity.grade]++;
                break;
            case "Portfolio":
                ectActivityList[(int)EctActivity.portfolio]++;
                break;
            case "F":
                ectActivityList[(int)EctActivity.f]++;
                break;

        }
        item.SetActive(false);
    }

    public void GameOver()
    {
        
    }

    public void GameClear()
    {

    }

}
