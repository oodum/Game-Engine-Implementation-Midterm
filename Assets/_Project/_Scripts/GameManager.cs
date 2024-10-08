using System;
using TMPro;
using UnityEngine;
using Utility;
namespace Managers {
    public class GameManager : Singleton<GameManager> {
        public int Shells;
[SerializeField] TextMeshProUGUI shellsText;
        [SerializeField] Enemy enemy;
        float time;
        void Update() {
            time += Time.deltaTime;
            if (time > 2) {
                time = 0;
                SpawnEnemy();
            }
            shellsText.text = $"Shells: {Shells}";
        }

        void SpawnEnemy() {
            var newEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), Quaternion.identity);
        }
    }
}
