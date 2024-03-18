using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLeveldPopup : MonoBehaviour
{
    [System.Serializable]
    public struct CategoryName
    {
        public string name;
        public Sprite sprite;
    };

    public GameData currentGameData;
    public List<CategoryName> categoryName;
    public GameObject winPopup;
    public Image categotyNameImage;


    void Start()
    {
        winPopup.SetActive(false);

        GameEvents.OnUnlockNextLevelCategory += OnUnlockNextLevelCategory;
    }

    private void OnDisable()
    {
        GameEvents.OnUnlockNextLevelCategory -= OnUnlockNextLevelCategory;
    }

    private void OnUnlockNextLevelCategory()
    {
        bool captureNext = false;
        foreach (var writing in categoryName)
        {
            if (captureNext)
            {
                categotyNameImage.sprite = writing.sprite;
                captureNext = false;
                break;
            }

            if(writing.name == currentGameData.selectedCategoryName)
            {
                captureNext = true;
            }
          
        }
        winPopup.SetActive(true);
    }

}
