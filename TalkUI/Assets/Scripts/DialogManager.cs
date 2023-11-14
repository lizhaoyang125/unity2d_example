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
    public List<Sprite> images = new List<Sprite>();    //�Ի�����ͷ��
    Dictionary<string, Sprite> imageDic=new Dictionary<string, Sprite>();  //�Ի�����ͷ�����ֺ�ͼƬ�Ķ�Ӧ��ϵ
    int currentDialogIndex = 1; //��ǰ�Ի�����
    [HideInInspector]   //������Inspector���
    public string currentNPCName;    //��ǰ�Ի���������
    [HideInInspector]
    public string excelNPCName;     //Excel���еĶԻ���������

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
        excelNPCName = "ͬ����";

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
                print("���������");
            }
        }
    }
    void UpdateText(string name, string txt)
    {
        dialogImage.sprite = imageDic[name];    //����ͷ��
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
        string[] cells = dialogRows[index].Split(",");  //�Զ��ŷָ�,cells[0]Ϊ&��cells[1]Ϊ�Ի�������cells[2]Ϊ�Ի����ݣ�cells[3]Ϊ��һ��Ի�������cells[4]Ϊ��һ��Ի���������
        if (cells[0]=="&" && ButtonGroup.childCount<2)// && int.Parse(cells[1]) == currentDialogIndex && currentNPCName == excelNPCName)
        {
            GameObject btn= Instantiate(optionButtionPrefab, ButtonGroup.transform);
            btn.GetComponentInChildren<TMP_Text>().text = cells[3];
            btn.GetComponent<Button>().onClick.AddListener(
                delegate    //��������,
                {
                    OnOptionClick(int.Parse(cells[5]));
                });
            generateOptionButtion(index+1);
        }
    }
    void OnOptionClick(int index)
    {
        currentDialogIndex = index; //���¶Ի�����
        ShowDialogRow();            
        for (int i=0;i< ButtonGroup.childCount;i++)
        {
            Destroy(ButtonGroup.GetChild(i).gameObject);
        }
    }
}
