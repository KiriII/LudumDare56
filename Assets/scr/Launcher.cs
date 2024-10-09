using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Transform _canvas;
    [SerializeField] private GameObject _mainUI;

    private GameObject _mainUIObject;

    private TinyCore _tinyCore;

    void Start()
    {
        _tinyCore = new();
        _mainUIObject = Instantiate(_mainUI, _canvas);

        var mainUI = _mainUIObject.GetComponent<MainUI>();
        var canvas = _canvas.GetComponent<Canvas>();
        mainUI.init(canvas, _tinyCore);
        //mainUI.EnableCreatureDestroyedListener(_tinyCore.CreateNewCreatrure);
        _tinyCore.EnableCreatureMagnifyedListener(mainUI.creatureSpawner.MagnifyCreature);
        _tinyCore.EnableCurrentCreatureChangedListener(mainUI.creatureSpawner.CreateCreature);
        _tinyCore.EnableCurrentCreatureChangedListener(mainUI.dragAndDrop.HideTextBubble);
        _tinyCore.EnableGettedScoreListener(mainUI.CongraturationTextCreate);
        _tinyCore.EnableGameOverListener(mainUI.EndGame);
        _tinyCore._monsterController.EnableListener(mainUI.UpdateMonsterColor);
    }

    void Update()
    {
        
    }
}
