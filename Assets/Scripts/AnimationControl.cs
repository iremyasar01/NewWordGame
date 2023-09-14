using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using System;

public class AnimationControl : MonoBehaviour
{

    [SerializeField] private ParticleSystem particle = default;
    public GameObject prefab; //textMesh'i içeren prefab.
    //public TextMeshPro textMesh;
    public List<Transform> targetPositions; // Her harf için hedef pozisyonların listesi
    // Bu sınıfın tek örneğini oluşturmak için bir Singleton kullanabilirsiniz.
    public static AnimationControl Instance { get; private set; }
    public float moveDuration; // Hareket süresi
    public float delayBetweenLetters; // Yok olmadan önce bekleme süresi


    // List<TextMeshPro> temp = new List<TextMeshPro>();
    private void Awake()
    {
        Instance = this;
     

    }

    public void MoveTextMesh(string letters, int[] arr)
    {

        int letterCount = letters.Length;
       
       for (int i = 0; i < letterCount; i++) //kelime sayısı kadar prefab oluştur.
        { 

               Transform target= targetPositions[arr[i]].transform;
               //burda tanımlamamızın sebebi hafızada yer kaplama.

                TextMeshPro temp = Instantiate(prefab).GetComponent<TextMeshPro>();
                 //ürettiği gameobject'i döndürüyor.
                 //positions'ları prefaba ekledik.
                temp.SetText(letters[i].ToString());
                // DOTween ile TextMesh'i hedef pozisyona taşı
                temp.transform.DOMove(target.position, moveDuration)
                .SetEase(Ease.InOutQuad) // Hareketin hız eğrisi
                 .SetDelay(delayBetweenLetters * i) // Harf arasındaki gecikme (opsiyonel)
                 .OnComplete(() =>
                 {
                     temp.transform.SetParent(target);
                     //temp target'ın child'ı haline geliyor.
                     temp.DOColor(Color.white, moveDuration)
                      .SetEase(Ease.InOutQuad);

                     SpriteRenderer spriteRenderer = target.GetComponentInParent<SpriteRenderer>();
                     spriteRenderer.DOColor(Color.blue,moveDuration)
                     .SetEase(Ease.InOutQuad);

                     particle.transform.position = target.position;
                     particle.Play();

                     /*
                     if (particle == null)
                     {
                         particle = GetComponent<ParticleSystem>();
                     }

                     if (particle != null && !particle.IsAlive(true))
                     {
                         Destroy(gameObject);
                     }


                     //PARTICLE BURAYA

                     /*
                     if (GameControl.EndGame == true)
                     {
                         foreach (var textMeshPro in temp)
                         {
                             Destroy(textMeshPro.gameObject);
                         }
                         //GameObject temp = temp[i].gameObject; //direkt destroy edersek bir daha kullanamayız diye.
                         temp.Clear();
                          //Destroy(temp);



                     }
                     */


                     //GameObject temp = temp[0].gameObject; //direkt destroy edersek bir daha kullanamayız diye.
                     //temp.RemoveAt(0);
                     //Destroy(temp);
                     //  GameControl.Instance.Boxes[arr[j]].GetComponent<TextMeshPro>().text = ClickControl.CurrentWord[j].ToString();

                     //GameControl.Instance.EndGameControl(); //bunu buraya ekleyince coinleri animasyon sayısı kadar arttırıyo

                 });

         }
     }
            


 }
   































