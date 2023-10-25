﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.BpmEditor.Commands.Tools.EndBpmMoveBeatCommand
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

namespace BeatmapEditor3D.BpmEditor.Commands.Tools
{
  public class EndBpmMoveBeatCommand : UpdateAllRegionsBeatBoundsCommand
  {
    public override bool ShouldMergeWith(
      IBeatmapEditorCommandWithHistoryMergeable previousCommand)
    {
      return previousCommand is BpmMoveBeatCommand;
    }

    public override void MergeWith(
      IBeatmapEditorCommandWithHistoryMergeable previousCommand)
    {
      BpmMoveBeatCommand bpmMoveBeatCommand = (BpmMoveBeatCommand) previousCommand;
      this._oldRegions[bpmMoveBeatCommand.regionIndex] = bpmMoveBeatCommand.oldRegion;
      if (!bpmMoveBeatCommand.nextRegionIndex.HasValue)
        return;
      this._oldRegions[bpmMoveBeatCommand.nextRegionIndex.Value] = bpmMoveBeatCommand.oldNextRegion;
    }
  }
}
