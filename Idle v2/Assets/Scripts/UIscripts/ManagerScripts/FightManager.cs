using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MonoBehaviours;
using TDDscripts;
using UIscripts.ManagerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Object = System.Object;

public class FightManager : MonoBehaviour {
    public static FightManager instance;
    private EnemyContainer enemyContainer;
    private Dictionary<int, string> fightScene;
    private Dictionary<int, Sprite[]> backgroundImages;
    public Sprite[] firstMapBackgroundImages;
    private int[] amountOfEnemiesPerFight;
    private int mapNumber;
    private int fightNumber;

    private int enemiesKilled;
    //public Image[] secondMapBackgroundImages;
    //public Image[] thirdMapBackgroundImages;

    private void Awake() {
        this.MakeSingleton();
        fightScene = new Dictionary<int, string> {{1,"1-FightScene"}};
        backgroundImages = new Dictionary<int, Sprite[]> {{1, firstMapBackgroundImages}};
        //cantidad de enemigos por pelea
        amountOfEnemiesPerFight = new int[4];
        amountOfEnemiesPerFight[0] = 5;
        amountOfEnemiesPerFight[1] = 2;
        amountOfEnemiesPerFight[2] = 4;
        amountOfEnemiesPerFight[3] = 3;
        //TODO EN VEZ DE HACER ESTO CON PREFAB DE GAMEOBJECTS
        //TODO HACERLO CON SPRITES Y LOS STATS LOS SACO INTERNAMENTE
        //TODO DESDE EL JUEGO, CREO UNA CLASE NUEVA Q LOS CONTENGA Y ACTUALIZE
    }

    private void MakeSingleton() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance!=this)
            Destroy(gameObject);
    }

    public void StartFight(int mapNumber, int fightNumber) {
        this.mapNumber = mapNumber;
        this.fightNumber = fightNumber;
        this.enemiesKilled = 0;
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene() {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(fightScene[mapNumber],LoadSceneMode.Additive);
        while (!sceneLoad.isDone) {
            yield return null;
        }
        GameObject background = GameObject.Find("Background");
        background.GetComponent<Image>().sprite = backgroundImages[mapNumber][fightNumber-1];
        this.enemyContainer = GameObject.Find("Enemy").GetComponent<EnemyContainer>();
        enemyContainer.SpawnEnemy();
    }

    public void EnemyDied() {
        enemyContainer.gameObject.SetActive(false);
        enemiesKilled++;
        //placeholder de como irme de la batalla
        if (enemiesKilled < amountOfEnemiesPerFight[fightNumber-1]) {
            enemyContainer.SpawnEnemy();
            StartCoroutine(SpawnCooldown());
        }
        else {
            GameManager.instance.RunAwayFromFight();
        }
    }
    
    private IEnumerator SpawnCooldown() {
        yield return new WaitForSeconds(1f);
        enemyContainer.gameObject.SetActive(true);
    }
}
