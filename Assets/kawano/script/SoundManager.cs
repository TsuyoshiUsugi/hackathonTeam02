using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;


/// <summary>
/// BGMやSEの再生を管理するクラス
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// BGMの種類
    /// </summary>
    public enum BGM
    {
        Title,
        Ingame,
        GameClear,
        GameOver,
        Max,
    }

    /// <summary>
    /// 効果音の種類
    /// </summary>
    public enum ONE_SHOT_SOUND
    {
        Attack,
        Damage, 
        Click,
        ChangeSlot,
        Max,
    }

    /// <summary>
    /// BGM 一覧
    /// </summary>
    [SerializeField]
    private GameObject[] _BGMArray = new GameObject[(int)BGM.Max];

    /// <summary>
    /// 効果音一覧
    /// </summary>
    [SerializeField]
    private AudioClip[] _OneShotSoundArray = new AudioClip[(int)ONE_SHOT_SOUND.Max];

    /// <summary>
    /// BGM再生器
    /// </summary>
    [SerializeField]
    private AudioSource _BGMSource = null;

    /// <summary>
    /// 効果音再生器
    /// </summary>
    [SerializeField]
    private AudioSource _OneShotSoundSource = null;



    void Awake()
    {
        foreach (BGM value in Enum.GetValues(typeof(BGM)))
        {
            // BGMの登録
            if (Enum.GetName(typeof(BGM), value) == "Max") { continue; }
            string bgmObjName = Enum.GetName(typeof(BGM), value) + "BGM";
            GameObject bgmObj = GameObject.Find(bgmObjName);
            _BGMArray[(int)value] = bgmObj;

            // いったん全部再生ストップ
            _BGMSource = bgmObj.GetComponent<AudioSource>();
            StopBGM();
        }
    }

    void Update()
    {
        // テスト用入力
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    PlayBGM(BGM.Title);
        //}
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    StopBGM();
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayOneShotSound(ONE_SHOT_SOUND.Attack);
        //}
    }

    /// <summary>
    /// BGM再生
    /// </summary>
    /// <param name="bgmId"></param>
    public void PlayBGM(BGM bgmId)
    {
        _BGMSource = _BGMArray[(int)bgmId].GetComponent<AudioSource>();
        _BGMSource.Play();
    }

    /// <summary>
    /// BGMストップ
    /// </summary>
    public void StopBGM()
    {
        _BGMSource.Stop();
    }
    
    /// <summary>
    /// SE再生（OneShot）
    /// </summary>
    /// <param name="soundId"></param>
    public void PlayOneShotSound(ONE_SHOT_SOUND soundId)
    {

        AudioClip targetSound = _OneShotSoundArray[(int)soundId];
        if (targetSound == null)
        {
            Debug.LogWarning( "[SoundManager]" + soundId + "に登録された効果音が再生できません");
            return;
        }

        _OneShotSoundSource.PlayOneShot(targetSound);
    }
}
