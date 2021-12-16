using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClubPersonScript : MonoBehaviour
{
    public GameObject wordBox;
    public Button communicationBtn;
    private bool isTrigger = false;

    private void Start()
    {
        wordBox.SetActive(false);
        communicationBtn.onClick.AddListener(OnCommunicationBtnClick);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.GetClub() == "")
        {
            isTrigger = true;
            wordBox.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameManager.Instance.GetClub() == "")
        {
            isTrigger = false;
            wordBox.SetActive(false);
        }
    }
    public void OnCommunicationBtnClick()
    {
        if (isTrigger && GameManager.Instance.GetClub()=="")
        {
            GameManager.Instance.SetClub(this.gameObject.tag);
        }
    }
}
