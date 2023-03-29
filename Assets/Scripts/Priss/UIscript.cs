using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{




    // _________________________________________INTERACTION MENU_____________________________________________________
    public string loadScene;
    //public UnityEvent OkLetsGo;
    public void PlayMode() 
    
    {
        SceneManager.LoadScene("Level1_NEO");
    }

  
    public void Restart()
    {
        //WID: Reload my Current Scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ==> Ca me parlerait plus avec le nom mais pas optimisé pour réutilisation du script 
        // Permet de réinitialiser la scene

        int currentSceneIndex;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);


    }

    // -----------------------         PAUSE          --------------------------------------

    private bool pauseMode = false;

    public void TimeStopper()
    {
        if (pauseMode)
        {
            pauseMode =   false;
            Time.timeScale = 1f;
        }
        else
        {
            pauseMode =  true;
            Time.timeScale = 0f;
        }
    }

    //                    PAUSE          --------------------------------------




    // ____________________________________DIFFERENTS LEVELS/WORLD I CAN CHOOSE________________________________
    public void LoadNeo()
    {
        SceneManager.LoadScene("Level1_NEO");
    }

    public void LoadRingy() 
    {
        SceneManager.LoadScene("Level3_RINGYSNOWY");
    }


    public void LoadHalo() 
    {
        SceneManager.LoadScene("Level2_FIREBOREAL");

        /*
          // Charger la scene par son Index. Optimiser le code avec cette méthode plus tard pour réutiliser le script dans d'autres projets
          public void LoadSceneByIndex(int sceneIndex)
          {
               SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
               Donc: SceneManager.LoadScene(2, LoadSceneMode.Single);
          }

         */
    }

    /********                           END DIFFERENTS LEVELS/WORLD I CAN CHOOSE                            ********/


    public Animation OkLetsGoAnimation;// ne fonctionne pas, je n'arrive pas le faire glisser. recherche à faire

    private void Awake()
    {
        OkLetsGoAnimation.Play();
        Invoke("StopAnimation", OkLetsGoAnimation.clip.length); // puis j'arrête après
    }

    private void StopAnimation()
    {
        OkLetsGoAnimation.Stop();
    }



    void Update()
    {
        //Pour la Pause
        if (Input.GetKeyDown(KeyCode.P))

        {
            TimeStopper();
        }

    }

}
 