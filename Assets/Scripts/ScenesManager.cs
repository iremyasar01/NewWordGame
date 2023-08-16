using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public int CoinsScore= 1;
    private int coinsPerLevel = 1;
    public TextMeshProUGUI CoinText;
    public static ScenesManager Instance; //her class'tan ulaşabilmem için.
    //Instance yerine istediğimizi verebiliriz ama Instance en uygunu.
    private void Awake()
    {
        Instance = this;
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
    */

    public void LoadNextScene()
    {
        CoinsScore++;
        PlayerPrefs.SetInt("CoinsScore", CoinsScore);

        // Oyuncuya coin ekle
        int currentCoins = PlayerPrefs.GetInt("Coins", 1);
        currentCoins += coinsPerLevel;
        PlayerPrefs.SetInt("Coins", currentCoins);
        UpdateCoinText(); // Coin miktarını güncelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void LoadMainMenu()
    {
        //CoinsScore = 0; // Coins sayısını sıfırla
        PlayerPrefs.DeleteAll(); // PlayerPrefs ile sil.
        //UpdateCoinText();
        //coinsPerLevel = 1;
        // Ana menüye dönme işlemlerini gerçekleştir
        SceneManager.LoadScene(Scene.Level1.ToString());
        //anamenü yapılınca buraya ana menünün olduğu scene yazılcak.
    }
    private void UpdateCoinText()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 1);
        CoinText.GetComponent<TextMeshProUGUI>().text = "Coins: " + currentCoins;
    }
}
