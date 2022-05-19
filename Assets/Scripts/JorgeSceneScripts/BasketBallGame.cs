using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasketBallGame : MonoBehaviour
{
    [SerializeField] private Text pointManager;
    private int _pointCounter = 0;
    private bool basketMiniGameStarted = false;

    private void OnEnable()
    {
        PointButtonReset.ScoreReset += ScoreReset;
        PointCounter.UpdateScore += PointScored;
    }

    private void OnDisable()
    {
        PointButtonReset.ScoreReset -= ScoreReset;
        PointCounter.UpdateScore -= PointScored;
    }

    private void ScoreReset()
    {
        _pointCounter = 0;
    }

    private void Update()
    {
        //if (basketMiniGameStarted)
        {
            PointManagement();
        }
    }

    private void PointScored()
    {
        _pointCounter++;
    }

    private void PointManagement()
    {
        pointManager.text = _pointCounter.ToString();
    }
}
