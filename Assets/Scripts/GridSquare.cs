using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlphabetData;

public class GridSquare : MonoBehaviour
{
    public int SquareIndex { get; set; }

    private AlphabetData.LetterData _normalLetterData;
    private AlphabetData.LetterData _selectedLetterData;
    private AlphabetData.LetterData _correctLetterData;

    private SpriteRenderer _displayedImage;

    private bool _selected;
    private bool _clicked;
    private int _index = -1;
    private bool _correct;

    private AudioSource _source;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public int GetIndex()
    {
        return _index;
    }

    void Start()
    {
        _selected = false;
        _clicked = false;
        _correct = false;
        _displayedImage = GetComponent<SpriteRenderer>();
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnEnableSqaureSelection += OnEnableSqaureSelection;
        GameEvents.OnDisableSqaureSelection += OnDisableSqaureSelection;
        GameEvents.OnSelectSquare += OnSelectSquare;
        GameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvents.OnEnableSqaureSelection -= OnEnableSqaureSelection;
        GameEvents.OnDisableSqaureSelection -= OnDisableSqaureSelection;
        GameEvents.OnSelectSquare -= OnSelectSquare;
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if(_selected && squareIndexes.Contains(_index))
        {
            _correct = true;
            _displayedImage.sprite = _correctLetterData.image;
        }

        _selected = false;
        _clicked = false;
    }

    public void OnEnableSqaureSelection()
    {
        _clicked = true;
        _selected = false;
    }

    public void OnDisableSqaureSelection()
    {
        
        _selected = false;
        _clicked = false;

        if (_correct == true)
            _displayedImage.sprite = _correctLetterData.image;
        else
            _displayedImage.sprite = _normalLetterData.image;
        
    }

    public void OnSelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position)
            _displayedImage.sprite = _selectedLetterData.image;
    }


    public void SetSprite(AlphabetData.LetterData normalLetterData, AlphabetData.LetterData selectedLetterData,
    AlphabetData.LetterData correctLetterData)
    {
        _normalLetterData = normalLetterData;
        _selectedLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normalLetterData.image;
    }

    private void OnMouseDown()
    {
        OnEnableSqaureSelection();
        GameEvents.EnableSqaureSelectionMethod();
        CheckSquare();
        _displayedImage.sprite = _selectedLetterData.image;
    }

    private void OnMouseEnter()
    {
        CheckSquare();
    }

    private void OnMouseUp()
    {
        GameEvents.ClearSelectioMethod();
        GameEvents.DisableSqaureSelectionMethod();
    }

    public void CheckSquare()
    {
        if(_selected == false && _clicked == true)
        {
            if (SoundManager.instance.IsSoundFxMuted() == false)
                _source.Play();
            _selected = true;
            GameEvents.CheckSqaureMethod(_normalLetterData.letter, gameObject.transform.position, _index);

        }
    }
}
