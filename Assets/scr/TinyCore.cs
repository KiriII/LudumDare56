using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyCore 
{
    private Creature _currentCreature;

    public MonsterController _monsterController;
    private LaserState _laserState;

    public Action currentCreatureChanged;
    public Action<double> creatureMagnifyed;
    public Action<int> gettedScore;
    public Action<Score> gameOver;

    private bool canNext;

    private int _score;
    private int _friendKilled;
    private int _monsterKilled;

    public TinyCore()
    {
        CreateNewCreatrure(true);
        _monsterController = new();
        _laserState = new MagnifierState(MagnifyCreature, KillCreature);
        canNext = false;
        _friendKilled = 0;
        _monsterKilled = 0;
    }

    public void CreateNewCreatrure(bool force = false)
    {
        if (canNext || force)
        {
            canNext = false;
            var newCreature = (_currentCreature is not null) ? CreatureRandomizer.GenerateCreature(_currentCreature) : CreatureRandomizer.GenerateCreature(new Creature(0, 7, 7, 7, 7));
            _currentCreature = newCreature;
            OnCurrentCreatureChanged();
            Debug.Log($"{_currentCreature.skin} {_currentCreature.needScale}");
        }
    }

    public void ScaleEnds(float currentScale)
    {
        if (_monsterController.CheckCreatureIsMonster(_currentCreature))
        {
            Debug.Log("YOU DIED");
            GenerateScore(true);
        }
        else
        {
            var goal = TinyScaleController.CountScaleResult(_currentCreature.needScale, currentScale);
            _score += goal;
            canNext = true;
            OnGettedScore(goal);
            Debug.Log($"score {_score}");
        }
    }

    public void KillCreature(double time)
    {
        if (!_monsterController.CheckCreatureIsMonster(_currentCreature))
        {
            _friendKilled += 1;
            if (_friendKilled == 5)
            {
                GenerateScore(false);
            }
            OnGettedScore(0-_friendKilled);
            Debug.Log("NOT THIS ONE!");
        }
        else
        {
            OnGettedScore(15);
            _score += 15;
            _monsterKilled += 1;
        }
        CreateNewCreatrure(true);
    }

    private void GenerateScore(bool reason)
    {
        if (reason)
        {
            OnGameOver(new Score(
                "YOU DIED",
                $"Your points - {_score}\nMonster killed - {_monsterKilled}\nFriends killed - {_friendKilled}",
                "Maybe making tiny monster bigger is not a good idea...",
                reason));
        }
        else
        {
            OnGameOver(new Score(
                "...",
                $"Your points - {_score}\nMonster killed - {_monsterKilled}\nFriends killed - {_friendKilled}",
                "You killed enouth of my friends...",
                reason));
        }
    }

    public void MagnifyCreature(double time)
    {
        OnCreatureMagnifyed(time);
    }

    public void LaserShot(double time)
    {
        _laserState.LaserShot(time);
    }

    public void SwitchLaserState()
    {
        _laserState = _laserState.OtherState();
    }

    public Creature GetCurrentCreatureColor()
    {
        //Debug.Log($"{_currentCreature.color}");
        return _currentCreature;
    }

    public string GetCurrentCreatureText()
    {
        return $"Actually my height is {_currentCreature.needScale} bananas";
    }

    // MONSTER 
    public Creature GetMonsterColor()
    {
        return _monsterController.GetMonsterColor();
    }

    private void OnCurrentCreatureChanged()
    {
        currentCreatureChanged?.Invoke();
    }

    public void EnableCurrentCreatureChangedListener(Action method)
    {
        currentCreatureChanged += method;
    }

    private void OnCreatureMagnifyed(double time)
    {
        creatureMagnifyed?.Invoke(time);
    }

    public void EnableCreatureMagnifyedListener(Action<double> method)
    {
        creatureMagnifyed += method;
    }

    private void OnGettedScore(int score)
    {
        gettedScore?.Invoke(score);
    }

    public void EnableGettedScoreListener(Action<int> method)
    {
        gettedScore += method;
    }

    private void OnGameOver(Score score)
    {
        gameOver?.Invoke(score);
    }

    public void EnableGameOverListener(Action<Score> method)
    {
        gameOver += method;
    }
}
