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
            TalkUI.SetActive(true);
            DialogManager.Instance.ShowDialogRow();//��ʾ�Ի�
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            TalkUI.SetActive(false);
        }

    }
}
