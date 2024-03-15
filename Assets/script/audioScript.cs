using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class audioScript : MonoBehaviour
{
    public AudioSource audios;
    public AudioSource[] sfxsound;
    public Button audiosBnt,btnSfx;
    public Sprite[] sprites,sfx1;
    bool isOn =false,isOn1=false;
    //detail of sfx
    //0.click
    //1.win
    //2.over
    //3.true
    //4.false
    //5.dice
    private void Start()
    {
       
    }
    IEnumerator wiat()
    {
        yield return new WaitForSeconds(1f);
    }
    public void Audio()
    {
        isOn =!isOn;
        if (isOn)
        {
            
            audiosBnt.image.sprite = sprites[1];
            audios.Play();
            audios.mute = true;
        }else if(!isOn)
        {
            audiosBnt.image.sprite = sprites[0];
            //audios.Play();
            audios.mute = false;
        }
    }
    public void sfx()
    {
        isOn1= !isOn1;
        if (isOn1)
        {
            btnSfx.image.sprite = sfx1[0];
            for(int i = 0;i<sfxsound.Length ;i++)
            {
                sfxsound[0].Play();
                sfxsound[i].mute = true;
            }


        }
        else if(!isOn1)
        {
            btnSfx.image.sprite =sfx1[1];
            for (int i = 0;i< sfxsound.Length ; i++)
            {
                //sfxsound[i].Play();
                sfxsound[i].mute = false;
            }
        }
    }
    public GameObject setting;
   
   
    public void btnsettingopen()
    {
        sfxsound[0].Play();
        StartCoroutine(wiat());
        setting.SetActive(true);
    }
    public void btnsettingclose()
    {
        sfxsound[0].Play();
        StartCoroutine(wiat());
        setting.SetActive(false);
    }
}
