﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.Controller.BeatmapEditorNoteController
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using UnityEngine;

namespace BeatmapEditor3D.Controller
{
  public class BeatmapEditorNoteController : NoteController
  {
    public void Init(NoteData noteData) => this.Init(noteData, 0.0f, Vector3.zero, Vector3.zero, Vector3.zero, 0.0f, 0.0f, 0.0f, 0.0f, 1f, false, false);

    public override void Pause(bool pause)
    {
    }

    protected override void HiddenStateDidChange(bool hide)
    {
    }
  }
}
