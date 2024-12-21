using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//!  A component that loads scenes.
/*!
  Loads scens by name or just by build order.
*/
public class SceneLoader : MonoBehaviour
{

    //!  Loads the main game screen.
    /*!
      Uses string input to load the starter scene.
    */
    public void LoadSceneByName()
    { 
        SceneManager.LoadScene("Create-with-VR-Starter-Scene");
    }


    //!  Loads the next scene in build order.
    /*!
      Finds the next scene in the build index and loads it.
    */
    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
