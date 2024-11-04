using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] float _beforeStartTime = 10;
    [SerializeField] EnemyManager _enemyManager;
    [SerializeField] private Player player;
    [SerializeField] private float _clearKillCount = 100;
    public int GetClearKillCount { get { return (int)_clearKillCount; } }
    public static float GameTime { get; private set; }

    CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    public static GameState CurrentGameState {  get; private set; }
    public int KillCount { get; set; }

    public enum GameState
    {
        BeforeGame,
        PlayingGame,
        GameClear,
        GameOver,
    }

    private void Awake()
    {
        _enemyManager.enabled = false;
        GameTime = 0;
    }

    // Start is called before the first frame update
    async void Start()
    {
        FindAnyObjectByType<SoundManager>()?.PlayBGM(SoundManager.BGM.Ingame);
        CurrentGameState = GameState.BeforeGame;
        //数秒待機
        await UniTask.Delay(System.TimeSpan.FromSeconds(_beforeStartTime), cancellationToken: _cancellationTokenSource.Token);
        CurrentGameState = GameState.PlayingGame;
        //ゲームスタート
        _enemyManager.enabled = true;
    }

    private void Update()
    {
        if (CurrentGameState == GameState.PlayingGame)
        {
            GameTime += Time.deltaTime;
        }
        if (CurrentGameState == GameState.GameClear || CurrentGameState == GameState.GameOver) return;
        //プレイヤーが死んだらゲームオーバー
        if (player.Hp <= 0)
        {
            CurrentGameState = GameState.GameOver;
            GameEnd();
        }
        else if (KillCount >= _clearKillCount)
        {
            //最後のボスが死んだらゲームクリア
            CurrentGameState = GameState.GameClear;
            GameEnd();
        }
    }

    private void GameEnd()
    {
        SceneTransition.Instance.LoadScene(SceneTransition.SceneType.Result);
    }

    private void OnDisable()
    {
        _cancellationTokenSource.Cancel();
    }
}
