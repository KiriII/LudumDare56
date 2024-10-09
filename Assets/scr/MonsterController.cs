using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using UnityEngine;

public class MonsterController 
{
    private CreatureColor _monsterColor = CreatureColor.Empty;
    private int glaza = -1;
    private int smile = -1;
    private int hat = -1;

    private int _checkCount = 0;

    private Action monsterChanged;

    public bool CheckCreatureIsMonster(Creature creature)
    {
        if (creature.color == _monsterColor || creature.glaza == glaza || creature.smile == smile || creature.hat == hat)
        {
            Checked();
            return true;
        }
        else
        {
            Checked();
            return false;
        }   
    }

    public void Checked()
    {
        UnityEngine.Debug.Log($"CHECKED {_checkCount}");
        _checkCount += 1;
        if (_checkCount == 5)
        {
            System.Random rand = new();
            _monsterColor = (CreatureColor)rand.Next(Enum.GetValues(typeof(CreatureColor)).Length - 1);
            monsterChanged?.Invoke();
            //UnityEngine.Debug.Log($"MONSTER!!! {_monsterColor}");
        }
        if (_checkCount == 15)
        {
            System.Random rand = new();
            glaza = rand.Next(4);
            monsterChanged?.Invoke();
        }
        if (_checkCount == 25)
        {
            System.Random rand = new();
            smile = rand.Next(4);
            monsterChanged?.Invoke();
        }
        if (_checkCount == 35)
        {
            System.Random rand = new();
            hat = rand.Next(4);
            monsterChanged?.Invoke();
        }
        if (_checkCount > 35 && _checkCount % 10 == 0)
        {
            RandomMonster();
            monsterChanged?.Invoke();
        }
    }

    private void RandomMonster()
    {
        UnityEngine.Debug.Log("Randomize");
        System.Random rand = new();
        var elem = rand.Next(3);
        switch (elem)
        {
            case 0:
                System.Random rand1 = new();
                _monsterColor = (CreatureColor)rand1.Next(Enum.GetValues(typeof(CreatureColor)).Length - 1);
                break;
            case 1:
                System.Random rand2 = new();
                glaza = rand2.Next(4);
                break;
            case 2:
                System.Random rand3 = new();
                smile = rand3.Next(4);
                break;
            case 3:
                System.Random rand4 = new();
                hat = rand4.Next(4);
                break;
        }
    }

    public Creature GetMonsterColor()
    {
        return new Creature(0, _monsterColor, glaza, smile, hat);
    }

    public void EnableListener(Action method)
    {
        monsterChanged += method;
    }
}
