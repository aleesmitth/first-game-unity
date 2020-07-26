using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteCollectionScript : MonoBehaviour
{
    public GameObject manager;
    public Image monsterImage;
    public Image backgroundImage;
    private NewManagerScript script;
    public List<Image> MonstersCollection;
    public List<Image> BackgroundsCollection;

    private void Awake()
    {
        script = manager.GetComponent<NewManagerScript>();
        script.OnMonsterKill += changeImages;
    }

    private void changeImages(int rng)
    {
        monsterImage = MonstersCollection[Random.Range(0, MonstersCollection.Count)];
        backgroundImage = BackgroundsCollection[Random.Range(0, BackgroundsCollection.Count)];
    }
}
