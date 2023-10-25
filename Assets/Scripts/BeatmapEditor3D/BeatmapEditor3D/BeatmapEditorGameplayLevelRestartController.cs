﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.BeatmapEditorGameplayLevelRestartController
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using UnityEngine;
using Zenject;

namespace BeatmapEditor3D
{
  public class BeatmapEditorGameplayLevelRestartController : MonoBehaviour, ILevelRestartController
  {
    [SerializeField]
    private BeatmapEditorStandardLevelScenesTransitionSetupDataSO _beatmapEditorStandardLevelScenesTransitionSetupData;
    [Inject]
    private readonly PrepareLevelCompletionResults _prepareLevelCompletionResults;

    public void RestartLevel() => this._beatmapEditorStandardLevelScenesTransitionSetupData.Finish(this._prepareLevelCompletionResults.FillLevelCompletionResults(LevelCompletionResults.LevelEndStateType.Incomplete, LevelCompletionResults.LevelEndAction.Restart));
  }
}
