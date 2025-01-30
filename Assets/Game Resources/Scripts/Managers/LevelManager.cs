using Hexkritor.BalloonPopper.Data;
using Hexkritor.BalloonPopper.Data;
using Hexkritor.BalloonPopper.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Hexkritor.BalloonPopper.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [HideInInspector]
        public Player Player;
        [HideInInspector]
        public SpawnerContainer Spawners;

        [SerializeField]
        private LevelSettings levelSettings;

        private LevelData currentLevel;

        private int level;
        private int killed;

        private Coroutine spawnCoroutine;
        private Coroutine delayCoroutine;

        public bool IsGameActive { get; private set; }
        public float SpeedMultiplier => Mathf.Pow(levelSettings.SpeedMultiplierPerLevel, level - 1);
        public float SpawnTime => currentLevel.SpawnTime;
        public LevelData CurrentLevel => currentLevel;
        public LevelData NextLevel => levelSettings.GetLoopedLevel(level + 1);

        public event Action<int> OnLevelStart = delegate { };
        public event Action<float> OnBalloonKill = delegate { };
        public event Action<int> OnGameOver = delegate { };

        public void Initialize(Player player, SpawnerContainer spawnerContainer)
        {
            this.Player = player;
            Spawners = spawnerContainer;
            Player.Life.OnLivesDepleted += GameOver;
        }

        public void ResetObject()
        {
            level = 1;
            killed = 0;
            StartGame();
        }

        public void CheckKill(Balloon balloon)
        {
            if (currentLevel.IsBossLevel)
            {
                if (balloon.Type == BalloonType.Boss)
                {
                    AddKill();
                }
            }
            else
            {
                AddKill();
            }
        }

        public void CheckLevelProgress()
        {
            if (killed >= currentLevel.KillsRequired)
            {
                killed = 0;
                ++level;
                StartLevel();
            }
        }

        public void CloseGame()
        {
            StopAllCoroutines();
            var balloons = gameObject.GetComponentsInChildren<Balloon>();
            foreach (var balloon in balloons)
            {
                Destroy(balloon.gameObject, Time.fixedDeltaTime);
            }
            gameObject.SetActive(false);
        }

        public void DelaySpawn(float time)
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
            delayCoroutine = StartCoroutine(DelaySpawnCoroutine(time));
        }

        private void StartGame()
        {
            IsGameActive = true;
            StartCoroutine(SpawnBonusBalloonCoroutine());
            StartLevel();
        }

        private void StartLevel()
        {
            currentLevel = levelSettings.GetLoopedLevel(level);
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
            if (delayCoroutine == null)
            {
                if (currentLevel.IsBossLevel)
                {
                    spawnCoroutine = StartCoroutine(SpawnBalloonOnceCoroutine());
                }
                else
                {
                    spawnCoroutine = StartCoroutine(SpawnBalloonCoroutine());
                }
            }
            OnLevelStart(level);
        }

        private IEnumerator DelaySpawnCoroutine(float time)
        {
            yield return new WaitForSeconds(time);
            if (currentLevel.IsBossLevel)
            {
                spawnCoroutine = StartCoroutine(SpawnBalloonOnceCoroutine());
            }
            else
            {
                spawnCoroutine = StartCoroutine(SpawnBalloonCoroutine());
            }
            delayCoroutine = null;
        }

        private IEnumerator SpawnBalloonCoroutine()
        {
            while (IsGameActive)
            {
                yield return new WaitForSeconds(SpawnTime);
                Spawners.Spawn(currentLevel.GetRandomBalloon());
            }
        }
        private IEnumerator SpawnBalloonOnceCoroutine()
        {
            yield return new WaitForSeconds(SpawnTime);
            Spawners.Spawn(currentLevel.GetRandomBalloon());
        }

        private IEnumerator SpawnBonusBalloonCoroutine()
        {
            while (IsGameActive)
            {
                yield return new WaitForSeconds(levelSettings.BonusBalloonSpawnDelay);
                Spawners.Spawn(levelSettings.BonusBalloonTypes[UnityEngine.Random.Range(0, levelSettings.BonusBalloonTypes.Count)]);
            }
        }


        private void AddKill()
        {
            ++killed;
            OnBalloonKill((float)killed / currentLevel.KillsRequired);
        }

        private void GameOver()
        {
            StopAllCoroutines();
            Spawners.ReleaseAll();
            OnGameOver(Player.Score.Score);
            IsGameActive = false;
        }
       
    }
}