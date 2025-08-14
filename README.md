# GhostMovementSystem
Framewors:
1. VContainer,
2. R3,
3. UniTask,
4. Addressable

Patterns:
1. DI Container (Parent & Child Scope),
2. EntryPoint,
3. MVVM,
4. Persistent & OnDemandLoading UI,
5. State(FSM)

Инструкция:
1. Ассеты загружаеются удалённо с помощью Addressable, экрана загрузки нет, поэтому нужно немного подождать.
2. Чтобы поменять режим уровня, на UI предоставленны кнопки. В процессе игры изменить состояние уровня не удастся.
3. Чтобы выйти из приложения, закройте с помощью диспетчера задач.
