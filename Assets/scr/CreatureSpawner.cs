using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _creaturePrefab;

    public GameObject[] glaza;
    public GameObject[] smiles;
    public GameObject[] hat;

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
        switch (creature.color)
        {
            case CreatureColor.Red:
                image.color = Color.red;
                imageForGlass.color = Color.red;
                break;
            case CreatureColor.Green:
                image.color = Color.green;
                imageForGlass.color = Color.green;
                break;
            case CreatureColor.Blue:
                image.color = Color.blue;
                imageForGlass.color = Color.blue;
                break;
            case CreatureColor.Yellow:
                image.color = Color.yellow;
                imageForGlass.color = Color.yellow;
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
        }
    }
}
