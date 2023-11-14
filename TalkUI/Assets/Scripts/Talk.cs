using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public GameObject TalkUI;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (DialogManager.Instance.excelNPCName == gameObject.name)
            {
                TalkUI.SetActive(true);
                DialogManager.Instance.currentNPCName = gameObject.name;
                DialogManager.Instance.ShowDialogRow();//œ‘ æ∂‘ª∞
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            //if TalkUI is active, set it to false
            if (TalkUI.activeSelf)
            {
                TalkUI.SetActive(false);
            }
        }

    }
}
