using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class Select : MonoBehaviour
{
    public GameObject create;
    public Text[] slotText;
    public Text playername;
    bool[] savefile=new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<3;i++)
        {
            if(File.Exists(DataManager.instance.path +$"{i}"))
            {
                savefile[i]= true;
                DataManager.instance.nowSlot = i;//현재 슬롯을 지정해줌
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.playerData.name;//이렇게하고나서 게임의 저장시간을 뒤에 넣어주면 끝난다.
                
            }
            else
            {
                slotText[i].text = "비어있음";
            }
        }
        //슬롯별로 저장된 데이터가 존재하는지 판단
        DataManager.instance.DataClear();//값이 초기화되서 문제가 없도록 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        //1. 저장된 데이터가 없을때
        if (savefile[number]) 
        {
            DataManager.instance.LoadData();
            GoGame();
        }
        else 
        {
            Creat();
        }
        
        //2. 저장된 데이터가 있을때 => 불러오기해서 게임씬으로 넘어감
        
       
        

    }

    public void Creat()//여기에 하면은 이름이 입력하지 않은상태
    {
        create.gameObject.SetActive(true);
    }
    public void GoGame()
    {
        if (savefile[DataManager.instance.nowSlot] == false)
        {
            DataManager.instance.playerData.name = playername.text;
            DataManager.instance.SaveData();
        }
        //여기에 이름을 입력하는것을 한다면 조건이 없다면 해당하는 값이 초기화 되버림
        SceneManager.LoadScene(1);
    }
}
