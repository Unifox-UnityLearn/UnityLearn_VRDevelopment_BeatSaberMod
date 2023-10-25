﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.BpmEditor.Commands.PlayHeadZoomCommand
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using UnityEngine;
using Zenject;

namespace BeatmapEditor3D.BpmEditor.Commands
{
  public class PlayHeadZoomCommand : IBeatmapEditorCommand
  {
    [Inject]
    private readonly PlayHeadZoomSignal _signal;
    [Inject]
    private readonly BpmEditorState _bpmEditorState;
    [Inject]
    private readonly SignalBus _signalBus;

    public void Execute()
    {
      this._bpmEditorState.previewHalfSize = Mathf.Clamp(this._bpmEditorState.previewHalfSize + this._signal.sampleDelta, 5000, 250000);
      this._signalBus.Fire<PlayHeadUpdatePreviewSignal>();
      this._signalBus.Fire<PlayHeadZoomedSignal>();
    }
  }
}
