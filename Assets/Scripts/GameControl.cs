using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System;

public class GameControl : MonoBehaviour
{
   
    public static GameControl Instance { get; private set; }
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
    public int[] arr9;
    //dizi oluşturup unity üzerinden kelimeleri dizilere yerleştirdik.

    public List<string> CorrectWords;
    public bool[] AllCorrectWords;
    public static bool EndGame;
    //public GameObject NextText;


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
        arrs.Add(arr9);

        AllCorrectWords = new bool[CorrectWords.Count];

    }
    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (ClickControl.Control == true && EndGame == false)
        //tıklama bittiyse ve oyun bitmediyse aşağıdaki kodlar çalışsın.
        //kelimenin doğruluğunu tespit etmek için.
        {
            
            ClickControl.Control = false; //sadece bi kere çalışması için geri false'a çevirmeliyiz yoksa frame sayısı kadar çalışır.

            for (int i = 0; i < CorrectWords.Count; i++)
            {
             
                if (ClickControl.CurrentWord == CorrectWords[i] && AllCorrectWords[i] == false)
                //eğer girdiğim şimdiki kelime CorrectWords listesinden bir elemana eşitse 

                {
                    AllCorrectWords[i] = true;
                    int[] index = arrs[i]; 
                    Debug.Log(CorrectWords[i].ToString().Length); //doğru kelimeyi bulduğu yer.
                   AnimationControl.Instance.MoveTextMesh(CorrectWords[i].ToString(), index );

                    //for (int j = 0; j < CorrectWords[i].Length; j++) //correctWords listesindeki tüm elemenlar bulunana kadar
                    //{

                        //AnimationControl.Instance.MoveTextMesh(CorrectWords[i].ToString(), index);
                        // Boxes[index[j]].GetComponent<TextMeshPro>().text = ClickControl.CurrentWord[j].ToString();
                        //git Boxes listesininin içindeki dizilerin Text'ini al onları şimdiki kelimenin?
                        //bunu stringe çevir.


                    //}
                   
                }

                   
            }
            
            ClickControl.CurrentWord = "";
            EndGameControl();

        }

    }



    public void EndGameControl()
    {
        int num = 0;
        for (int i = 0; i < AllCorrectWords.Length; i++)
        //bütün doğru kelimeler bulunana kadar.
        {
            if (AllCorrectWords[i] == false) //eğer bütün doğru kelimeler bulunmamışsa
            {
                //sayıyı bir arttır.
                num++;
            }
        }
        if (num == 0) //eğer sayaç sıfırlanırsa
        {
           // EndGame = true; //oyun biter.
            ScenesManager.Instance.ShowNextLevel();
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            //scenesManager.LoadNextLevel();

        }

    }

}


       


    


    /*
      private void MoveToNextTarget()
      {

              if (currentIndex < Boxes.Count)
              {
                  foreach (var Letter in selectedLetters2)
                  {
                      // Her 2D nesneyi ayrı ayrı 2D hedef pozisyona animasyonla taşıyın
                      Vector3 targetPosition2D = new Vector3(Boxes[currentIndex].position.x, Boxes[currentIndex].position.y, 0f);
                      Letter.DOMove(targetPosition2D, moveDuration);
                  }

                  // Animasyonların tamamlanmasını beklemek için bir süre bekle
                  StartCoroutine(WaitForAnimationCompletion());
              }
          }

      private IEnumerator WaitForAnimationCompletion()
      {
          yield return new WaitForSeconds(moveDuration);

          // Animasyonlar tamamlandığında bir sonraki hedefe geçin
          currentIndex++;
          MoveToNextTarget();
      }











      for (int i = 0; i < arrs.Count; i++)
      {
          int[] WordArray = arrs[i];
          Transform target = Boxes[i];

          // Harf dizisini hedef pozisyonuna taşı
          for (int j = 0; j < WordArray.Length; j++)
          {
              int WordIndex = WordArray[j];

              // int değerini kullanarak harf nesnesini alın
              Transform letter =selectedLetters2[WordIndex]; // yourLetterArray burada harf nesnelerinizi içeren bir dizi olmalıdır

              // DOTween kullanarak harfi hedef pozisyona taşı
              letter.DOMove(target.position, moveDuration)
                  //.SetDelay(delayBetweenLetters * j) // Harf arasındaki gecikme (opsiyonel)
                  .SetEase(Ease.InOutQuad); // Hareket kolaylığı (isteğe bağlı)
          }
      }
  }






  async void ForDotween() //asyc asenkron fonk demek.

  {

    foreach(var Letter in selectedLetters2) //harflerin herbirini yukarı hareket ettirir ve bekler.
    {
       await Letter.DOMoveY(2, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion();
    }
  }
  async void Tasks()
  {
    var tasks = new List<Task>();

    foreach (var Letter in selectedLetters2)
    {

        tasks.Add(Letter.DOMoveY(2, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion());
    }


    await Task.WhenAll(tasks); //tüm nesneelerin hareketini bekelr.

    foreach (var Letter in selectedLetters2) Letter.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
  }

}
      
*/


