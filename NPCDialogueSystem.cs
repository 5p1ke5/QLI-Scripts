using System;
using UnityEngine;
using UnityEngine.UI;

//!  An NPC object that displays text when the player is close.
/*!
  Detects the location of the player object. If the player object is near displays text. If the player text is outside of range hides the text.
*/
public class NPCDialogueSystem : MonoBehaviour
{
    //Time to wait between displaying the texts in the array.
    public float textTimeIncrement = 5.0f;

    //Different messages for the NPC to display. One message is ideal but you can do more if necessary.
    public string[] texts;

    //Text component that will display texts. Will usually be set in prefab.
    public Text dialogueText;

    // Player Detection value assigned to false
    bool playerDetection = false;

    //Timer variable.
    private float textTimer;
    private int textIndex = 0;


    //!  Initializes variables on start.
    /*!
        Initializes the dialogueText as hidden and starts the timer for text to increment
    */
    void Start()
    {
        dialogueText.gameObject.SetActive(false);
        textTimer = textTimeIncrement;
    }
    
    void Update()
    {
        if (playerDetection)
       {
            dialogueText.text = texts[textIndex];

            //Increment timer.
            if (textTimer > 0)
            {
                textTimer -= Time.deltaTime;
            }
            //If timer finishes counting down increments index, resets timer.
            else
            {
                textIndex++;
                if (textIndex >= texts.Length)
                {
                    //If index reaches the end of the texts array resets it to 0.
                    textIndex = 0;
                }

                textTimer = textTimeIncrement;
            }
       } 
       else 
       {
            dialogueText.text = "";
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if OnTrigger detects the Player, then Player Detection is set to true
        if (other.tag == "MainCamera")
        {
            playerDetection = true;
            dialogueText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Player Detection is set to false when left range
            playerDetection = false;
            dialogueText.gameObject.SetActive(false);
    }
}
