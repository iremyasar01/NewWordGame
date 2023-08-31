using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using System;

public class AnimationControl : MonoBehaviour
{

    public GameObject prefab; //textMesh'i içeren prefab.
    //public TextMeshPro textMesh;
    public List<Transform> targetPositions; // Her harf için hedef pozisyonların listesi
    // Bu sınıfın tek örneğini oluşturmak için bir Singleton kullanabilirsiniz.
    public static AnimationControl Instance { get; private set; }
    public float moveDuration; // Hareket süresi
    public float delayBetweenLetters; // Yok olmadan önce bekleme süresi
    private void Awake()
    {
        Instance = this;
    }

    public void MoveTextMesh(string letters, int[] arr)
    {

        int letterCount = letters.Length;
        List<TextMeshPro> textMeshPros = new List<TextMeshPro>();

        for (int i = 0; i < letterCount; i++) //kelime sayısı kadar prefab oluştur.
        {
            textMeshPros.Add(Instantiate(prefab).GetComponent<TextMeshPro>());
            //ürettiği gameobject'i döndürüyor.
            textMeshPros[i].SetText(letters[i].ToString());
            // DOTween ile TextMesh'i hedef pozisyona taşı
            textMeshPros[i].transform.DOMove(targetPositions[arr[i]].position, moveDuration)
                .SetEase(Ease.InOutQuad) // Hareketin hız eğrisi
                .SetDelay(delayBetweenLetters * i) // Harf arasındaki gecikme (opsiyonel)
                .OnComplete(() => {
                   
                    GameObject temp = textMeshPros[0].gameObject; //direkt destroy edersek bir daha kullanamayız diye.
                    textMeshPros.RemoveAt(0);
                    Destroy(temp);
                    //GameControl.Instance.EndGameControl(); //bunu buraya ekleyince coinleri animasyon sayısı kadar arttırıyo

                });

                



        }

    }

 }







    











/*
{
GameControl gameControl = FindObjectOfType<GameControl>();

RectTransform rectTransform = externalTextMeshPro.rectTransform;


foreach (var word in rectTransform)
{

    // Her 2D nesneyi ayrı ayrı 2D hedef pozisyona animasyonla taşıyın
    Vector3 targetPosition2D = new Vector3(gameControl.Boxes[currentIndex].position.x, gameControl.Boxes[currentIndex].position.y, 0f);
    rectTransform.DOMove(targetPosition2D, moveDuration)
       .SetEase(Ease.InOutQuad);
}

// Animasyonların tamamlanmasını beklemek için bir süre bekle
StartCoroutine(WaitForAnimationCompletion());
}


private IEnumerator WaitForAnimationCompletion()
{
yield return new WaitForSeconds(moveDuration);

// Animasyonlar tamamlandığında bir sonraki hedefe geçin
currentIndex++;
PlayAnimation();
}
}




/*
    // Her harfi hedef pozisyona taşı
    for (int i = 0; i < externalTextMeshPro.text.Length; i++)
    {
        char[] characters = externalTextMeshPro.ToCharArray(); // Kelimeyi karakter dizisine dönüştür
        char letter = externalTextMeshPro.text[i];

        Vector3 targetPosition = targetPositions[i].position;

        // DOTween ile harfi hedef pozisyona taşı
        DOTween.To(() => letter.transform.position,
                    (x) => letter.transform.position = x,
                    targetPosition, moveDuration)
            .SetEase(Ease.InOutQuad);
    }








/*

// Verilen kelimeyi externalTextMeshPro nesnesine ayarla
externalTextMeshPro.text = ClickControl.CurrentWord;

for (int i = 0; i < externalTextMeshPro.text.Length; i++)
{
    char letter = externalTextMeshPro.text[i];
    Vector3 targetPosition = targetPositions[i];

    // DOTween ile harfi hedef pozisyona taşı
    int characterIndex = externalTextMeshPro.textInfo.characterInfo[i].index;
    DOTween.To(() => externalTextMeshPro.textInfo.characterInfo[characterIndex].bottomLeft,
                (x) => UpdateVertexPosition(characterIndex, x),
                targetPosition, moveDuration)
        .SetEase(Ease.InOutQuad);
}
}

// Vertex pozisyonunu güncellemek için bu fonksiyonu kullanın
private void UpdateVertexPosition(int characterIndex, Vector3 newPosition)
{
TMP_CharacterInfo charInfo = externalTextMeshPro.textInfo.characterInfo[characterIndex];
int vertexIndex = charInfo.vertexIndex;

for (int i = 0; i < 4; i++)
{
    externalTextMeshPro.textInfo.meshInfo[0].vertices[vertexIndex + i] = newPosition;
}

externalTextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
}
*/




