using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameView : MonoBehaviour
{
    [SerializeField] Text _timeText;

    // Update is called once per frame
    void Update()
    {
        _timeText.text = $"{IngameManager.GameTime:F2}";
    }
}
