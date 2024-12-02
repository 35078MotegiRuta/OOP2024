﻿#1 2 3 4 5 6 7 8 9 10
# for n in range(1, 11):
#     print(n,"   ", end=" ")


#3
# a = 5
# b = 3
# a,b = b,a
# print(a)


# a = [1,2]
# b = [3,4]
# s = 0
# for n,m in enumerate(a+b):
#      s = s + n * m
# print(s)

# for i in enumerate(a):
#     print(i)

# for i in zip(a,b):
#     print(i)


# cities = ['Tokyo','Paris','London','Beijing']
# for city in cities:
#     print(city)


# cities = ['Tokyo', 'Paris', 'London', 'Beijing', 'New York']
# count = 0
# while count < len(cities):
#     print(cities[count])
#     count += 1


# cities = ['Tokyo','Paris','London','Beijing']
# for index,city in enumerate(cities):
#     print(index)
#     print(city)


# numbers = [1,2,3,4,5,6,7,8,9,10]
# for number in numbers:
#     if number % 2 == 0:
#         print(number)
#     else:
#         print('kisuu')


# print("数値を入力")
# num = int(input())
# if num >= 100:
#     print("合格")
# else:
#     print("不合格")


# member = {'name':'坂本龍馬','age':28,'gender':'male'}
# print(member['name'])


# def func():
#     a = 1
#     b = 2
#     c = a + b
#     print(c)

# func()

from dataclasses import dataclass

@dataclass
class Item:
    kind : str
    price : int

def tax_included_price(item):
    if item.kind == "food" :
        return item.price * 1.08
    else:
        return item.price + 1.1

def total_amount(items) :
    amounts = [tax_included_price(item) for item in items]
    return sum(amounts)

items =[Item("food",200),
        Item("book",1000),
        Item("food",100)]
print(total_amount[items])