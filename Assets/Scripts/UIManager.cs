using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    public static UIManager Instance  // 인스턴스에 접근하기 위한 프로퍼티
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(UIManager)) as UIManager;
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
}
