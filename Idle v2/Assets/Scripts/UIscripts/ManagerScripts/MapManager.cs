using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour {
    // aca no estoy seguro si es mas conveniente customizar la escena
    // o ya tener varias escenas y customizar solo el canvas por ej.
    // TODO elegir una de las dos, el dictionary puede que este de mas
    public GameObject canvas;
    private Dictionary<int, string> mapScenes;
    private Dictionary<int, GameObject[]> fights;
    public GameObject[] firstMapFights;
    //public LinkedList<GameObject> secondMapFights;
    //public LinkedList<GameObject> thirdMapFights;

    private void Awake() {
        mapScenes = new Dictionary<int, string> {{1, "1-MapScene"}};
        fights = new Dictionary<int, GameObject[]> {{1, firstMapFights}};
    }

    public void Initialize(int mapNumber) {
        // aca deberia cargarle info a cada boton del mapa
        // para que cuando los clickee hablen bien con el
        // fight manager
        /*hay varias formas de cargar una escena, puede ser asincronica y que
         vaya returneando null hasta que este cargada, puede ser load normal
         y despues muevo los objetos que instancie a la nueva escena, porque el gran
         problema que tengo es que si hago LoadScene, y abajo instancio objetos,
         los objetos se me instancian en la escena anterior porque la nueva
         no termino de cargar*/
        StartCoroutine(LoadScene(mapNumber));
    }

    private IEnumerator LoadScene(int mapNumber) {
        // deje estos comentarios, si los DESCOMENTO, y cambio el scene load
        // a un additive, la puedo deslodear a la anterior, no se q sera mas rapido.
        
        //var scene = SceneManager.GetActiveScene();
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(mapScenes[mapNumber],LoadSceneMode.Single);
        while (!sceneLoad.isDone) {
            yield return null;
        }
        //SceneManager.UnloadSceneAsync(scene);
        GameObject canvasInstance = InstantiateCanvas();
        InstantiateFightButtons(canvasInstance, mapNumber);
    }

    private GameObject InstantiateCanvas() {
        return Instantiate<GameObject>(this.canvas);
    }

    private void InstantiateFightButtons(GameObject canvasInstance, int mapNumber) {
        for (int i = 0; i < fights[mapNumber].Length; i++) {
            GameObject fightGameObject = fights[mapNumber][i];
            Instantiate(fightGameObject, canvasInstance.transform,false);
        }
    }
}
