using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class 
ResultView : MonoBehaviour
{
    [SerializeField] Text _titleText;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _highScore;
    [SerializeField] float _tweenTime = 1f;
    [SerializeField] float _tweenWaitTime = 0.5f;
    [SerializeField] float _stateTextTweenTime = 3;
    [SerializeField] Vector3 _originSize = Vector3.one * 3;
    [SerializeField] GameObject _clearObjs;
    // Start is called before the first frame update
    async void Start()
    {
        UnityroomApiClient.Instance.SendScore(1, IngameManager.GameTime, ScoreboardWriteMode.HighScoreAsc);
        _scoreText.text = "";
        _highScore.text = "";
        _titleText.transform.localScale = _originSize;
        if (IngameManager.CurrentGameState == IngameManager.GameState.GameClear)
        {
            FindAnyObjectByType<SoundManager>().PlayBGM(SoundManager.BGM.GameClear);
            _titleText.text = "ゲームクリア!";
            _titleText.rectTransform.DOScale(Vector3.one, _tweenTime).SetEase(Ease.OutBounce).SetLink(gameObject);
        }
        else
        {
            FindAnyObjectByType<SoundManager>().PlayBGM(SoundManager.BGM.GameOver);
            _clearObjs?.SetActive(false);
            _titleText.text = "ゲームオーバー!";
            _titleText.rectTransform.DOScale(Vector3.one, _tweenTime).SetEase(Ease.OutBounce).SetLink(gameObject);
            return;
        }
        await UniTask.Delay(System.TimeSpan.FromSeconds(_stateTextTweenTime));
        string timeText = IngameManager.CurrentGameState == IngameManager.GameState.GameClear ? IngameManager.GameTime.ToString("F2") : "記録なし";
        _scoreText.DOText($"タイム:{timeText}", _tweenTime).SetLink(gameObject);
        await UniTask.Delay(System.TimeSpan.FromSeconds(_tweenWaitTime));
    }
}
