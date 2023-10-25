﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.Views.BeatMarkerView
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor3D.DataModels;
using TMPro;
using UnityEngine;

namespace BeatmapEditor3D.Views
{
  public class BeatMarkerView : MonoBehaviour
  {
    [SerializeField]
    private TextMeshProUGUI _label;
    [SerializeField]
    private RectTransform _rectTransform;

    public RectTransform rectTransform => this._rectTransform;

    public void SetData(int beat) => this._label.text = StringsRepository.GetIntString(beat);
  }
}
