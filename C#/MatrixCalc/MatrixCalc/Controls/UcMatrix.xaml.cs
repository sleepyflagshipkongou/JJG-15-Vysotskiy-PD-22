using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MatrixCalc.Controls
{
    /// <summary>
    /// Логика взаимодействия для UcMatrix.xaml
    /// </summary>
    public partial class UcMatrix
    {
        public UcMatrix()
        {
            InitializeComponent();
            MatrixSize = 3;
            InitMatrix();
        }

        public bool IsReadOnly
        {
            set
            {
                    isReadOnly = value;
                ButtonsVisible = !isReadOnly;

            }
        }
        public bool ButtonsVisible
        {
            set
            {
                if (!value) PnlButtons.Visibility = Visibility.Hidden;
            }
        }

        public float[,] Matrix
        {
            get
            {
                GetMatrix();
                return matrix;
            }
            set
            {
                matrix = value;
                SetMatrix();
            }
        }

        public float[,] InverseMatrix
        {
            get { return inverseMatrix; }
        }

     

        public int MatrixSize { set; get; }

        public float? Determinant
        {
            get { return determinant; }
        }
        

        public string MatrixHeader
        {
            get { return TbxHeader.Text; }
            set { TbxHeader.Text = value; }
        }

        private float? determinant;
        private float[,] matrix;
        private float[,] inverseMatrix;
        private TextBox[,] Tbx;
        public event EventHandler CellChanged;
        public event EventHandler MatrixSizeChanged;
        private bool buttonsVisible;
        private bool isReadOnly = false;
        private bool isInitialize = false;
        


        

        private void GridMatrixClear(Grid grid)
        {
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
            grid.Children.Clear();
        }
        
        public void InitMatrix()
        {
            isInitialize = true;
            GridMatrixClear(GrdMatrix);
            Tbx = new TextBox[MatrixSize, MatrixSize];
            matrix = new float[MatrixSize, MatrixSize];
            determinant = null;
            for (var i = 0; i < MatrixSize; i++)
            {
               
                GrdMatrix.ColumnDefinitions.Add(new ColumnDefinition() {MinWidth = 25});
            }
            for (var i = 0; i < MatrixSize; i++)
                GrdMatrix.RowDefinitions.Add(new RowDefinition());

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    var brdStyle = new Style();
                    brdStyle.Setters.Add(new Setter()
                    {
                        Property = BorderThicknessProperty,
                        Value = new Thickness(j == 0 ? 0 : 0.5, i == 0 ? 0 : 0.5, 0, 0)
                    });
                    brdStyle.Setters.Add(new Setter()
                    {
                        Property = BorderBrushProperty,
                        Value = new SolidColorBrush(Colors.DeepSkyBlue)
                    });

                    Tbx[i, j] = new TextBox();

                    var tbxStyle = new Style();

                    tbxStyle.Setters.Add(new Setter()
                    {
                        Property = BorderThicknessProperty,
                        Value = new Thickness(0)
                    });
                    tbxStyle.Setters.Add(new Setter()
                    {
                        Property = BackgroundProperty,
                        Value = new SolidColorBrush(Colors.Transparent)
                    });

                    tbxStyle.Setters.Add(new Setter()
                    {
                        Property = VerticalAlignmentProperty,
                        Value = VerticalAlignment.Center
                    });
                    
                    tbxStyle.Setters.Add(new Setter()
                    {
                        Property = HorizontalContentAlignmentProperty,
                        Value = HorizontalAlignment.Center
                    });
                    tbxStyle.Setters.Add(new Setter()
                    {
                        Property = HorizontalAlignmentProperty,
                        Value = HorizontalAlignment.Center
                    });
                    Tbx[i, j].MinWidth = 35;
                    Tbx[i, j].MinHeight = 25;
                    Tbx[i,j].VerticalContentAlignment = VerticalAlignment.Center;
                    Tbx[i, j].FontWeight = FontWeights.Bold;
                    Tbx[i, j].Style = tbxStyle;
                    Tbx[i, j].KeyDown += new KeyEventHandler(TbxKeyDown);
                    Tbx[i,j].PreviewTextInput += new TextCompositionEventHandler(TbxInputNumberFloat);
                    Tbx[i,j].TextChanged += new TextChangedEventHandler(TbxTextChanged);
                    var brd = new Border
                    {
                        Child = Tbx[i, j],
                        Style = brdStyle
                    };
                    GrdMatrix.Children.Add(brd);
                    Grid.SetRow(brd,i);
                    Grid.SetColumn(brd, j);
                }

            }
            isInitialize = false;
            if (CellChanged != null)
                CellChanged(this, EventArgs.Empty);
        

    

        }
        private static void TbxKeyDown(object sender, KeyEventArgs e)
        {
            // Запрет клавиши пробел, которая не генерирует событие PreviewTextlnput.
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private static void TbxInputNumberFloat(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            var tb = textBox.Text;

            var key = e.Text[0];
            if (key == '-') tb = key + tb;
            else tb += key;
            var isAllowed = false;
            try
            {
                if (tb != "-")
                {
                    var d = Convert.ToDouble(tb);
                }
                isAllowed = true;
            }
            catch
            {
                //
            }


            e.Handled = !isAllowed;
        }

        private void TbxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (isReadOnly||isInitialize) return;
            
            determinant = null;
            determinant = MatrixFunctions.CalcDeterminant(MatrixSize, Matrix);
            if ((determinant == 0) || (determinant == null))
                inverseMatrix = null;
            else inverseMatrix = MatrixFunctions.CalcInverseMatrix(MatrixSize, (float)determinant, Matrix);

            if (CellChanged != null)
                CellChanged(this, EventArgs.Empty);
        }


        private void ButtonMatrixSizeDec_OnClick(object sender, RoutedEventArgs e)
        {
            if (MatrixSize<2) return;
            MatrixSize--;

            InitMatrix();
            if (MatrixSizeChanged != null)
                MatrixSizeChanged(this, EventArgs.Empty);
        }

        private void ButtonMatrixSizeInc_OnClick(object sender, RoutedEventArgs e)
        {
            if (MatrixSize>10) return;
            MatrixSize++;
            InitMatrix();
            if (MatrixSizeChanged != null)
                MatrixSizeChanged(this, EventArgs.Empty);
        }
        
        private void GetMatrix()
        {
            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    try
                    {
                        matrix[i, j] = float.Parse(Tbx[i, j].Text);
                    }
                    catch (Exception)
                    {
                        matrix[i, j] = 0;
                    }
                    
                }
                
            }
        }

        private void SetMatrix()
        {
           
            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    try
                    {
                            Tbx[i, j].Text = string.Format("{0:N2}", matrix[i, j]); 
                    }
                    catch (Exception)
                    {
                        Tbx[i, j].Text = ""; 
                    }
                    
                }
            }
        }
    }
}
