﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.Commands.ChangeHoverEventBoxBaseEventCommand
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor3D.DataModels;
using Zenject;

namespace BeatmapEditor3D.Commands
{
  public class ChangeHoverEventBoxBaseEventCommand : IBeatmapEditorCommand
  {
    [Inject]
    private readonly ChangeHoverEventBoxBaseEventSignal _signal;
    [Inject]
    private readonly EventBoxGroupsState _eventBoxGroupsState;

    public void Execute()
    {
      this._eventBoxGroupsState.currentHoverEventBoxId = this._signal.eventBoxId;
      this._eventBoxGroupsState.currentHoverBaseEventId = this._signal.baseEventId;
    }
  }
}
