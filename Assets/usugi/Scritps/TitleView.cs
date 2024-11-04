using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType<SoundManager>().PlayBGM(SoundManager.BGM.Title);  
    }
}
