namespace TextAndQuest.Game.Ui;

using SimpleUi;

public class GameMainScreenWindow : WindowBase
{
    public override string Name => "GameMainScreen";

    protected override void AddControllers()
    {
        AddController<SimpleUiController>();
    }
}
