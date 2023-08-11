using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance; //her class'tan ulaşabilmem için.
    //Instance yerine istediğimizi verebiliriz ama Instance en uygunu.
    private void Awake()
    {
        Instance = this;
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.Level1.ToString());
        //anamenü yapılınca buraya ana menünün olduğu scene yazılcak.
    }
}
