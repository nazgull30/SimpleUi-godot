namespace SimpleUi.Src;

using Godot;
using TextAndQuest.Game.Ui;
using VContainer.Unity;

public partial class EntryPoint : Node, IInitializable
{
    public void Initialize()
    {
        Ui.OpenWindow<GameMainScreenWindow>();
    }
}
