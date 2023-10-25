﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.Commands.MoveEventsSelectionInTimeCommand
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor3D.DataModels;
using BeatmapEditor3D.LevelEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace BeatmapEditor3D.Commands
{
  public class MoveEventsSelectionInTimeCommand : 
    IBeatmapEditorCommandWithHistory,
    IBeatmapEditorCommand
  {
    [Inject]
    private readonly MoveEventsSelectionInTimeSignal _signal;
    [Inject]
    private readonly EventsSelectionState _eventsSelectionState;
    [Inject]
    private readonly BeatmapBasicEventsDataModel _beatmapBasicEventsDataModel;
    [Inject]
    private readonly SignalBus _signalBus;
    [Inject]
    private readonly IReadonlyBeatmapState _beatmapState;
    private IEnumerable<BasicEventEditorData> _originalEvents;
    private List<BasicEventEditorData> _movedEvents;

    public bool shouldAddToHistory { get; private set; }

    public void Execute()
    {
      if (this._eventsSelectionState.events.Count == 0)
        return;
      this._originalEvents = (IEnumerable<BasicEventEditorData>) this._eventsSelectionState.events.Select<BeatmapEditorObjectId, BasicEventEditorData>((Func<BeatmapEditorObjectId, BasicEventEditorData>) (id => this._beatmapBasicEventsDataModel.GetBasicEventById(id))).OrderBy<BasicEventEditorData, float>((Func<BasicEventEditorData, float>) (e => e.beat)).ToList<BasicEventEditorData>();
      this._movedEvents = new List<BasicEventEditorData>(this._eventsSelectionState.events.Count);
      bool flag1 = false;
      foreach (BasicEventEditorData originalEvent in this._originalEvents)
      {
        float newTime1 = this.GetNewTime(this._signal.direction, originalEvent.beat);
        BasicEventEditorData newWithId;
        if (originalEvent.hasEndTime)
        {
          float newTime2 = this.GetNewTime(this._signal.direction, originalEvent.endBeat);
          newWithId = BasicEventEditorData.CreateNewWithId(originalEvent.id, originalEvent.type, newTime1, originalEvent.value, originalEvent.floatValue, newTime2, originalEvent.endValue, originalEvent.endFloatValue);
        }
        else
          newWithId = BasicEventEditorData.CreateNewWithId(originalEvent.id, originalEvent.type, newTime1, originalEvent.value, originalEvent.floatValue);
        BasicEventEditorData basicEventEditorData = this._beatmapBasicEventsDataModel.GetBasicEventAt(newWithId.type, newWithId.beat);
        int num = !(basicEventEditorData != (BasicEventEditorData) null) ? 0 : (this._originalEvents.Any<BasicEventEditorData>(new Func<BasicEventEditorData, bool>(basicEventEditorData.PositionEquals)) ? 1 : 0);
        bool flag2 = this._movedEvents.Any<BasicEventEditorData>(new Func<BasicEventEditorData, bool>(newWithId.PositionEquals));
        if (num != 0 && !flag2)
          basicEventEditorData = (BasicEventEditorData) null;
        flag1 |= basicEventEditorData == (BasicEventEditorData) null;
        this._movedEvents.Add(basicEventEditorData == (BasicEventEditorData) null ? newWithId : originalEvent);
      }
      if (!flag1)
        return;
      this.shouldAddToHistory = true;
      this.Redo();
    }

    public void Undo()
    {
      this._eventsSelectionState.Clear();
      this._beatmapBasicEventsDataModel.Remove((IEnumerable<BasicEventEditorData>) this._movedEvents);
      this._beatmapBasicEventsDataModel.Insert(this._originalEvents);
      this._eventsSelectionState.AddRange(this._originalEvents.Select<BasicEventEditorData, BeatmapEditorObjectId>((Func<BasicEventEditorData, BeatmapEditorObjectId>) (evt => evt.id)));
      this._signalBus.Fire<BeatmapLevelUpdatedSignal>();
    }

    public void Redo()
    {
      this._eventsSelectionState.Clear();
      this._beatmapBasicEventsDataModel.Remove(this._originalEvents);
      this._beatmapBasicEventsDataModel.Insert((IEnumerable<BasicEventEditorData>) this._movedEvents);
      this._eventsSelectionState.AddRange(this._movedEvents.Select<BasicEventEditorData, BeatmapEditorObjectId>((Func<BasicEventEditorData, BeatmapEditorObjectId>) (evt => evt.id)));
      this._signalBus.Fire<BeatmapLevelUpdatedSignal>();
    }

    private float GetNewTime(
      MoveEventsSelectionInTimeSignal.Direction direction,
      float beat)
    {
      int num = direction == MoveEventsSelectionInTimeSignal.Direction.Forward ? 1 : -1;
      return AudioTimeHelper.ChangeBeatBySubdivision(beat, this._beatmapState.subdivision * 128, num * 128);
    }
  }
}
