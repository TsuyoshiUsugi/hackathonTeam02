using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class TitleTextView : MonoBehaviour
{
    [SerializeField] Text _titleText;
    [SerializeField] float _tweenTime;
    [SerializeField] List<string> _changeWords;
    [SerializeField] int _changeWordIndex = 0;
    // Start is called before the first frame update
    async void Start()
    {
        if (_changeWords == null || _changeWords.Count == 0) return;
        while (true)
        {
            if (_titleText == null) return;
            _titleText.text = "";
            _titleText.DOText(_changeWords[_changeWordIndex], _tweenTime).SetLink(gameObject);
            await Task.Delay(System.TimeSpan.FromSeconds(_tweenTime));
            _changeWordIndex++;
            if (_changeWordIndex >= _changeWords.Count) _changeWordIndex = 0;
        }
    }
}
