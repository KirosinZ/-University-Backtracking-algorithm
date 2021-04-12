using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STRIALG_BACKTRACK
{ 
    public partial class Form1 : Form
    {
        Chess position;

        public int boardsize;
        PictureBox[] squares = new PictureBox[0];
        List<PictureBox> pieces = new List<PictureBox>();
        bool[] occupied;

        public static Color LightSquare = Color.FromArgb(200, 225, 200);
        public static Color DarkSquare = Color.FromArgb(125, 155, 125);

        public static Image BlackBishop = Image.FromFile("..\\..\\Pieces\\BBishop.png");
        public static Image BlackKnight = Image.FromFile("..\\..\\Pieces\\BKnight.png");
        public static Image BlackRook = Image.FromFile("..\\..\\Pieces\\BRook.png");
        public static Image BlackQueen = Image.FromFile("..\\..\\Pieces\\BQueen.png");
        public static Image BlackEasterEgg = Image.FromFile("..\\..\\Pieces\\BEaster.png");
        public static Image WhiteRook = Image.FromFile("..\\..\\Pieces\\Wrook.png");
        public static Image WhiteQueen = Image.FromFile("..\\..\\Pieces\\WQueen.png");

        void BackTrackRook()
        {
            ClearSolution();
            for (int depth = 1; depth <= occupied.Length - pieces.Count;depth++)
            {
                if (TryRook(0, 1, depth))
                {
                    foreach (int r in position.AllyIndices)
                    {
                        AddPiece(r, WhiteRook);
                    }
                    return;
                }
            }

            MessageBox.Show(this, "Нет решения для ладьи", "Нет решений", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool TryRook(int startindex, int number, int depth)
        {
            for (int i=startindex; i<occupied.Length - depth + number; i++)
            {
                if (!occupied[i])
                {
                    position.AllyIndices.Add(i);
                    if (position.ValidateRooks() || number < depth && TryRook(i + 1, number + 1, depth)) return true;
                    position.AllyIndices.Remove(i);
                }
            }
            return false;
        }

        void BackTrackQueen()
        {
            ClearSolution();
            for (int depth = 1; depth <= occupied.Length - pieces.Count; depth++)
            {
                if (TryQueen(0, 1, depth))
                {
                    foreach (int r in position.AllyIndices)
                    {
                        AddPiece(r, WhiteQueen);
                    }
                    return;
                }
            }

            MessageBox.Show(this, "Нет решения для ферзя", "Нет решений", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool TryQueen(int startindex, int number, int depth)
        {
            for (int i = startindex; i < occupied.Length - depth + number; i++)
            {
                if (!occupied[i])
                {
                    position.AllyIndices.Add(i);
                    if (position.ValidateQueens() || number < depth && TryQueen(i + 1, number + 1, depth)) return true;
                    position.AllyIndices.Remove(i);
                }
            }
            return false;
        }

        void CreateBoard()
        {
            var tmp = new SizePicker("Создание доски", "Введите размер доски", 2, 20);
            if (tmp.ShowDialog(this) == DialogResult.OK)
            {
                DisposeBoard();
                AssembleBoard(tmp.Result);
            }
        }

        void AssembleBoard(int size)
        {
            BackTrackStrip.Enabled = true;
            position = new Chess(size);

            boardsize = size;
            occupied = new bool[size * size];
            squares = new PictureBox[size * size];

            for (int i = 0; i < size * size; i++)
            {
                int picsize = BoardBox.Width / size;
                int x = i % size;
                int y = i / size;
                squares[i] = new PictureBox()
                {
                    Parent = BoardBox,
                    Location = new Point(x * picsize, y * picsize),
                    Height = picsize,
                    Width = picsize,
                    BackColor = (x + y) % 2 == 0 ? LightSquare : DarkSquare
                };

                squares[i].Click += (ob, ev) => PutEnemy(ob);
            }
        }

        void DisposeBoard()
        {
            foreach (var item in squares)
            {
                item.Dispose();
            }
            pieces?.Clear();
            position?.Clear();
        }

        void ClearSolution()
        {
            foreach(var item in position.AllyIndices)
            {
                RemovePiece(item);
            }
        }

        void PutEnemy(object sender)
        {
            if (!(sender is PictureBox pic)) throw new Exception("Событие не может вызываться объектом, не являющимся PictureBox");

            int x = pic.Location.X / pic.Width;
            int y = pic.Location.Y / pic.Width;

            int index = y * boardsize + x;

            AddEnemy(index);
        }

        void AddPiece(int index, Image img)
        {
            if (!occupied[index])
            {
                int picsize = squares[index].Width;
                var tmp = new PictureBox()
                {
                    Parent = squares[index],
                    Location = new Point(0, 0),
                    Height = picsize,
                    Width = picsize,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = img
                };
                tmp.BringToFront();
                tmp.Click += (ob, ev) => DeletePiece(ob);

                pieces.Add(tmp);
                occupied[index] = true;
            }
        }

        void AddEnemy(int index)
        {
            Image img;
            Random rand = new Random();
            if (rand.Next(0, 21) == 0) img = BlackEasterEgg;
            else switch (rand.Next(0, 4))
                {
                    case 0: img = BlackKnight; break;
                    case 1: img = BlackBishop; break;
                    case 2: img = BlackQueen; break;
                    case 3: img = BlackRook; break;
                    default: img = null; break;
                }
            AddPiece(index, img);
            position.EnemyIndices.Add(index);
        }

        void AddQueen(int index)
        {
            AddPiece(index, WhiteQueen);
            position.AllyIndices.Add(index);
        }

        void AddRook(int index)
        {
            AddPiece(index, WhiteRook);
            position.AllyIndices.Add(index);
        }

        void DeletePiece(object sender)
        {
            if (!(sender is PictureBox pic)) throw new Exception("Событие не может вызываться объектом, не являющимся PictureBox");

            int index = pic.Parent.Location.Y / pic.Width * boardsize + pic.Parent.Location.X / pic.Width;

            RemovePiece(index);
        }

        void RemovePiece(int index)
        {
            var piece = squares[index].Controls[0] as PictureBox;
            pieces.Remove(piece);
            piece.Dispose();
            position.AllyIndices.Remove(index); position.EnemyIndices.Remove(index);
            occupied[index] = false;
        }


        public Form1()
        {
            InitializeComponent();

            CreateBoardStrip.Click += (o, e) => CreateBoard();

            RookBackTrackStrip.Click += (ob, ev) => BackTrackRook();
            QueenBackTrackStrip.Click += (ob, ev) => BackTrackQueen();
        }
    }

    public class Chess
    {
        public int Size { get; private set; }
        public SortedUniqueIntList EnemyIndices { get; set; } = new SortedUniqueIntList();
        public SortedUniqueIntList AllyIndices { get; set; } = new SortedUniqueIntList();

        public Chess(int size)
        {
            Size = size;
        }

        public void Clear()
        {
            EnemyIndices.Clear();
            AllyIndices.Clear();
        }

        int FileNumber(int index) => index % Size;

        int RankNumber(int index) => index / Size;

        int MainDiagonalNumber(int index) => index / Size - index % Size;

        int AuxDiagonalNumber(int index) => index % Size + index / Size;

        public bool ValidateQueens()
        {
            if (EnemyIndices.IsEmpty) return true;

            SortedUniqueIntList enemies;
            SortedUniqueIntList threatened = new SortedUniqueIntList();
            int tmp;
            foreach (int q in AllyIndices)
            {
                enemies = EnemyIndices.Where(en => FileNumber(en) == FileNumber(q)).ToSortedUniqueList();
                tmp = enemies.First(en => RankNumber(en) > RankNumber(q));
                if (tmp != -1) threatened.Add(tmp);
                tmp = enemies.Last(en => RankNumber(en) < RankNumber(q));
                if (tmp != -1) threatened.Add(tmp);

                if (threatened == EnemyIndices) return true;

                enemies = EnemyIndices.Where(en => RankNumber(en) == RankNumber(q)).ToSortedUniqueList();
                tmp = enemies.First(en => FileNumber(en) > FileNumber(q));
                if (tmp != -1) threatened.Add(tmp);
                tmp = enemies.Last(en => FileNumber(en) < FileNumber(q));
                if (tmp != -1) threatened.Add(tmp);

                if (threatened == EnemyIndices) return true;

                enemies = EnemyIndices.Where(en => MainDiagonalNumber(en) == MainDiagonalNumber(q)).ToSortedUniqueList();
                tmp = enemies.First(en => AuxDiagonalNumber(en) > AuxDiagonalNumber(q));
                if (tmp != -1) threatened.Add(tmp);
                tmp = enemies.Last(en => AuxDiagonalNumber(en) < AuxDiagonalNumber(q));
                if (tmp != -1) threatened.Add(tmp);

                if (threatened == EnemyIndices) return true;

                enemies = EnemyIndices.Where(en => AuxDiagonalNumber(en) == AuxDiagonalNumber(q)).ToSortedUniqueList();
                tmp = enemies.First(en => MainDiagonalNumber(en) > MainDiagonalNumber(q));
                if (tmp != -1) threatened.Add(tmp);
                tmp = enemies.Last(en => MainDiagonalNumber(en) < MainDiagonalNumber(q));
                if (tmp != -1) threatened.Add(tmp);

                if (threatened == EnemyIndices) return true;
            }
            return false;
        }

        public bool ValidateRooks()
        {
            if (EnemyIndices.IsEmpty) return true;

            SortedUniqueIntList enemies;
            SortedUniqueIntList threatened = new SortedUniqueIntList();
            int tmp;
            foreach (int r in AllyIndices)
            {
                enemies = EnemyIndices.Where(en => FileNumber(en) == FileNumber(r)).ToSortedUniqueList();
                tmp = enemies.First(en => RankNumber(en) > RankNumber(r));
                if (tmp != -1) threatened.Add(tmp);
                tmp = enemies.Last(en => RankNumber(en) < RankNumber(r));
                if (tmp != -1) threatened.Add(tmp);

                if (threatened == EnemyIndices) return true;

                enemies = EnemyIndices.Where(en => RankNumber(en) == RankNumber(r)).ToSortedUniqueList();
                tmp = enemies.First(en => FileNumber(en) > FileNumber(r));
                if (tmp != -1) threatened.Add(tmp);
                tmp = enemies.Last(en => FileNumber(en) < FileNumber(r));
                if (tmp != -1) threatened.Add(tmp);

                if (threatened == EnemyIndices) return true;
            }
            return false;
        }
    }
}
