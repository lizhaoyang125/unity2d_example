using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public TextAsset DialogDataFile;
    string[] dialogRows;
    public TMP_Text dialogText;
    public Image dialogImage;
    public Button nextBtn;
    public List<Sprite> images = new List<Sprite>();    //�Ի�����ͷ��
    Dictionary<string, Sprite> imageDic=new Dictionary<string, Sprite>();  //�Ի�����ͷ�����ֺ�ͼƬ�Ķ�Ӧ��ϵ
    int currentDialogIndex = 1; //��ǰ�Ի�����
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        ReadText();
        Init();
    }
    private void Init()
    {
        imageDic["ͬ����"]     = images[0];
        imageDic["SiKi�ͷ�"] = images[1];
        imageDic["Trigger��ʦ"] = images[2];
        imageDic["SiKi��ʦ"] = images[3];
        imageDic["СY��ʦ"] = images[4];
        imageDic["Mono��ʦ"] = images[5];
        imageDic["ϡ����ʦ"] = images[6];
        imageDic["С��"] = images[7];
    }
    void ReadText()
    {
        dialogRows=DialogDataFile.text.Split('\n');
    }
    public void ShowDialogRow()
    {
        for (int i = 0; i < dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(",");  //�Զ��ŷָ�
            if (cells[0] == "#" && int.Parse(cells[1]) == currentDialogIndex)
            {
                UpdateText(cells[2], cells[3]);
                break;
            }
        }
    }
    void UpdateText(string name, string txt)
    {
        dialogImage.sprite = imageDic[name];    //����ͷ��
        dialogText.text = txt;                  

    }
}
