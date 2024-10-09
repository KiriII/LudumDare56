using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public TinyCore _tinyCore;

    public CreatureSpawner creatureSpawner;
    public DragAndDrop dragAndDrop;
    public LeverDragAndDrop lever;
    public LaserSwitch laserSwitch;
    public LaserCharger charger;
    public NextCreature nextCreature;
    public GameObject floatingText;
    public GameObject floatingTextSpawner;

    public GameObject EndScreen;
    public Text EndHader;
    public Text Stats;
    public Text Comment;

    public GameObject monsterColor;
    public GameObject monsterGlaza;
    public GameObject monsterSmile;
    public GameObject monsterHat;

    public GameObject currentSkin;
    public GameObject currentGlaza;
    public GameObject currentSmile;
    public GameObject currentHat;

    public void init(Canvas canvas, TinyCore tinyCore)
    {
        if (creatureSpawner is not null)
        {
            creatureSpawner.init(tinyCore.GetCurrentCreatureColor, tinyCore.ScaleEnds);
        }
        if (dragAndDrop is not null)
        {
            dragAndDrop.init(canvas, tinyCore.GetCurrentCreatureText);
        }
        if (lever is not null)
        {
            lever.init(canvas);
        }
        if (laserSwitch is not null)
        {
            laserSwitch.init(tinyCore.SwitchLaserState);
        }
        if (nextCreature is not null)
        {
            nextCreature.init(tinyCore.CreateNewCreatrure);
        }

        charger.EnableChargedListener(tinyCore.LaserShot);
        _tinyCore = tinyCore;
    }

    public void UpdateMonsterColor()
    {
        var monster = _tinyCore.GetMonsterColor();
        var color = monster.skin;
        monsterColor.gameObject.SetActive(true);
        if (currentSkin is not null)
        {
            Destroy(currentSkin);
        }
        switch (color)
        {
            case 0:
                currentSkin = Instantiate(creatureSpawner.skins[0], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 1:
                currentSkin = Instantiate(creatureSpawner.skins[1], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 2:
                currentSkin = Instantiate(creatureSpawner.skins[2], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 3:
                currentSkin = Instantiate(creatureSpawner.skins[3], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 4:
                currentSkin = Instantiate(creatureSpawner.skins[4], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 5:
                currentSkin = Instantiate(creatureSpawner.skins[5], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 6:
                currentSkin = Instantiate(creatureSpawner.skins[6], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 7:
                currentSkin = Instantiate(creatureSpawner.skins[7], monsterColor.transform);
                currentSkin.transform.localScale = new Vector3(450, 450, 450);
                break;
            case -1:
                monsterColor.gameObject.SetActive(false);
                break;
        }
        monsterGlaza.SetActive(true);
        if (currentGlaza is not null)
        {
            Destroy(currentGlaza);
        }
        switch (monster.glaza)
        {
            case 0:
                currentGlaza = Instantiate(creatureSpawner.glaza[0], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 1:
                currentGlaza = Instantiate(creatureSpawner.glaza[1], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 2:
                currentGlaza = Instantiate(creatureSpawner.glaza[2], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 3:
                currentGlaza = Instantiate(creatureSpawner.glaza[3], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 4:
                currentGlaza = Instantiate(creatureSpawner.glaza[4], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 5:
                currentGlaza = Instantiate(creatureSpawner.glaza[5], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 6:
                currentGlaza = Instantiate(creatureSpawner.glaza[6], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 7:
                currentGlaza = Instantiate(creatureSpawner.glaza[7], monsterGlaza.transform);
                currentGlaza.transform.localScale = new Vector3(450, 450, 450);
                break;
            case -1:
                monsterGlaza.SetActive(false);
                break;
        }
        monsterSmile.SetActive(true);
        if (currentSmile is not null)
        {
            Destroy(currentSmile);
        }
        switch (monster.smile)
        {
            case 0:
                currentSmile = Instantiate(creatureSpawner.smiles[0], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 1:
                currentSmile = Instantiate(creatureSpawner.smiles[1], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 2:
                currentSmile = Instantiate(creatureSpawner.smiles[2], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 3:
                currentSmile = Instantiate(creatureSpawner.smiles[3], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 4:
                currentSmile = Instantiate(creatureSpawner.smiles[4], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 5:
                currentSmile = Instantiate(creatureSpawner.smiles[5], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 6:
                currentSmile = Instantiate(creatureSpawner.smiles[6], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 7:
                currentSmile = Instantiate(creatureSpawner.smiles[7], monsterSmile.transform);
                currentSmile.transform.localScale = new Vector3(450, 450, 450);
                break;
            case -1:
                monsterSmile.SetActive(false);
                break;
        }
        if (currentHat is not null)
        {
            Destroy(currentHat);
        }
        monsterHat.SetActive(true);
        switch (monster.hat)
        {
            case 0:
                currentHat = Instantiate(creatureSpawner.hat[0], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 1:
                currentHat = Instantiate(creatureSpawner.hat[1], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 2:
                currentHat = Instantiate(creatureSpawner.hat[2], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 3:
                currentHat = Instantiate(creatureSpawner.hat[3], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 4:
                currentHat = Instantiate(creatureSpawner.hat[4], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 5:
                currentHat = Instantiate(creatureSpawner.hat[4], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 6:
                currentHat = Instantiate(creatureSpawner.hat[4], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case 7:
                currentHat = Instantiate(creatureSpawner.hat[4], monsterHat.transform);
                currentHat.transform.localScale = new Vector3(450, 450, 450);
                break;
            case -1:
                monsterHat.SetActive(false);
                break;
        }
    }

    public void CongraturationTextCreate(int score)
    {
        string text = "BANANZA";
        UnityEngine.Color color = UnityEngine.Color.black;
        switch (score)
        {
            case 15:
                text = "MONSTER SLAYER";
                color = new UnityEngine.Color(160, 32, 240, 1);
                break;
            case 10:
                text = "YOU R BEST";
                color = new UnityEngine.Color(255, 192, 203, 1);
                break;
            case 9:
            case 8:
                text = "VERY GOOD";
                color = UnityEngine.Color.green;
                break;
            case 7:
            case 6:
            case 5:
                text = "NOT BAD";
                color = UnityEngine.Color.yellow;
                break;
            case 4:
            case 3:
            case 2:
            case 1:
                text = "CLOSE ONE";
                color = new UnityEngine.Color(255, 165, 0, 1);
                break;
            case 0:
                text = "NOT LIKE THIS";
                break;
            case -1:
            case -2:
                text = "IT WAS MY\nTINY FRIEND(";
                color = UnityEngine.Color.red;
                break;
            case -3:
                text = "YOU KILLED\nKENNY!";
                color = UnityEngine.Color.red;
                break;
            case -4:
                text = "STOP KILLING\nFRIENDS!";
                color = UnityEngine.Color.red;
                break;
        }
        var ft = Instantiate(floatingText, floatingTextSpawner.transform);
        var ftt = ft.GetComponent<Text>();
        ftt.text = text;
        ftt.color = color;
    }

    public void EndGame(Score score)
    {
        EndHader.text = score.header;
        Stats.text = score.stats;
        Comment.text = score.comment;
        EndScreen.SetActive(true);
    }
}   
