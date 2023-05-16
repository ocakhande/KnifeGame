using DG.Tweening;
using System.Collections;
using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private Congrats _nextLevel;
    [SerializeField] private Heart heart;
    [SerializeField] private Target target;
    [SerializeField] private Knife knife;
    public int counter = 0;
    bool knifeSpawned = false;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && (target.GetComponent<Target>().KnifeCount != 7))
        {
            if (knifeSpawned == false)
            {
                CreateKnife();
                counter++;
            }

        }
        if (Input.GetKey(KeyCode.W))
        {
            ForceKnife();
        }

    }
    private void CreateKnife()
    {
        knife = Instantiate(knifePrefab, transform).GetComponent<Knife>();
        knife.User = this;

        knifeSpawned = true;
    }

    private void ForceKnife()
    {
        if (knife == null) return;

        knife.transform.DOMoveZ(knife.transform.position.z + 10f, 2)
                                         .SetEase(Ease.Linear);
        knife = null;
        knifeSpawned = false;
    }

    public void ReloadGame()
    {
        StartCoroutine(_gameOver.ReloadScene());

    }
    public void ShowGameOver()
    {
        StartCoroutine(_gameOver.DisplayGameOver());

    }
    public void ShowNextLevel()
    {
        StartCoroutine(_nextLevel.DisplayCongrats());
    }

    public void GetKnifeProcess()
    {
        heart.heart--;
        //knifeCounter++;

        if (heart.heart==0)
        {
            ShowGameOver();

        }
        else if (target.KnifeCount==7 && heart.heart!=0)
        {
            ShowNextLevel();
        }
        else
        {
            heart.GetComponent<Heart>().HeartCalc(heart.heart);
        }

    }
}
