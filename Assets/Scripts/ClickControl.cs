using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickControl : MonoBehaviour
{
    public static string CurrentWord = "";
    public static bool FirstClick = false; //her objede oluşacağından ötürü tıklanmayan objelerde sıkıntı çıkarmasın diye
    //static tanımladık.
    TextMeshPro text;
    public bool active = true; //bir harfi bir kelimede bir kere seçebilmesi adına.
    public static bool Control = false;
    void Start()
    {
        
    }


    void Update()
    {
        if (FirstClick == false)
        {
            text = GetComponent<TextMeshPro>();
            text.color = Color.black;
            active = true;
        }
        
    }
    public void OnClick() 
    {
        text = GetComponent<TextMeshPro>();
        text.color = Color.blue;
        CurrentWord += GetComponent<TextMeshPro>().text;
        Debug.Log(CurrentWord);
        active = false;

    }
    public void OnMouseDown() //üzerine tıkladığın zaman aktifleşen.
    {
        if (FirstClick == false)
        {
            OnClick();
            FirstClick =true;
        }
      
    }
    public void OnMouseEnter() //üzerine geldiğin sürece aktifleşen.
    {
       if (FirstClick == true && active==true) //ilk tıklama ile harf seçimi başlıyor sonra üzerine geldiğinde harfi seçtiriyor.
        {
            OnClick();
         
        }
       
    }
    
    public void OnMouseUp() //üzerinden gittikten sonra aktifleşen.
    {
        FirstClick = false;
        
       // CurrentWord = "";
        Control = true;
    }
    
}
