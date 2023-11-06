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
    public List<Sprite> images = new List<Sprite>();    //对话人物头像
    Dictionary<string, Sprite> imageDic=new Dictionary<string, Sprite>();  //对话人物头像名字和图片的对应关系
    int currentDialogIndex = 1; //当前对话索引
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        ReadText();
        Init();
    }
    private void Init()
    {
        imageDic["同龄人"]     = images[0];
        imageDic["SiKi客服"] = images[1];
        imageDic["Trigger老师"] = images[2];
        imageDic["SiKi老师"] = images[3];
        imageDic["小Y老师"] = images[4];
        imageDic["Mono老师"] = images[5];
        imageDic["稀粥老师"] = images[6];
        imageDic["小白"] = images[7];
    }
    void ReadText()
    {
        dialogRows=DialogDataFile.text.Split('\n');
    }
    public void ShowDialogRow()
    {
        for (int i = 0; i < dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(",");  //以逗号分隔
            if (cells[0] == "#" && int.Parse(cells[1]) == currentDialogIndex)
            {
                UpdateText(cells[2], cells[3]);
                break;
            }
        }
    }
    void UpdateText(string name, string txt)
    {
        dialogImage.sprite = imageDic[name];    //更新头像
        dialogText.text = txt;                  

    }
}
