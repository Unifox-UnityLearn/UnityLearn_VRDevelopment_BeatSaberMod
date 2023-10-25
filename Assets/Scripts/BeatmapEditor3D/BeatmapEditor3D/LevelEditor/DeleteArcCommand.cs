﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.LevelEditor.DeleteArcCommand
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor3D.DataModels;
using Zenject;

namespace BeatmapEditor3D.LevelEditor
{
  public class DeleteArcCommand : DeleteBeatmapObjectCommand
  {
    [Inject]
    private readonly DeleteArcSignal _signal;
    private ArcEditorData _arc;

    protected override void GatherBeatmapObject() => this._arc = this.beatmapLevelDataModel.GetArcById(this._signal.id);

    protected override bool ShouldAddToHistory() => this._arc != (ArcEditorData) null;

    protected override void DeselectBeatmapObjectIfSelected()
    {
    }

    protected override void RemoveFromBeatmapLevelDataModel() => this.beatmapLevelDataModel.RemoveArc(this._arc);

    protected override void AddToBeatmapLevelDataModel() => this.beatmapLevelDataModel.AddArc(this._arc);
  }
}
