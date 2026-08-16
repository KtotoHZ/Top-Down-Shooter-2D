# 🎯 Top Down Shooter

![Unity](https://img.shields.io/badge/Unity-2022.3_LTS-000000?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-9.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

![Zenject](https://img.shields.io/badge/DI-Zenject_%2F_Extenject-brightgreen?style=flat-square)
![UniTask](https://img.shields.io/badge/Async-UniTask-orange?style=flat-square)
![SignalBus](https://img.shields.io/badge/Events-SignalBus-teal?style=flat-square)
![Pooling](https://img.shields.io/badge/Perf-Object_Pooling-red?style=flat-square)
![ScriptableObject](https://img.shields.io/badge/Data-ScriptableObject-blue?style=flat-square)
![Event-Driven](https://img.shields.io/badge/Arch-Event--Driven-purple?style=flat-square)

<!-- Замени на GIF или видео с геймплеем -->
![Gameplay](Docs/GamePlay_1.gif)

> Пет-проект top-down shooter на Unity.
Цель проекта — продемонстрировать навыки проектирования игровой архитектуры, работы с DI, событийной системой, пулом объектов, ScriptableObject, асинхронными операциями и разделением ответственности между системами.

## ⚡ Что внутри

- 🧍 Игрок: движение, прицел мышью, урон, смерть
- 🔫 Оружие: огнестрел и ближний бой, переключение
- 🎒 Обобщённый инвентарь `Inventory<T>`
- 👾 Враги: ближний и дальний бой, волны, асинхронный спавн
- ♻️ Пул объектов для пуль и частиц, асинхронная инициализация пула без фризов
- 🎥 Камера: плавное следование + тряска
- ❤️ UI: HP-бар, инвентарь, экран смерти

## 🧠 Ключевые решения

- **Zenject** — инсталлеры здоровья, ввода, инвентаря, пулов и сигналов
- **`HealthSystem`** — чистый C#-класс с `IHealth`, переиспользуется игроком и врагами
- **Интерфейсы** (`IWeapon`, `IEnemy`, `ITakeDamage`, `IInputPlayer`…)
- **События + SignalBus** — анимации, частицы, тряска камеры и UI реагируют без прямых ссылок
- **Object Pool** — в игре, меньше GC-пиков
- **`WeaponData` (ScriptableObject)** — урон, кулдаун и иконки настраиваются без кода

## 🎮 Управление

| Действие | Клавиша |
|---|---|
| Движение | `WASD` |
| Прицел | Мышь |
| Атака | ЛКМ |
| Альт. атака | ПКМ |
| Смена оружия | Колесо / `1`–`9` |

Управление реализовано через интерфейс IInputPlayer, что позволяет добавлять новое управление под разные платформы.

## 🚀 Запуск

1. `git clone https://github.com/KtotoHZ/Top-Down-Shooter-2D`
2. Открыть в **Unity Hub** (2022.3 LTS+)
3. Возможно потребуется поставить [Extenject](https://github.com/Mathijs-Bakker/Extenject) и [UniTask](https://github.com/Cysharp/UniTask)
4. Открыть сцену (Assets\Project\Scenes\Level_1) и нажать **Play**

## 📫 Контакты

**Никита Тронь** — [GitHub](https://github.com/KtotoHZ) · [Telegram](https://t.me/NICK) · [Email](tron.nick@yandex.ru)

---
