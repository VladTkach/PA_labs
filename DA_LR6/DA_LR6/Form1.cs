using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DA_LR6
{
    public partial class Form1 : Form
    {
        private int _currentPlayer = 1;
        private Map _map = new Map();

        private Button[,] _bMap;
        private int _finish;

        HardEnemmy _hardEnemmy = new HardEnemmy(2, 2);
        private bool _enemmyMakeMove = false;

        private Label _currentPlayerLable;

        private Label _bleackScore;
        private Label _whiteScore;

        private ComboBox _levels;

        private Button _restart;

        private Label _victory;

        private bool Restart = false;

        public Form1()
        {
            InitializeComponent();
            FormLoad();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Size = new Size(720, 460);
            this.MinimumSize = new Size(720, 460);
            this.MaximumSize = new Size(720, 460);
        }

        private void FormLoad()
        {
            _finish = 0;
            _bMap = new Button[_map.mapSize, _map.mapSize];
            Text = "Reversi";
            CreateMap();

            _victory = new Label();
            _victory.Location = new Point(450, 300);
            _victory.Font = new Font(_victory.Font.FontFamily, 16);
            _victory.Size = new Size(300, 100);
            Controls.Add(_victory);

            _restart = new Button();
            _restart.Text = "Restart";
            _restart.Location = new Point(450, 170);
            _restart.Click += new EventHandler(RestartGameBtn);
            Controls.Add(_restart);

            _levels = new ComboBox();
            _levels.Location = new Point(450, 110);
            _levels.Text = "Levels";
            string[] difficultyLevels = new String[] { "1", "2", "3" };
            _levels.Items.AddRange(difficultyLevels);
            _levels.SelectedIndexChanged += new EventHandler(SelectLevel);
            Controls.Add(_levels);

            _bleackScore = new Label();
            _bleackScore.Location = new Point(450, 50);
            _bleackScore.Text = "Score Black: ";
            _bleackScore.Font = new Font(_bleackScore.Font.FontFamily, 16);
            _bleackScore.Size = new Size(180, 25);
            Controls.Add(_bleackScore);

            _whiteScore = new Label();
            _whiteScore.Location = new Point(450, 80);
            _whiteScore.Text = "Score White: ";
            _whiteScore.Font = new Font(_whiteScore.Font.FontFamily, 16);
            _whiteScore.Size = new Size(180, 25);
            Controls.Add(_whiteScore);

            Label label = new Label();
            label.Location = new Point(450, 20);
            label.Text = "Current player: ";
            label.Font = new Font(label.Font.FontFamily, 16);
            label.Size = new Size(160, 25);
            Controls.Add(label);

            _currentPlayerLable = new Label();
            _currentPlayerLable.Location = new Point(610, 20);
            _currentPlayerLable.Text = _currentPlayer == 1 ? "Black" : "White";
            _currentPlayerLable.Size = new Size(100, 200);
            _currentPlayerLable.Font = new Font(_currentPlayerLable.Font.FontFamily, 16);


            Controls.Add(_currentPlayerLable);
            RefreshScore();
            StartColoringMap();
            FindPossibleMove();
        }

        public void CreateMap()
        {
            for (int i = 0; i < _map.mapSize; i++)
            {
                for (int j = 0; j < _map.mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(i * _map.cellSize, j * _map.cellSize);
                    button.Size = new Size(_map.cellSize, _map.cellSize);
                    button.Click += new EventHandler(OnPress);
                    _bMap[i, j] = button;
                    Controls.Add(button);
                }
            }
        }

        private void StartColoringMap()
        {
            _levels.Enabled = true;
            for (int i = 0; i < _map.map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.map.GetLength(1); j++)
                {
                    if (_map.map[i, j] == 1)
                    {
                        _bMap[i, j].BackColor = Color.Black;
                    }
                    else if (_map.map[i, j] == 2)
                    {
                        _bMap[i, j].BackColor = Color.White;
                    }
                    else
                    {
                        _bMap[i, j].BackColor = Color.DarkGreen;
                    }
                }
            }
        }

        public void FindPossibleMove()
        {
            bool sucsees = false;
            for (int i = 0; i < _map.mapSize; i++)
            {
                for (int j = 0; j < _map.mapSize; j++)
                {
                    if (_map.map[i, j] == _currentPlayer)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            Point point = PossibleFinder.Check(_map.map, _currentPlayer, i, j, (Direction)k);
                            if (point.X != i || point.Y != j)
                            {
                                sucsees = true;
                                _bMap[point.X, point.Y].BackColor = Color.CornflowerBlue;
                                _map.map[point.X, point.Y] = 3;
                            }
                        }
                    }
                }
            }

            if (!sucsees)
            {
                _finish++;
                if (_finish >= 2)
                {
                    VictoryOutput();
                    RestartGame();
                }
                else
                {
                    EnemyMove();
                    if (!Restart)
                        ChangeCurrentPlayer();
                }
            }
            else
            {
                _finish = 0;
            }
        }

        public void OnPress(object sender, EventArgs e)
        {
            Restart = false;

            _levels.Enabled = false;

            Button button = sender as Button;

            Point coordinates = IndexFinder.CoordinatesOf(_bMap, button);

            if (_map.map[coordinates.X, coordinates.Y] == 3 && !_enemmyMakeMove)
            {
                _enemmyMakeMove = true;
                button.BackColor = _currentPlayer == 1 ? Color.Black : Color.White;

                _map.map[coordinates.X, coordinates.Y] = _currentPlayer;

                for (int i = 0; i < 8; i++)
                {
                    if (SameFinder.Check(_map.map, _currentPlayer, coordinates.X, coordinates.Y, (Direction)i))
                    {
                        EnemyColoring.Coloring(_bMap, _map.map, _currentPlayer, coordinates.X, coordinates.Y,
                            (Direction)i);
                    }
                }

                RefreshScore();


                ClearTips();
                Sleep.sleep(1);
                ChangeCurrentPlayer();
                EnemyMove();
            }
        }

        public void EnemyMove()
        {
            int[,] newMap = Copy.Map(_map.map);
            Point? point = _hardEnemmy.nextMove(newMap);
            if (point == null)
            {
                _finish++;
            }
            else
            {
                EnemyMakeMove(point);
                ClearTips();
            }

            ChangeCurrentPlayer();
            _enemmyMakeMove = false;
            FindPossibleMove();
        }

        public void EnemyMakeMove(Point? point)
        {
            Sleep.sleep(1);
            _bMap[point.Value.X, point.Value.Y].BackColor = Color.Red;
            Sleep.sleep(1);
            _bMap[point.Value.X, point.Value.Y].BackColor = _currentPlayer == 1 ? Color.Black : Color.White;
            _map.map[point.Value.X, point.Value.Y] = _currentPlayer;

            for (int i = 0; i < 8; i++)
            {
                if (SameFinder.Check(_map.map, _currentPlayer, point.Value.X, point.Value.Y, (Direction)i))
                {
                    EnemyColoring.Coloring(_bMap, _map.map, _currentPlayer, point.Value.X, point.Value.Y,
                        (Direction)i);
                }
            }

            RefreshScore();
        }

        private void ClearTips()
        {
            for (int i = 0; i < _map.map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.map.GetLength(1); j++)
                {
                    if (_map.map[i, j] == 3)
                    {
                        _bMap[i, j].BackColor = Color.DarkGreen;
                        _map.map[i, j] = 0;
                    }
                }
            }
        }

        private void RefreshScore()
        {
            int black = Culculator.ScoreBlack(_map.map);
            int white = Culculator.ScoreWhite(_map.map);

            _bleackScore.Text = "Score Black: " + black;
            _whiteScore.Text = "Score White: " + white;
        }

        private void ChangeCurrentPlayer()
        {
            _currentPlayer = _currentPlayer == 1 ? 2 : 1;
            _currentPlayerLable.Text = _currentPlayer == 1 ? "Black" : "White";
        }

        private void SelectLevel(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedEmployee = (string)comboBox.SelectedItem;
            int resultIndex = comboBox.FindStringExact(selectedEmployee);

            Debug.WriteLine("Complexety choose: " + resultIndex);
            _hardEnemmy.ChangeComplexity(resultIndex + 1);
        }

        private void RestartGame()
        {
            _currentPlayer = 1;
            Restart = true;
            _finish = 0;

            _map.ReloadMap();
            StartColoringMap();
            RefreshScore();
            FindPossibleMove();
        }

        private void RestartGameBtn(object sender, EventArgs e)
        {
            if (!_enemmyMakeMove)
            {
                RestartGame();
            }
        }

        private void VictoryOutput()
        {
            int score = Culculator.Score(_map.map);
            if (score < 0)
            {
                _victory.Text = "Black win - restart 5s";
            }
            else if (score > 0)
            {
                _victory.Text = "White win - restart 5s";
            }
            else
            {
                _victory.Text = "Draw - restart 5s";
            }

            Sleep.sleep(5);
            _victory.Text = "";
        }
    }
}