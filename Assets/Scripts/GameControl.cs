using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{

    
    //public int CoinsScore=0;
    //private int coinsPerLevel = 1;
    //public TextMeshProUGUI CoinText;
    public List<Transform> Boxes;
    public List<int[]> arrs = new List<int[]>();

    public int[] arr1;
    public int[] arr2;
    public int[] arr3;
    public int[] arr4;
    public int[] arr5;
    public int[] arr6;
    public int[] arr7;
    public int[] arr8;

    //dizi oluşturup unity üzerinden kelimeleri dizilere yerleştirdik.

    public List<string> CorrectWords;
    public bool[] AllCorrectWords;
    public static bool EndGame;
    public GameObject NextText;


    void Start()
    {
        /*
        // Eğer daha önce bir kayıt yoksa, varsayılan değer olarak 1. seviyeyi kullan
        if (PlayerPrefs.HasKey("CoinsScore"))
        {
          CoinsScore = PlayerPrefs.GetInt("CoinsScore");
        }
        else
        {
            PlayerPrefs.SetInt("CoinsScore", CoinsScore);
        }
        UpdateCoinText(); // Coin miktarını başlangıçta güncelle
        */
        
        NextText.SetActive(false);
        arrs.Add(arr1);
        arrs.Add(arr2);
        arrs.Add(arr3);
        arrs.Add(arr4);
        arrs.Add(arr5);
        arrs.Add(arr6);
        arrs.Add(arr7);
        arrs.Add(arr8);

        AllCorrectWords = new bool[CorrectWords.Count];

    }


    void Update()
    {
        if (ClickControl.Control == true && EndGame==false )
            //tıklama bittiyse ve oyun bitmediyse aşağıdaki kodlar çalışsın.
            //kelimenin doğruluğunu tespit etmek için.
        {
            ClickControl.Control = false; //sadece bi kere çalışması için geri false'a çevirmeliyiz yoksa frame sayısı kadar çalışır.

            for (int i = 0; i < CorrectWords.Count; i++) {



                if (ClickControl.CurrentWord == CorrectWords[i]&& AllCorrectWords[i]==false)
                //eğer girdiğim şimdiki kelime CorrectWords listesinden bir elemana eşitse 


                {
                    AllCorrectWords[i] = true;

                    int[] index = arrs[i]; 

                    for (int j = 0; j < CorrectWords[i].Length; j++) //correctWords listesindeki tüm elemenlar bulunana kadar
                    {


                        Boxes[index[j]].GetComponent<TextMeshPro>().text = ClickControl.CurrentWord[j].ToString();
                        //git Boxes listesininin içindeki dizilerin Text'ini al onları şimdiki kelimenin?
                        //bunu stringe çevir.

                    }
                }
            }
           
            ClickControl.CurrentWord = "";
            EndGameControl();
            
        }

    }
    public void EndGameControl()
    {
        int num = 0;
        for(int i=0; i< AllCorrectWords.Length; i++)
            //bütün doğru kelimeler bulunana kadar.
        {
            if(AllCorrectWords[i]== false) //eğer bütün doğru kelimeler bulunmamışsa
            {
                //sayıyı bir arttır.
                num++;
            }
        }
        if (num == 0) //eğer sayaç sıfırlanırsa
        {/*
            CoinsScore++;
            PlayerPrefs.SetInt("CoinsScore", CoinsScore);

            // Oyuncuya coin ekle
            int currentCoins = PlayerPrefs.GetInt("Coins", 0);
            currentCoins += coinsPerLevel;
            PlayerPrefs.SetInt("Coins", currentCoins);
            UpdateCoinText(); // Coin miktarını güncelle
            */
            

            // EndGame = true; //oyun biter.
            NextText.SetActive(true);
        }
    }
    /*
    private void UpdateCoinText()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        CoinText.GetComponent<TextMeshProUGUI>().text= "Coins: " + currentCoins;
    }
    */


}


