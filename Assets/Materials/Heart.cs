using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Heart : MonoBehaviour

{
    //public health=3; 
    //Knife healthBar;
    public int heart = 3;
    public UnityEngine.UI.Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;


    public void HeartCalc(int heart)
    {

        hearts[heart].sprite = emptyHeart;
        // heart--;




    }
    //for (int i = 0; i < heart; i++)
    //       {
    //          
    //       }

}
