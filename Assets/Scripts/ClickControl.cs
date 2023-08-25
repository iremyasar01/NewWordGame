using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickControl : MonoBehaviour

{
    public List<Transform> selectedLetters2 = new List<Transform>();
    public TextMeshPro selectedLetterText; // Harfi yazdırmak için UI Text bileşeni
    public GameObject highlightPrefab; //Yuvarlak obje ön tanımlı prefab
                                       // private GameObject currentHighlight; // Şu an seçili olan yuvarlak obje

    private SpriteRenderer highlightRenderer; // Yuvarlak objenin Sprite Renderer bileşeni
    private bool isHighlighted = false; // Vurgulamanın açık veya kapalı olduğunu tutar

    public static string CurrentWord = "";
    public static bool FirstClick = false; //her objede oluşacağından ötürü tıklanmayan objelerde sıkıntı çıkarmasın diye
    //static tanımladık.
    TextMeshPro text;
    public bool active = true; //bir harfi bir kelimede bir kere seçebilmesi adına.
    public static bool Control = false;

    void Start()
    {
        highlightRenderer = highlightPrefab.GetComponent<SpriteRenderer>();
        highlightRenderer.enabled = false; // Vurgulamayı başlangıçta kapalı yap
    }
  


    void Update()
    {
        if (FirstClick == false)
        {
            text = GetComponent<TextMeshPro>();
            text.color = Color.black;
            if (!isHighlighted)
            {
                highlightRenderer = highlightPrefab.GetComponent<SpriteRenderer>();
                highlightRenderer.enabled = false; // Harften ayrıldığında vurgulamayı kapat
            }
            active = true;

          
        }
    }
    

        public void OnClick()
        {
        text = GetComponent<TextMeshPro>();
        text.color = Color.white;
     



        if (!isHighlighted)
        {
            highlightRenderer.enabled = true; // Harfin üzerine gelindiğinde vurgulamayı aç
        }
        // CreateHighlight();
        // LineManager'ı burada çağırarak çizgi çizimini güncelle
        LineControl lineControl = FindObjectOfType<LineControl>();
        if (lineControl != null)
        {
            lineControl.UpdateLineRenderer();
        }
        CurrentWord += GetComponent<TextMeshPro>().text;
        selectedLetterText.text = CurrentWord;
        Debug.Log(CurrentWord);
       
        active = false;

       


    }
    public void OnMouseDown() //üzerine tıkladığın zaman aktifleşen.
    {
        if (FirstClick == false &&GameControl.EndGame==false)
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
          
            FirstClick = true;

        }
       
    }
    
    public void OnMouseUp() //üzerinden gittikten sonra aktifleşen.
    {
        FirstClick = false;

        
            highlightRenderer = highlightPrefab.GetComponent<SpriteRenderer>();
            highlightRenderer.enabled = false; // Harften ayrıldığında vurgulamayı kapat
        
       
        

        // LineManager'ı burada çağırarak çizgiyi temizle
        LineControl lineControl = FindObjectOfType<LineControl>();
        if (lineControl != null)
        {
            lineControl.ClearSelectedLetters();
        }

        // CurrentWord = "";
        Control = true;
       
    }


}
