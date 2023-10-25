﻿// Decompiled with JetBrains decompiler
// Type: BeatmapEditor3D.CommandInstaller
// Assembly: BeatmapEditor3D, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F08665C-E1B6-4752-A219-2B54516F316A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\BeatmapEditor3D.dll

using BeatmapEditor.Commands;
using BeatmapEditor3D.BpmEditor.Commands;
using BeatmapEditor3D.BpmEditor.Commands.Tools;
using BeatmapEditor3D.Commands;
using BeatmapEditor3D.Commands.LevelEditor;
using BeatmapEditor3D.Controller;
using BeatmapEditor3D.DataModels;
using BeatmapEditor3D.LevelEditor;
using System;
using Zenject;

namespace BeatmapEditor3D
{
  public class CommandInstaller : MonoInstaller<CommandInstaller>
  {
    private DiContainer _commandContainer;

    public override void InstallBindings()
    {
      Installer<SignalBusInstaller>.Install(this.Container);
      this._commandContainer = this.Container.CreateSubContainer();
      this.Container.Bind<IBeatmapEditorCommandRunner>().To<BeatmapEditorCommandRunner>().AsSingle();
      this.Container.Bind<BeatmapEditorCommandRunnerSignalBinder>().AsSingle();
      this.Container.Bind<RunningAsyncBeatmapEditorCommandCache>().AsSingle();
      this.Container.Bind<DiContainer>().WithId((object) "SignalsContainer").FromInstance(this._commandContainer).AsSingle();
      this.BindSignalToCommand<RedoEditorHistorySignal, RedoEditorHistoryCommand>();
      this.BindSignalToCommand<UndoEditorHistorySignal, UndoEditorHistoryCommand>();
      this.BindSignalToCommand<ClearEditorHistorySignal, ClearEditorHistoryCommand>();
      this.Container.DeclareSignal<CommandMessageSignal>().OptionalSubscriber();
      this.Container.BindInterfacesAndSelfTo<UndoRedoController>().AsSingle();
      this.Container.DeclareSignal<BeatmapsCollectionSignals.UpdatedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapsCollectionSignals.BeatmapAddedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapDataModelSignals.DifficultyBeatmapAddedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapDataModelSignals.BeatmapLoadedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapDataModelSignals.WaveformDataProcessedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapDataModelSignals.BeatmapLoadErrorSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapProjectManagerSignals.BeatmapLevelDataModelLoaded>().OptionalSubscriber();
      this.BindSignalToCommand<BeatmapEditorSettingsSignals.UpdateSettingsSignal, BeatmapEditorSettingsSignals.UpdateSettingsCommand>();
      this.BindSignalToCommand<TimeControlsPlaySignal, TimeControlsPlayCommand>();
      this.BindSignalToCommand<TimeControlsPauseSignal, TimeControlsPauseCommand>();
      this.BindSignalToCommand<TimeControlsStopSignal, TimeControlsStopCommand>();
      this.BindSignalToCommand<TimeControlsMovePlayHeadSignal, TimeControlsMovePlayHeadCommand>();
      this.BindSignalToCommand<TimeControlsReplaySignal, TimeControlsReplayCommand>();
      this.Container.DeclareSignal<BeatmapLevelStateTimeUpdated>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapLevelStatePreviewUpdated>().OptionalSubscriber();
      this.Container.DeclareSignal<SubdivisionChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<UpdatePlayHeadSignal, UpdatePlayHeadCommand>();
      this.BindSignalToCommand<ZoomPreviewSelectionSignal, ZoomPreviewSelectionCommand>();
      this.BindSignalToCommand<SetPreviewSignal, SetPreviewCommand>();
      this.BindSignalToCommand<ChangeSubdivisionSignal, ChangeSubdivisionCommand>();
      this.BindSignalToCommand<SwapSubdivisionSignal, SwapSubdivisionCommand>();
      this.Container.DeclareSignal<SubdivisionSwappedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeBeatmapTimeScaleSignal, ChangeBeatmapTimeScaleCommand>();
      this.Container.DeclareSignal<BeatmapTimeScaleChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<UpdatePlaybackSpeedSignal, UpdatePlaybackSpeedCommand>();
      this.BindSignalToCommand<UpdateModifyScrollPrecisionSignal, UpdateModifyScrollPrecisionCommand>();
      this.Container.DeclareSignal<PlaybackSpeedUpdatedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapObjectsCountUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<CalculateBeatmapObjectsCountSignal, CalculateBeatmapObjectsCountCommand>();
      this.BindSignalToCommand<SwitchBeatmapEditingModeSignal, SwitchBeatmapEditingModeCommand>();
      this.Container.DeclareSignal<BeatmapEditingModeSwitched>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeBeatmapObjectTypeSignal, ChangeBeatmapObjectTypeCommand>();
      this.Container.DeclareSignal<BeatmapObjectTypeChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeHoveredNoteCutDirectionSignal, ChangeHoveredNoteCutDirectionCommand>();
      this.BindSignalToCommand<ChangeNoteCutDirectionSignal, ChangeNoteCutDirectionCommand>();
      this.Container.DeclareSignal<NoteCutDirectionChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeHoveredNoteColorTypeSignal, ChangeHoveredNoteColorTypeCommand>();
      this.BindSignalToCommand<ChangeNoteColorTypeSignal, ChangeNoteColorTypeCommand>();
      this.Container.DeclareSignal<NoteColorTypeChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeDotNoteAngleSignal, ChangeDotNoteAngleCommand>();
      this.BindSignalToCommand<ChangeHoveredDotNoteAngleSignal, ChangeHoveredDotNoteAngleCommand>();
      this.Container.DeclareSignal<DotNoteAngleChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeHoveredObstacleDurationSignal, ChangeHoveredObstacleDurationCommand>();
      this.BindSignalToCommand<ChangeObstacleDurationSignal, ChangeObstacleDurationCommand>();
      this.Container.DeclareSignal<ObstacleDurationChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<InvertHoveredNoteColorSignal, InvertHoveredNoteColorCommand>();
      this.BindSignalToCommand<InvertHoveredChainColorSignal, InvertHoveredChainColorCommand>();
      this.BindSignalToCommand<InvertHoveredArcColorSignal, InvertHoveredArcColorCommand>();
      this.BindSignalToCommand<ChangeHoveredArcControlPointLengthSignal, ChangeHoveredArcControlPointLengthCommand>();
      this.BindSignalToCommand<ChangeHoveredArcControlPointCutDirectionSignal, ChangeHoveredArcControlPointCutDirectionCommand>();
      this.BindSignalToCommand<ChangeHoveredArcControlPointCutDirectionAndLengthSignal, ChangeHoveredArcControlPointCutDirectionAndLengthCommand>();
      this.BindSignalToCommand<ChangeHoveredArcMidAnchorModeSignal, ChangeHoveredArcMidAnchorModeCommand>();
      this.Container.DeclareSignal<InteractionModeChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeInteractionModeSignal, ChangeInteractionModeCommand>();
      this.Container.DeclareSignal<BeatmapObjectsRectangleSelectionChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BeatmapObjectsChangeRectangleSelectionSignal, BeatmapObjectsChangeRectangleSelectionCommand>();
      this.BindSignalToCommand<StartBeatmapObjectsSelectionSignal, StartBeatmapObjectsSelectionCommand>();
      this.BindSignalToCommand<EndBeatmapObjectsSelectionSignal, EndBeatmapObjectsSelectionCommand>();
      this.BindSignalToCommand<SelectMultipleBeatmapObjectsSignal, SelectMultipleBeatmapObjectsCommand>();
      this.BindSignalToCommand<SelectAllBeatmapObjectsSignal, SelectAllBeatmapObjectsCommand>();
      this.BindSignalToCommand<DeselectAllBeatmapObjectsSignal, DeselectAllBeatmapObjectsCommand>();
      this.BindSignalToCommand<SelectNoteSignal, SelectNoteCommand>();
      this.BindSignalToCommand<SelectObstacleSignal, SelectObstacleCommand>();
      this.BindSignalToCommand<SelectChainSignal, SelectChainCommand>();
      this.BindSignalToCommand<SelectArcSignal, SelectArcCommand>();
      this.BindSignalToCommand<CutBeatmapObjectsSignal, CutBeatmapObjectsCommand>();
      this.BindSignalToCommand<DeleteBeatmapObjectsSignal, DeleteBeatmapObjectsCommand>();
      this.BindSignalToCommand<CopyBeatmapObjectsSignal, CopyBeatmapObjectsCommand>();
      this.BindSignalToCommand<PasteBeatmapObjectsSignal, PasteBeatmapObjectsCommand>();
      this.BindSignalToCommand<MirrorSelectedBeatmapObjectsSignal, MirrorSelectedBeatmapObjectsCommand>();
      this.BindSignalToCommand<MoveBeatmapObjectSelectionOnGridSignal, MoveBeatmapObjectSelectionOnGridCommand>();
      this.BindSignalToCommand<MoveBeatmapObjectSelectionInTimeSignal, MoveBeatmapObjectSelectionInTimeCommand>();
      this.BindSignalToCommand<ClearDraggedBeatmapObjectSignal, ClearDraggedBeatmapObjectCommand>();
      this.BindSignalToCommand<PlaceNoteObjectSignal, PlaceNoteObjectCommand>();
      this.BindSignalToCommand<PlaceObstacleObjectSignal, PlaceObstacleObjectCommand>();
      this.BindSignalToCommand<PlaceChainObjectSignal, PlaceChainObjectCommand>();
      this.BindSignalToCommand<PlaceArcObjectSignal, PlaceArcObjectCommand>();
      this.BindSignalToCommand<MoveNoteToBeatLineSignal, MoveNoteToBeatLineCommand>();
      this.BindSignalToCommand<MoveObstacleToBeatLineSignal, MoveObstacleToBeatLineCommand>();
      this.BindSignalToCommand<MoveChainToBeatLineSignal, MoveChainToBeatLineCommand>();
      this.BindSignalToCommand<MoveArcToBeatLineSignal, MoveArcToBeatLineCommand>();
      this.BindSignalToCommand<MoveHoveredBeatmapObjectOnGridSignal, MoveHoveredBeatmapObjectOnGridCommand>();
      this.BindSignalToCommand<MoveNoteOnGridSignal, MoveNoteOnGridCommand>();
      this.BindSignalToCommand<MoveObstacleOnGridSignal, MoveObstacleOnGridCommand>();
      this.BindSignalToCommand<MoveChainOnGridSignal, MoveChainOnGridCommand>();
      this.BindSignalToCommand<MoveArcOnGridSignal, MoveArcOnGridCommand>();
      this.BindSignalToCommand<DeleteNoteSignal, DeleteNoteCommand>();
      this.BindSignalToCommand<DeleteObstacleSignal, DeleteObstacleCommand>();
      this.BindSignalToCommand<DeleteChainSignal, DeleteChainCommand>();
      this.BindSignalToCommand<DeleteArcSignal, DeleteArcCommand>();
      this.BindSignalToCommand<ConnectBeatmapObjectsWithArcSignal, ConnectBeatmapObjectsWithArcCommand>();
      this.BindSignalToCommand<ChangeArcMidAnchorModeSignal, ChangeSliderMidAnchorModeCommand>();
      this.BindSignalToCommand<ChangeArcHeadControlPointLengthSignal, ChangeArcHeadControlPointLengthCommand>();
      this.BindSignalToCommand<ChangeArcTailControlPointLengthSignal, ChangeArcTailControlPointLengthCommand>();
      this.BindSignalToCommand<ChangeHoveredChainSliceCountSignal, ChangeHoveredChainSliceCountCommand>();
      this.BindSignalToCommand<ChangeHoveredChainSquishAmountSignal, ChangeHoveredChainSquishAmountCommand>();
      this.Container.DeclareSignal<ArcMidAnchorModeChangedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<ArcControlPointLengthChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ToggleCameraMovementSignal, ToggleCameraMovementCommand>();
      this.BindSignalToCommand<ToggleAutoRotationSignal, ToggleAutoRotationCommand>();
      this.BindSignalToCommand<ToggleFpfcSignal, ToggleFpfcCommand>();
      this.BindSignalToCommand<TogglePreserveTimeSignal, TogglePreserveTimeCommand>();
      this.BindSignalToCommand<ToggleStaticLightSignal, ToggleStaticLightCommand>();
      this.Container.DeclareSignal<LevelEditorStateStaticLightsUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ToggleZenModeSignal, ToggleZenModeCommand>();
      this.Container.DeclareSignal<LevelEditorStateZenModeUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ToggleAutoExposureSignal, ToggleAutoExposureCommand>();
      this.Container.DeclareSignal<LevelEditorStateAutoExposureUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeWaveformTypeSignal, ChangeWaveformTypeCommand>();
      this.Container.DeclareSignal<WaveformTypeChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeGameplayUIStateSignal, ChangeGameplayUIStateCommand>();
      this.Container.DeclareSignal<GameplayUIStateChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeHoverSignal, ChangeHoverCellDataCommand>();
      this.Container.DeclareSignal<HoverChangedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<ViewRotatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<RotateViewSignal, RotateViewCommand>();
      this.BindSignalToCommand<SetViewRotationSignal, SetViewRotationCommand>();
      this.BindSignalToCommand<ChangeEventBoxGroupsPageSignal, ChangeEventBoxGroupsPageCommand>();
      this.Container.DeclareSignal<EventBoxGroupsPageChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeEventBoxGroupExtensionSignal, ChangeEventBoxGroupExtensionCommand>();
      this.Container.DeclareSignal<EventBoxGroupExtensionChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<SelectSingleEventBoxGroupSignal, SelectSingleEventBoxGroupCommand>();
      this.BindSignalToCommand<DeselectSingleEventBoxGroupSignal, DeselectSingleEventBoxGroupCommand>();
      this.BindSignalToCommand<ClearEventBoxGroupsSelectionSignal, ClearEventBoxGroupsSelectionCommand>();
      this.BindSignalToCommand<CopyEventBoxGroupsSignal, CopyEventBoxGroupsCommand>();
      this.BindSignalToCommand<PasteEventBoxGroupsSignal, PasteEventBoxGroupsCommand>();
      this.BindSignalToCommand<CutEventBoxGroupsSignal, CutEventBoxGroupsCommand>();
      this.BindSignalToCommand<MirrorSelectedEventBoxGroupsSignal, MirrorSelectedEventBoxGroupsCommand>();
      this.BindSignalToCommand<DeleteSelectedEventBoxGroupsSignal, DeleteSelectedEventBoxGroupsCommand>();
      this.BindSignalToCommand<DuplicateSelectedEventBoxGroupsSignal, DuplicateSelectedEventBoxGroupsCommand>();
      this.BindSignalToCommand<SelectMultipleEventBoxGroupsSignal, SelectMultipleEventBoxGroupsCommand>();
      this.BindSignalToCommand<EventBoxGroupChangeRectangleSelectionSignal, EventBoxGroupChangeRectangleSelectionCommand>();
      this.Container.DeclareSignal<EventBoxGroupsSelectionRectangleChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<MirrorSelectedEventBoxEventsSignal, MirrorSelectedEventBoxEventsCommand>();
      this.BindSignalToCommand<ChangeHoverGroupIdSignal, ChangeHoverGroupIdCommand>();
      this.Container.DeclareSignal<EventBoxGroupHoverChanged>().OptionalSubscriber();
      this.BindSignalToCommand<EditEventBoxGroupSignal, EditEventBoxGroupCommand>();
      this.Container.DeclareSignal<EditingEventBoxGroupChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ClearEditedEventBoxGroupSignal, ClearEditedEventBoxGroupCommand>();
      this.BindSignalToCommand<ExitEditEventBoxGroupSignal, ExitEditEventBoxGroupCommand>();
      this.BindSignalToCommand<PlaceEventBoxGroupSignal, PlaceEventBoxGroupCommand>();
      this.BindSignalToCommand<DeleteEventBoxGroupSignal, DeleteEventBoxGroupCommand>();
      this.BindSignalToCommand<SwapLightColorEventBoxesEditorGroupSignal, SwapLightColorEventBoxesEditorGroupCommand>();
      this.BindSignalToCommand<InsertEventBoxSignal, InsertEventBoxCommand>();
      this.BindSignalToCommand<SuperInsertEventBoxSignal, SuperInsertEventBoxCommand>();
      this.BindSignalToCommand<DeleteEventBoxSignal, DeleteEventBoxCommand>();
      this.BindSignalToCommand<PruneEventBoxesSignal, PruneEventBoxesCommand>();
      this.BindSignalToCommand<ModifyEventBoxSignal, ModifyEventBoxCommand>();
      this.Container.DeclareSignal<EventBoxesUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeHoverEventBoxIdSignal, ChangeHoverEventBoxIdCommand>();
      this.BindSignalToCommand<ChangeHoverEventBoxBaseEventSignal, ChangeHoverEventBoxBaseEventCommand>();
      this.BindSignalToCommand<CopyEventBoxEventsSignal, CopyEventBoxEventsCommand>();
      this.BindSignalToCommand<PasteEventBoxEventsSignal, PasteEventBoxEventsCommand>();
      this.BindSignalToCommand<CutEventBoxEventsSignal, CutEventBoxEventsCommand>();
      this.BindSignalToCommand<DeleteSelectedEventBoxEventsSignal, DeleteSelectedEventBoxEventsCommand>();
      this.BindSignalToCommand<SelectSingleEventBoxesEventSignal, SelectSingleEventBoxesEventCommand>();
      this.BindSignalToCommand<SelectMultipleEventBoxesEventsSignal, SelectMultipleEventBoxesEventsCommand>();
      this.BindSignalToCommand<ClearEventBoxesSelectionSignal, ClearEventBoxesSelectionCommand>();
      this.BindSignalToCommand<EventBoxesChangeRectangleSelectionSignal, EventBoxesChangeRectangleSelectionCommand>();
      this.BindSignalToCommand<ChangeLightColorEventSignal, ChangeLightColorEventCommand>();
      this.Container.DeclareSignal<LightColorEventChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeLightRotationEventSignal, ChangeLightRotationEventCommand>();
      this.Container.DeclareSignal<LightRotationEventChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ChangeLightTranslationEventSignal, ChangeLightTranslationEventCommand>();
      this.Container.DeclareSignal<LightTranslationEventChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<DeleteLightEventSignal, DeleteLightEventCommand>();
      this.BindSignalToCommand<PlaceLightColorEventSignal, PlaceLightColorEventCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorSignal, ModifyHoveredLightColorCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorSwapSignal, ModifyHoveredLightColorSwapCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorTransitionTypeSignal, ModifyHoveredLightColorTransitionTypeCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorBrightnessSignal, ModifyHoveredLightColorBrightnessCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorDeltaBrightnessSignal, ModifyHoveredLightColorDeltaBrightnessCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorStrobeFrequencySignal, ModifyHoveredLightColorStrobeFrequencyCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorDeltaStrobeFrequencySignal, ModifyHoveredLightColorDeltaStrobeFrequencyCommand>();
      this.BindSignalToCommand<ModifyHoveredLightColorCycleStrobeFrequencySignal, ModifyHoveredLightColorCycleStrobeFrequencyCommand>();
      this.BindSignalToCommand<PlaceLightRotationEventSignal, PlaceLightRotationEventCommand>();
      this.BindSignalToCommand<ModifyHoveredLightRotationEaseTypeSignal, ModifyHoveredLightRotationEaseTypeCommand>();
      this.BindSignalToCommand<ModifyHoveredLightRotationLoopsCountSignal, ModifyHoveredLightRotationLoopsCountCommand>();
      this.BindSignalToCommand<ModifyHoveredLightRotationRotationSignal, ModifyHoveredLightRotationRotationCommand>();
      this.BindSignalToCommand<ModifyHoveredLightRotationDeltaRotationSignal, ModifyHoveredLightRotationDeltaRotationCommand>();
      this.BindSignalToCommand<ModifyHoveredLightRotationDirectionSignal, ModifyHoveredLightRotationDirectionCommand>();
      this.BindSignalToCommand<PlaceLightTranslationEventSignal, PlaceLightTranslationEventCommand>();
      this.BindSignalToCommand<ModifyHoveredLightTranslationEaseTypeSignal, ModifyHoveredLightTranslationEaseTypeCommand>();
      this.BindSignalToCommand<ModifyHoveredLightTranslationTranslationSignal, ModifyHoveredLightTranslationTranslationCommand>();
      this.BindSignalToCommand<ModifyHoveredLightTranslationDeltaTranslationSignal, ModifyHoveredLightTranslationDeltaTranslationCommand>();
      this.BindSignalToCommand<ChangeEventSignal, ChangeEventCommand>();
      this.BindSignalToCommand<UpdateHoverBeatAndTrackSignal, UpdateHoverBeatAndTrackCommand>();
      this.BindSignalToCommand<ChangeEventsPageSignal, ChangeEventsPageCommand>();
      this.BindSignalToCommand<ChangeLightEventsVersionSignal, ChangeLightEventsVersionCommand>();
      this.BindSignalToCommand<MirrorLightEventsSignal, MirrorLightEventsCommand>();
      this.BindSignalToCommand<ModifyLightEventColorSignal, ModifyLightEventColorCommand>();
      this.BindSignalToCommand<ModifyHoveredLightEventColorSignal, ModifyHoveredLightEventColorCommand>();
      this.BindSignalToCommand<ModifyHoveredLightEventTypeSignal, ModifyHoveredLightEventTypeCommand>();
      this.BindSignalToCommand<ModifyHoveredLightEventIntensitySignal, ModifyHoveredLightEventIntensityCommand>();
      this.BindSignalToCommand<ModifyHoveredLightEventDeltaIntensitySignal, ModifyHoveredLightEventDeltaIntensityCommand>();
      this.BindSignalToCommand<ModifyHoveredLaserRotationSpeedSignal, ModifyHoveredLaserRotationSpeedCommand>();
      this.BindSignalToCommand<ModifyHoveredFloatEventValueSignal, ModifyHoveredFloatEventValueCommand>();
      this.BindSignalToCommand<ModifyHoveredDeltaFloatEventValueSignal, ModifyHoveredDeltaFloatEventValueCommand>();
      this.BindSignalToCommand<MoveEventToBeatLineSignal, MoveEventToBeatLineCommand>();
      this.BindSignalToCommand<MoveEventsSelectionSignal, MoveEventsSelectionCommand>();
      this.BindSignalToCommand<MoveEventsSelectionInTimeSignal, MoveEventsSelectionInTimeCommand>();
      this.BindSignalToCommand<MoveEventToTrackSignal, MoveEventToTrackCommand>();
      this.BindSignalToCommand<ClearDraggedEventSignal, ClearDraggedEventCommand>();
      this.BindSignalToCommand<ChangeHoverEventObjectSignal, ChangeHoverEventObjectCommand>();
      this.Container.DeclareSignal<SelectedEventChangedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<EventHoverUpdatedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<EventsPageChangedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<LightEventsVersionChanged>().OptionalSubscriber();
      this.BindSignalToCommand<EventsChangeRectangleSelectionSignal, EventsChangeRectangleSelectionCommand>();
      this.BindSignalToCommand<SelectSingleEventSignal, SelectSingleEventCommand>();
      this.BindSignalToCommand<DeselectSingleEventSignal, DeselectSingleEventCommand>();
      this.BindSignalToCommand<SelectMultipleEventsSignal, SelectMultipleEventsCommand>();
      this.BindSignalToCommand<StartEventsSelectionSignal, StartEventsSelectionCommand>();
      this.BindSignalToCommand<EndEventsSelectionSignal, EndEventsSelectionCommand>();
      this.BindSignalToCommand<SelectAllEventsOnTrackSignal, SelectAllEventsOnTrackCommand>();
      this.BindSignalToCommand<ClearEventsSelectionSignal, ClearEventsSelectionCommand>();
      this.Container.DeclareSignal<EventsSelectionRectangleChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<CopyEventsSignal, CopyEventsCommand>();
      this.BindSignalToCommand<PasteEventsSignal, PasteEventsCommand>();
      this.BindSignalToCommand<CutEventsSignal, CutEventsCommand>();
      this.BindSignalToCommand<DeleteSelectedEventsSignal, DeleteSelectedEventsCommand>();
      this.BindSignalToCommand<PlaceEventSignal, PlaceEventCommand>();
      this.BindSignalToCommand<RemoveEventSignal, RemoveEventCommand>();
      this.BindSignalToCommand<SetAllTracksSignal, SetAllTracksCommand>();
      this.BindSignalToCommand<MuteEventTrackSignal, MuteEventTrackCommand>();
      this.BindSignalToCommand<SoloEventTrackSignal, SoloEventTrackCommand>();
      this.Container.DeclareSignal<EventsTrackStateUpdated>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapLevelUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ClearSelectionSignal, ClearSelectionCommand>();
      this.BindSignalToCommand<BeatmapsCollectionSignals.RefreshSignal, BeatmapsCollectionSignals.RefreshCommand>();
      this.BindSignalToCommand<BeatmapsCollectionSignals.AddNewBeatmapSignal, BeatmapsCollectionSignals.AddNewBeatmapCommand>();
      this.BindSignalToCommand<BeatmapsCollectionSignals.AddRecentlyOpenedBeatmapSignal, BeatmapsCollectionSignals.AddRecentlyOpenedBeatmapCommand>();
      this.BindSignalToCommand<BeatmapDataModelSignals.AddDifficultyBeatmapSignal, BeatmapDataModelSignals.AddDifficultyBeatmapCommand>();
      this.BindSignalToCommand<BeatmapDataModelSignals.RemoveDifficultyBeatmapSignal, BeatmapDataModelSignals.RemoveDifficultyBeatmapCommand>();
      this.BindSignalToCommand<BeatmapDataModelSignals.UpdateDifficultyBeatmapSignal, BeatmapDataModelSignals.UpdateDifficultyBeatmapCommand>();
      this.BindSignalToCommand<BeatmapDataModelSignals.UpdateBeatmapDataSignal, BeatmapDataModelSignals.UpdateBeatmapDataCommand>();
      this.BindSignalToCommand<BeatmapDataModelSignals.UpdateBeatmapSongSignal, BeatmapDataModelSignals.UpdateBeatmapSongCommand>();
      this.BindSignalToCommand<BeatmapDataModelSignals.UpdateBeatmapCoverImageSignal, BeatmapDataModelSignals.UpdateBeatmapCoverImageCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.LoadSettingsSignal, BeatmapProjectManagerSignals.LoadSettingsCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveSettingsSignal, BeatmapProjectManagerSignals.SaveSettingsCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.LoadBeatmapProjectSignal, BeatmapProjectManagerSignals.LoadBeatmapProjectCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.LoadBeatmapProjectFromLastSaveSignal, BeatmapProjectManagerSignals.LoadBeatmapProjectFromLastSaveCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveBeatmapProjectSignal, BeatmapProjectManagerSignals.SaveBeatmapProjectCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveBeatmapProjectToTempSignal, BeatmapProjectManagerSignals.SaveBeatmapProjectToTempCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveBpmInfoSignal, BeatmapProjectManagerSignals.SaveBpmInfoCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveBpmInfoToTempSignal, BeatmapProjectManagerSignals.SaveBpmInfoToTempCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.CloseBpmInfoSignal, BeatmapProjectManagerSignals.CloseBpmInfoCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.CloseBeatmapProjectSignal, BeatmapProjectManagerSignals.CloseBeatmapProjectCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.LoadBeatmapLevelSignal, BeatmapProjectManagerSignals.LoadBeatmapLevelCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveBeatmapLevelSignal, BeatmapProjectManagerSignals.SaveBeatmapLevelCommand>();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.SaveBeatmapLevelToTempSignal, BeatmapProjectManagerSignals.SaveBeatmapLevelToTempCommand>();
      this.Container.DeclareSignal<BeatmapProjectManagerSignals.BeatmapSaveFailedSignal>().OptionalSubscriber().RunAsync();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.CloseBeatmapLevelSignal, BeatmapProjectManagerSignals.CloseBeatmapLevelCommand>();
      this.Container.DeclareSignal<BeatmapProjectManagerSignals.BeatmapLevelWillCloseSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BeatmapProjectManagerSignals.LoadBeatmapLevelFromLastSaveSignal, BeatmapProjectManagerSignals.LoadBeatmapLevelFromLastSaveCommand>();
      this.Container.DeclareSignal<BeatmapDataModelSignals.BeatmapUpdatedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BeatmapProjectManagerSignals.BeatmapProjectSavedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<CopyBeatmapDifficultySignal, CopyBeatmapDifficultyCommand>();
      this.BindSignalToCommand<SetPlayHeadSignal, SetPlayHeadCommand>();
      this.BindSignalToCommand<PlayHeadControlPlaySignal, PlayHeadControlPlayCommand>();
      this.BindSignalToCommand<PlayHeadControlPauseSignal, PlayHeadControlPauseCommand>();
      this.BindSignalToCommand<PlayHeadControlStopSignal, PlayHeadControlStopCommand>();
      this.BindSignalToCommand<PlayHeadControlMoveSignal, PlayHeadControlMoveCommand>();
      this.BindSignalToCommand<PlayHeadControlReplaySignal, PlayHeadControlReplayCommand>();
      this.BindSignalToCommand<PlayHeadZoomSignal, PlayHeadZoomCommand>();
      this.BindSignalToCommand<PlayHeadUpdatePreviewSignal, PlayHeadUpdatePreviewCommand>();
      this.Container.DeclareSignal<PlayHeadUpdatedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<PlayHeadZoomedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<CurrentBpmRegionChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<SetHoverSampleSignal, SetHoverSampleCommand>();
      this.Container.DeclareSignal<HoverSampleChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BpmMoveBeatSignal, BpmMoveBeatCommand>();
      this.BindSignalToCommand<EndBpmMoveBeatSignal, EndBpmMoveBeatCommand>();
      this.Container.DeclareSignal<BpmRegionBeatsUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BpmMoveRegionsSignal, BpmMoveRegionsCommand>();
      this.BindSignalToCommand<EndBpmMoveRegionsSignal, EndBpmMoveRegionsCommand>();
      this.Container.DeclareSignal<BpmRegionsMovedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BpmSplitRegionSignal, BpmSplitRegionCommand>();
      this.Container.DeclareSignal<BpmRegionSplitSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BpmMergeRegionsSignal, BpmMergeRegionsCommand>();
      this.BindSignalToCommand<EndBpmMergeRegionsSignal, EndBpmMergeRegionsCommand>();
      this.Container.DeclareSignal<BpmRegionsMergedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<SwitchBpmToolSignal, SwitchBpmToolCommand>();
      this.Container.DeclareSignal<BpmToolSwitchedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<SwitchBpmToolSnapTypeSignal, SwitchBpmToolSnapTypeCommand>();
      this.Container.DeclareSignal<BpmToolSnapTypeSwitchedSignal>().OptionalSubscriber();
      this.Container.DeclareSignal<BpmRegionsChangedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<BpmPlaybackChangeSpeedSignal, BpmPlaybackChangeSpeedCommand>();
      this.BindSignalToCommand<BpmPlaybackChangeMetronomeVolumeSignal, BpmPlaybackChangeMetronomeVolumeCommand>();
      this.BindSignalToCommand<BpmPlaybackChangeMusicVolumeSignal, BpmPlaybackChangeMusicVolumeCommand>();
      this.BindSignalToCommand<CurrentRegionUpdateBpmSignal, CurrentRegionUpdateBpmCommand>();
      this.Container.DeclareSignal<CurrentRegionUpdatedBpmSignal>().OptionalSubscriber();
      this.BindSignalToCommand<EndCurrentRegionUpdateBpmSignal, EndCurrentRegionUpdateBpmCommand>();
      this.BindSignalToCommand<CurrentRegionUpdateBeatsSignal, CurrentRegionUpdateBeatsCommand>();
      this.BindSignalToCommand<EndCurrentRegionUpdateBeatsSignal, EndCurrentRegionUpdateBeatsCommand>();
      this.BindSignalToCommand<BpmToolOneBeatToggleSignal, BpmToolOneBeatToggleCommand>();
      this.Container.DeclareSignal<BpmToolOneBeatToggleChanged>().OptionalSubscriber();
      this.BindSignalToCommand<BpmToolStretchToggleSignal, BpmToolStretchToggleCommand>();
      this.Container.DeclareSignal<BpmToolStretchChanged>().OptionalSubscriber();
      this.Container.DeclareSignal<BpmEditorDataUpdatedSignal>().OptionalSubscriber();
      this.BindSignalToCommand<ImportMidiTempoMapSignal, ImportMidiTempoMapCommand>();
      this.BindSignalToCommand<SwitchBpmSubdivisionSignal, SwitchBpmSubdivisionCommand>();
      this.Container.DeclareSignal<BpmSubdivisionSwitchedSignal>().OptionalSubscriber();
    }

    private void BindSignalToCommand<TSignal, TCommand>() where TCommand : IBeatmapEditorCommand
    {
      this._commandContainer.BindFactory<TCommand, PlaceholderFactory<TCommand>>();
      this.Container.DeclareSignal<TSignal>().OptionalSubscriber();
      this.Container.BindSignal<TSignal>().ToMethod<BeatmapEditorCommandRunnerSignalBinder>((Func<BeatmapEditorCommandRunnerSignalBinder, Action<TSignal>>) (binder => new Action<TSignal>(binder.BindSignal<TSignal, TCommand>))).FromResolve();
    }
  }
}
