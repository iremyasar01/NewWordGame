using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
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



    void Start()
    {
        
        arrs.Add(arr1);
        arrs.Add(arr2);
        arrs.Add(arr3);
        arrs.Add(arr4);
        arrs.Add(arr5);
        arrs.Add(arr6);
        arrs.Add(arr7);
        arrs.Add(arr8);



    }


    void Update()
    {
        if (ClickControl.Control == true) //kelimenin doğruluğunu tespit etmek için.
        {
            ClickControl.Control = false; //sadece bi kere çalışması için geri false'a çevirmeliyiz yoksa frame sayısı kadar çalışır.

            for (int i = 0; i < CorrectWords.Count; i++) {



                if (ClickControl.CurrentWord == CorrectWords[i])

                {

                    int[] index = arrs[i];

                    for (int j = 0; j < CorrectWords[i].Length; j++)
                    {


                        Boxes[index[j]].GetComponent<TextMeshPro>().text = ClickControl.CurrentWord[j].ToString();

                    }
                }
            }
            ClickControl.CurrentWord = "";
        }
    }
    
}

