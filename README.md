# Space Defender

**Space Defender** is a 2D Tower Defense game developed with **Unity** and **C#**. Players place towers on fixed platforms, manage coins, and choose the right defense to stop enemy waves from reaching the base. Enemies follow a path made of waypoints.

The game focuses on a simple gameplay loop that can be extended with data. Players win by completing all waves and must protect the base from losing all its health.

## Game Links

- **Play on itch.io:** [PLAY GAME](https://hoangdn1908.itch.io/space-defender)
- **Gameplay Video:** [WATCH GAME PLAY](https://www.youtube.com/watch?v=_UwyfFQEHTo)

## My Contributions

I led the game's development, defined its concept, and made the final gameplay and system design decisions.

The art and audio were created by external creators.[Asset Credits](https://www.youtube.com/redirect?event=video_description&redir_token=QUZZTVljSEZjczFGLTluVVB5WUtQaDE4MV9COHxBSTVJdTV0Vm5aa0NndDVITjZySGozM0JwRHhtX3oyRGtCLWE1NUE4NmlZRGZEQlZPVUNkTHBBTVlNNDRjVzlmeUlhRG5qRDJFNV9ZU0FvNjBJdUNGMGNJUmJYTkpfWTFsQUR4&q=https%3A%2F%2Fwww.frankslaboratory.co.uk%2Fdownloads%2F11%2F11_resources.zip&v=py_TyP0tQN8).

## Gameplay Screenshots

![Gameplay Level 1](Screenshots/Level1.png)

| Main Menu | Level 2 | Level 3 |
|---|---|---|
| ![Main Menu](Screenshots/Menu.png) | ![Gameplay Level 2](Screenshots/Level2.png) | ![Gameplay Level 3](Screenshots/Level3.png) |

## About the Game

Each level has several enemy waves with different enemies and spawn times. Enemies follow a fixed path. If they reach the end, they damage the base. When players defeat enemies, they earn coins. They can use these coins to build more towers and prepare for the next waves.

**Gameplay Loop**

1. Choose an empty platform on the map.
2. Buy a tower with the available coins.
3. The tower finds enemies in its range and fires projectiles automatically.
4. Earn coins from defeated enemies and improve the defense until all waves are completed or the base is destroyed.

## Gameplay Features

- Build towers on fixed platforms. The game checks if a platform is empty and if the player has enough coins.
- Towers find enemies within their range and attack based on their own fire rate and damage settings.
- Multiple enemy waves with different `SpawnGroup` settings, including enemy count, group delay, and spawn interval.
- Enemies follow waypoints, give coins when defeated, and damage the base when they reach the goal.
- UI displays base health, coins, and wave progress. The game also supports pause, win, lose, restart, and next-level features.
- Sound effects for UI actions and gameplay events, such as building towers, spawning enemies, shooting, pausing, winning, and losing.

## Technical Highlights

### 1. Data-Driven Gameplay with ScriptableObject

Game data is separated from gameplay logic. This allows me to change settings in the Unity Inspector without changing the main gameplay code.

- `EnemyData` stores enemy speed, health, damage, coin reward, sprite, and enemy type.
- `TowerData` stores tower cost, detection range, fire rate, projectile settings, and tower image.
- `PlayerData` stores starting health and coins. `GameModeData` contains wave data, while `TowerDatabase` provides tower data for the tower card UI.
- Each `WaveData` contains several `SpawnGroup` objects. `WaveController` reads this data with coroutines and spawns each group in order. It starts the next wave only when no enemies are active.

This system allows me to change enemy types, spawn times, and level difficulty through assets in `Assets/ScriptableObject/` without changing the main spawning logic.

**Problem and approach:** With several tower and enemy types, setting up each one separately would take time and make their values harder to manage. I stored their stats and visuals in ScriptableObject data assets, which reusable prefabs and components read to configure each object. I can now adjust a type through its data asset instead of editing individual objects. Variants that share the same behavior can reuse the existing code.

### 2. Component-Based Architecture

Enemies, towers, and projectiles use separate components for different tasks instead of putting all behavior in one class.

- `EnemyController` prepares enemy data before spawning and works with `EnemyMovement`, `EnemyHealth`, `EnemyVisual`, and `EnemyLive`.
- `TowerController` works with `TowerDetect`, `TowerShoot`, and `TowerVisual` to find targets, control shooting, and update the tower's appearance using `TowerData`.
- `ProjectileController` works with `ProjectileShoot`, `ProjectileDamage`, `ProjectileSize`, and `ProjectileLive` to control movement, damage, size, and lifetime.

This structure keeps tasks such as movement, health, target detection, and object lifetime separate. It also makes the code easier to read and update when adding new enemy or tower types.

**Problem and approach:** Putting every responsibility in one script would make it long, difficult to read, and harder to change. I split the behavior into smaller scripts with specific jobs and used controllers to coordinate them. This makes it easier to find the code for a feature and limits how much unrelated code I need to change when extending it.

### 3. Event-Driven Communication

`GameEvents` is a central place for gameplay events, such as platform and tower selection, enemy spawning and death, base damage, coin and health changes, wave updates, and game results.

Systems send events through `Raise...` methods. The UI, player, and `GameManager` listen for these events in `OnEnable()` and stop listening in `OnDisable()`.

For example, building a tower follows this flow:

```mermaid
flowchart LR
    PlatformController -->|OnPlatformSelected| TowerUI
    TowerCard -->|OnTowerSelected| TowerBuildManager
    TowerBuildManager -->|TryBuyTower| PlayerWallet
    TowerBuildManager --> TowerSpawner
    TowerBuildManager -->|OnTowerBuilt| PlatformLive
```

`TowerBuildManager` only creates a tower after checking that the platform is empty and `PlayerWallet.TryBuyTower()` succeeds. Using events means the UI does not need direct references to gameplay controllers.

**Learning goal and approach:** I wanted to practice keeping gameplay and UI updates organized without making every system call every other system directly. Events let a system announce a change, such as a new coin balance, while interested UI components respond to it. This reduces direct references in these interactions. The project still uses direct calls and singleton references for operations such as purchasing towers and changing state UI; these dependencies remain in the current implementation.

### 4. Game State Machine

`GameManager` controls the `GameStateMachine`, which has four states: `PlayingState`, `PauseState`, `WinState`, and `LoseState`.

`GameStateMachine.ChangeState()` calls `Exit()` on the current state before calling `Enter()` on the new state.

- `PlayingState` allows the game to continue and hides the state UI.
- `PauseState`, `WinState`, and `LoseState` stop gameplay by setting `Time.timeScale = 0` and show the correct panel.
- `GameManager` changes states when it receives `OnGameWin` or `OnGameLose`, or when the player presses `Escape` during gameplay.

This system separates game state logic from the UI and helps prevent gameplay from continuing behind the pause, win, or lose screens.

**Learning goal and approach:** I wanted to make the game's different modes easier to follow and maintain. I organized the behavior for entering and leaving Playing, Pause, Win, and Lose into separate states. This gives each mode a clear place in the code and makes it easier to understand what happens when the game changes state.

### 5. Object Pooling for Enemies and Projectiles

`ObjectPool` stores pre-created prefabs in a `Queue<GameObject>`. When an object is needed, `EnemySpawner` or `TowerShoot` gets it by calling `GetFromPool()`. When an enemy is defeated or reaches the goal, or when a projectile reaches the end of its lifetime, the object is returned by calling `ReturnToPool()`.

`EnemyLive` and `ProjectileLive` control when objects are returned. `EnemySpawner` selects the correct pool based on `EnemyType`.

The pool can create more objects when the queue is empty. It also uses a `HashSet<GameObject>` to help prevent the same object from being returned more than once. This is useful for enemies and projectiles that are created and reused many times during a game.

**Problem and approach:** Repeated enemy waves and multiple firing towers require many enemies and projectiles to appear and disappear. To reduce the overhead of repeatedly creating and destroying them, I used pools that keep inactive objects ready for reuse. The goal was to reduce gameplay stuttering by reducing repeated Instantiate/Destroy calls.

## Controls

| Action | Function |
|---|---|
| Click an empty platform | Select a place to build a tower |
| Click a tower card | Buy and build a tower if there are enough coins |
| `Escape` | Pause the game during gameplay |
| Speed button | Change `Time.timeScale` |
| `Resume` / `Restart` / `Main Menu` | Continue, restart, or return to the main menu |
| `Next Level` | Go to the next level after winning |

