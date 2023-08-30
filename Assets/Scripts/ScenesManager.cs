using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class ScenesManager : MonoBehaviour
{

    [SerializeField] private GameObject currentLevelPrefab; // Mevcut seviye prefabını temsil eden referans

    public float delayInSeconds = 2.0f; // Next level panelini ne kadar süre sonra açmak istediğinizi ayarlayın
    public GameObject NextText;
    public GameObject[] levelPrefabs; // Seviye prefablarını içeren dizi
    private int currentLevelIndex = 0; // Mevcut seviye indeksi
    public int CoinsScore= 0;
    private int coinsPerLevel = 1;
    public TextMeshProUGUI CoinText;
    public static ScenesManager Instance; //her class'tan ulaşabilmem için.
    //Instance yerine istediğimizi verebiliriz ama Instance en uygunu.
    private void Awake()
    {
        //singleton
        if (Instance == null)
        {
           
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //Sahnedeki objeyi yok etme.
        }
        else
        {
            Destroy(this);
        }
        GenerateLevel();
        print(PlayerPrefs.GetInt("Level")); //Level adlı key'le saklanan int değerini al.
        //oyuncunun son ilerlemesini takip etmek amacıyla kullanılır.
        NextText.SetActive(false);
        /*
        // Mevcut seviye indeksine göre prefabı çağır
        if (currentLevelIndex < LevelPrefabs.Count)
        {
            Instantiate(LevelPrefabs[currentLevelIndex], Vector3.zero, Quaternion.identity);
        }
         NextText.SetActive(false);
        */

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
    }

    // Bir sonraki seviyeye geçmek için çağırılabilir fonksiyon
    public void ShowNextLevel()
    {
        if (currentLevelPrefab != null)
        {
            // Belirtilen süre sonra objeyi yok etmek için bir Coroutine başlatın
            StartCoroutine(DestroyObjectWithDelay());
            // Destroy(currentLevelPrefab);
        }
        currentLevelIndex = PlayerPrefs.GetInt("Level"); //aldığın level değerini şuanki levelin indeksine eşitle.
        // Belirtilen süre sonra Next level panelini açmak için bir Coroutine başlatın
        StartCoroutine(ActivateNextLevelPanel());
       // NextText.SetActive(true);
        CoinsScore++;
        PlayerPrefs.SetInt("CoinsScore", CoinsScore);

        // Oyuncuya coin ekle
        int currentCoins = PlayerPrefs.GetInt("Coins", 1);
        currentCoins += coinsPerLevel;
        PlayerPrefs.SetInt("Coins", currentCoins);
        UpdateCoinText(); // Coin miktarını güncelle

        // Tüm seviyeler tamamlandıysa oyunu yeniden başlat
        if (currentLevelIndex >= levelPrefabs.Length)
        {
            currentLevelIndex = 0;
            PlayerPrefs.SetInt("Level", currentLevelIndex);
            NextText.SetActive(false);
        }

    }

    private IEnumerator DestroyObjectWithDelay()
    {
        // Belirtilen süre kadar bekleyin
        yield return new WaitForSeconds(delayInSeconds);

        // Bekleme süresi sona erdiğinde objeyi yok et
        if (currentLevelPrefab != null)
        {
            Destroy(currentLevelPrefab);
        }
    }

    private IEnumerator ActivateNextLevelPanel()
    {
        // Belirtilen süre kadar bekleyin
        yield return new WaitForSeconds(delayInSeconds);
        // Bekleme süresi sona erdiğinde Next level panelini aktif hale getirin
        if (NextText != null)
        {
            NextText.SetActive(true);
        }
    }




        private void UpdateCoinText()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 1);
        CoinText.GetComponent<TextMeshProUGUI>().text = "Coins: " + currentCoins;
    }
    public void GenerateLevel()
    {
        NextText.SetActive(false);
        //level atlamayı playerPrefs ile tuttuğun için işin bitince bunu true yap ve main menuye tıkla.
        //Çünkü sıfırlama işlemine main menuye atadın.
        int getLevel = PlayerPrefs.GetInt("Level");
        if (currentLevelIndex >= 0 && currentLevelIndex < levelPrefabs.Length)
            //Eğer şuanki level'in indeksi 0'a eşit ya da büyükse ve şuanki levelin indeksi
            //bütün prefabları tutan dizimin uzunluğundan küçükse 
        {
            currentLevelPrefab = Instantiate(levelPrefabs[getLevel],Vector2.zero, Quaternion.identity);
            //diğer leveli getir.
        }


    }
    /*
    public void LoadNextLevel()
    {
        // Eğer mevcut seviye prefabı varsa, devre dışı bırak
        if (currentLevelPrefab != null)
        {
            currentLevelPrefab.SetActive(false);
        
        }
        currentLevelIndex++;
        /*
        // Tüm seviyeler tamamlandıysa oyunu yeniden başlat
        if (currentLevelIndex >= LevelPrefabs.Count)
        {
           
            currentLevelIndex = 0;
            NextText.SetActive(false);
            
        }
        
        // Yeni seviye prefabını etkinleştir
        currentLevelPrefab = LevelPrefabs[currentLevelIndex];
        currentLevelPrefab.SetActive(true);

        // Mevcut seviye indeksine göre prefabı çağır
        if (currentLevelIndex < LevelPrefabs.Count)
        {
            Instantiate(LevelPrefabs[currentLevelIndex], Vector3.zero, Quaternion.identity);
          
        }
    //eğer sahne şeklinde olsaydı.

    public enum Scene //enum=değiştirilemez sabit

    {
        //bu isimler scene'lerin ile aynı sırada ve aynı isimde olmalı.
        Level1,
        Level2
    }
   

    public void LoadScene(Scene scene)
    {
        
        SceneManager.LoadScene(scene.ToString());
        //bunu yapma sebebimiz scene enum değerinde ama bizim onu stringe çevirip loadscenede içini okumamız gerek.
      
    }
    /*
     //ana menüde birinci levele gelsin diye
    public void LoadNewGame() 
        {

        SceneManager.LoadScene(Scene.Level1.ToString());

        }
    
    
    public void LoadNextScene()
    {
        CoinsScore++;
        PlayerPrefs.SetInt("CoinsScore", CoinsScore);

        // Oyuncuya coin ekle
        int currentCoins = PlayerPrefs.GetInt("Coins", 1);
        currentCoins += coinsPerLevel;
        PlayerPrefs.SetInt("Coins", currentCoins);
        UpdateCoinText(); // Coin miktarını güncelle
        LoadNextLevel();
       
      
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    */
    public void LoadMainMenu()
    {
        //CoinsScore = 0; // Coins sayısını sıfırla
        PlayerPrefs.DeleteAll(); // PlayerPrefs ile sil.
        
        //UpdateCoinText();
        //coinsPerLevel = 1;
        // Ana menüye dönme işlemlerini gerçekleştir
        // SceneManager.LoadScene(Scene.Level1.ToString());
        //anamenü yapılınca buraya ana menünün olduğu scene yazılcak.
    }
    /*
    private void UpdateCoinText()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 1);
        CoinText.GetComponent<TextMeshProUGUI>().text = "Coins: " + currentCoins;
    }


  */


}
