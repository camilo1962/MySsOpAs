using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountGameTimer : MonoBehaviour
{
    public GameData currentGameData;
    public Text timerText;

    private float _timeLeft;
    private float _minutes;
    private float _seconds;
    private float _oneSecondsDown;
    private bool _timerOut;
    private bool _stopTimer;

    void Start()
    {
        _stopTimer = false;
        _timerOut = false;
        _timeLeft = currentGameData.selectedBoardData.timeInSeconds;
        _oneSecondsDown = _timeLeft - 1f;

        GameEvents.OnBoardCompleted += StopTimer;
        GameEvents.OnUnlockNextLevelCategory += StopTimer;

    }

    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= StopTimer;
        GameEvents.OnUnlockNextLevelCategory -= StopTimer;
    }

    private void Update()
    {
        if (_stopTimer == false)
            _timeLeft -= Time.deltaTime;
        if(_timeLeft <= _oneSecondsDown)
        {
            _oneSecondsDown = _timeLeft - 1f;
        }
    }
    public void StopTimer()
    {
        _stopTimer = true;  
    }

    private void OnGUI()
    {
       if(_timerOut == false)
        {
            if(_timeLeft > 0)
            {
                _minutes = Mathf.Floor(_timeLeft / 60);
                _seconds = Mathf.RoundToInt(_timeLeft % 60);

                timerText.text = _minutes.ToString("00") + ":" + _seconds.ToString("00");

            }
            else
            {
                _stopTimer = true;
                ActivateGameOverGUI();
            }
        }

        
    }

    private void ActivateGameOverGUI()
    {
        GameEvents.GameOverMethod();
        _timerOut = true;
    }
}
