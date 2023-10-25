﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.BpmEditor.UI.Tools.SplitRegionTool
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor3D.BpmEditor.Commands.Tools;
using System;
using UnityEngine;

namespace BeatmapEditor3D.BpmEditor.UI.Tools
{
  public class SplitRegionTool : BpmEditorTool
  {
    [SerializeField]
    private BpmRegionsInputController _inputController;

    public override void EnableTool() => this._inputController.mouseClickEvent += new Action<int>(this.HandleInputControllerMouseClick);

    public override void DisableTool() => this._inputController.mouseClickEvent -= new Action<int>(this.HandleInputControllerMouseClick);

    private void HandleInputControllerMouseClick(int sample) => this._signalBus.Fire<BpmSplitRegionSignal>(new BpmSplitRegionSignal(sample));
  }
}
