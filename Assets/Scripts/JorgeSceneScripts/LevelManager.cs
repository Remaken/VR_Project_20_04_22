using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text pointManager;
    private int _pointCounter = 0;

    private void OnEnable()
    {
        PointButtonReset.ScoreReset += ScoreResetter;
    }

    private void OnDisable()
    {
        PointButtonReset.ScoreReset -= ScoreResetter;
    }

    private void ScoreResetter()
    {
        _pointCounter = 0;
    }

    private void Update()
    {
        PointManagement();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Ball>()!=null)
        {
            _pointCounter++;
        }
    }

    private void PointManagement()
    {
        pointManager.text = _pointCounter.ToString();
    }
}
