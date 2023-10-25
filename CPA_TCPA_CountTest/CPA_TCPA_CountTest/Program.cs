using System;


class Program
{
    

    static void Main()
    {
        double x1 = -5965.4071;
        double y1 = 11567.126;
        double hDirection = -(271.295) + 90 + 360;
        hDirection = 90-hDirection;
        double x2 = -7626.07;
        double y2 = 11698.26;
        //double vx = -2.361;
        //double vy = -0.004;

        double dx = x2 - x1;
        double dy = y2 - y1;
        float[][] result = MatrixCreate(1, 2);
        float[][] transfromMatrix = MatrixCreate(2, 2);
        result[0][0] = (float)dx;
        result[0][1] = (float)dy;
        transfromMatrix[0][0] = (float)Math.Cos((hDirection / 360) * 2 * Math.PI);
        transfromMatrix[0][1] = (float)Math.Sin((hDirection / 360) * 2 * Math.PI)*-1f;
        transfromMatrix[1][0] = (float)Math.Sin((hDirection / 360) * 2 * Math.PI);
        transfromMatrix[1][1] = (float)Math.Cos((hDirection / 360) * 2 * Math.PI);
        result = MatrixProduct(result, transfromMatrix);
        Console.WriteLine($"{result[0][0]}, {result[0][1]}");


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
    public static float[][] MatrixProduct(float[][] matrixA, float[][] matrixB)
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
