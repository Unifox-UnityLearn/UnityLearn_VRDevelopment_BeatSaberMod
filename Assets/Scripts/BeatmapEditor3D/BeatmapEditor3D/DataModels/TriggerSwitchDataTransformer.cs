﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.DataModels.TriggerSwitchDataTransformer
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace BeatmapEditor3D.DataModels
{
  public class TriggerSwitchDataTransformer : IEventDataTransformer
  {
    public List<BasicEventEditorData> TransformTo(
      List<BasicEventEditorData> events,
      BpmData bpmData)
    {
      List<BasicEventEditorData> basicEventEditorDataList = new List<BasicEventEditorData>();
      for (int index = 0; index < events.Count; index += 2)
      {
        BasicEventEditorData basicEventEditorData1 = events[index];
        BasicEventEditorData basicEventEditorData2 = index < events.Count - 1 ? events[index + 1] : (BasicEventEditorData) null;
        float num1 = (object) basicEventEditorData2 != null ? basicEventEditorData2.beat : 3000f;
        int endValue = (object) basicEventEditorData2 != null ? basicEventEditorData2.value : 0;
        float num2 = (object) basicEventEditorData2 != null ? basicEventEditorData2.floatValue : 1f;
        basicEventEditorDataList.Add(BasicEventEditorData.CreateNewWithId(basicEventEditorData1.id, basicEventEditorData1.type, basicEventEditorData1.beat, basicEventEditorData1.value, basicEventEditorData1.floatValue, num1, endValue, num2));
        if (basicEventEditorData2 != (BasicEventEditorData) null)
          basicEventEditorDataList.Add(BasicEventEditorData.CreateNewWithId(basicEventEditorData2.id, basicEventEditorData2.type, num1, endValue, num2));
      }
      return basicEventEditorDataList;
    }

    public List<BasicEventEditorData> TransformFrom(List<BasicEventEditorData> events) => events.Select<BasicEventEditorData, BasicEventEditorData>((Func<BasicEventEditorData, BasicEventEditorData>) (current => !current.hasEndTime ? current : BasicEventEditorData.CreateNewWithId(current.id, current.type, current.beat, current.value, current.floatValue))).ToList<BasicEventEditorData>();
  }
}
