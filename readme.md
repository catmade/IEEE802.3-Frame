# IEEE 802.3 以太网帧封装

## 循环冗余码计算

### 原理

根据一下公式

$$
r ≡ (n * c + r) \mod c\\
$$

可以得到

$$
110 ≡ (10010101 + 110) \mod m\\
≡ (10010101000000 + 110) \mod m\\
≡ 10010101000110 \mod m
$$

即，将一个数扩大n倍，然后再加上余数，此时求得的余数不变

### 举例应用

待处理数据：1010 0111 0110 0

生成多项式：1010 1101 0	($$P(x) = x^8 + x^6 + x^4 + x^3 + x^1$$)

1. 将待处理数据全部放入队列 `data` 中

   ```
   data = [1010011101100]
   ```

2. 生成多项式共 `9` 位，所以先让队列 `data` 的前 `8` 项出队，并将数据放入队列 `str` 中

   ```
   str  = [10100111]
   data = [01100]
   ```

3. 队列 `data.Count = 5` != 0，继续执行

   1. 将队列 `data` 的第项出队，并放入队列 `str` 中

      ```
      str  = [101001110]
      data = [1100]
      ```

   2. `str` 的第一个元素是`1`

      1. 向列 `S` 中插入 `1`

      2. 将队列 `str` 的值和生成多项式的值进行按位异或，并将结果的后`8`个字符复制给 `str`
         101001110 ^ 101011010 = 000010100

         ```
         S    = [1]
         str  = [00010100]
         data = [1100]
         ```

4. 队列 `data.Count = 4` != 0，继续执行
   1. 将队列 `data` 的第一项出队，并放入队列 `str` 中

      ```
      S    = [1]
      str  = [000101001]
      data = [100]
      ```
      
   2. `str` 的第一个元素是`0`
   
      1. 向列 `S` 中插入 `0`，并让 `str` 的第一项出队
   
          ```
           S    = [10]
           str  = [00101001]
           data = [100]
          ```
4. 队列 `data.Count = 3` != 0，继续执行
   1. 将队列 `data` 的第一项出队，并放入队列 `str` 中

      ```
      S    = [10]
      str  = [001010011]
      data = [00]
      ```
      
   2. `str` 的第一个元素是`0`
   
      1. 向列 `S` 中插入 `0`，并让 `str` 的第一项出队
   
          ```
           S    = [100]
           str  = [01010011]
           data = [00]
          ```
4. 队列 `data.Count = 2` != 0，继续执行
   1. 将队列 `data` 的第一项出队，并放入队列 `str` 中

      ```
      S    = [100]
      str  = [010100110]
      data = [0]
      ```
      
   2. `str` 的第一个元素是`0`
   
      1. 向列 `S` 中插入 `0`，并让 `str` 的第一项出队
   
          ```
           S    = [1000]
           str  = [10100110]
           data = [0]
          ```
7. 队列 `data.Count = 1` != 0，继续执行

   1. 将队列 `data` 的第项出队，并放入队列 `str` 中

      ```
       S    = [1000]
       str  = [101001100]
       data = []
      ```

   2. `str` 的第一个元素是`1`

      1. 向列 `S` 中插入 `1`

      2. 将队列 `str` 的值和生成多项式的值进行按位异或，并将结果的后`8`个字符复制给 `str`
         101001100 ^ 101011010 = 000010110

         ```
         S    = [10001]
         str  = [00010110]
         data = []
         ```

7. 队列 `data.Count = 0` == 0，结束，余数为 `str = 00010110`，商为`S = 10001`
8. 整个计算过程为：

```
          10001
101011010|1010011101100
          101011010||||
           000101001|||
            001010011||
             010100110|
              101001100
              101011010
               00010110
```

### 代码实现

```c#
private byte[] CalcCRC(string v)
{
    var data = new Queue<char>(v.ToArray());    // 被除数
    char[] divisor = binaryString.ToArray();    // 除数
    Queue<char> S = new Queue<char>();          // 商
    int width = divisor.Length;                 // 每次取 width 个字符进行异或运算
    Queue<char> str = new Queue<char>();        // 每次取的长度为 width 的部分被除数

    // 获取前 width - 1 个字符，填入到str中
    for (int i = 0; i < width - 1; i++)
    {
        str.Enqueue(data.Dequeue());
    }

    while (data.Count != 0)
    {
        str.Enqueue(data.Dequeue());

        if (str.First() == '0')
        {
            S.Enqueue('0');
            str.Dequeue();
        }
        else
        {
            S.Enqueue('1');

            var temp = str.ToArray();
            str.Clear();

            for (int i = 1; i < temp.Length; i++)
            {
                str.Enqueue(temp[i] == divisor[i] ? '0' : '1');
            }
        }
    }
	// 计算结束，str中的值就是结果
    
    var res = new string(str.ToArray()).PadLeft(32, '0');
    var result = new byte[4];
    // 将字符串格式化为byte
    for (int i = 0; i < 4; i++)
    {
        result[i] = Convert.ToByte(res.Substring(i * 8, 8), 2);
    }

    return result;
}
```


