using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// 사운드 싱글턴
    /// </summary>
    #region
    private static SoundManager _instance;
    public static SoundManager instance
    {
        get
        {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
                if(_instance ==null)
                {
                    Debug.Log("no Singleton");

                }
            }
                return _instance;
        }
    }
    private void Awake()
    {
        if(_instance ==null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public AudioSource soundplay;
    public AudioSource[] effectbgm;
    public Toggle soundtoggle;
    public Toggle effecttoggle;
    private void Update()
    {
        if (soundtoggle.isOn)
        {
            soundplay.volume = 1;
        }
        else
        {
            soundplay.volume = 0;
        }
        if (effecttoggle.isOn)
        {
            for (int i = 0; i < effectbgm.Length; i++)
            {
                effectbgm[i].volume = 1;
            }
        }
        else
        {
            for (int i = 0; i < effectbgm.Length; i++)
            {
                effectbgm[i].volume = 0;
            }
        }
     
       

    }

}
