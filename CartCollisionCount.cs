using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//!  An object that counts the grocery objects inside it.
/*!
  Uses a collision box to detect when an object enters the cart. Also randomly generates a grocery list at the start of each stage.
*/
public class CartCollisionCount : MonoBehaviour
{
    private int itemCount = 0;
    private int nannersCount = 0;
    private int nuggetsCount = 0;
    private int cakesCount = 0;
    private int crittersCount = 0;

    private int nannersNeeded;
    private int nuggetsNeeded;
    private int cakesNeeded;
    private int crittersNeeded;

    //Text component that will display item count. Will usually be set in prefab.
    public Text dialogueText;

    private void Start()
    {
        GenerateGroceries();
        UpdateDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Contains("Groceries"))
        {
            itemCount++;
            switch (other.tag)
            {
                case "GroceriesNanners":
                    nannersCount++;
                    break;
                case "GroceriesNuggets":
                    nuggetsCount++;
                    break;
                case "GroceriesFrostedCakes":
                    cakesCount++;
                    break;
                case "GroceriesCritters":
                    crittersCount++;
                    break;
            }

            if ((nannersCount >= nannersNeeded) & (nuggetsCount >= nuggetsNeeded) & (cakesCount >= cakesNeeded) & (crittersCount >= crittersNeeded))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            UpdateDisplay();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Groceries"))
        {
            itemCount--;
            switch (other.tag)
            {
                case "GroceriesNanners":
                    nannersCount--;
                    break;
                case "GroceriesNuggets":
                    nuggetsCount--;
                    break;
                case "GroceriesFrostedCakes":
                    cakesCount--;
                    break;
                case "GroceriesCritters":
                    crittersCount--;
                    break;
            }
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        String write = "Items:";
        if (nannersNeeded > 0) write = write + "\nRainbow Nanners: " + nannersCount + "/" + nannersNeeded;
        if (nuggetsNeeded > 0) write = write + "\nChicken Nuggets: " + nuggetsCount + "/" + nuggetsNeeded;
        if (cakesNeeded > 0) write = write + "\nFrosted Cakes: " + cakesCount + "/" + cakesNeeded;
        if (crittersNeeded > 0) write = write + "\nCocoa Critters: " + crittersCount + "/" + crittersNeeded;
        dialogueText.text = write;

        Debug.Log(itemCount + ", " + nannersNeeded + ", " + nuggetsNeeded + ", " + cakesNeeded + ", " + crittersNeeded);
    }

    void GenerateGroceries()
    {
        nannersNeeded = UnityEngine.Random.Range(1, 2);
        nuggetsNeeded = UnityEngine.Random.Range(1, 2);
        cakesNeeded = UnityEngine.Random.Range(0, 2);
        crittersNeeded = UnityEngine.Random.Range(0, 2);
    }
}
