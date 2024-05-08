using System.Windows;
using System.Windows.Controls;

namespace NaviApp.Controls;

public class ClickableTextBlock : Control
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(ClickableTextBlock),
            new PropertyMetadata(default(string)));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // Click事件
    public static readonly RoutedEvent ClickEvent =
        EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler),
            typeof(ClickableTextBlock));

    // .NET事件包装器
    public event RoutedEventHandler Click
    {
        add => AddHandler(ClickEvent, value);
        remove => RemoveHandler(ClickEvent, value);
    }

    // 增加事件触发
    protected virtual void OnClick()
    {
        var newEventArgs = new RoutedEventArgs(ClickEvent);
        RaiseEvent(newEventArgs);
    }

    // 构造函数
    static ClickableTextBlock()
    {
        // 通过覆盖元数据以实现按键调用OnClick方法
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ClickableTextBlock),
            new FrameworkPropertyMetadata(typeof(ClickableTextBlock)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        // 为整个控件添加点击事件处理程序
        MouseLeftButtonDown += (s, e) =>
        {
            OnClick(); // 触发点击事件
        };
    }
}