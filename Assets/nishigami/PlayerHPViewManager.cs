using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHPViewManager : MonoBehaviour
{
    [SerializeField] private Text hpText = null;

    [SerializeField] private Character character = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int hp = character.Hp;
        hpText.text = string.Format("Žc‚èHP : {0}", hp);
    }
}
