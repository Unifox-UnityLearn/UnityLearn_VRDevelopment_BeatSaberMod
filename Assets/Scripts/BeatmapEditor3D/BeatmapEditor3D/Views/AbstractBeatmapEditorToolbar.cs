﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.Views.AbstractBeatmapEditorToolbar
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor3D.DataModels;
using HMUI;
using UnityEngine;

namespace BeatmapEditor3D.Views
{
  public abstract class AbstractBeatmapEditorToolbar : BeatmapEditorView, IBeatmapEditorToolbar
  {
    [SerializeField]
    private TrackToolbarType _toolbarType;

    public TrackToolbarType toolbarType => this._toolbarType;

    public abstract void SetValue(int value, float floatValue, object payload);

    public abstract void SetKeyBindings(KeyboardBinder keyboardBinder);
  }
}
