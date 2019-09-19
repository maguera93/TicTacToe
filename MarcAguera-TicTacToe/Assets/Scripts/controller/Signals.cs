using UnityEngine;
using strange.extensions.signal.impl;
using strange.extensions.pool.api;

public class StartSignal : Signal{};
public class ClickedCellSignal : Signal<Vector2Int>{ };
public class MarkCellSignal : Signal<bool, Vector2Int> { };
public class MenuSignal : Signal { };
public class GameOverSignal : Signal<string> {};
public class EnemyAISignal : Signal {};
public class ResetSignal : Signal {};
public class WebServiceSignalStart : Signal { };
public class SpawnCellsSignal : Signal<GameObject> { };
