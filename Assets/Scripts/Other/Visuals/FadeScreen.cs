using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    //[SerializeField] private Image fadeScreen;

    //private bool transition_;
    //private bool fadeIn = false;

    //private float time = 1;
    //private float alpha;

    //public void FadeActive() { transition_ = true; }

    //private void Update()
    //{
    //    if (transition_)
    //    {
    //        if (fadeIn)
    //        {
    //            if (time <= 0)
    //            {
    //                alpha += Time.deltaTime;

    //                if (alpha >= 1)
    //                {
    //                    fadeIn = false;
    //                    transition_ = false;
    //                    time = 1;
    //                }
    //            }
    //            else
    //            {
    //                time -= Time.deltaTime;
    //            }
    //        }
    //        else
    //        {
    //            if (alpha >= 0)
    //            {
    //                alpha -= Time.deltaTime;

    //                if (alpha == 0)
    //                {
    //                    fadeIn = true;
    //                }
    //            }
    //        }

    //        fadeScreen.color = new Color(0, 0, 0, alpha);
    //    }
    //}
}
