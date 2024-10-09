using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _creaturePrefab;

    public GameObject[] skins;
    public GameObject[] glaza;
    public GameObject[] smiles;
    public GameObject[] hat;

    public GameObject[] skinsSprite;
    public GameObject[] glazaSprite;
    public GameObject[] smileSprite;
    public GameObject[] hatSprite;

    private GameObject _currentCreatureObject;

    // delegate
    private Func<Creature> _getCreatureColor;
    private Action<float> _magnifierEnds;

    public void init(Func<Creature> getCreatureColor, Action<float> magnifierEnds)
    {
        _getCreatureColor = getCreatureColor;
        _magnifierEnds = magnifierEnds;

        CreateCreature();
    }

    public void MagnifyCreature(double time)
    {
        if (_currentCreatureObject is not null)
        {
            _currentCreatureObject.GetComponent<CreatureMagnifier>().StartMagnify(time);
        }
    }

    public void CreateCreature()
    {
        if (_currentCreatureObject is not null)
        {
            Destroy(_currentCreatureObject);
        }
        _currentCreatureObject = Instantiate(_creaturePrefab, transform);
        _currentCreatureObject?.GetComponent<CreatureMagnifier>().EnableMagnifierEndsListener(_magnifierEnds);
        DrawCreature(_getCreatureColor.Invoke());
    }

    private void DrawCreature(Creature creature)
    {
        var image = _currentCreatureObject.GetComponent<CreatureMagnifier>().creature.GetComponent<Image>();
        var imageForGlass = _currentCreatureObject.GetComponent<CreatureMagnifier>().creatureForMagnifierGlass.GetComponent<SpriteRenderer>();
        switch (creature.skin)
        {
            case 0:
                Instantiate(skins[0], image.gameObject.transform);
                Instantiate(skinsSprite[0], imageForGlass.gameObject.transform);
                break;
            case 1:
                Instantiate(skins[1], image.gameObject.transform);
                Instantiate(skinsSprite[1], imageForGlass.gameObject.transform);
                break;
            case 2:
                Instantiate(skins[2], image.gameObject.transform);
                Instantiate(skinsSprite[2], imageForGlass.gameObject.transform);
                break;
            case 3:
                Instantiate(skins[3], image.gameObject.transform);
                Instantiate(skinsSprite[3], imageForGlass.gameObject.transform);
                break;
            case 4:
                Instantiate(skins[4], image.gameObject.transform);
                Instantiate(skinsSprite[4], imageForGlass.gameObject.transform);
                break;
            case 5:
                Instantiate(skins[5], image.gameObject.transform);
                Instantiate(skinsSprite[5], imageForGlass.gameObject.transform);
                break;
            case 6:
                Instantiate(skins[6], image.gameObject.transform);
                Instantiate(skinsSprite[6], imageForGlass.gameObject.transform);
                break;
            case 7:
                Instantiate(skins[7], image.gameObject.transform);
                Instantiate(skinsSprite[7], imageForGlass.gameObject.transform);
                break;
        }
        switch (creature.smile)
        {
            case 0:
                Instantiate(smiles[0], image.gameObject.transform);
                Instantiate(smileSprite[0], imageForGlass.gameObject.transform);
                break;
            case 1:
                Instantiate(smiles[1], image.gameObject.transform);
                Instantiate(smileSprite[1], imageForGlass.gameObject.transform);
                break;
            case 2:
                Instantiate(smiles[2], image.gameObject.transform);
                Instantiate(smileSprite[2], imageForGlass.gameObject.transform);
                break;
            case 3:
                Instantiate(smiles[3], image.gameObject.transform);
                Instantiate(smileSprite[3], imageForGlass.gameObject.transform);
                break;
            case 4:
                Instantiate(smiles[4], image.gameObject.transform);
                Instantiate(smileSprite[4], imageForGlass.gameObject.transform);
                break;
            case 5:
                Instantiate(smiles[5], image.gameObject.transform);
                Instantiate(smileSprite[5], imageForGlass.gameObject.transform);
                break;
            case 6:
                Instantiate(smiles[6], image.gameObject.transform);
                Instantiate(smileSprite[6], imageForGlass.gameObject.transform);
                break;
            case 7:
                Instantiate(smiles[7], image.gameObject.transform);
                Instantiate(smileSprite[7], imageForGlass.gameObject.transform);
                break;
        }
        switch (creature.hat)
        {
            case 0:
                Instantiate(hat[0], image.gameObject.transform);
                Instantiate(hatSprite[0], imageForGlass.gameObject.transform);
                break;
            case 1:
                Instantiate(hat[1], image.gameObject.transform);
                Instantiate(hatSprite[1], imageForGlass.gameObject.transform);
                break;
            case 2:
                Instantiate(hat[2], image.gameObject.transform);
                Instantiate(hatSprite[2], imageForGlass.gameObject.transform);
                break;
            case 3:
                Instantiate(hat[3], image.gameObject.transform);
                Instantiate(hatSprite[3], imageForGlass.gameObject.transform);
                break;
            case 4:
                Instantiate(hat[4], image.gameObject.transform);
                Instantiate(hatSprite[4], imageForGlass.gameObject.transform);
                break;
            case 5:
                Instantiate(hat[5], image.gameObject.transform);
                Instantiate(hatSprite[5], imageForGlass.gameObject.transform);
                break;
            case 6:
                Instantiate(hat[6], image.gameObject.transform);
                Instantiate(hatSprite[6], imageForGlass.gameObject.transform);
                break;
            case 7:
                Instantiate(hat[7], image.gameObject.transform);
                Instantiate(hatSprite[7], imageForGlass.gameObject.transform);
                break;
        }
        switch (creature.glaza)
        {
            case 0:
                Instantiate(glaza[0], image.gameObject.transform);
                Instantiate(glazaSprite[0], imageForGlass.gameObject.transform);
                break;
            case 1:
                Instantiate(glaza[1], image.gameObject.transform);
                Instantiate(glazaSprite[1], imageForGlass.gameObject.transform);
                break;
            case 2:
                Instantiate(glaza[2], image.gameObject.transform);
                Instantiate(glazaSprite[2], imageForGlass.gameObject.transform);
                break;
            case 3:
                Instantiate(glaza[3], image.gameObject.transform);
                Instantiate(glazaSprite[3], imageForGlass.gameObject.transform);
                break;
            case 4:
                Instantiate(glaza[4], image.gameObject.transform);
                Instantiate(glazaSprite[4], imageForGlass.gameObject.transform);
                break;
            case 5:
                Instantiate(glaza[5], image.gameObject.transform);
                Instantiate(glazaSprite[5], imageForGlass.gameObject.transform);
                break;
            case 6:
                Instantiate(glaza[6], image.gameObject.transform);
                Instantiate(glazaSprite[6], imageForGlass.gameObject.transform);
                break;
            case 7:
                Instantiate(glaza[7], image.gameObject.transform);
                Instantiate(glazaSprite[7], imageForGlass.gameObject.transform);
                break;
        }
    }
}
