using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Codex
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public class GameViewModel : INotifyPropertyChanged
    {
        // 属性定义
        private string _actionPoints;
        public string ActionPoints
        {
            get => _actionPoints;
            set => SetField(ref _actionPoints, value);
        }

        private string _balancePoints;
        public string BalancePoints
        {
            get => _balancePoints;
            set => SetField(ref _balancePoints, value);
        }

        private string _playerHealth;
        public string PlayerHealth
        {
            get => _playerHealth;
            set => SetField(ref _playerHealth, value);
        }

        private string _enemyHealth;
        public string EnemyHealth
        {
            get => _enemyHealth;
            set => SetField(ref _enemyHealth, value);
        }

        private string _distance;
        public string Distance
        {
            get => _distance;
            set => SetField(ref _distance, value);
        }

        private ObservableCollection<Skill> _skills;
        public ObservableCollection<Skill> Skills
        {
            get => _skills;
            set => SetField(ref _skills, value);
        }

        private ObservableCollection<string> _handCards;
        public ObservableCollection<string> HandCards
        {
            get => _handCards;
            set => SetField(ref _handCards, value);
        }

        private string _playerPosition;
        public string PlayerPosition
        {
            get => _playerPosition;
            set => SetField(ref _playerPosition, value);
        }

        private Thickness _playerPositionMargin;
        public Thickness PlayerPositionMargin
        {
            get => _playerPositionMargin;
            set => SetField(ref _playerPositionMargin, value);
        }

        private string _enemyPosition;
        public string EnemyPosition
        {
            get => _enemyPosition;
            set => SetField(ref _enemyPosition, value);
        }

        private Thickness _enemyPositionMargin;
        public Thickness EnemyPositionMargin
        {
            get => _enemyPositionMargin;
            set => SetField(ref _enemyPositionMargin, value);
        }

        // 初始化方法
        public GameViewModel()
        {
            // 设置初始值
            ActionPoints = "12/12";
            BalancePoints = "3/3";
            PlayerHealth = "40";
            EnemyHealth = "40";
            Distance = "5";

            // 初始化战技列表
            Skills = new ObservableCollection<Skill>
            {
                new Skill { Name = "直冲", Type = "拳", DistanceRange = "1-2", Damage = "2", Description = "前置效果:可向前一步;后续效果:击退一步，抽一张牌" },
                new Skill { Name = "钩拳", Type = "拳", DistanceRange = "1-2", Damage = "2", Description = "前置效果:可向前一步;后续效果:击退一步" }
            };

            // 初始化手牌
            HandCards = new ObservableCollection<string> { "5", "A", "7", "3", "8", "K" };

            // 设置初始位置
            SetPositions(playerIndex: 4, enemyIndex: 8); // 示例位置
        }

        // 设置玩家和敌人位置的方法
        public void SetPositions(int playerIndex, int enemyIndex)
        {
            PlayerPosition = playerIndex.ToString();
            EnemyPosition = enemyIndex.ToString();

            // 计算Margin (这里假设每个格子80x80像素)
            PlayerPositionMargin = CalculatePositionMargin(playerIndex);
            EnemyPositionMargin = CalculatePositionMargin(enemyIndex);
        }

        private Thickness CalculatePositionMargin(int index)
        {
            // 9宫格布局计算位置
            int row = index / 3;
            int col = index % 3;

            // 假设战场区域大小为 270x270 (9个90x90格子)
            double left = col * 90 + 20; // 20为初始偏移
            double top = row * 90 + 20;

            return new Thickness(left, top, 0, 0);
        }

        // INotifyPropertyChanged实现
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    // 战技模型类
    public class Skill
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DistanceRange { get; set; }
        public string Damage { get; set; }
        public string Description { get; set; }
    }
    public partial class MainWindow : Window
    {
        static void distant()
        {
        }
        public MainWindow()
        {

            //InitializeComponent();
        }
    }
}
