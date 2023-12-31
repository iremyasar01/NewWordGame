using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class ClickControl : MonoBehaviour

{
    
    public TextMeshPro selectedLetterText; // Harfi yazdırmak için  Text bileşeni
    public GameObject highlightPrefab; //Yuvarlak obje ön tanımlı prefab
                                       // private GameObject currentHighlight; // Şu an seçili olan yuvarlak obje

    private SpriteRenderer highlightRenderer; // Yuvarlak objenin Sprite Renderer bileşeni
    private bool isHighlighted = false; // Vurgulamanın açık veya kapalı olduğunu tutar

    public static string CurrentWord = "";
    public static bool FirstClick = false; //her objede oluşacağından ötürü tıklanmayan objelerde sıkıntı çıkarmasın diye
    //static tanımladık.
    TextMeshPro text;
    private SpriteRenderer spriteText;
    public GameObject highlightText;
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
        spriteText = highlightText.GetComponent<SpriteRenderer>();
        spriteText.enabled = true;
        // TextMeshPro'nun boyutlarını al
        Vector2 textSize = selectedLetterText.GetPreferredValues();
        // SpriteRenderer'ın boyutlarını ayarla
        spriteText.size = new Vector2(textSize.x, textSize.y);
        Debug.Log(spriteText.size);
        // SpriteRenderer'ın scale'ını güncelle.
        spriteText.transform.localScale = new Vector2(textSize.x,textSize.y);
        // SpriteRenderer'ı metnin ortasına konumlandır.
        spriteText.transform.position = selectedLetterText.transform.position;
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

            selectedLetterText.text = "";
            highlightRenderer = highlightPrefab.GetComponent<SpriteRenderer>();
            highlightRenderer.enabled = false; // Harften ayrıldığında vurgulamayı kapat

        // LineManager'ı burada çağırarak çizgiyi temizle
        LineControl lineControl = FindObjectOfType<LineControl>();
        if (lineControl != null)
        {
            lineControl.ClearSelectedLetters();
            spriteText = highlightText.GetComponent<SpriteRenderer>();
            spriteText.enabled = false;
        }

        
        Control = true;
       
    }
   

}
