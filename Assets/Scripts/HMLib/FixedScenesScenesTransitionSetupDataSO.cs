﻿// Decompiled with JetBrains decompiler
// Type: FixedScenesScenesTransitionSetupDataSO
// Assembly: HMLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8CC76D59-1DD6-42EE-8DB5-092A3F1E1FFA
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\HMLib.dll

using UnityEngine;

public class FixedScenesScenesTransitionSetupDataSO : ScenesTransitionSetupDataSO
{
  [SerializeField]
  protected SceneInfo[] _sceneInfos;

  public virtual void Init() => this.Init(this._sceneInfos, (SceneSetupData[]) null);
}
