using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ANCIEN_UI_SCRIPT : MonoBehaviour
{




    // _________________________________________INTERACTION MENU_____________________________________________________
    public string loadScene;

    public void PlayMode() 
    
    {
        SceneManager.LoadScene("Level1_NEO");
    }

  
    public void Restart()
    {
        //WID: Reload my Current Scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ==> Ca me parlerait plus avec le nom mais pas optimis� pour r�utilisation du script 
        // Permet de r�initialiser la scene

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
          // Charger la scene par son Index. Optimiser le code avec cette m�thode plus tard pour r�utiliser le script dans d'autres projets
          public void LoadSceneByIndex(int sceneIndex)
          {
               SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
               Donc: SceneManager.LoadScene(2, LoadSceneMode.Single);
          }

         */
    }

    /********                           END DIFFERENTS LEVELS/WORLD I CAN CHOOSE                            ********/


   
}
 