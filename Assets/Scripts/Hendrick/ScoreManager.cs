using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _scoreCurrent;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        print("ScoreManager est détecté");

        _scoreCurrent = 0;
        _scoreText.text = _scoreCurrent.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("DestroyableObj1")) ||
            (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("DestroyableObj2")) ||
            (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("DestroyableObj3")) ||
            (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("DestroyableObj4")))
        {
            print("Destroyable object hit ! + 100");
            ScoreDestroyable();
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("AvoidableObj"))
        {
            print("Avoidable object hit ! + 50");
            ScoreAvoidable();
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("OpposableObj"))
        {
            print("Opposable object hit ! + 100");
            ScoreOpposable();
            gameObject.SetActive(false);
        }

        if ((other.gameObject.CompareTag("LimitZone") && gameObject.CompareTag("OpposableObj")) ||
            (other.gameObject.CompareTag("LimitZone") && gameObject.CompareTag("AvoidableObj")) ||
            (other.gameObject.CompareTag("LimitZone") && gameObject.CompareTag("DestroyableObj4")) ||
            (other.gameObject.CompareTag("LimitZone") && gameObject.CompareTag("DestroyableObj3")) ||
            (other.gameObject.CompareTag("LimitZone") && gameObject.CompareTag("DestroyableObj2")) ||
            (other.gameObject.CompareTag("LimitZone") && gameObject.CompareTag("DestroyableObj1")))
        {
            print("The player missed the object! - 50");
            ScoreMissed();
            gameObject.SetActive(false);
        }
    }

    // ! Refactoring needed
    private void ScoreDestroyable()
    {
        _scoreCurrent += 100;
        _scoreText.text = _scoreCurrent.ToString();
    }

    private void ScoreAvoidable()
    {
        _scoreCurrent += 50;
        _scoreText.text = _scoreCurrent.ToString();
    }

    private void ScoreOpposable()
    {
        _scoreCurrent += 50;
        _scoreText.text = _scoreCurrent.ToString();
    }

    private void ScoreMissed()
    {
        _scoreCurrent += -50;
        _scoreText.text = _scoreCurrent.ToString();
    }

    public void DisplayScore()
    {
        print("DisplayScore is called");
        _scoreText.text = _scoreCurrent.ToString();
    }
}
