using UnityEngine;

//!  Makes a sprite always face the camera. 
/*!
  Detects the location of the camera and rotates the sprite to face it on Update.
*/

public class Billboard : MonoBehaviour
{
    //! A constructor.
    /*!
      A more elaborate description of the constructor.
    */
    void Update()
    {
            transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
