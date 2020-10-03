using System;
using System.Collections;
using TDDscripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIscripts.ManagerScripts {
    public class GameManager : MonoBehaviour {
        public static GameManager instance;
        public MapManager mapManager;
        public IPlayerCharacter Player { get; private set; } = new Player(new LvlOne());

        public FightManager fightManager;
        public int currentMapNumber = 1;
        public int MAPS_CUANTITY = 1;
        public int STAGES_PER_MAP = 4;

        private void Awake() {
            // esto seria un singleton medio atado con alambre
            this.MakeSingleton();
        }

        private void MakeSingleton() {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if(instance!=this)
                Destroy(gameObject);
        }

        public void StartGame() {
            InitializeMap(currentMapNumber);
        }
        
        private void InitializeMap(int mapNumber) {
            mapManager.Initialize(mapNumber);
        }

        public void StartFight(int fightNumber) {
            fightManager.StartFight(currentMapNumber, fightNumber);
        }

        public void RunAwayFromFight() {
            InitializeMap(currentMapNumber);
        }

        public void MainMenu() {
            StartCoroutine(LoadScene("MainMenu"));
        }

        private IEnumerator LoadScene(string sceneName) {
            AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
            while (!sceneLoad.isDone) {
                yield return null;
            }
        }

        public static void Quit() {
            Application.Quit();
        }

    }
}
