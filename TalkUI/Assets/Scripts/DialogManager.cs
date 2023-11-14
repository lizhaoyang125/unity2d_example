using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public TextAsset DialogDataFile;
    string[] dialogRows;
    public TMP_Text dialogText;
    public UnityEngine.UI.Image dialogImage;
    public Button nextBtn;
    public List<Sprite> images = new List<Sprite>();    //对话人物头像
    Dictionary<string, Sprite> imageDic=new Dictionary<string, Sprite>();  //对话人物头像名字和图片的对应关系
    int currentDialogIndex = 1; //当前对话索引
    [HideInInspector]   //隐藏在Inspector面板
    public string currentNPCName;    //当前对话人物名字
    [HideInInspector]
    public string excelNPCName;     //Excel表中的对话人物名字

    public GameObject talkUI;
    public GameObject optionButtionPrefab;
    public Transform ButtonGroup;
    private float textspeed=0.05f;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        ReadText();
        Init();
        excelNPCName = "同龄人";

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
            if (cells[0] == "#" && int.Parse(cells[1]) == currentDialogIndex && currentNPCName== excelNPCName)
            {
                UpdateText(cells[2], cells[3]);
                excelNPCName = cells[4];
                currentDialogIndex = cells[5] == "null" ? 1 : int.Parse(cells[5]);
                break;
            } else if (cells[0] == "&" && int.Parse(cells[1]) == currentDialogIndex && currentNPCName == excelNPCName)
            {
                generateOptionButtion(i);
                break;
            } else if (cells[0] == "end" )
            {
                print("剧情结束！");
            }
        }
    }
    void UpdateText(string name, string txt)
    {
        dialogImage.sprite = imageDic[name];    //更新头像
        StartCoroutine(SetTestUI(txt));
    }
    IEnumerator SetTestUI(string text)
    {
        int letter = 0;
        dialogText.text = "";
        while (letter < text.Length)
        {
            dialogText.text += text[letter];
            letter++;
            yield return new WaitForSeconds(textspeed);
        }      
    }
    public void OnNextBtnClick()
    {
        if(currentNPCName == excelNPCName) {
            ShowDialogRow();
        }
        else
        {
            talkUI.SetActive(false);
        }
    }
    void generateOptionButtion(int index)
    {
        string[] cells = dialogRows[index].Split(",");  //以逗号分隔,cells[0]为&，cells[1]为对话索引，cells[2]为对话内容，cells[3]为下一句对话索引，cells[4]为下一句对话人物名字
        if (cells[0]=="&" && ButtonGroup.childCount<2)// && int.Parse(cells[1]) == currentDialogIndex && currentNPCName == excelNPCName)
        {
            GameObject btn= Instantiate(optionButtionPrefab, ButtonGroup.transform);
            btn.GetComponentInChildren<TMP_Text>().text = cells[3];
            btn.GetComponent<Button>().onClick.AddListener(
                delegate    //匿名函数,
                {
                    OnOptionClick(int.Parse(cells[5]));
                });
            generateOptionButtion(index+1);
        }
    }
    void OnOptionClick(int index)
    {
        currentDialogIndex = index; //更新对话索引
        ShowDialogRow();            
        for (int i=0;i< ButtonGroup.childCount;i++)
        {
            Destroy(ButtonGroup.GetChild(i).gameObject);
        }
    }
}
