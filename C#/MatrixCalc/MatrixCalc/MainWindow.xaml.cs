using System;
using System.Windows;

namespace MatrixCalc
{
    /// Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MatrixA_OnCellChanged(object sender, EventArgs e)
        {
            if (MatrixA.Determinant == null)
            {
                TbxDeterminant.Text = " Non ";
                MatrixInverseA.Matrix = null;
                return;
            }
            TbxDeterminant.Text = string.Format("{0:N2}", MatrixA.Determinant);
            MatrixInverseA.Matrix = MatrixA.InverseMatrix;

            if (MatrixA.MatrixSize != MatrixB.MatrixSize) return;
            CalcMatrix();
        }

        private void MatrixB_OnCellChanged(object sender, EventArgs e)
        {
            if (MatrixB.Determinant == null)
            {
                TbxDeterminantB.Text = " Non ";
                MatrixInverseB.Matrix = null;
                return;
            }
            TbxDeterminantB.Text = string.Format("{0:N2}", MatrixB.Determinant);
            MatrixInverseB.Matrix = MatrixB.InverseMatrix;
            if (MatrixA.MatrixSize == MatrixB.MatrixSize)
            CalcMatrix();
        }

        private void MatrixA_OnMatrixSizeChanged(object sender, EventArgs e)
        {
            MatrixInverseA.MatrixSize = MatrixA.MatrixSize;
            MatrixInverseA.InitMatrix();
            InitMatrixResults();
        }

        private void MatrixB_OnMatrixSizeChanged(object sender, EventArgs e)
        {
            MatrixInverseB.MatrixSize = MatrixB.MatrixSize;
            MatrixInverseB.InitMatrix();

            InitMatrixResults();

        }

        private void InitMatrixResults()
        {
            MatrixSum.Visibility = Visibility.Collapsed;
            if (MatrixA.MatrixSize == MatrixB.MatrixSize)
            {
                MatrixSum.Visibility = Visibility.Visible;
                MatrixSum.MatrixSize = MatrixA.MatrixSize;
                MatrixSum.InitMatrix();

                
                MatrixDif.MatrixSize = MatrixA.MatrixSize;
                MatrixDif.InitMatrix();

                MatrixMul.MatrixSize = MatrixA.MatrixSize;
                MatrixMul.InitMatrix();
                
            }
        }

        private void CalcMatrix()
        {
            MatrixSum.Matrix = MatrixFunctions.GetMatrixSum(MatrixA.MatrixSize, MatrixA.Matrix, MatrixB.Matrix);
            MatrixDif.Matrix = MatrixFunctions.GetMatrixDif(MatrixA.MatrixSize, MatrixA.Matrix, MatrixB.Matrix);
            MatrixMul.Matrix = MatrixFunctions.GetMatrixMul(MatrixA.MatrixSize, MatrixA.Matrix, MatrixB.Matrix);
        }
    }
}
