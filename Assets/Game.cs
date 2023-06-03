using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text name;
    public Text level;
    public Text coin;
    public GameObject[] item;
    
    // Start is called before the first frame update
    void Start()
    {
        name.text+=DataManager.instance.playerData.name;//뒤에 텍스트를 추가하기 위함

        level.text += DataManager.instance.playerData.level.ToString();//뒤에 텍스트를 추가하기 위함

        coin.text += DataManager.instance.playerData.coin;//뒤에 텍스트를 추가하기 위함
        ItemSetting(DataManager.instance.playerData.item);//이렇게 시작부터 사용하는것을 이용

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelup()
    {
        DataManager.instance.playerData.level++;
        level.text ="레벨 :"+ DataManager.instance.playerData.level.ToString();//뒤에 텍스트를 추가하기 위함

        
    }
    public void Coinup()
    {

        DataManager.instance.playerData.coin+=100;//값을 바꾸는것
        coin.text ="코인 :"+ DataManager.instance.playerData.coin;//ui를 바꾸는것
    }
    public void Save()
    {
        DataManager.instance.SaveData();
    }
    public void ItemSetting(int number)
    {
        for(int i=0;i<item.Length;i++)
        {
            if(number==i)
            {
                item[i].SetActive(true);
                DataManager.instance.playerData.item = number;
            }
            else
            {
                item[i].SetActive(false);
            }
        }
    }
}
