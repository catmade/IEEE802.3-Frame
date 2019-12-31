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

### 应用

设待检验字段为 `length` 个字节

设生成多项式的阶数为 `rank`（生成多项式  $$P(x) = x^8 + x^6 + x^3 + x^2 + 1$$ 的阶数为 8）

算法开始

1. 将待检验数据转换成 `char` 字符串数组，并在最后面添加 32 个 `0` 

2. 定义除数字符串数组 `divisor` ，长度为 `rank + 1`。定义游标 `cursor = rank`。定义缓冲数组temp，长度为`rank`

3. 获取字符数组从下标 `cursor` 开始的，长度为 `rank + 1` 的子串 `str`

4. 将 `str` 和 `divisor` 进行比较

   1. 如果 str[0] == ‘1’

      则 temp[0] = str[1] == divisor[1] ? '0' : '1'

   2. 如果 str[0] == ‘0’

      则 temp[0] = str[1]

      ​	temp[rank - 1] = str[]