using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private enum EctActivity { portfolio, grade, award, friend, club, lab, f };
    private enum Club { soccer, band, volunteer, star };

    [SerializeField] private int[] majorList = new int[4] { 0, 0, 0, 0 };
    [SerializeField] private int[] ectActivityList = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

    private string club = "";

    #region Ending
    private List<string> endingList = new List<string>();
    private string[] ectActivityEnding =
    {
        "포폴 준비를 열심히 함", "포폴 준비를 열심히 하지 않음",
        "성적이 나쁨", "성적이 좋음",
        "공모전 수상을 많이 하지 않음", "공모전 수상을 많이 함",
        "친구가 적음", "친구가 많음",
        "동아리 활동을 열심히 하지 않음", "동아리 활동을 열심히 함",
        "연구실에 들어가서 논문을 많이 쓰지 않음", "연구실에 들어가서 논문을 많이 씀"
    };
    #endregion

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
            case "Friend":
                ectActivityList[(int)EctActivity.friend]++;
                break;
            case "Lab":
                ectActivityList[(int)EctActivity.lab]++;
                break;
            case "Club":
                ectActivityList[(int)EctActivity.club]++;
                break;
            default:
                return;

        }
        //item.SetActive(false);
        Destroy(item);
    }

    public int GetHeartCount() { return ectActivityList[(int)EctActivity.f]; }
    public string GetClub() { return club; }
    public void SetClub(string choice)
    {
        club = choice;
        ItemManager.Instance.ClubItemCreate(choice);
    }

    public void GameOver()
    {
        Debug.Log("GameOver! 학고 Ending");
        SceneManager.LoadScene("GameOverScene");
    }

    public void GameClear()
    {
        Check();
        CheckMajor();

        foreach(string end in endingList)
        {
            Debug.Log(end);
        }
        SceneManager.LoadScene("GameClearScene");
    }

    private void Check()
    {
        if (ectActivityList[(int)EctActivity.friend] > 2)
            endingList.Add(ectActivityEnding[(int)EctActivity.friend * 2 + 1]);
        else
            endingList.Add(ectActivityEnding[(int)EctActivity.friend * 2]);

        if (ectActivityList[(int)EctActivity.club] > 10)
            endingList.Add(ectActivityEnding[(int)EctActivity.club * 2 + 1]);
        else
            endingList.Add(ectActivityEnding[(int)EctActivity.club * 2]);

        if (ectActivityList[(int)EctActivity.grade] > 10)
            endingList.Add(ectActivityEnding[(int)EctActivity.grade * 2 + 1]);
        else
            endingList.Add(ectActivityEnding[(int)EctActivity.grade * 2]);

        if (ectActivityList[(int)EctActivity.portfolio] > 5)
            endingList.Add(ectActivityEnding[(int)EctActivity.portfolio * 2 + 1]);
        else
            endingList.Add(ectActivityEnding[(int)EctActivity.portfolio * 2]);

        if (ectActivityList[(int)EctActivity.award] > 5)
            endingList.Add(ectActivityEnding[(int)EctActivity.award * 2 + 1]);
        else
            endingList.Add(ectActivityEnding[(int)EctActivity.award * 2]);

        if (ectActivityList[(int)EctActivity.lab] > 5)
            endingList.Add(ectActivityEnding[(int)EctActivity.lab * 2 + 1]);
        else
            endingList.Add(ectActivityEnding[(int)EctActivity.lab * 2]);
    }

    private void CheckMajor()
    {

    }
}
