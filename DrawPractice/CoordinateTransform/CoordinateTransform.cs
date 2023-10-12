using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DrawPractice
{
    public class CoordinateTransform
    {
        public static float[][] CT(float x, float y)
        {
            float[][] origin = MatrixCreate(1,2);
            origin[1][1] = x;
            origin[1][2] = y;
            float[][] transform1 = MatrixCreate(2,2);
            transform1[1][1] = 1;
            transform1[2][1] = 0;
            transform1[1][2] = 0;
            transform1[2][2] = -1;
            float[][] result = MatrixCreate(1,2);
            result = MatrixProduct(origin, transform1);
            return result;
        }
        public static float[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s
            // do error checking here?
            float[][] result = new float[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new float[cols]; // auto init to 0.0
            return result;
        }
        public static float[][] MatrixProduct(float[][] matrixA,float[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
            float[][] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];
            return result;
        }
    }
}
