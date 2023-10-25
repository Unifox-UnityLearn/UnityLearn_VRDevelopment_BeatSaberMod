﻿// Decompiled with JetBrains decompiler
// Type: MissionLevelGameplayManager
// Assembly: Main, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89B9E799-8342-47B3-85ED-672D6883482A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\Main.dll

using System.Collections;
using UnityEngine;
using Zenject;

public class MissionLevelGameplayManager : MonoBehaviour, ILevelEndActions, ILevelStartController
{
  [SerializeField]
  protected MissionObjectiveCheckersManager _missionObjectiveCheckersManager;
  [Inject]
  protected readonly GameScenesManager _gameScenesManager;
  [Inject]
  protected readonly GameSongController _gameSongController;
  [Inject]
  protected readonly GameEnergyCounter _gameEnergyCounter;
  [Inject]
  protected readonly PauseController _pauseController;
  [Inject]
  protected readonly MissionLevelGameplayManager.InitData _initData;
  protected MissionLevelGameplayManager.GameState _gameState;
  protected MissionLevelGameplayManager.GameState _prePauseGameState;

  public event System.Action levelWillStartIntroEvent;

  public event System.Action levelDidStartEvent;

  public event System.Action levelFailedEvent;

  public event System.Action levelFinishedEvent;

  public virtual void Awake() => this._gameState = MissionLevelGameplayManager.GameState.Intro;

  public virtual IEnumerator Start()
  {
    MissionLevelGameplayManager levelGameplayManager = this;
    levelGameplayManager._gameSongController.songDidFinishEvent += new System.Action(levelGameplayManager.HandleSongDidFinish);
    levelGameplayManager._gameEnergyCounter.gameEnergyDidReach0Event += new System.Action(levelGameplayManager.HandleGameEnergyDidReach0);
    levelGameplayManager._missionObjectiveCheckersManager.objectiveDidFailEvent += new System.Action(levelGameplayManager.HandleMissionObjectiveCheckersManagerObjectiveDidFail);
    levelGameplayManager._pauseController.canPauseEvent += new System.Action<System.Action<bool>>(levelGameplayManager.HandlePauseControllerCanPause);
    levelGameplayManager._pauseController.didPauseEvent += new System.Action(levelGameplayManager.HandlePauseControllerDidPause);
    levelGameplayManager._pauseController.didResumeEvent += new System.Action(levelGameplayManager.HandlePauseControllerDidResume);
    yield return (object) levelGameplayManager._gameScenesManager.waitUntilSceneTransitionFinish;
    System.Action willStartIntroEvent = levelGameplayManager.levelWillStartIntroEvent;
    if (willStartIntroEvent != null)
      willStartIntroEvent();
    yield return (object) null;
    yield return (object) levelGameplayManager._gameSongController.waitUntilIsReadyToStartTheSong;
    switch (levelGameplayManager._gameState)
    {
      case MissionLevelGameplayManager.GameState.Intro:
        levelGameplayManager._gameState = MissionLevelGameplayManager.GameState.Playing;
        break;
      case MissionLevelGameplayManager.GameState.Paused:
        levelGameplayManager._prePauseGameState = MissionLevelGameplayManager.GameState.Playing;
        break;
      default:
        Debug.LogError((object) string.Format("Unexpected game state {0}", (object) levelGameplayManager._gameState));
        break;
    }
    levelGameplayManager._gameSongController.StartSong(0.0f);
    System.Action levelDidStartEvent = levelGameplayManager.levelDidStartEvent;
    if (levelDidStartEvent != null)
      levelDidStartEvent();
  }

  public virtual void OnDestroy()
  {
    if ((UnityEngine.Object) this._gameSongController != (UnityEngine.Object) null)
      this._gameSongController.songDidFinishEvent -= new System.Action(this.HandleSongDidFinish);
    if ((UnityEngine.Object) this._gameEnergyCounter != (UnityEngine.Object) null)
      this._gameEnergyCounter.gameEnergyDidReach0Event -= new System.Action(this.HandleGameEnergyDidReach0);
    if ((UnityEngine.Object) this._missionObjectiveCheckersManager != (UnityEngine.Object) null)
      this._missionObjectiveCheckersManager.objectiveDidFailEvent -= new System.Action(this.HandleMissionObjectiveCheckersManagerObjectiveDidFail);
    if (!((UnityEngine.Object) this._pauseController != (UnityEngine.Object) null))
      return;
    this._pauseController.canPauseEvent -= new System.Action<System.Action<bool>>(this.HandlePauseControllerCanPause);
    this._pauseController.didPauseEvent -= new System.Action(this.HandlePauseControllerDidPause);
    this._pauseController.didResumeEvent -= new System.Action(this.HandlePauseControllerDidResume);
  }

  public virtual void HandleGameEnergyDidReach0()
  {
    if (this._gameState == MissionLevelGameplayManager.GameState.Failed || this._gameState == MissionLevelGameplayManager.GameState.Finished || !this._initData.failOn0Energy)
      return;
    this._gameState = MissionLevelGameplayManager.GameState.Failed;
    System.Action levelFailedEvent = this.levelFailedEvent;
    if (levelFailedEvent == null)
      return;
    levelFailedEvent();
  }

  public virtual void HandleMissionObjectiveCheckersManagerObjectiveDidFail()
  {
    if (this._gameState == MissionLevelGameplayManager.GameState.Failed || this._gameState == MissionLevelGameplayManager.GameState.Finished)
      return;
    this._gameState = MissionLevelGameplayManager.GameState.Failed;
    System.Action levelFailedEvent = this.levelFailedEvent;
    if (levelFailedEvent == null)
      return;
    levelFailedEvent();
  }

  public virtual void HandleSongDidFinish()
  {
    if (this._gameState == MissionLevelGameplayManager.GameState.Failed || this._gameState == MissionLevelGameplayManager.GameState.Finished)
      return;
    this._gameState = MissionLevelGameplayManager.GameState.Finished;
    System.Action levelFinishedEvent = this.levelFinishedEvent;
    if (levelFinishedEvent == null)
      return;
    levelFinishedEvent();
  }

  public virtual void HandlePauseControllerCanPause(System.Action<bool> canPause)
  {
    if (canPause == null)
      return;
    canPause(this._gameState == MissionLevelGameplayManager.GameState.Playing || this._gameState == MissionLevelGameplayManager.GameState.Intro);
  }

  public virtual void HandlePauseControllerDidPause()
  {
    if (this._gameState != MissionLevelGameplayManager.GameState.Playing && this._gameState != MissionLevelGameplayManager.GameState.Intro)
      return;
    this._prePauseGameState = this._gameState;
    this._gameState = MissionLevelGameplayManager.GameState.Paused;
  }

  public virtual void HandlePauseControllerDidResume()
  {
    if (this._gameState != MissionLevelGameplayManager.GameState.Paused)
      return;
    this._gameState = this._prePauseGameState;
  }

  public class InitData
  {
    public readonly bool failOn0Energy;

    public InitData(bool failOn0Energy) => this.failOn0Energy = failOn0Energy;
  }

  public enum GameState
  {
    Intro,
    Playing,
    Paused,
    Finished,
    Failed,
  }
}
