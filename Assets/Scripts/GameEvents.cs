using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public delegate void EnableSqaureSelection();
    public static event EnableSqaureSelection OnEnableSqaureSelection;

    public static void EnableSqaureSelectionMethod()
    {
        if (OnEnableSqaureSelection != null)
            OnEnableSqaureSelection();
    }

    //********************************************************
    public delegate void DisableSqaureSelection();
    public static event DisableSqaureSelection OnDisableSqaureSelection;

    public static void DisableSqaureSelectionMethod()
    {
        if (OnDisableSqaureSelection != null)
            OnDisableSqaureSelection();
    }

    //*********************************************************

    public delegate void SelectSquare(Vector3 position);
    public static event SelectSquare OnSelectSquare;

    public static void SelectSquareMethod(Vector3 position)
    {
        if (OnSelectSquare != null)
            OnSelectSquare(position);
    }
    //*********************************************************

    public delegate void CheckSqaure(string letter, Vector3 squarePosition, int squareIndex);
    public static event CheckSqaure OnCheckSqaure;

    public static void CheckSqaureMethod(string letter, Vector3 squarePosition, int squareIndex)
    {
        if (OnCheckSqaure != null)
            OnCheckSqaure(letter, squarePosition, squareIndex);
    }
    //*********************************************************

    public delegate void ClearSelection();
    public static event ClearSelection OnClearSelection;

    public static void ClearSelectioMethod()
    {
        if (OnClearSelection != null)
            OnClearSelection();
    }
    //*********************************************************
    public delegate void CorrectWord(string word, List<int> squareIndexes);

    public static event CorrectWord OnCorrectWord;

    public static void CorrectWordMethod(string word, List<int> squareIndexes)
    {
        if(OnCorrectWord != null)
        {
            OnCorrectWord(word, squareIndexes);
        }
    }
    //*********************************************************
   

    public delegate void BoardCompleted();
    public static event BoardCompleted OnBoardCompleted;

    public static void BoardCompletedMethod()
    {
        if (OnBoardCompleted != null)
            OnBoardCompleted();
    }
    //*********************************************************

    public delegate void UnlockNextLevelCategory();
    public static event UnlockNextLevelCategory OnUnlockNextLevelCategory;

    public static void UnLockLevelCategoryMethod()
    {
        if (OnUnlockNextLevelCategory != null)
            OnUnlockNextLevelCategory();
    }
    //*********************************************************

    public delegate void LoadNextLevel();
    public static event LoadNextLevel OnLoadNextLevel;

    public static void LoadNextLevelMethod()
    {
        if (OnLoadNextLevel != null)
            OnLoadNextLevel();
    }
    //*********************************************************

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public static void GameOverMethod()
    {
        if (OnGameOver != null)
            OnGameOver();
    }
    //*********************************************************

    public delegate void ToggleSoundFX();
    public static event ToggleSoundFX OnToggleSoundFX;

    public static void OnToggleSoundFXMethod()
    {
        if (OnToggleSoundFX != null)
            OnToggleSoundFX();
    }
}
