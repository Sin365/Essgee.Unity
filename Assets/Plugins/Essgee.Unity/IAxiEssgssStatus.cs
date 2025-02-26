using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class AxiEssgssStatusData
{
    public Dictionary<string, byte[]> MemberData = new Dictionary<string, byte[]>();
    public Dictionary<string, AxiEssgssStatusData_2DArray> Array2DMemberData = new Dictionary<string, AxiEssgssStatusData_2DArray>();
    public Dictionary<string, AxiEssgssStatusData> ClassData = new Dictionary<string, AxiEssgssStatusData>();
}


[Serializable]
public class AxiEssgssStatusData_2DArray
{
    public int rows;
    public int cols;
    public byte[] array1D;
    public AxiEssgssStatusData_2DArray(byte[,] data2D)
    {
        rows = data2D.GetLength(0);
        cols = data2D.GetLength(1);
        array1D = data2D.FlattenByteArray2D();
    }

    public byte[,] Get2DArrayBytesData()
    {
        return array1D.CreateByteArray2D(rows, cols);
    }
}
internal static class AxiEssgssStatusDataExtention
{
    internal static byte[] ToByteArray(this AxiEssgssStatusData data)
    {
        return AxiStatus.saveCover.ToByteArray(data);
    }

    internal static AxiEssgssStatusData ToAxiEssgssStatusData(this byte[] byteArray)
    {
        return AxiStatus.saveCover.ToAxiEssgssStatusData(byteArray);
    }
}
public interface IAxiEssgssStatus
{
    public void LoadAxiStatus(AxiEssgssStatusData data);
    public AxiEssgssStatusData SaveAxiStatus();
}

public interface IAxiEssgssStatusBytesCover
{
    public byte[] ToByteArray(AxiEssgssStatusData data);
    public AxiEssgssStatusData ToAxiEssgssStatusData(byte[] byteArray);
}

internal static class AxiStatus
{
    public static IAxiEssgssStatusBytesCover saveCover { get; private set; }
    public static void Init(IAxiEssgssStatusBytesCover coverter)
    {
        saveCover = coverter;
    }
    // ������ö������ת��Ϊbyte[]
    public static byte[] ToByteArray<TEnum>(this TEnum[] enumArray) where TEnum : struct, Enum
    {
        if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

        // ��ȡö�ٵĻ������ͣ�ͨ����Int32��
        Type enumUnderlyingType = Enum.GetUnderlyingType(typeof(TEnum));
        if (enumUnderlyingType != typeof(byte)) // �����������Ƿ�Ϊbyte��������ǣ�����Ҫ���ж���Ĵ���
        {
            // ����������Ͳ���byte��������Ҫ������δ����������Ǽ������������int��������ת��Ϊbyte���飬
            // ��Ҫע�⣬����ܻᵼ�����ݶ�ʧ�����ö��ֵ������byte�ķ�Χ����
            // һ������ȫ�ķ�����ʹ�ø�����������ͣ���int[]����Ϊ�м��ʾ��
            // ��Ϊ�˼�ʾ�������ǽ���������������ö��ֵ�����԰�ȫ��ת��Ϊbyte��
            // ���棺���������ܲ����������������

            // �������Ǽ������������int�����������ö�ٻ������ͣ������ǿ���ֱ��ת��ÿ��ö��ֵΪint��
            // Ȼ���������Ƿ���԰�ȫ��ת��Ϊbyte��������ܣ����ｫ�׳��쳣��
            return enumArray.Select(e =>
            {
                int intValue = Convert.ToInt32(e);
                if (intValue < byte.MinValue || intValue > byte.MaxValue)
                    throw new OverflowException($"Enum value {e} ({intValue}) is out of range for byte.");
                return (byte)intValue;
            }).ToArray();
        }
        else
        {
            // ������������Ѿ���byte����ֱ��ת��
            return Array.ConvertAll(enumArray, e => Convert.ToByte(e));
        }
    }

    // ��byte[]ת��Ϊ����ö������
    public static TEnum[] ToEnumArray<TEnum>(this byte[] byteArray) where TEnum : struct, Enum
    {
        if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

        // ֱ��ת��ÿ��byteΪö��ֵ
        return Array.ConvertAll(byteArray, b => (TEnum)Enum.ToObject(typeof(TEnum), b));
    }

    // ������ö��ת��Ϊbyte[]��ͨ�����ת����̫��������Ϊ�����ֻ��һ���ֽڣ������ǻ���ʵ������
    public static byte[] ToByteArray<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
    {
        if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

        // ��ȡö�ٵĻ�������
        Type enumUnderlyingType = Enum.GetUnderlyingType(typeof(TEnum));

        // �����������Ƿ�Ϊbyte��������ǣ������ת�����������Ǽ�����԰�ȫ��ת��Ϊbyte����ͨ��ö�ٵĻ���������int��
        if (enumUnderlyingType == typeof(byte))
        {
            // ������������Ѿ���byte����ֱ�ӷ��ذ������ֽڵ�����
            return new[] { Convert.ToByte(enumValue) };
        }
        else if (enumUnderlyingType == typeof(int)) // �����ö�ٻ�������
        {
            // ��ö��ֵת��Ϊint��Ȼ�����Ƿ���԰�ȫ��ת��Ϊbyte
            int intValue = Convert.ToInt32(enumValue);
            if (intValue < byte.MinValue || intValue > byte.MaxValue)
                throw new OverflowException($"Enum value {enumValue} ({intValue}) is out of range for byte.");

            // ���ذ���ת������ֽڵ�����
            return new[] { (byte)intValue };
        }
        else
        {
            // ����������Ͳ���byte��int�����׳��쳣�������������Ӹ�������ͼ��ʹ����߼���
            throw new NotSupportedException($"The underlying type of the enum {typeof(TEnum).Name} is not supported.");
        }
    }

    // ��byte[]ת��Ϊ����ö�٣�����byte[]ֻ��һ���ֽڣ�
    public static TEnum ToEnum<TEnum>(this byte[] byteArray) where TEnum : struct, Enum
    {
        if (byteArray == null || byteArray.Length != 1)
            throw new ArgumentException("The byte array must contain exactly one byte.");

        // ֱ�Ӵ��ֽ�ת��Ϊö��ֵ
        return (TEnum)Enum.ToObject(typeof(TEnum), byteArray[0]);
    }

    // ushort[] ת byte[]
    public static byte[] ToByteArray(this ushort[] ushortArray)
    {
        byte[] byteArray = new byte[ushortArray.Length * 2];
        Buffer.BlockCopy(ushortArray, 0, byteArray, 0, byteArray.Length);
        return byteArray;
    }

    // byte[] ת ushort[]
    public static ushort[] ToUShortArray(this byte[] byteArray)
    {
        if (byteArray.Length % 2 != 0)
            throw new ArgumentException("byte���鳤�ȱ�����ż��");

        ushort[] ushortArray = new ushort[byteArray.Length / 2];
        Buffer.BlockCopy(byteArray, 0, ushortArray, 0, byteArray.Length);
        return ushortArray;
    }



    public static byte[] ToByteArray(this bool[] boolArr)
    {
        byte[] byteArray = new byte[boolArr.Length];
        for (int i = 0; i < byteArray.Length; i++)
        {
            byteArray[i] = (byte)(boolArr[i] ? 1 : 0);
        }
        return byteArray;
    }

    public static bool[] ToBoolArray(this byte[] byteArray)
    {
        bool[] boolArr = new bool[byteArray.Length];
        for (int i = 0; i < byteArray.Length; i++)
        {
            boolArr[i] = byteArray[i] == 0 ? false : true;
        }
        return boolArr;
    }

    public static byte[] FlattenByteArray2D(this byte[,] array2D)
    {
        int rows = array2D.GetLength(0);
        int cols = array2D.GetLength(1);
        byte[] array1D = new byte[rows * cols];

        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array1D[index++] = array2D[i, j];
            }
        }

        return array1D;
    }
    public static byte[,] CreateByteArray2D(this byte[] array1D, int rows, int cols)
    {
        if (array1D.Length != rows * cols)
        {
            throw new ArgumentException("The length of the 1D array does not match the specified dimensions for the 2D array.");
        }

        byte[,] array2D = new byte[rows, cols];

        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array2D[i, j] = array1D[index++];
            }
        }

        return array2D;
    }

    public static byte[] FlattenByteArray3D(this byte[,,] array3D)
    {
        int layer = array3D.GetLength(0);
        int rows = array3D.GetLength(1);
        int cols = array3D.GetLength(2);
        byte[] array1D = new byte[layer * rows * cols];

        int index = 0;
        for (int i = 0; i < layer; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < cols; k++)
                {
                    array1D[index++] = array3D[i, j, k];
                }
            }
        }

        return array1D;
    }

    public static byte[,,] CreateByteArray3D(this byte[] array1D, int layer, int rows, int cols)
    {
        if (array1D.Length != layer * rows * cols)
        {
            throw new ArgumentException("The length of the 1D array does not match the specified dimensions for the 3D array.");
        }

        byte[,,] array3D = new byte[layer, rows, cols];

        int index = 0;
        for (int i = 0; i < layer; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < cols; k++)
                {
                    array3D[i, j, k] = array1D[index++];
                }
            }
        }

        return array3D;
    }
}
