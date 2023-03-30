using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _scoreCurrent;
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private int _pointDestroyables;
    [SerializeField] private int _pointAvoidable;
    [SerializeField] private int _pointOpposable;
    [SerializeField] private int _pointMissed;

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
            // ScoreDestroyable();
            Score(_pointDestroyables);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("AvoidableObj"))
        {
            print("Avoidable object hit ! + 50");
            // ScoreAvoidable();
            Score(_pointAvoidable);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Gloves") && gameObject.CompareTag("OpposableObj"))
        {
            print("Opposable object hit ! + 100");
            // ScoreOpposable();
            Score(_pointOpposable);
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
            // ScoreMissed();
            Score(_pointMissed);
            gameObject.SetActive(false);
        }
    }

    private void Score(int scoreObj)
    {
        _scoreCurrent += scoreObj;
        _scoreText.text = _scoreCurrent.ToString();
    }
}
