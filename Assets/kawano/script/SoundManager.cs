using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;


/// <summary>
/// BGM��SE�̍Đ����Ǘ�����N���X
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// BGM�̎��
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
    /// ���ʉ��̎��
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
    /// BGM �ꗗ
    /// </summary>
    [SerializeField]
    private GameObject[] _BGMArray = new GameObject[(int)BGM.Max];

    /// <summary>
    /// ���ʉ��ꗗ
    /// </summary>
    [SerializeField]
    private AudioClip[] _OneShotSoundArray = new AudioClip[(int)ONE_SHOT_SOUND.Max];

    /// <summary>
    /// BGM�Đ���
    /// </summary>
    [SerializeField]
    private AudioSource _BGMSource = null;

    /// <summary>
    /// ���ʉ��Đ���
    /// </summary>
    [SerializeField]
    private AudioSource _OneShotSoundSource = null;



    void Awake()
    {
        foreach (BGM value in Enum.GetValues(typeof(BGM)))
        {
            // BGM�̓o�^
            if (Enum.GetName(typeof(BGM), value) == "Max") { continue; }
            string bgmObjName = Enum.GetName(typeof(BGM), value) + "BGM";
            GameObject bgmObj = GameObject.Find(bgmObjName);
            _BGMArray[(int)value] = bgmObj;

            // ��������S���Đ��X�g�b�v
            _BGMSource = bgmObj.GetComponent<AudioSource>();
            StopBGM();
        }
    }

    void Update()
    {
        // �e�X�g�p����
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
    /// BGM�Đ�
    /// </summary>
    /// <param name="bgmId"></param>
    public void PlayBGM(BGM bgmId)
    {
        _BGMSource = _BGMArray[(int)bgmId].GetComponent<AudioSource>();
        _BGMSource.Play();
    }

    /// <summary>
    /// BGM�X�g�b�v
    /// </summary>
    public void StopBGM()
    {
        _BGMSource.Stop();
    }
    
    /// <summary>
    /// SE�Đ��iOneShot�j
    /// </summary>
    /// <param name="soundId"></param>
    public void PlayOneShotSound(ONE_SHOT_SOUND soundId)
    {

        AudioClip targetSound = _OneShotSoundArray[(int)soundId];
        if (targetSound == null)
        {
            Debug.LogWarning( "[SoundManager]" + soundId + "�ɓo�^���ꂽ���ʉ����Đ��ł��܂���");
            return;
        }

        _OneShotSoundSource.PlayOneShot(targetSound);
    }
}
